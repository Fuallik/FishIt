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
    public partial class UC_MonitoringIkan : UserControl
    {
        public UC_MonitoringIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVMonitoringIkan);
            new AutoScaleHelper(this);
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
                        "SELECT * FROM view_monitoring_ikan WHERE id_akun = @id", conn);
                    cmd.Parameters.AddWithValue("@id", Session.IdAkun);

                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVMonitoringIkan.DataSource = tabel;
                    if (DGVMonitoringIkan.Columns.Contains("id_akun"))
                        DGVMonitoringIkan.Columns["id_akun"].Visible = false;
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

                labelTotalBulanPerAkun.Text = HitungMonitoring(conn, "BULAN", Session.IdAkun).ToString();
                labelTotalHariPerAkun.Text = HitungMonitoring(conn, "HARI_INI", Session.IdAkun).ToString();
             }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int HitungMonitoring(NpgsqlConnection conn, string periode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_monitoring(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int HitungMonitoring(NpgsqlConnection conn, string periode, int idAkun)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_monitoring(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void buttonTambahMonitoring_Click(object sender, EventArgs e)
        {
            FormTambahMonitoring formTambah = new FormTambahMonitoring();

            if (formTambah.ShowDialog() == DialogResult.OK)
            {
                MuatData();
            }
        }
    }
}
