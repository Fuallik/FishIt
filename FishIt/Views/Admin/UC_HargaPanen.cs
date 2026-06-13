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
        private string namaIkanTerpilih = "";
        private int idJenisTerpilih = 0;
        private int idKualitasTerpilih = 0;
        private decimal jumlahKgTerpilih = 0;
        private int idIkanKatalogDitemukan = 0;   // 0 = entri (spesies+kualitas) belum ada di katalog

        public UC_HargaPanen()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVPanen);
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

        // Grid: panen yang belum diproses. Sertakan jenis & id_kualitas (dari konversi A/B/C).
        private void MuatAntrean()
        {
            string query = @"
                SELECT p.id_panen        AS ""ID"",
                       i.nama_ikan         AS ""Ikan"",
                       i.id_jenis_ikan     AS ""ID Jenis"",
                       p.kualitas          AS ""Kualitas"",
                       ku.id_kualitas      AS ""ID Kualitas"",
                       k.nomor             AS ""Kolam"",
                       p.jumlah_kg         AS ""Jumlah (kg)"",
                       p.tanggal_panen     AS ""Tgl Panen"",
                       a.nama              AS ""Dipanen Oleh""
                FROM panen p
                JOIN ikan i     ON i.id_ikan = p.id_ikan
                JOIN kolam k    ON k.id_kolam = p.id_kolam
                JOIN akun a     ON a.id_akun = p.id_akun
                JOIN kualitas ku ON ku.kualitas_ikan = p.kualitas   -- konversi 'A'/'B'/'C' -> id_kualitas
                WHERE p.sudah_dihargai = FALSE
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
                    foreach (var k in new[] { "ID", "ID Jenis", "ID Kualitas" })
                        if (DGVPanen.Columns.Contains(k)) DGVPanen.Columns[k].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat antrean panen: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Klik baris: simpan info panen + cek apakah entri (spesies+kualitas) sudah ada di katalog
        private void DGVPanen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = DGVPanen.Rows[e.RowIndex];

            idPanenTerpilih = Convert.ToInt32(row.Cells["ID"].Value);
            namaIkanTerpilih = row.Cells["Ikan"].Value.ToString();
            idJenisTerpilih = Convert.ToInt32(row.Cells["ID Jenis"].Value);
            idKualitasTerpilih = Convert.ToInt32(row.Cells["ID Kualitas"].Value);
            jumlahKgTerpilih = Convert.ToDecimal(row.Cells["Jumlah (kg)"].Value);
            string kualitasChar = row.Cells["Kualitas"].Value.ToString();

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    // Cari entri katalog yang cocok SPESIES + KUALITAS
                    using var cmd = new NpgsqlCommand(@"
                        SELECT id_ikan, harga_per_kg FROM ikan
                        WHERE nama_ikan = @nama AND id_jenis_ikan = @jenis AND id_kualitas = @kualitas
                        LIMIT 1", conn);
                    cmd.Parameters.AddWithValue("@nama", namaIkanTerpilih);
                    cmd.Parameters.AddWithValue("@jenis", idJenisTerpilih);
                    cmd.Parameters.AddWithValue("@kualitas", idKualitasTerpilih);

                    using var r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        // Sudah ada di katalog -> cukup tambah stok, harga dikunci
                        idIkanKatalogDitemukan = Convert.ToInt32(r["id_ikan"]);
                        TBHarga.Text = Convert.ToDecimal(r["harga_per_kg"]).ToString("0.##");
                        TBHarga.Enabled = false;
                        labelIkanTerpilih.Text = $"{namaIkanTerpilih} (Kualitas {kualitasChar}) — sudah di katalog, hanya tambah stok";
                    }
                    else
                    {
                        // Belum ada -> entri katalog BARU, admin wajib isi harga
                        idIkanKatalogDitemukan = 0;
                        TBHarga.Text = "";
                        TBHarga.Enabled = true;
                        labelIkanTerpilih.Text = $"{namaIkanTerpilih} (Kualitas {kualitasChar}) — BARU, isi harga dulu";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal cek katalog: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            // Harga wajib hanya kalau entri katalog BARU
            decimal harga = 0;
            if (idIkanKatalogDitemukan == 0)
            {
                if (!decimal.TryParse(TBHarga.Text.Trim(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out harga) || harga <= 0)
                {
                    MessageBox.Show("Isi harga per kg dengan angka lebih dari 0!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using var conn = new NpgsqlConnection(Config.ConnString);
            conn.Open();
            using var tx = conn.BeginTransaction();   // katalog + penanda harus konsisten
            try
            {
                if (idIkanKatalogDitemukan > 0)
                {
                    // Entri (spesies+kualitas) sudah ada -> tambah stok saja
                    using var cmdStok = new NpgsqlCommand(
                        "UPDATE ikan SET stok_ikan = stok_ikan + @kg WHERE id_ikan = @id", conn, tx);
                    cmdStok.Parameters.AddWithValue("@kg", jumlahKgTerpilih);
                    cmdStok.Parameters.AddWithValue("@id", idIkanKatalogDitemukan);
                    cmdStok.ExecuteNonQuery();
                }
                else
                {
                    // Belum ada -> BUAT entri katalog baru untuk kualitas ini
                    using var cmdNew = new NpgsqlCommand(@"
                        INSERT INTO ikan (harga_per_kg, stok_ikan, nama_ikan, id_jenis_ikan, id_kualitas)
                        VALUES (@harga, @kg, @nama, @jenis, @kualitas)", conn, tx);
                    cmdNew.Parameters.AddWithValue("@harga", harga);
                    cmdNew.Parameters.AddWithValue("@kg", jumlahKgTerpilih);
                    cmdNew.Parameters.AddWithValue("@nama", namaIkanTerpilih);
                    cmdNew.Parameters.AddWithValue("@jenis", idJenisTerpilih);
                    cmdNew.Parameters.AddWithValue("@kualitas", idKualitasTerpilih);
                    cmdNew.ExecuteNonQuery();
                }

                // Tandai panen diproses. Guard FALSE cegah dobel.
                int baris;
                using (var cmdTandai = new NpgsqlCommand(
                    "UPDATE panen SET sudah_dihargai = TRUE WHERE id_panen = @id AND sudah_dihargai = FALSE", conn, tx))
                {
                    cmdTandai.Parameters.AddWithValue("@id", idPanenTerpilih);
                    baris = cmdTandai.ExecuteNonQuery();
                }
                if (baris == 0)
                {
                    tx.Rollback();
                    MessageBox.Show("Panen ini sudah diproses sebelumnya. Coba refresh.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                tx.Commit();
                MessageBox.Show("Stok masuk ke katalog sesuai kualitasnya!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                idPanenTerpilih = 0;
                idIkanKatalogDitemukan = 0;
                TBHarga.Text = "";
                TBHarga.Enabled = true;
                labelIkanTerpilih.Text = "";
                MuatAntrean();
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
