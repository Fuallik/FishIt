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

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_PemberianPakan : UserControl
    {
        public UC_PemberianPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPakan);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panel1, 25);
            PanelHelper.BuatMelengkung(panel2, 25);
            PanelHelper.BuatMelengkung(panel6, 25);
            PanelHelper.MakeButtonRounded(buttonPemberianPakan, 25);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatData();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
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

                    using var cmd = new NpgsqlCommand(
                        "SELECT * FROM view_pemberian_pakan WHERE id_akun = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Session.IdAkun);

                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVPakan.DataSource = tabel;

                    if (DGVPakan.Columns.Contains("id_akun"))
                        DGVPakan.Columns["id_akun"].Visible = false;
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

                try
                {
                    conn.Open();
                    labelTotalAkumulasiPerAkun.Text = HitungPakan(conn, "AKUMULASI", Session.IdAkun).ToString("N2") + " kg";
                    labelTotalPerBulanPerAkun.Text = HitungPakan(conn, "BULAN", Session.IdAkun).ToString("N2") + " kg";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private decimal HitungPakan(NpgsqlConnection conn, string periode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_pakan(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private decimal HitungPakan(NpgsqlConnection conn, string periode, int idAkun)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_pakan(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        private void buttonPemberianPakan_Click(object sender, EventArgs e)
        {
            FormTambahPemberianPakan formTambah = new FormTambahPemberianPakan();

            if (formTambah.ShowDialog() == DialogResult.OK)
            {
                MuatData();
            }
        }
    }
}
