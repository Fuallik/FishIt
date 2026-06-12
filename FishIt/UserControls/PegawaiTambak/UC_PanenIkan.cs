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
    public partial class UC_PanenIkan : UserControl
    {
        public UC_PanenIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPanen);   // ganti nama DGV sesuai Designer-mu
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
            MuatKartu();
            MuatGrid();
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
                        "SELECT * FROM view_panen WHERE id_akun = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Session.IdAkun);

                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVPanen.DataSource = tabel;

                    // Sembunyikan kolom id_akun — dipakai buat filter, nggak perlu dilihat user
                    if (DGVPanen.Columns.Contains("id_akun"))
                        DGVPanen.Columns["id_akun"].Visible = false;
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
                    labelAkumulasiPerAkun.Text = HitungPanen(conn, "AKUMULASI", Session.IdAkun).ToString("N2") + " kg";
                    labelPerTahunPerAkun.Text = HitungPanen(conn, "TAHUN", Session.IdAkun).ToString("N2") + " kg";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // SEMUA akun
        private decimal HitungPanen(NpgsqlConnection conn, string periode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_panen(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        // PER akun
        private decimal HitungPanen(NpgsqlConnection conn, string periode, int idAkun)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_panen(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private void buttonTambahPanen_Click(object sender, EventArgs e)
        {
            FormTambahPanenIkan form = new FormTambahPanenIkan();
            if (form.ShowDialog() == DialogResult.OK)
                MuatData();
        }
    }
}
