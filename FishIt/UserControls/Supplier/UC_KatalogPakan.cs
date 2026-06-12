using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KatalogPakan : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_KatalogPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVKatalog);
        }

        private void UC_KatalogPakan_Load(object sender, EventArgs e)
        {
            MuatKatalog();
        }

        /// <summary> Menampilkan seluruh pakan beserta stoknya. </summary>
        private void MuatKatalog()
        {
            string query = @"
                SELECT  nama          AS ""Nama Pakan"",
                        jumlah_stok    AS ""Stok""
                FROM pakan
                ORDER BY nama";

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
                    MessageBox.Show("Gagal memuat katalog pakan: " + ex.Message,
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