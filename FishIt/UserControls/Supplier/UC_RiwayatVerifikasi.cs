using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_RiwayatVerifikasi : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_RiwayatVerifikasi()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVRiwayat);
        }

        private void UC_RiwayatVerifikasi_Load(object sender, EventArgs e)
        {
            MuatRiwayat();
        }

        /// <summary>
        /// Menampilkan SEMUA pengajuan (benih & pakan, semua status) milik supplier yang login.
        /// Catatan teknis:
        /// - LEFT JOIN ke benih DAN pakan, karena tiap baris cuma punya salah satu
        ///   (id_benih terisi -> benih NULL di pakan, begitu sebaliknya).
        /// - COALESCE(b.nama, p.nama) mengambil nama dari kolom mana pun yang terisi,
        ///   jadi satu kolom "Item" bisa menampilkan benih maupun pakan.
        /// </summary>
        private void MuatRiwayat()
        {
            string query = @"
                SELECT  ps.tipe                          AS ""Tipe"",
                        COALESCE(b.nama, p.nama)          AS ""Item"",
                        ps.kuantitas                     AS ""Kuantitas"",
                        ps.tanggal_kirim                 AS ""Tgl Ajukan"",
                        ps.status_verifikasi             AS ""Status"",
                        ps.tanggal_verifikasi            AS ""Tgl Verifikasi""
                FROM pengiriman_supplier ps
                LEFT JOIN benih b ON b.id_benih = ps.id_benih
                LEFT JOIN pakan p ON p.id_pakan = ps.id_pakan
                WHERE ps.id_akun = @id_akun
                ORDER BY ps.tanggal_kirim DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            var tabel = new DataTable();
                            adapter.Fill(tabel);
                            DGVRiwayat.DataSource = tabel;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat verifikasi: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MuatRiwayat();
        }
    }
}