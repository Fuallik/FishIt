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

namespace FishIt
{
    public partial class FormTambahPenebaranBenih : Form
    {
        public FormTambahPenebaranBenih()
        {
            InitializeComponent();
            MuatDropdown();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBBenihIkan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kolam dan benih dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NUBEkor.Value <= 0)
            {
                MessageBox.Show("Jumlah ekor harus lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idKolam = Convert.ToInt32(CBKolam.SelectedValue);
            int ekorBaru = (int)NUBEkor.Value;

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();

                    // Ambil kapasitas kolam + jumlah ikan yang SUDAH ada (tebar - panen) sekaligus
                    using var cmdCek = new NpgsqlCommand(@"
                        SELECT k.kapasitas,
                               fn_isi_kolam(k.id_kolam) AS isi_sekarang
                        FROM kolam k
                        WHERE k.id_kolam = @kolam", conn);
                    cmdCek.Parameters.AddWithValue("@kolam", idKolam);

                    int kapasitas = 0, isiSekarang = 0;
                    using (var r = cmdCek.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            kapasitas = Convert.ToInt32(r["kapasitas"]);
                            isiSekarang = Convert.ToInt32(r["isi_sekarang"]);
                        }
                    }

                    // Cek: isi sekarang + yang mau ditebar tidak boleh lebih dari kapasitas
                    if (isiSekarang + ekorBaru > kapasitas)
                    {
                        int sisaMuat = kapasitas - isiSekarang;   // berapa lagi yang masih muat
                        MessageBox.Show(
                            $"Melebihi kapasitas kolam!\n\n" +
                            $"Kapasitas    : {kapasitas} ekor\n" +
                            $"Sudah terisi : {isiSekarang} ekor\n" +
                            $"Masih muat   : {sisaMuat} ekor\n" +
                            $"Mau ditebar  : {ekorBaru} ekor",
                            "Kapasitas Penuh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;   // batal, jangan lanjut INSERT
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal cek kapasitas: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
            INSERT INTO penebaran (tanggal_tebar, jumlah_ekor, id_akun, id_benih, id_kolam)
            VALUES (CURRENT_DATE, @ekor, @akun, @benih, @kolam)", conn);

                cmd.Parameters.AddWithValue("@ekor", (int)NUBEkor.Value);
                cmd.Parameters.AddWithValue("@akun", Session.IdAkun);
                cmd.Parameters.AddWithValue("@benih", Convert.ToInt32(CBBenihIkan.SelectedValue));
                cmd.Parameters.AddWithValue("@kolam", Convert.ToInt32(CBKolam.SelectedValue));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Penebaran benih dicatat & stok otomatis diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (PostgresException pgEx)
            {
                MessageBox.Show(pgEx.MessageText, "Gagal",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDropdown()
        {
            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                var dtKolam = new DataTable();
                // Query diubah untuk mengambil semua kolam kecuali yang 'Tidak Terpakai'
                using (var ad = new NpgsqlDataAdapter(@"SELECT id_kolam, nomor 
                                                        FROM kolam 
                                                        WHERE status_kolam != 'Tidak Terpakai' 
                                                        ORDER BY nomor", conn))
                {
                    ad.Fill(dtKolam);
                }

                CBKolam.DataSource = dtKolam;
                CBKolam.DisplayMember = "nomor";
                CBKolam.ValueMember = "id_kolam";
                CBKolam.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat dropdown: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatBenihByKolam(int idKolam)
        {
            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
                    SELECT b.id_benih, b.nama
                    FROM benih b
                    WHERE b.id_jenis_ikan = (
                        SELECT id_jenis_ikan FROM kolam WHERE id_kolam = @kolam
                    )
                      AND b.jumlah_stok > 0
                    ORDER BY b.nama", conn);
                cmd.Parameters.AddWithValue("@kolam", idKolam);

                var dt = new DataTable();
                using var ad = new NpgsqlDataAdapter(cmd);
                ad.Fill(dt);

                CBBenihIkan.DataSource = dt;
                CBBenihIkan.DisplayMember = "nama";
                CBBenihIkan.ValueMember = "id_benih";
                CBBenihIkan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat benih: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBBenihIkan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBBenihIkan.SelectedIndex == -1)
            {
                labelStok.Text = "";
                return;
            }

            using (var conn = new NpgsqlConnection(Config.ConnString))

                try
                {
                    conn.Open();

                    using var cmd = new NpgsqlCommand(
                        "SELECT jumlah_stok FROM benih WHERE id_benih=@id", conn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(CBBenihIkan.SelectedValue));

                    int stok = Convert.ToInt32(cmd.ExecuteScalar());
                    labelStok.Text = $"{stok} ekor";
                }
                catch (Exception ex)
                {
                    labelStok.Text = "Gagal ambil stok";
                    Console.WriteLine(ex.Message);
                }
        }

        private void CBKolam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBKolam.SelectedValue == null
        || !int.TryParse(CBKolam.SelectedValue.ToString(), out int idKolam))
            {
                CBBenihIkan.DataSource = null;
                return;
            }

            MuatBenihByKolam(idKolam);
        }

    }
}
