using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;

namespace FishIt
{
    public partial class UC_KelolaAkun : UserControl
    {
        public UC_KelolaAkun()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void UC_KelolaAkun_Load(object sender, EventArgs e)
        {
            HitungJumlahAkun();
        }

        private void panelUtama_Paint(object sender, PaintEventArgs e)
        {

        }
        private void HitungJumlahAkun()
        {
            // Pastikan nama tabel di query ini diganti sesuai nama tabel aslimu di PostgreSQL
            string query = "SELECT COUNT(*) FROM akun";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open(); // Membuka koneksi di dalam try agar jika gagal langsung masuk ke catch

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // KUNCI: PostgreSQL mengembalikan Int64 (long) untuk fungsi COUNT(*)
                        long totalAkun = (long)cmd.ExecuteScalar();

                        // Masukkan ke label kamu
                        lblHitungAkun.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Koneksi otomatis tertutup dengan aman di sini berkat 'using'
        }
    }
}
