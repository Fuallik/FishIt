using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static FishIt.FormMain;

namespace FishIt
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            this.ActiveControl = null;

            TBNama.PlaceholderText = "Nama";
            TBUsername.PlaceholderText = "Username";
            TBPassword.PlaceholderText = "Password";
            TBKonfirmasiPassword.PlaceholderText = "Konfirmasi Password";
            TBTelpon.PlaceholderText = "No. Telpon";
            TBAlamat.PlaceholderText = "Alamat";
            TBKelurahan.PlaceholderText = "Kelurahan";
            TBKecamatan.PlaceholderText = "Kecamatan";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {

        }

        private void TBNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBTelpon_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBAlamat_TextChanged(object sender, EventArgs e)
        {

        }
        private void TBKelurahan_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBKecamatan_TextChanged(object sender, EventArgs e)
        {

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            labelRegister.Focus();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string nama = TBNama.Text.Trim();
            string username = TBUsername.Text.Trim();
            string password = TBPassword.Text;
            string konfirmasipassword = TBKonfirmasiPassword.Text;
            string telpon = TBTelpon.Text.Trim();
            string alamat = TBAlamat.Text.Trim();
            string kelurahan = TBKelurahan.Text.Trim();
            string kecamatan = TBKecamatan.Text.Trim();



            // Validasi: Cek apakah TextBox kosong
            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(konfirmasipassword) || string.IsNullOrEmpty(telpon))
            {
                MessageBox.Show("nama, username, password, konfirmasi password, dan no telepon tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi: Cek apakah password dan konfirmasi password cocok
            if (password != konfirmasipassword)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!telpon.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Nomor telepon hanya boleh berisi angka!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                TBTelpon.Focus();
                return;
            }

            try
            {
                // Panggil koneksi Database menggunakan class buatanmu
                Database db = new Database(Config.ConnString);

                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    // Cek ke database apakah Username sudah dipakai orang lain
                    string checkQuery = "SELECT COUNT(*) FROM akun WHERE Username = @username";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@username", username);

                        long count = (long)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username sudah terdaftar! Silakan gunakan nama lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int id_Kecamatan = GetOrCreateKecamatan(conn, kecamatan);
                    int id_Kelurahan = GetOrCreateKelurahan(
                        conn,
                        kelurahan,
                        id_Kecamatan
                    );

                    // Enkripsi password sebelum disimpan (Keamanan)
                    //string hashedPassword = HashPassword(password);

                    // Simpan data Username dan Password (yang sudah di-hash) ke tabel Users
                    string insertQuery = @"CALL tambah_akun(@nama, @username, @passwords, @telpon, @alamat, @id_kelurahan, @id_role)";
                    using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@nama", nama);
                        insertCmd.Parameters.AddWithValue("@username", username);
                        insertCmd.Parameters.AddWithValue("@passwords", password);
                        insertCmd.Parameters.AddWithValue("@telpon", telpon);
                        insertCmd.Parameters.AddWithValue("@alamat", alamat);
                        insertCmd.Parameters.AddWithValue("@id_Kelurahan", id_Kelurahan);
                        insertCmd.Parameters.AddWithValue("@id_role", 6);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Bersihkan TextBox setelah sukses mendaftar
                            TBNama.Clear();
                            TBUsername.Clear();
                            TBPassword.Clear();
                            TBTelpon.Clear();
                            TBAlamat.Clear();
                            TBKelurahan.Clear();
                            TBKecamatan.Clear();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Registrasi gagal, sistem tidak dapat menyimpan data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Menangkap error jika database belum nyala atau query salah
                MessageBox.Show("Terjadi kesalahan koneksi atau database: " + ex.Message, "Error System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetOrCreateKecamatan(NpgsqlConnection conn, string nama_Kecamatan)
        {
            // Cek apakah kecamatan sudah ada
            string selectQuery = "SELECT id_kecamatan FROM kecamatan WHERE LOWER(nama_kecamatan) = LOWER(@nama_kecamatan)";
            using (var selectCmd = new NpgsqlCommand(selectQuery, conn))
            {
                selectCmd.Parameters.AddWithValue("@nama_kecamatan", nama_Kecamatan);
                object result = selectCmd.ExecuteScalar();

                // Jika data ada, kembalikan ID-nya
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            // Jika data tidak ada, Insert data baru dan ambil ID-nya (RETURNING id)
            string insertQuery = "INSERT INTO kecamatan (nama_kecamatan) VALUES (@nama_kecamatan) RETURNING id_kecamatan";
            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@nama_kecamatan", nama_Kecamatan);
                return Convert.ToInt32(insertCmd.ExecuteScalar());
            }
        }

        private int GetOrCreateKelurahan(
    NpgsqlConnection conn,
    string nama_Kelurahan,
    int id_Kecamatan)
        {
            string selectQuery =
                "SELECT id_kelurahan FROM kelurahan WHERE LOWER(nama_kelurahan) = LOWER(@nama_kelurahan) AND id_kecamatan = @id_kecamatan";

            using (var selectCmd = new NpgsqlCommand(selectQuery, conn))
            {
                selectCmd.Parameters.AddWithValue("@nama_kelurahan", nama_Kelurahan);
                selectCmd.Parameters.AddWithValue("@id_kecamatan", id_Kecamatan);

                object result = selectCmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            string insertQuery =
                "INSERT INTO kelurahan (nama_kelurahan, id_kecamatan) VALUES (@nama_kelurahan, @id_kecamatan) RETURNING id_kelurahan";

            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@nama_kelurahan", nama_Kelurahan);
                insertCmd.Parameters.AddWithValue("@id_kecamatan", id_Kecamatan);

                return Convert.ToInt32(insertCmd.ExecuteScalar());
            }
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
