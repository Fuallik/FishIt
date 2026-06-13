using FishIt.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace FishIt.Views.Admin
{
    public partial class UC_HargaPanen : UserControl
    {
        private int idPanenTerpilih = 0;
        private int idIkanTerpilih = 0;
        private decimal jumlahKgTerpilih = 0;
        private bool ikanSudahPunyaHarga = false;
        public UC_HargaPanen()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVPanen);
        }

        private void UC_HargaPanen_Load(object sender, EventArgs e)
        {

        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatAntrean();
        }
        private void MuatAntrean()
        {
            string query = @"
                SELECT p.id_panen     AS ""ID"",
                       p.id_ikan       AS ""ID Ikan"",
                       i.nama_ikan      AS ""Ikan"",
                       k.nomor          AS ""Kolam"",
                       p.jumlah_kg      AS ""Jumlah (kg)"",
                       p.kualitas       AS ""Kualitas"",
                       p.tanggal_panen  AS ""Tgl Panen"",
                       a.nama           AS ""Dipanen Oleh"",
                       i.harga_per_kg   AS ""Harga Ikan Saat Ini""
                FROM panen p
                JOIN ikan i  ON i.id_ikan  = p.id_ikan
                JOIN kolam k ON k.id_kolam = p.id_kolam
                JOIN akun a  ON a.id_akun  = p.id_akun
                WHERE p.sudah_dihargai = FALSE          -- belum diproses
                ORDER BY p.tanggal_panen ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var ad = new NpgsqlDataAdapter(cmd);
                    var dt = new DataTable();
                    ad.Fill(dt);
                    DGVPanen.DataSource = dt;

                    GridHelper.AturTemaModern(DGVPanen);
                    if (DGVPanen.Columns.Contains("ID")) DGVPanen.Columns["ID"].Visible = false;
                    if (DGVPanen.Columns.Contains("ID Ikan")) DGVPanen.Columns["ID Ikan"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat antrean panen: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Klik baris -> simpan data panen terpilih + cek ikan sudah punya harga atau belum
        private void DGVPanen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGVPanen.Rows[e.RowIndex];
            idPanenTerpilih = Convert.ToInt32(row.Cells["ID"].Value);
            idIkanTerpilih = Convert.ToInt32(row.Cells["ID Ikan"].Value);
            jumlahKgTerpilih = Convert.ToDecimal(row.Cells["Jumlah (kg)"].Value);

            // Harga ikan saat ini: kalau sudah ada (bukan NULL/0) -> ini bukan panen pertama
            var hargaSekarang = row.Cells["Harga Ikan Saat Ini"].Value;
            decimal hargaIkan = hargaSekarang == DBNull.Value ? 0 : Convert.ToDecimal(hargaSekarang);
            ikanSudahPunyaHarga = hargaIkan > 0;

            if (ikanSudahPunyaHarga)
            {
                // Panen kedua dst: ikan sudah punya harga -> cukup tambah stok, harga tak perlu diisi
                TBHarga.Text = hargaIkan.ToString("0.##");
                TBHarga.Enabled = false;   // dikunci, nggak perlu ubah harga
                labelIkanTerpilih.Text = row.Cells["Ikan"].Value + " (sudah ada harga, hanya tambah stok)";
            }
            else
            {
                // Panen pertama: admin wajib isi harga
                TBHarga.Text = "";
                TBHarga.Enabled = true;
                labelIkanTerpilih.Text = row.Cells["Ikan"].Value + " (belum ada harga, isi harga dulu)";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (idPanenTerpilih == 0)
            {
                MessageBox.Show("Pilih panen di antrean dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tentukan harga: kalau ikan belum punya harga, admin harus input angka valid > 0
            decimal harga;
            if (!ikanSudahPunyaHarga)
            {
                if (!decimal.TryParse(TBHarga.Text.Trim(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out harga) || harga <= 0)
                {
                    MessageBox.Show("Isi harga per kg dengan angka lebih dari 0!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                harga = 0;   // tidak dipakai (harga ikan tidak diubah)
            }

            using var conn = new NpgsqlConnection(Config.ConnString);
            conn.Open();
            using var tx = conn.BeginTransaction();   // stok + harga + penanda harus konsisten
            try
            {
                // 1. SELALU tambah stok ikan (tiap panen yang diproses nambah stok sekali)
                using (var cmdStok = new NpgsqlCommand(
                    "UPDATE ikan SET stok_ikan = stok_ikan + @kg WHERE id_ikan = @id_ikan", conn, tx))
                {
                    cmdStok.Parameters.AddWithValue("@kg", jumlahKgTerpilih);
                    cmdStok.Parameters.AddWithValue("@id_ikan", idIkanTerpilih);
                    cmdStok.ExecuteNonQuery();
                }

                // 2. Set harga HANYA kalau panen pertama (ikan belum punya harga)
                if (!ikanSudahPunyaHarga)
                {
                    using var cmdHarga = new NpgsqlCommand(
                        "UPDATE ikan SET harga_per_kg = @harga WHERE id_ikan = @id_ikan", conn, tx);
                    cmdHarga.Parameters.AddWithValue("@harga", harga);
                    cmdHarga.Parameters.AddWithValue("@id_ikan", idIkanTerpilih);
                    cmdHarga.ExecuteNonQuery();
                }

                // 3. Tandai panen ini sudah diproses. Guard FALSE cegah dobel proses.
                int baris;
                using (var cmdTandai = new NpgsqlCommand(
                    "UPDATE panen SET sudah_dihargai = TRUE WHERE id_panen = @id AND sudah_dihargai = FALSE", conn, tx))
                {
                    cmdTandai.Parameters.AddWithValue("@id", idPanenTerpilih);
                    baris = cmdTandai.ExecuteNonQuery();
                }

                // Kalau 0 baris -> panen sudah diproses sebelumnya. Batalkan semua (jangan tambah stok lagi).
                if (baris == 0)
                {
                    tx.Rollback();
                    MessageBox.Show("Panen ini sudah diproses sebelumnya. Coba refresh.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tx.Commit();
                MessageBox.Show("Harga ditetapkan & stok ikan ditambahkan ke katalog!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                idPanenTerpilih = 0;
                TBHarga.Text = "";
                TBHarga.Enabled = true;
                labelIkanTerpilih.Text = "";
                MuatAntrean();   // refresh antrean (panen tadi hilang)
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("Gagal memproses: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
