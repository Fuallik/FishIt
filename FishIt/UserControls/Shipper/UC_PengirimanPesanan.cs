using Npgsql;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    public partial class UC_PengirimanPesanan : UserControl
    {
        // Pola Config lokal mengikuti gaya UserControl lain di proyek ini.
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_PengirimanPesanan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengiriman); // pakai tema DGV yang sudah ada di proyek
        }

        private void UC_PengirimanPesanan_Load(object sender, EventArgs e)
        {
            LoadDataPengiriman();
        }

        /// <summary>
        /// Menampilkan pengiriman yang masih AKTIF (Diproses / Dikirim)
        /// dan hanya yang ditugaskan ke shipper yang sedang login.
        /// </summary>
        private void LoadDataPengiriman()
        {
            // JOIN ke orders & akun supaya shipper melihat info pesanan dan nama pembeli,
            // bukan sekadar angka id. Kolom id_pengiriman tetap dibawa untuk dipakai saat UPDATE.
            string query = @"
                SELECT  p.id_pengiriman           AS ""ID"",
                        p.id_order                AS ""ID Order"",
                        a.nama                     AS ""Pembeli"",
                        o.total_harga              AS ""Total Harga"",
                        p.tanggal_pengiriman       AS ""Tgl Kirim"",
                        p.status_pengiriman        AS ""Status"",
                        p.catatan                  AS ""Catatan""
                FROM pengiriman p
                JOIN orders o ON o.id_order = p.id_order
                JOIN akun   a ON a.id_akun  = o.id_akun
                WHERE p.id_akun = @id_shipper
                  AND p.status_pengiriman IN ('Diproses', 'Dikirim')
                ORDER BY p.tanggal_pengiriman ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Parameter, bukan konkatenasi string -> aman dari SQL injection.
                        cmd.Parameters.AddWithValue("@id_shipper", Session.IdAkun);

                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            var tabel = new System.Data.DataTable();
                            adapter.Fill(tabel);
                            DGVPengiriman.DataSource = tabel;
                        }
                    }

                    // Sembunyikan kolom ID dari tampilan (tetap ada di data, dipakai logika).
                    if (DGVPengiriman.Columns.Contains("ID"))
                        DGVPengiriman.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data pengiriman: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Mengambil id_pengiriman dari baris yang dipilih di DataGridView.
        /// Mengembalikan -1 kalau belum ada baris yang dipilih.
        /// </summary>
        private int AmbilIdTerpilih(out string statusSekarang)
        {
            statusSekarang = "";
            if (DGVPengiriman.CurrentRow == null)
                return -1;

            var rowId = DGVPengiriman.CurrentRow.Cells["ID"].Value;
            if (rowId == null || rowId == DBNull.Value)
                return -1;

            statusSekarang = DGVPengiriman.CurrentRow.Cells["Status"].Value?.ToString() ?? "";
            return Convert.ToInt32(rowId);
        }

        // Diproses -> Dikirim
        private void btnMulaiKirim_Click(object sender, EventArgs e)
        {
            int id = AmbilIdTerpilih(out string status);
            if (id == -1)
            {
                MessageBox.Show("Pilih dulu baris pengiriman yang mau dikirim.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status != "Diproses")
            {
                MessageBox.Show("Hanya pesanan berstatus 'Diproses' yang bisa mulai dikirim.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guard di WHERE (status = 'Diproses') mencegah race condition:
            // kalau status sudah berubah dari sumber lain, UPDATE-nya tidak kena baris apa pun.
            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Dikirim'
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Diproses'";

            JalankanUpdate(query, id, "Pesanan ditandai sedang dikirim.");
        }

        // Dikirim -> Diterima (sekaligus isi tanggal_diterima = hari ini)
        private void btnTandaiDiterima_Click(object sender, EventArgs e)
        {
            int id = AmbilIdTerpilih(out string status);
            if (id == -1)
            {
                MessageBox.Show("Pilih dulu baris pengiriman yang mau ditandai diterima.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (status != "Dikirim")
            {
                MessageBox.Show("Hanya pesanan berstatus 'Dikirim' yang bisa ditandai diterima.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Diterima',
                    tanggal_diterima  = CURRENT_DATE
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Dikirim'";

            JalankanUpdate(query, id, "Pesanan ditandai sudah diterima pembeli.");
        }

        /// <summary>
        /// Helper umum untuk menjalankan UPDATE status dan me-refresh tabel.
        /// Dipakai dua tombol di atas supaya tidak duplikat kode.
        /// </summary>
        private void JalankanUpdate(string query, int idPengiriman, string pesanSukses)
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idPengiriman);
                        cmd.Parameters.AddWithValue("@id_shipper", Session.IdAkun);

                        int baris = cmd.ExecuteNonQuery();
                        if (baris > 0)
                        {
                            MessageBox.Show(pesanSukses, "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPengiriman(); // refresh supaya baris pindah/hilang dari daftar aktif
                        }
                        else
                        {
                            MessageBox.Show("Tidak ada perubahan. Mungkin status sudah berubah, coba Refresh.",
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui status: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataPengiriman();
        }
    }
}