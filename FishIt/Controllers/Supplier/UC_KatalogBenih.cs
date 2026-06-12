using FishIt.Helpers;
using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KatalogBenih : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_KatalogBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVKatalog);
        }

        private void UC_KatalogBenih_Load(object sender, EventArgs e)
        {
            MuatKatalog();
        }

        /// <summary>
        /// Menampilkan seluruh benih beserta jenis ikannya.
        /// JOIN ke jenis_ikan supaya yang tampil nama jenisnya, bukan angka id.
        /// </summary>
        private void MuatKatalog()
        {
            string query = @"
                SELECT  b.nama                AS ""Nama Benih"",
                        j.nama_jenis_ikan      AS ""Jenis Ikan"",
                        b.jumlah_stok          AS ""Stok"",
                        b.tanggal_masuk        AS ""Tanggal Masuk""
                FROM benih b
                JOIN jenis_ikan j ON j.id_jenis_ikan = b.id_jenis_ikan
                ORDER BY b.nama";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        var tabel = new DataTable();
                        adapter.Fill(tabel);
                        DGVKatalog.DataSource = tabel;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat katalog benih: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MuatKatalog();
        }
    }
}