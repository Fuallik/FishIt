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
    public partial class FormTambahPanenIkan : Form
    {
        public FormTambahPanenIkan()
        {
            InitializeComponent();
            MuatDropdown();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void MuatDropdown()
        {
            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                var dtKolam = new DataTable();
                using (var ad = new NpgsqlDataAdapter(@"
                 SELECT k.id_kolam, k.nomor FROM kolam k WHERE ( SELECT m.siap_panen FROM monitoring m WHERE m.id_kolam = k.id_kolam ORDER BY m.tanggal DESC, m.id_monitoring DESC LIMIT 1 ) = TRUE AND k.status_kolam = 'Terisi'
                 ORDER BY k.nomor", conn))
                    ad.Fill(dtKolam);
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

        private void MuatIkanByKolam(int idKolam)
        {
            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
            SELECT DISTINCT i.id_ikan, i.nama_ikan AS label
            FROM ikan i
            JOIN benih b ON b.id_ikan = i.id_ikan
            JOIN penebaran p ON p.id_benih = b.id_benih
            JOIN kolam k ON k.id_kolam = p.id_kolam
            WHERE p.id_kolam = @kolam AND fn_sisa_ikan(@kolam, i.id_ikan) > 0 AND k.status_kolam != 'Kosong' AND k.status_kolam != 'Tidak terpakai'
            ORDER BY label", conn);
                cmd.Parameters.AddWithValue("@kolam", idKolam);

                var dt = new DataTable();
                using var ad = new NpgsqlDataAdapter(cmd);
                ad.Fill(dt);

                CBIkan.DataSource = null;
                CBIkan.DataSource = dt;
                CBIkan.DisplayMember = "label";
                CBIkan.ValueMember = "id_ikan";
                CBIkan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat ikan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TampilkanSisaIkan(int idKolam, int idIkan)
        {
            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                using var cmd = new NpgsqlCommand("SELECT fn_sisa_ikan(@kolam, @ikan)", conn);
                cmd.Parameters.AddWithValue("@kolam", idKolam);
                cmd.Parameters.AddWithValue("@ikan", idIkan);

                int sisa = Convert.ToInt32(cmd.ExecuteScalar());
                labelIkan.Text = sisa.ToString();
            }
            catch (Exception ex)
            {
                labelIkan.Text = "0";
                Console.WriteLine(ex.Message);
            }
        }
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBIkan.SelectedIndex == -1 || CBKualitas.SelectedIndex == -1)
            {
                MessageBox.Show("Lengkapi kolam, ikan, dan kualitas dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NUDBerat.Value <= 0 || NUBEkor.Value <= 0)
            {
                MessageBox.Show("Jumlah kg dan ekor harus lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new NpgsqlConnection(Config.ConnString);
                conn.Open();

                using var cmd = new NpgsqlCommand(@"
            INSERT INTO panen (tanggal_panen, jumlah_kg, jumlah_ekor, kualitas, id_akun, id_ikan, id_kolam)
            VALUES (CURRENT_DATE, @kg, @ekor, @kualitas, @akun, @ikan, @kolam)", conn);

                cmd.Parameters.AddWithValue("@kg", NUDBerat.Value);
                cmd.Parameters.AddWithValue("@ekor", (int)NUBEkor.Value);
                cmd.Parameters.AddWithValue("@kualitas", CBKualitas.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@akun", Session.IdAkun);
                cmd.Parameters.AddWithValue("@ikan", Convert.ToInt32(CBIkan.SelectedValue));
                cmd.Parameters.AddWithValue("@kolam", Convert.ToInt32(CBKolam.SelectedValue));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Panen dicatat, kolam dikosongkan & stok ikan bertambah!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (PostgresException pgEx)
            {
                MessageBox.Show(pgEx.MessageText, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CBKolam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBKolam.SelectedValue == null
        || !int.TryParse(CBKolam.SelectedValue.ToString(), out int idKolam))
            {
                CBIkan.DataSource = null;
                labelIkan.Text = "0";
                return;
            }

            MuatIkanByKolam(idKolam);
            labelIkan.Text = "0";
        }

        private void CBIkan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBIkan.SelectedIndex == -1 || CBKolam.SelectedValue == null || CBIkan.SelectedValue == null
        || !int.TryParse(CBKolam.SelectedValue.ToString(), out int idKolam)
        || !int.TryParse(CBIkan.SelectedValue.ToString(), out int idIkan))
            {
                labelIkan.Text = "0";
                return;
            }

            TampilkanSisaIkan(idKolam, idIkan);
        }
    }
}
