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
    public partial class UC_Monitoring : UserControl
    {
        public UC_Monitoring()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelMonitoring, 25);
            PanelHelper.BuatMelengkung(panelSatuBulan, 25);
            PanelHelper.BuatMelengkung(panelHariIni, 25);
            new AutoScaleHelper(this);
        }

        private void UC_Monitoring_Load(object sender, EventArgs e)
        {
            MuatKartu();
            MuatGrid();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        private void MuatKartu()
        {

            using (var conn = new NpgsqlConnection(Config.ConnString))

                try
                {
                    conn.Open();

                    lblHariIni.Text = HitungMonitoring(conn, "HARI_INI").ToString();
                    lblSatuBulan.Text = HitungMonitoring(conn, "SATU_BULAN").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        private int HitungMonitoring(NpgsqlConnection conn, string periode)
        {
            using var cmd = new NpgsqlCommand("SELECT fn_total_monitoring(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        private void MuatGrid()
        {
            string query = "SELECT * FROM view_monitoring_ikan";

            using (var conn = new NpgsqlConnection(Config.ConnString))

                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using var adapter = new NpgsqlDataAdapter(cmd);

                        var tabel = new DataTable();
                        adapter.Fill(tabel);
                        DGVMonitoring.DataSource = tabel;

                        GridHelper.AturTemaModern(DGVMonitoring);
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data monitoring: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

    }
}
