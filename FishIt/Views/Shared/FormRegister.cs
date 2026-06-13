using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;

            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btnExit.ForeColor = Color.Black;

            btnExit.UseVisualStyleBackColor = false;

            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;

            PanelHelper.MakeButtonRounded(buttonRegister, 20);
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.MidnightBlue;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Black;

            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
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

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(konfirmasipassword) || string.IsNullOrEmpty(telpon))
            {
                MessageBox.Show("nama, username, password, konfirmasi password, dan no telepon tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!username.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Username tidak boleh mengandung simbol atau spasi! Hanya boleh huruf dan angka.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBUsername.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password minimal harus 8 karakter!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPassword.Focus();
                return;
            }

            if (password.Contains(" "))
            {
                MessageBox.Show("Password tidak boleh mengandung spasi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBPassword.Focus();
                return;
            }

            if (password != konfirmasipassword)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!telpon.All(char.IsDigit))
            {
                MessageBox.Show("Nomor telepon hanya boleh berisi angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                TBTelpon.Focus();
                return;
            }

            try
            {
                using (var conn = new NpgsqlConnection(Config.ConnString))
                {
                    conn.Open();

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
                    int id_Kelurahan = GetOrCreateKelurahan(conn, kelurahan, id_Kecamatan);

                    string insertQuery = @"CALL sp_tambah_akun(@p_username, @p_nama, @p_passwords, @p_alamat, @p_no_telp, @p_aktif, @p_id_role, @p_nama_kelurahan, @p_nama_kecamatan, @p_id_baru)";
                    using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@p_username", username);
                        insertCmd.Parameters.AddWithValue("@p_nama", nama);
                        insertCmd.Parameters.AddWithValue("@p_passwords", password);
                        insertCmd.Parameters.AddWithValue("@p_alamat", alamat);
                        insertCmd.Parameters.AddWithValue("@p_no_telp", telpon);
                        insertCmd.Parameters.AddWithValue("@p_aktif", true);
                        insertCmd.Parameters.AddWithValue("@p_id_role", 6);
                        insertCmd.Parameters.AddWithValue("@p_nama_kelurahan", kelurahan);
                        insertCmd.Parameters.AddWithValue("@p_nama_kecamatan", kecamatan);

                        var paramIdBaru = new NpgsqlParameter("@p_id_baru", NpgsqlTypes.NpgsqlDbType.Integer);
                        paramIdBaru.Direction = ParameterDirection.InputOutput;
                        paramIdBaru.Value = DBNull.Value;
                        insertCmd.Parameters.Add(paramIdBaru);

                        insertCmd.ExecuteNonQuery();

                        if (paramIdBaru.Value != DBNull.Value && Convert.ToInt32(paramIdBaru.Value) > 0)
                        {
                            MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Terjadi kesalahan koneksi atau database: " + ex.Message, "Error System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetOrCreateKecamatan(NpgsqlConnection conn, string nama_Kecamatan)
        {
            string selectQuery = "SELECT id_kecamatan FROM kecamatan WHERE LOWER(nama_kecamatan) = LOWER(@nama_kecamatan)";
            using (var selectCmd = new NpgsqlCommand(selectQuery, conn))
            {
                selectCmd.Parameters.AddWithValue("@nama_kecamatan", nama_Kecamatan);
                object result = selectCmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            string insertQuery = "INSERT INTO kecamatan (nama_kecamatan) VALUES (@nama_kecamatan) RETURNING id_kecamatan";
            using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@nama_kecamatan", nama_Kecamatan);
                return Convert.ToInt32(insertCmd.ExecuteScalar());
            }
        }

        private int GetOrCreateKelurahan(NpgsqlConnection conn, string nama_Kelurahan, int id_Kecamatan)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
