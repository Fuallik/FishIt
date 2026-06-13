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
    public partial class FormTambahPemberianPakan : Form
    {
        public FormTambahPemberianPakan()
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
            using (var conn = new NpgsqlConnection(Config.ConnString))

                try
                {
                    conn.Open();

                    var dtKolam = new DataTable();
                    using (var ad = new NpgsqlDataAdapter(
                        @"SELECT k.id_kolam, k.nomor
                          FROM kolam k
                          WHERE
                              COALESCE((SELECT SUM(jumlah_ekor) FROM penebaran WHERE id_kolam = k.id_kolam), 0)
                            - COALESCE((SELECT SUM(jumlah_ekor) FROM panen     WHERE id_kolam = k.id_kolam), 0)
                              > 0
                          ORDER BY k.nomor", conn))
                        ad.Fill(dtKolam);
                    CBKolam.DataSource = dtKolam;
                    CBKolam.DisplayMember = "nomor";
                    CBKolam.ValueMember = "id_kolam";
                    CBKolam.SelectedIndex = -1;

                    var dtPakan = new DataTable();
                    using (var ad = new NpgsqlDataAdapter(
                        "SELECT id_pakan, nama FROM pakan WHERE jumlah_stok > 0 ORDER BY nama", conn))
                        ad.Fill(dtPakan);
                    CBPakan.DataSource = dtPakan;
                    CBPakan.DisplayMember = "nama";
                    CBPakan.ValueMember = "id_pakan";
                    CBPakan.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat dropdown: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBPakan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kolam dan pakan dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (NUBJumlahPakan.Value <= 0)
            {
                MessageBox.Show("Jumlah pakan harus lebih dari 0!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var conn = new NpgsqlConnection(Config.ConnString);
            conn.Open();

            using var tx = conn.BeginTransaction();
            try
            {
                int idPakan = Convert.ToInt32(CBPakan.SelectedValue);
                int idKolam = Convert.ToInt32(CBKolam.SelectedValue);
                decimal jumlah = NUBJumlahPakan.Value;

                decimal stok;
                using (var cmdCek = new NpgsqlCommand(
                    "SELECT jumlah_stok FROM pakan WHERE id_pakan=@id FOR UPDATE", conn, tx))
                {
                    cmdCek.Parameters.AddWithValue("@id", idPakan);
                    stok = Convert.ToDecimal(cmdCek.ExecuteScalar());
                }

                if (jumlah > stok)
                {
                    MessageBox.Show($"Stok pakan tidak cukup! Sisa stok: {stok:N2} kg",
                        "Stok Kurang", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tx.Rollback();
                    return;
                }

                using (var cmdInsert = new NpgsqlCommand(@"
                    INSERT INTO pemberian_pakan (tanggal, jumlah_kg, id_akun, id_pakan, id_kolam)
                    VALUES (CURRENT_DATE, @jumlah, @akun, @pakan, @kolam)", conn, tx))
                {
                    cmdInsert.Parameters.AddWithValue("@jumlah", jumlah);
                    cmdInsert.Parameters.AddWithValue("@akun", Session.IdAkun);
                    cmdInsert.Parameters.AddWithValue("@pakan", idPakan);
                    cmdInsert.Parameters.AddWithValue("@kolam", idKolam);
                    cmdInsert.ExecuteNonQuery();
                }

                using (var cmdUpdate = new NpgsqlCommand(
                    "UPDATE pakan SET jumlah_stok = jumlah_stok - @jumlah WHERE id_pakan=@id", conn, tx))
                {
                    cmdUpdate.Parameters.AddWithValue("@jumlah", jumlah);
                    cmdUpdate.Parameters.AddWithValue("@id", idPakan);
                    cmdUpdate.ExecuteNonQuery();
                }

                tx.Commit();

                MessageBox.Show("Pemberian pakan dicatat & stok diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("Transaksi gagal, semua perubahan dibatalkan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBPakan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPakan.SelectedIndex == -1)
            {
                labelStokPakan.Text = "";
                return;
            }

            using (var conn = new NpgsqlConnection(Config.ConnString))

            try
            {
                
                conn.Open();

                using var cmd = new NpgsqlCommand(
                    "SELECT jumlah_stok FROM pakan WHERE id_pakan=@id", conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(CBPakan.SelectedValue));

                decimal stok = Convert.ToDecimal(cmd.ExecuteScalar());
                labelStokPakan.Text = $" {stok:N2} kg";
            }
            catch (Exception ex)
            {
                labelStokPakan.Text = "Gagal ambil stok";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
