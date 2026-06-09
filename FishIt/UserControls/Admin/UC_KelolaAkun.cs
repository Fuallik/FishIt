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
    public partial class UC_KelolaAkun : UserControl
    {
        public UC_KelolaAkun()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahAkun, 25);
            PanelHelper.BuatMelengkung(panelAkunTambak, 25);
            PanelHelper.BuatMelengkung(panelStatistik, 25);
            new AutoScaleHelper(this);
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void UC_TambahAkun_Load(object sender, EventArgs e)
        {
            MuatDataRiwayat();
            HitungAkunAktif();
            HitungAkunTidakAktif();
        }

        public void MuatDataRiwayat()
        {
            // Ambil dari VIEW dan urutkan dari yang paling baru (DESC)
            string query = "SELECT * FROM view_laporan_riwayat ORDER BY \"Waktu\" DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // IKATKAN KE DATA GRID VIEW RIWAYAT KAMU
                        DGVRiwayatTambahAkun.DataSource = dt;

                        // Rapikan tampilan visualnya menggunakan helper tema modern
                        GridHelper.AturTemaModern(DGVRiwayatTambahAkun);

                        // (Opsional) Atur ukuran kolom aktivitas agar lebih lebar dibanding ID
                        if (DGVRiwayatTambahAkun.Columns["Aktivitas"] != null)
                        {
                            DGVRiwayatTambahAkun.Columns["Aktivitas"].Width = 300;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat tabel riwayat: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // 1. Buat objek/instance baru dari FormTambahAkun
            FormTambahAkun formTambah = new FormTambahAkun();

            // 2. Tampilkan form sebagai Dialog (Pop-up yang mengunci halaman belakang)
            // Menggunakan ShowDialog() jauh lebih disarankan dibanding Show() biasa agar admin fokus mengisi data
            if (formTambah.ShowDialog() == DialogResult.OK)
            {
                MuatDataRiwayat();
            }
        }
        private void HitungAkunAktif()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE aktif = true";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        lblHitungAkunAktif.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HitungAkunTidakAktif()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE aktif = false";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        lblHitungAkunTidakAktif.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnHapusAkun_Click(object sender, EventArgs e)
        {
            FormHapusAkun formHapus = new FormHapusAkun();

            if (formHapus.ShowDialog() == DialogResult.OK)
            {
                MuatDataRiwayat();
            }
        }
    }
}
