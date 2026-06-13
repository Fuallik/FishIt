using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt.Views.Admin
{
    public partial class FormTambahKolam : Form
    {

        public FormTambahKolam()
        {
            InitializeComponent();
            MuatJenisIkan();   // isi dropdown jenis ikan dari database
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        // Isi ComboBox jenis ikan HANYA dari tabel jenis_ikan
        private void MuatJenisIkan()
        {
            string query = "SELECT id_jenis_ikan, nama_jenis_ikan FROM jenis_ikan ORDER BY nama_jenis_ikan";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);

                    CBJenisIkan.DataSource = tabel;                 // ganti nama CB sesuai Designer
                    CBJenisIkan.DisplayMember = "nama_jenis_ikan";  // yang DILIHAT user
                    CBJenisIkan.ValueMember = "id_jenis_ikan";      // yang DIKIRIM ke DB (id)
                    CBJenisIkan.SelectedIndex = -1;                 // jangan auto-pilih

                    // INI yang bikin "cuma bisa pilih dari database":
                    // user tidak bisa mengetik bebas, hanya memilih dari daftar.
                    CBJenisIkan.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat jenis ikan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // === VALIDASI ===
            if (string.IsNullOrWhiteSpace(TBNama.Text))   // "Nama" -> kolom nomor
            {
                MessageBox.Show("Nomor/Nama kolam wajib diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(TBPanjang.Text))
            {
                MessageBox.Show("Ukuran wajib diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kapasitas harus angka bulat > 0 (kolomnya INTEGER)
            if (!int.TryParse(TBPanjang.Text.Trim(), out int panjang) || panjang <= 0)
            {
                MessageBox.Show("Panjang harus angka lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(TBLebar.Text.Trim(), out int lebar) || lebar <= 0)
            {
                MessageBox.Show("Lebar harus angka lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBKapasitas.Text))   // "Nama" -> kolom nomor
            {
                MessageBox.Show("Kapasitas wajib diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TBTinggi.Text.Trim(), out int tinggi) || tinggi <= 0)
            {
                MessageBox.Show("Tinggi harus angka lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gabung jadi format "panjangxlebartinggi" -> contoh: 4x6x7
            string ukuran = $"{panjang}x{lebar}x{tinggi}";

            if (CBJenisIkan.SelectedIndex == -1 || CBJenisIkan.SelectedValue == null)
            {
                MessageBox.Show("Pilih jenis ikan dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    // Hitung berapa kolam yang nomornya sama (LOWER = 'K001' dianggap sama dengan 'k001')
                    using (var cmdCek = new NpgsqlCommand(
                        "SELECT COUNT(*) FROM kolam WHERE LOWER(nomor) = LOWER(@nomor)", conn))
                    {
                        cmdCek.Parameters.AddWithValue("@nomor", TBNama.Text.Trim());
                        long jumlah = (long)cmdCek.ExecuteScalar();

                        if (jumlah > 0)
                        {
                            MessageBox.Show("Nomor/Nama kolam '" + TBNama.Text.Trim() + "' sudah ada! Pakai yang lain.",
                                "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;   // berhenti, jangan insert
                        }
                    }

                    // === SIMPAN (nomor dipastikan belum ada) ===
                    string query = @"
            INSERT INTO kolam (nomor, ukuran, kapasitas, status_kolam, id_jenis_ikan)
            VALUES (@nomor, @ukuran, @kapasitas, 'Kosong', @id_jenis)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nomor", TBNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@ukuran", ukuran);
                        cmd.Parameters.AddWithValue("@kapasitas", Convert.ToInt32(TBKapasitas.Text.Trim()));
                        cmd.Parameters.AddWithValue("@id_jenis", Convert.ToInt32(CBJenisIkan.SelectedValue));
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kolam berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan kolam: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
