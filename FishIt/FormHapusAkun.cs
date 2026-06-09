using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormHapusAkun : Form
    {
        public FormHapusAkun()
        {
            InitializeComponent();
            TBUsername.MaxLength = 50;
            TBUsername.PlaceholderText = "Ketik username di sini...";
            TBUsername.KeyDown += TBUsername_KeyDown;
        }

        private void FormHapusAkun_Load(object sender, EventArgs e)
        {

        }

        private void btnHapusAkun_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBatalHapusAkun_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBUsername_KeyDown(object sender, KeyEventArgs e)
        {
            // Cek apakah tombol yang ditekan admin adalah tombol ENTER
            if (e.KeyCode == Keys.Enter)
            {
                // Mencegah suara "ding" default windows saat menekan enter di textbox
                e.SuppressKeyPress = true;

                string usernameInput = TBUsername.Text.Trim();

                if (string.IsNullOrWhiteSpace(usernameInput))
                {
                    MessageBox.Show("Username tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ambil data detail dari database
                string query = @"SELECT a.nama, a.alamat, a.no_telp, kl.nama_kelurahan, kc.nama_kecamatan
                                 FROM akun a
                                 JOIN kelurahan kl ON a.id_kelurahan = kl.id_kelurahan
                                 JOIN kecamatan kc ON kl.id_kecamatan = kc.id_kecamatan
                                 WHERE LOWER(a.username) = LOWER(@p_username) AND a.aktif = TRUE";

                using (var conn = new NpgsqlConnection(FormTambahAkun.Config.ConnString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.Add("@p_username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = usernameInput;

                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // 1. Ambil data dari database ke variabel sementara
                                    string nama = reader["nama"].ToString();
                                    string alamat = reader["alamat"].ToString();
                                    string telp = reader["no_telp"].ToString();
                                    string kelurahan = reader["nama_kelurahan"].ToString();
                                    string kecamatan = reader["nama_kecamatan"].ToString();

                                    // 2. Buka FORM POP-UP BARU dan kirim datanya lewat Constructor
                                    FormKonfirmasiHapus popUp = new FormKonfirmasiHapus(usernameInput, nama, alamat, telp, kelurahan, kecamatan);

                                    // 3. Tampilkan Pop-up dan tunggu keputusan verifikasi admin
                                    if (popUp.ShowDialog() == DialogResult.Yes)
                                    {
                                        // Jika admin klik "Ya, Hapus" di form pop-up, jalankan Stored Procedure Soft Delete
                                        EksekusiSoftDelete(usernameInput);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Akun dengan username '{usernameInput}' tidak ditemukan atau sudah tidak aktif!",
                                                    "Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TBUsername.Clear();
                                    TBUsername.Focus();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // GANTI BARIS YANG EROR TADI DENGAN INI:
                        MessageBox.Show("Gagal mengambil detail akun:\n" + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void EksekusiSoftDelete(string username)
        {
            string queryHapus = "CALL sp_hapus_akun(@p_username)";

            using (var conn = new NpgsqlConnection(FormTambahAkun.Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(queryHapus, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@p_username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Akun '{username}' berhasil dinonaktifkan dari sistem!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK; // Segera refresh DataGridView utama
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menonaktifkan akun:\n" + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

