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
    public partial class FormTambahAkun : Form
    {
        public FormTambahAkun()
        {
            InitializeComponent();

            TBUsername.PlaceholderText = "Username";
            TBPassword.PlaceholderText = "Password";
            TBKonfirmasi.PlaceholderText = "Konfirmasi Password";
            TBNama.PlaceholderText = "Nama Lengkap";
            TBTelpon.PlaceholderText = "No. Telpon";
            TBAlamat.PlaceholderText = "Alamat";
            TBKelurahan.PlaceholderText = "Kelurahan";
            TBKecamatan.PlaceholderText = "Kecamatan";
            CBJabatan.Text = "Pilih Jabatan";
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            lblTambahAkun.Focus();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void btnSaveTambahAkun_Click(object sender, EventArgs e)
        {
            // 1. VALIDASI KEKOSONGAN INPUT MANUAL
            if (string.IsNullOrWhiteSpace(TBUsername.Text) ||
                string.IsNullOrWhiteSpace(TBNama.Text) ||
                string.IsNullOrWhiteSpace(TBPassword.Text) ||
                string.IsNullOrWhiteSpace(TBKonfirmasi.Text) ||
                string.IsNullOrWhiteSpace(TBAlamat.Text) ||
                string.IsNullOrWhiteSpace(TBTelpon.Text) ||
                string.IsNullOrWhiteSpace(TBKelurahan.Text) ||
                string.IsNullOrWhiteSpace(TBKecamatan.Text))
            {
                MessageBox.Show("Semua data teks wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. VALIDASI KECOCOKAN PASSWORD
            if (TBPassword.Text != TBKonfirmasi.Text)
            {
                MessageBox.Show("Password dan Konfirmasi Password tidak cocok! Silakan periksa kembali.",
                                "Password Salah", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TBKonfirmasi.Clear();
                TBKonfirmasi.Focus();
                return;
            }

            // 3. VALIDASI COMBOBOX JABATAN
            if (CBJabatan.SelectedIndex == -1 || CBJabatan.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih Jabatan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query CALL disesuaikan jumlah parameternya menjadi 10 buah
            string query = "CALL sp_tambah_akun(@p_username, @p_nama, @p_passwords, @p_alamat, @p_no_telp, @p_aktif, @p_id_role, @p_nama_kelurahan, @p_nama_kecamatan, @p_id_baru)";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;

                        // URUTAN WAJIB SAMA PERSIS DENGAN DI PGADMIN:
                        cmd.Parameters.Add("@p_username", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBUsername.Text.Trim();
                        cmd.Parameters.Add("@p_nama", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBNama.Text.Trim();
                        cmd.Parameters.Add("@p_passwords", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBPassword.Text.Trim();
                        cmd.Parameters.Add("@p_alamat", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBAlamat.Text.Trim();
                        cmd.Parameters.Add("@p_no_telp", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBTelpon.Text.Trim();

                        // Parameter ke-6: p_aktif (Boolean) -> Kita set langsung true
                        cmd.Parameters.Add("@p_aktif", NpgsqlTypes.NpgsqlDbType.Boolean).Value = true;

                        // Parameter ke-7: p_id_role (Integer)
                        int idRoleTerpilih = Convert.ToInt32(CBJabatan.SelectedValue);
                        cmd.Parameters.Add("@p_id_role", NpgsqlTypes.NpgsqlDbType.Integer).Value = idRoleTerpilih;

                        // Parameter ke-8 & 9: Wilayah (Varchar)
                        cmd.Parameters.Add("@p_nama_kelurahan", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBKelurahan.Text.Trim();
                        cmd.Parameters.Add("@p_nama_kecamatan", NpgsqlTypes.NpgsqlDbType.Varchar).Value = TBKecamatan.Text.Trim();

                        // Parameter ke-10: p_id_baru (Integer OUT / InputOutput)
                        var paramIdBaru = new NpgsqlParameter("@p_id_baru", NpgsqlTypes.NpgsqlDbType.Integer);
                        paramIdBaru.Direction = ParameterDirection.InputOutput;
                        paramIdBaru.Value = DBNull.Value;
                        cmd.Parameters.Add(paramIdBaru);

                        // Eksekusi data
                        cmd.ExecuteNonQuery();

                        // Ambil nilai balik ID Akun Baru
                        int idUserTerbuat = Convert.ToInt32(paramIdBaru.Value);

                        MessageBox.Show($"Akun baru berhasil ditambahkan!\n" +
                                        $"Sistem database telah memvalidasi wilayah Kelurahan {TBKelurahan.Text.Trim()} - Kecamatan {TBKecamatan.Text.Trim()}.",
                                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan data akun:\n" + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBatalTambahAkun_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FormTambahAkun_Load(object sender, EventArgs e)
        {
            LoadRole();
        }
        private void LoadRole()
        {
            string queryRole = "SELECT id_role, nama_role FROM roles WHERE id_role != 6 ORDER BY nama_role ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(queryRole, conn))
                    {
                        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Ikat data ke ComboBox Role seperti biasa
                        CBJabatan.DataSource = dt;
                        CBJabatan.DisplayMember = "nama_role";
                        CBJabatan.ValueMember = "id_role";

                        // Set agar ComboBox tidak langsung terpilih otomatis di awal (kosong dulu)
                        CBJabatan.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar Role: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
