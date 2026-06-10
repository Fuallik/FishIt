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
    public partial class FormDetailBenih : Form
    {
        public FormDetailBenih()
        {
            InitializeComponent();
        }

        private void FormDetailBenih_Load(object sender, EventArgs e)
        {
            MuatDataBenih();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void MuatDataBenih()
        {
            string query = "SELECT id_benih, nama, jumlah_stok FROM benih";

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

                        DGVBenih.DataSource = dt;
                        DGVBenih.Columns["id_benih"].HeaderText = "ID Benih";
                        DGVBenih.Columns["nama"].HeaderText = "Nama Benih";
                        DGVBenih.Columns["jumlah_stok"].HeaderText = "Jumlah Stok";


                        GridHelper.AturTemaModern(DGVBenih);
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
