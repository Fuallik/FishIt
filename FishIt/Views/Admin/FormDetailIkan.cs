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
    public partial class FormDetailIkan : Form
    {
        public FormDetailIkan()
        {
            InitializeComponent();
        }

        private void FormDetailIkan_Load(object sender, EventArgs e)
        {
            MuatDataIkan();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void MuatDataIkan()
        {
            string query = "SELECT i.nama_ikan, j.nama_jenis_ikan, k.kualitas_ikan, i.harga_per_kg, i.stok_ikan \r\nFROM ikan i\r\nJOIN jenis_ikan j ON i.id_jenis_ikan = j.id_jenis_ikan\r\nJOIN kualitas k ON i.id_kualitas = k.id_kualitas\r\nWHERE i.stok_ikan > 0";

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

                        DGVIkan.DataSource = dt;
                        DGVIkan.Columns["nama_ikan"].HeaderText = "Nama Ikan";
                        DGVIkan.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
                        DGVIkan.Columns["kualitas_ikan"].HeaderText = "Kualitas Ikan";
                        DGVIkan.Columns["harga_per_kg"].HeaderText = "Harga per KG";
                        DGVIkan.Columns["stok_ikan"].HeaderText = "Stok Ikan";

                        GridHelper.AturTemaModern(DGVIkan);
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
