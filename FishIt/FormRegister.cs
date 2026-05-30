using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static FishIt.Form1;

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
            string telpon = TBTelpon.Text.Trim();
            string alamat = TBAlamat.Text.Trim();
            string kelurahan = TBKelurahan.Text.Trim();
            string kecamatan = TBKecamatan.Text.Trim();

            // Validasi: Cek apakah TextBox kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string checkQuery = "SELECT COUNT(*) FROM akun WHERE Username = @Username";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);

                        long count = (long)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Username sudah terdaftar! Silakan gunakan nama lain.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    int id_Kecamatan = GetOrCreateKecamatan(conn, kecamatan);
                    int id_Kelurahan = GetOrCreateKelurahan(conn, kelurahan);

                    // Enkripsi password sebelum disimpan (Keamanan)
                    //string hashedPassword = HashPassword(password);

                    // Simpan data Username dan Password (yang sudah di-hash) ke tabel Users
                    string insertQuery = "INSERT INTO akun (Nama, Username, Password, no_Telp, Alamat, id_kelurahan, id_kecamatan) VALUES (@Nama, @Username, @Password, @Telpon, @Alamat, @Id_Kelurahan, @Id_Kecamatan)";
                    using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Nama", nama);
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@Password", password);
                        insertCmd.Parameters.AddWithValue("@Telpon", telpon);
                        insertCmd.Parameters.AddWithValue("@Alamat", alamat);
                        insertCmd.Parameters.AddWithValue("@Id_Kelurahan", id_Kelurahan);
                        insertCmd.Parameters.AddWithValue("@Id_Kecamatan", id_Kecamatan);

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
            string selectQuery = "SELECT id FROM kecamatan WHERE nama_kecamatan = @nama_kecamatan";
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
            string insertQuery = "INSERT INTO kecamatan (nama_kecamatan) VALUES (@nama) RETURNING id";
            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@nama", nama_Kecamatan);
                return Convert.ToInt32(insertCmd.ExecuteScalar());
            }
        }

        private int GetOrCreateKelurahan(NpgsqlConnection conn, string nama_Kelurahan)
        {
            // Cek apakah kelurahan sudah ada
            string selectQuery = "SELECT id FROM kelurahan WHERE nama_kelurahan = @nama_kelurahan";
            using (var selectCmd = new NpgsqlCommand(selectQuery, conn))
            {
                selectCmd.Parameters.AddWithValue("@nama_kelurahan", nama_Kelurahan);
                object result = selectCmd.ExecuteScalar();

                // Jika data ada, kembalikan ID-nya
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            // Jika data tidak ada, Insert data baru dan ambil ID-nya (RETURNING id)
            string insertQuery = "INSERT INTO kelurahan (nama_kelurahan) VALUES (@nama) RETURNING id";
            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@nama", nama_Kelurahan);
                return Convert.ToInt32(insertCmd.ExecuteScalar());
            }
        }
    }
}
