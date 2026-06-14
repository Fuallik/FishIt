using FishIt.Helpers;
using Npgsql;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    public partial class UC_DashboardShipper : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_DashboardShipper()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelDiproses, 20);
            PanelHelper.BuatMelengkung(panelDikirim, 20);
            PanelHelper.BuatMelengkung(panelSelesai, 20);
            new AutoScaleHelper(this);
        }

        private void UC_DashboardShipper_Load(object sender, EventArgs e)
        {
            HitungRingkasan();
            if (!string.IsNullOrEmpty(Session.Username))
            {
                lblUsername.Text = Session.Username;
            }
            else
            {
                lblUsername.Text = "Guest";
            }
            new AutoScaleHelper(this);
        }

        /// <summary>
        /// Satu query GROUP BY menghitung jumlah pengiriman per status untuk shipper ini.
        /// Lebih hemat daripada 3 query terpisah karena cukup sekali jalan ke database.
        /// </summary>
        private void HitungRingkasan()
        {
            string query = @"
                SELECT status_pengiriman, COUNT(*) AS jumlah
                FROM pengiriman
                WHERE id_akun = @id_shipper
                GROUP BY status_pengiriman";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_shipper", Session.IdAkun);
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Reset ke 0 dulu, lalu isi sesuai baris yang ada.
                            // Status yang tidak muncul di hasil berarti jumlahnya 0.
                            lblAngkaDiproses.Text = "0";
                            lblAngkaDikirim.Text = "0";
                            lblAngkaSelesai.Text = "0";

                            while (reader.Read())
                            {
                                string status = reader.GetString(0);
                                long jumlah = reader.GetInt64(1);

                                switch (status)
                                {
                                    case "Diproses":
                                        lblAngkaDiproses.Text = jumlah.ToString();
                                        break;
                                    case "Dikirim":
                                        lblAngkaDikirim.Text = jumlah.ToString();
                                        break;
                                    case "Diterima":
                                        lblAngkaSelesai.Text = jumlah.ToString();
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}