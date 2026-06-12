using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_StatusKolam : UserControl
    {
        public UC_StatusKolam()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVStatusKolam);
            new AutoScaleHelper(this);
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatData();
        }

        private void MuatData()
        {
            MuatGrid();
            MuatKartu();
        }

        private void MuatGrid()
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand("SELECT * FROM view_status_kolam", conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVStatusKolam.DataSource = tabel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat status kolam: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MuatKartu()
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    labelTerisi.Text = HitungKolam(conn, "Terisi").ToString();
                    labelKosong.Text = HitungKolam(conn, "Kosong").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int HitungKolam(NpgsqlConnection conn, string status)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_hitung_kolam(@status)", conn);
            cmd.Parameters.AddWithValue("@status", status);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
