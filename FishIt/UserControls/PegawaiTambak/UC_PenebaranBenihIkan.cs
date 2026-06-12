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
    public partial class UC_PenebaranBenihIkan : UserControl
    {
        public UC_PenebaranBenihIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPenebaran);   // ganti nama DGV sesuai Designer-mu
            new AutoScaleHelper(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatData();
        }

        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
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

                    // Filter cuma data milik akun yang login
                    using var cmd = new NpgsqlCommand(
                        "SELECT * FROM view_penebaran WHERE id_akun = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Session.IdAkun);

                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVPenebaran.DataSource = tabel;

                    // Sembunyikan kolom id_akun — dipakai buat filter, nggak perlu dilihat user
                    if (DGVPenebaran.Columns.Contains("id_akun"))
                        DGVPenebaran.Columns["id_akun"].Visible = false;
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
                    labelTotalAkumulasiPerAkun.Text = HitungPenebaran(conn, "AKUMULASI", Session.IdAkun).ToString() + " ekor";
                    labelTotalPerBulanPerAkun.Text = HitungPenebaran(conn, "BULAN", Session.IdAkun).ToString() + " ekor";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private long HitungPenebaran(NpgsqlConnection conn, string periode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_penebaran(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        // Versi PER akun (2 argumen) — overloading, sama kayak HitungMonitoring
        private long HitungPenebaran(NpgsqlConnection conn, string periode, int idAkun)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_penebaran(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToInt64(cmd.ExecuteScalar());
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPenebaranBenih form = new FormTambahPenebaranBenih();
            if (form.ShowDialog() == DialogResult.OK)
                MuatData();
        }
    }
}
