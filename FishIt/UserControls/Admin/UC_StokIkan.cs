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
    public partial class UC_StokIkan : UserControl
    {
        public UC_StokIkan()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahIkan, 25);
            PanelHelper.BuatMelengkung(panelJumlahBenih, 25);
            PanelHelper.BuatMelengkung(panelJumlahPakan, 25);
            PanelHelper.BuatMelengkung(panelStatistikIkan, 25);
            PanelHelper.BuatMelengkung(panelStatistikBenih, 25);
            PanelHelper.BuatMelengkung(panelStatistikPakan, 25);
            PanelHelper.MakeButtonRounded(btnDetailIkan, 20);
            PanelHelper.MakeButtonRounded(btnDetailBenih, 20);
            PanelHelper.MakeButtonRounded(btnDetailPakan, 20);
            new AutoScaleHelper(this);
        }

        private void UC_StokIkan_Load(object sender, EventArgs e)
        {
            HitungStokIkan();
            HitungStokBenih();
            HitungStokPakan();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void HitungStokIkan()
        {
            string query = "SELECT COALESCE(SUM(stok_ikan), 0) AS total_ikan FROM ikan";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long totalIkan = Convert.ToInt64(reader["total_ikan"]);

                                lblHitungIkan.Text = totalIkan.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HitungStokBenih()
        {
            string query = "SELECT COALESCE(SUM(jumlah_stok), 0) AS total_benih FROM benih";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long totalBenih = Convert.ToInt64(reader["total_benih"]);

                                lblHitungBenih.Text = totalBenih.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HitungStokPakan()
        {
            string query = "SELECT COALESCE(SUM(jumlah_stok), 0) AS total_pakan FROM pakan";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                long totalPakan = Convert.ToInt64(reader["total_pakan"]);

                                lblHitungPakan.Text = totalPakan.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDetailIkan_Click(object sender, EventArgs e)
        {
            FormDetailIkan formDetailIkan = new FormDetailIkan();

            formDetailIkan.ShowDialog();
        }

        private void btnDetailBenih_Click(object sender, EventArgs e)
        {
            FormDetailBenih formDetailBenih = new FormDetailBenih();

            formDetailBenih.ShowDialog();
        }

        private void btnDetailPakan_Click(object sender, EventArgs e)
        {
            FormDetailPakan formDetailPakan = new FormDetailPakan();

            formDetailPakan.ShowDialog();
        }
    }
}
