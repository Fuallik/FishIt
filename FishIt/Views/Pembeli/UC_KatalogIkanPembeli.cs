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
    public partial class UC_KatalogIkanPembeli : UserControl
    {
        public UC_KatalogIkanPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
        }

        private void UC_KatalogIkanPembeli_Load(object sender, EventArgs e)
        {
            MuatDataIkan();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        public void MuatDataIkan()
        {
            string query = "SELECT i.id_ikan, i.nama_ikan, j.nama_jenis_ikan, k.kualitas_ikan, i.harga_per_kg, i.stok_ikan \r\nFROM ikan i\r\nJOIN jenis_ikan j ON i.id_jenis_ikan = j.id_jenis_ikan\r\nJOIN kualitas k ON i.id_kualitas = k.id_kualitas";

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

                        DGVKatalogIkan.DataSource = dt;
                        DGVKatalogIkan.Columns["id_ikan"].HeaderText = "ID Ikan";
                        DGVKatalogIkan.Columns["nama_ikan"].HeaderText = "Nama Ikan";
                        DGVKatalogIkan.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
                        DGVKatalogIkan.Columns["kualitas_ikan"].HeaderText = "Kualitas Ikan";
                        DGVKatalogIkan.Columns["harga_per_kg"].HeaderText = "Harga per KG";
                        DGVKatalogIkan.Columns["stok_ikan"].HeaderText = "Stok Ikan";

                        GridHelper.AturTemaModern(DGVKatalogIkan);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat tabel ikan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvStokIkan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVKatalogIkan.Columns[e.ColumnIndex].Name == "colTambah" && e.RowIndex >= 0)
            {
                int idIkan = Convert.ToInt32(DGVKatalogIkan.Rows[e.RowIndex].Cells["id_ikan"].Value);
                string namaIkan = DGVKatalogIkan.Rows[e.RowIndex].Cells["nama_ikan"].Value.ToString();
                decimal kuantitas = numericJumlah.Value;

                if (kuantitas <= 0)
                {
                    MessageBox.Show("Tentukan jumlah Kg terlebih dahulu di kotak jumlah!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO keranjang (id_akun, id_ikan, kuantitas) VALUES (@id_akun, @id_ikan, @kuantitas)";

                using (var conn = new NpgsqlConnection(UC_Keranjang.Config.ConnString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmd.Parameters.AddWithValue("@id_ikan", idIkan);
                            cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show($"Berhasil memasukkan {kuantitas} Kg {namaIkan} ke keranjang!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal masuk keranjang: " + ex.Message);
                    }
                }
            }
        }
    }
}
