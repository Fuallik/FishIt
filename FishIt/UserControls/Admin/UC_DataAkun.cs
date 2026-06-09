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
    public partial class UC_DataAkun : UserControl
    {
        public UC_DataAkun()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahAkun, 25);
            PanelHelper.BuatMelengkung(panelAkunTambak, 25);
            PanelHelper.BuatMelengkung(panelAkunKasir, 25);
            PanelHelper.BuatMelengkung(panelShipper, 25);
            PanelHelper.BuatMelengkung(panelAkunSupplier, 25);
            PanelHelper.BuatMelengkung(panelAkunPembeli, 25);
            PanelHelper.BuatMelengkung(panelStatistik, 25);
            new AutoScaleHelper(this);
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void UC_KelolaAkun_Load(object sender, EventArgs e)
        {
            HitungAkunAktif();
            HitungAkunTidakAktif();
            HitungTambak();
            HitungKasir();
            HitungSupplier();
            HitungShipper();
            HitungPembeli();
            TampilkanDataDariPostgres();
        }

        private void panelUtama_Paint(object sender, PaintEventArgs e)
        {

        }
        private void HitungAkunAktif()
        {
            // Pastikan nama tabel di query ini diganti sesuai nama tabel aslimu di PostgreSQL
            string query = "SELECT COUNT(*) FROM akun WHERE aktif = true";

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
                        lblHitungAkunAktif.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } // Koneksi otomatis tertutup dengan aman di sini berkat 'using'
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

                        lblHitungAkunTidakAKtif.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HitungTambak()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE id_role = 3";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        TotalTambakKelola.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HitungKasir()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE id_role = 2";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        TotalKasirKelola.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HitungSupplier()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE id_role = 5";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        TotalSupplierKelola.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void HitungShipper()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE id_role = 4";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        TotalShipperKelola.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HitungPembeli()
        {
            string query = "SELECT COUNT(*) FROM akun WHERE id_role = 6";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        long totalAkun = (long)cmd.ExecuteScalar();

                        TotalPembeliKelola.Text = totalAkun.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void TampilkanDataDariPostgres()
        {
            // Tulis perintah SQL untuk mengambil data dari tabel kamu
            string query = "SELECT a.id_akun, a.username, a.nama, a.no_telp, a.alamat, r.nama_role, a.aktif FROM akun a JOIN roles r ON a.id_role = r.id_role ORDER BY a.id_akun ASC";

            // Membuka koneksi dengan blok 'using' supaya memori otomatis bersih setelah selesai
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open(); // Buka gerbang koneksi ke Postgres

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // DataAdapter bertindak sebagai jembatan pembawa data
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);

                        // DataTable bertindak sebagai keranjang penampung data di aplikasi kita
                        DataTable dt = new DataTable();

                        // Isi keranjang (dt) dengan data yang diambil oleh adapter
                        adapter.Fill(dt);

                        // IKATKAN keranjang data ke DataGridView milikmu
                        // Ganti 'dataGridView1' sesuai dengan nama DGV kamu di desainer
                        DGVDataAkun.DataSource = dt;
                        DGVDataAkun.Columns["id_akun"].HeaderText = "ID Pengguna";
                        DGVDataAkun.Columns["username"].HeaderText = "Nama Pengguna";
                        DGVDataAkun.Columns["nama"].HeaderText = "Nama Lengkap";
                        DGVDataAkun.Columns["no_telp"].HeaderText = "No. Telepon";
                        DGVDataAkun.Columns["alamat"].HeaderText = "Alamat";
                        DGVDataAkun.Columns["nama_role"].HeaderText = "Hak Akses";
                        DGVDataAkun.Columns["aktif"].HeaderText = "Status Aktif"; 

                        GridHelper.AturTemaModern(DGVDataAkun);
                    }
                }
                catch (Exception ex)
                {
                    // Menampilkan pesan jika koneksi gagal atau query salah
                    MessageBox.Show("Waduh, gagal ambil data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panelJumlahAkun_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
