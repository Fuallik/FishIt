using Npgsql;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    public partial class UC_RiwayatPengirimanPesanan : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_RiwayatPengirimanPesanan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVRiwayat);
        }

        private void UC_RiwayatPengirimanPesanan_Load(object sender, EventArgs e)
        {
            LoadRiwayat();
        }

        /// <summary>
        /// Menampilkan pengiriman yang SUDAH selesai ('Diterima') milik shipper yang login.
        /// Read-only: shipper hanya melihat, tidak mengubah apa pun di sini.
        /// </summary>
        private void LoadRiwayat()
        {
            string query = @"
                SELECT  p.id_order            AS ""ID Order"",
                        a.nama                 AS ""Pembeli"",
                        o.total_harga          AS ""Total Harga"",
                        p.tanggal_pengiriman   AS ""Tgl Kirim"",
                        p.tanggal_diterima     AS ""Tgl Diterima"",
                        p.status_pengiriman    AS ""Status""
                FROM pengiriman p
                JOIN orders o ON o.id_order = p.id_order
                JOIN akun   a ON a.id_akun  = o.id_akun
                WHERE p.id_akun = @id_shipper
                  AND p.status_pengiriman = 'Diterima'
                ORDER BY p.tanggal_diterima DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_shipper", Session.IdAkun);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            var tabel = new System.Data.DataTable();
                            adapter.Fill(tabel);
                            DGVRiwayat.DataSource = tabel;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRiwayat();
        }
    }
}