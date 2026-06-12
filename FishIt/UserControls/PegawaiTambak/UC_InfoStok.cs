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
    public partial class UC_InfoStok : UserControl
    {
        public UC_InfoStok()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPakan);
            GridHelper.AturTemaModern(DGVBenih);
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
            MuatGrid("SELECT * FROM view_stok_pakan", DGVPakan);   // ganti nama DGV sesuai Designer
            MuatGrid("SELECT * FROM view_stok_benih", DGVBenih);
            MuatKartu();
        }

        // Satu method dipakai dua grid (kasih query + DGV target)
        private void MuatGrid(string query, DataGridView dgv)
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    dgv.DataSource = tabel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message,
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

                    // PAKAN — desimal, pakai N2
                    labelJenisPakan.Text = HitungStok(conn, "PAKAN", "JENIS").ToString("N0") + " jenis";
                    labelStokPakan.Text = HitungStok(conn, "PAKAN", "TOTAL").ToString("N2") + " kg";

                    // BENIH — bilangan bulat, pakai N0 (tanpa koma)
                    labelJenisBenih.Text = HitungStok(conn, "BENIH", "JENIS").ToString() + " jenis";
                    labelStokBenih.Text = HitungStok(conn, "BENIH", "TOTAL").ToString() + " ekor";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private decimal HitungStok(NpgsqlConnection conn, string tipe, string mode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_info_stok(@tipe, @mode)", conn);
            cmd.Parameters.AddWithValue("@tipe", tipe);
            cmd.Parameters.AddWithValue("@mode", mode);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }
    }
}
