using FishIt.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FishIt
{
    public partial class FormTambahMonitoring : Form
    {

        public FormTambahMonitoring()
        {
            InitializeComponent();

            MuatKolam();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void MuatKolam()
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))

                try
                {
                    conn.Open();

                    // === QUERY DIUBAH: Menambahkan pengurangan ikan mati dari tabel monitoring ===
                    using var cmd = new NpgsqlCommand(
                        @"SELECT k.id_kolam, k.nomor
                          FROM kolam k
                          WHERE fn_isi_kolam(k.id_kolam) > 0
                          ORDER BY k.nomor", conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);

                    var tabel = new DataTable();
                    adapter.Fill(tabel);

                    CBKolam.DataSource = tabel;
                    CBKolam.DisplayMember = "nomor";
                    CBKolam.ValueMember = "id_kolam";
                    CBKolam.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar kolam: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kolam dulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CBKondisi.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kondisi kolam!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NUDBerat.Value <= 0)
            {
                MessageBox.Show("Berat rata-rata harus lebih dari 0!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKolam = Convert.ToInt32(CBKolam.SelectedValue);
            int jumlahMati = (int)NUDMati.Value;

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    // === 1. VALIDASI SISA IKAN DI KOLAM ===
                    string cekSisaIkanQuery = "SELECT fn_isi_kolam(@id_kolam)";

                    using (var cmdCek = new NpgsqlCommand(cekSisaIkanQuery, conn))
                    {
                        cmdCek.Parameters.AddWithValue("@id_kolam", idKolam);
                        long sisaIkan = Convert.ToInt64(cmdCek.ExecuteScalar());

                        if (jumlahMati > sisaIkan)
                        {
                            MessageBox.Show($"Jumlah ikan mati ({jumlahMati} ekor) melebihi sisa ikan di kolam!\nSisa ikan saat ini hanya {sisaIkan} ekor.",
                                "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            NUDMati.Focus();
                            return; // Hentikan proses simpan
                        }
                    }
                    // ======================================

                    // === 2. PROSES INSERT DATA ===
                    string sql = @"
                INSERT INTO monitoring
                (berat_rata_rata, kondisi, jumlah_mati, catatan, siap_panen, id_akun, id_kolam)
                VALUES
                (@berat, @kondisi, @mati, @catatan, @siap, @id_akun, @id_kolam)";

                    using var cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@berat", NUDBerat.Value);
                    cmd.Parameters.AddWithValue("@kondisi", CBKondisi.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mati", jumlahMati);
                    cmd.Parameters.AddWithValue("@catatan", TBCatatan.Text.Trim());
                    cmd.Parameters.AddWithValue("@siap", CBPanen.Checked);
                    cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                    cmd.Parameters.AddWithValue("@id_kolam", idKolam);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data monitoring berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBKolam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
