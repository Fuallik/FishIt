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
    public partial class UC_DetailVerifikasi : UserControl
    {
        private int idPengajuanTerpilih = 0;
        private int idIkanTerpilih = 0;
        public UC_DetailVerifikasi(int idPengajuan, int kuantitas, string tipe, string tanggalKirim, string statusVerifikasi, string tanggalVerifikasi, string namaSupplier)
        {
            InitializeComponent();
            idPengajuanTerpilih = idPengajuan;

            TBIdPengajuan.Text = idPengajuan.ToString();
            TBSupplier.Text = namaSupplier;
            TBKuantitas.Text = kuantitas.ToString();
            TBTipe.Text = tipe;
            TBTglKirim.Text = tanggalKirim;
            TBStatus.Text = statusVerifikasi;
            TBTglVerifikasi.Text = tanggalVerifikasi;
        }

        private void UC_DetailVerifikasi_Load(object sender, EventArgs e)
        {

        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void btnACC_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show($"ACC pasokan ikan '{TBNamaIkan.Text}' sebanyak {TBKuantitas.Text} Kg?",
                                         "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                using (var conn = new NpgsqlConnection(Config.ConnString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Update status pengajuan_supplier menjadi Disetujui
                            string queryUpdate = "UPDATE pengajuan_supplier SET status_verifikasi = 'Disetujui' WHERE id_pengajuan = @id";
                            using (var cmd = new NpgsqlCommand(queryUpdate, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idPengajuanTerpilih);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Tambah stok ikan di tabel master (Gunakan InvariantCulture agar pecahan koma dari TextBox aman)
                            decimal jumlahTambah = Convert.ToDecimal(TBKuantitas.Text, System.Globalization.CultureInfo.InvariantCulture);
                            string queryStok = "UPDATE ikan SET stok_ikan = stok_ikan + @qty WHERE id_ikan = @id_i";
                            using (var cmdStok = new NpgsqlCommand(queryStok, conn))
                            {
                                cmdStok.Parameters.AddWithValue("@qty", jumlahTambah);
                                cmdStok.Parameters.AddWithValue("@id_i", idIkanTerpilih);
                                cmdStok.ExecuteNonQuery();
                            }

                            tx.Commit();
                            MessageBox.Show("Pengajuan supply BERHASIL DISETUJUI dan stok bertambah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KembaliKeMenuUtama();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            MessageBox.Show("Gagal memproses ACC: " + ex.Message, "Error Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show($"Apakah Anda yakin ingin menolak & mengarsipkan pengajuan ID {idPengajuanTerpilih}?",
                                         "Konfirmasi Soft Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                // Soft Delete: Ubah status jadi Ditolak dan is_deleted jadi TRUE
                string query = @"UPDATE pengajuan_supply 
                                 SET status_verifikasi = 'Ditolak' WHERE id_pengajuan = @id";

                using (var conn = new NpgsqlConnection(Config.ConnString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idPengajuanTerpilih);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pengajuan supply berhasil ditolak dan diarsipkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        KembaliKeMenuUtama();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal melakukan soft delete: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            KembaliKeMenuUtama();
        }
        private void KembaliKeMenuUtama()
        {
            Form FormInduk = this.FindForm();
            Panel pnlKonten = (Panel)FormInduk.Controls.Find("panelKontenAdmin", true)[0]; // Sesuaikan nama panel adminmu
            PanelHelper.ShowUserControl(pnlKonten, new UC_VerifikasiSupply()); // Balik ke halaman utama yang ada DataGridView-nya
        }

        private void TBSupplier_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

