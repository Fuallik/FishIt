using Npgsql;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_DashboardSupplier : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_DashboardSupplier()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelMenunggu, 20);
            PanelHelper.BuatMelengkung(panelDisetujui, 20);
            PanelHelper.BuatMelengkung(panelDitolak, 20);
        }

        private void UC_DashboardSupplier_Load(object sender, EventArgs e)
        {
            lblSelamatDatang.Text = $"Selamat datang, {Session.NamaUser}";
            HitungRingkasan();
        }

        /// <summary>
        /// Satu query GROUP BY menghitung jumlah pengajuan per status_verifikasi
        /// untuk supplier yang sedang login.
        /// </summary>
        private void HitungRingkasan()
        {
            string query = @"
                SELECT status_verifikasi, COUNT(*) AS jumlah
                FROM pengiriman_supplier
                WHERE id_akun = @id_akun
                GROUP BY status_verifikasi";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Reset ke 0 dulu; status yang tidak muncul berarti jumlahnya 0.
                            lblAngkaMenunggu.Text = "0";
                            lblAngkaDisetujui.Text = "0";
                            lblAngkaDitolak.Text = "0";

                            while (reader.Read())
                            {
                                string status = reader.GetString(0);
                                long jumlah = reader.GetInt64(1);

                                switch (status)
                                {
                                    case "Menunggu":
                                        lblAngkaMenunggu.Text = jumlah.ToString();
                                        break;
                                    case "Disetujui":
                                        lblAngkaDisetujui.Text = jumlah.ToString();
                                        break;
                                    case "Ditolak":
                                        lblAngkaDitolak.Text = jumlah.ToString();
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