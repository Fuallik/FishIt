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
    public partial class FormHapusKolam : Form
    {
        public FormHapusKolam()
        {
            InitializeComponent();
            MuatComboKolam();   // isi dropdown dengan kolam yang BISA dihapus
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        // Combobox hanya menampilkan kolam KOSONG (tidak ada ikan) -> yang aman dihapus.
        // status 'Tidak Terpakai' otomatis tidak muncul karena dia bukan 'Kosong'.
        private void MuatComboKolam()
        {
            string query = "SELECT id_kolam, nomor FROM kolam WHERE status_kolam = 'Kosong' ORDER BY nomor";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);

                    CBIdKolam.DataSource = tabel;            // ganti nama CB sesuai Designer
                    CBIdKolam.DisplayMember = "nomor";       // yang DILIHAT user (K001, K002, ...)
                    CBIdKolam.ValueMember = "id_kolam";      // yang DIPAKAI logika (id)
                    CBIdKolam.SelectedIndex = -1;            // jangan auto-pilih
                    CBIdKolam.DropDownStyle = ComboBoxStyle.DropDownList;  // cuma bisa pilih, tak bisa ngetik
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar kolam: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validasi: harus ada kolam yang dipilih
            if (CBIdKolam.SelectedIndex == -1 || CBIdKolam.SelectedValue == null)
            {
                MessageBox.Show("Pilih kolam yang mau dihapus dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKolam = Convert.ToInt32(CBIdKolam.SelectedValue);
            string nomorKolam = CBIdKolam.Text;

            var konfirmasi = MessageBox.Show($"Tandai kolam '{nomorKolam}' sebagai Tidak Terpakai?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (konfirmasi != DialogResult.Yes) return;

            // SOFT-DELETE: bukan DELETE, tapi UPDATE status jadi 'Tidak Terpakai'.
            // Guard 'status_kolam = Kosong' memastikan hanya kolam kosong yang bisa ditandai
            // (mencegah menghapus kolam yang ternyata sudah berubah jadi Terisi).
            string query = @"UPDATE kolam
                             SET status_kolam = 'Tidak Terpakai'
                             WHERE id_kolam = @id AND status_kolam = 'Kosong'";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idKolam);
                    int baris = cmd.ExecuteNonQuery();   // jumlah baris yang berubah

                    if (baris > 0)
                    {
                        MessageBox.Show($"Kolam '{nomorKolam}' ditandai Tidak Terpakai.", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;   // sinyal ke UC: refresh
                        this.Close();
                    }
                    else
                    {
                        // 0 baris = kolam sudah tidak 'Kosong' (mungkin keburu terisi). Jangan hapus.
                        MessageBox.Show("Kolam tidak bisa dihapus (mungkin sudah terisi). Coba refresh.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus kolam: " + ex.Message,
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
