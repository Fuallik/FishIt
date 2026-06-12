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
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string usernameInput = TBUsername.Text.Trim();

                if (string.IsNullOrWhiteSpace(usernameInput))
                {
                    MessageBox.Show("Username tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                                    string nama = reader["nama"].ToString();
                                    string alamat = reader["alamat"].ToString();
                                    string telp = reader["no_telp"].ToString();
                                    string kelurahan = reader["nama_kelurahan"].ToString();
                                    string kecamatan = reader["nama_kecamatan"].ToString();

                                    FormKonfirmasiHapus popUp = new FormKonfirmasiHapus(usernameInput, nama, alamat, telp, kelurahan, kecamatan);

                                    if (popUp.ShowDialog() == DialogResult.Yes)
                                    {
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

                        this.DialogResult = DialogResult.OK;
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

