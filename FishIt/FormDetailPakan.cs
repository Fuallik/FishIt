using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormDetailPakan : Form
    {
        public FormDetailPakan()
        {
            InitializeComponent();
        }

        private void FormDetailPakan_Load(object sender, EventArgs e)
        {
            MuatDataPakan();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void MuatDataPakan()
        {
            string query = "SELECT id_pakan, nama, jumlah_stok FROM pakan";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DGVPakan.DataSource = dt;
                        DGVPakan.Columns["id_pakan"].HeaderText = "ID Pakan";
                        DGVPakan.Columns["nama"].HeaderText = "Nama Pakan";
                        DGVPakan.Columns["jumlah_stok"].HeaderText = "Jumlah Stok";


                        GridHelper.AturTemaModern(DGVPakan);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat tabel ikan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
