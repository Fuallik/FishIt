using FishIt.Helpers;
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
            string query = "SELECT b.id_benih, b.nama, b.jumlah_stok, j.nama_jenis_ikan FROM benih b JOIN jenis_ikan j ON b.id_jenis_ikan = j.id_jenis_ikan WHERE b.jumlah_stok > 0 ORDER BY b.id_benih ASC";

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
                        DGVBenih.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
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
