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
    public partial class UC_DetailVerifikasi : Form
    {
        private int idPengajuanTerpilih = 0;
        private int idBenihTerpilih = 0;
        private int idPakanTerpilih = 0;
        public UC_DetailVerifikasi(int idPengajuan, int idBenih, int idPakan, string namaBarang, int kuantitas, string tipe, string tanggalKirim, string statusVerifikasi, string tanggalVerifikasi, string namaSupplier)
        {
            InitializeComponent();
            idPengajuanTerpilih = idPengajuan;
            idBenihTerpilih = idBenih;
            idPakanTerpilih = idPakan;

            TBIdPengajuan.Text = idPengajuan.ToString();
            TBSupplier.Text = namaSupplier;
            TBNamaIkan.Text = namaBarang;
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
            var dialog = MessageBox.Show($"ACC pasokan '{TBNamaIkan.Text}' sebanyak {TBKuantitas.Text}?",
                                         "Konfirmasi ACC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                using (var conn = new NpgsqlConnection(Config.ConnString))
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            string queryUpdate = @"UPDATE pengiriman_supplier 
                                                   SET status_verifikasi = 'Disetujui', tanggal_verifikasi = CURRENT_DATE 
                                                   WHERE id_pengiriman_supplier = @id";
                            using (var cmd = new NpgsqlCommand(queryUpdate, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", idPengajuanTerpilih);
                                cmd.ExecuteNonQuery();
                            }

                            decimal jumlahTambah = Convert.ToDecimal(TBKuantitas.Text, System.Globalization.CultureInfo.InvariantCulture);

                            if (idBenihTerpilih > 0)
                            {
                                string queryBenih = "UPDATE benih SET stok_benih = jumlah_stok + @qty WHERE id_benih = @id_b";
                                using (var cmdBenih = new NpgsqlCommand(queryBenih, conn))
                                {
                                    cmdBenih.Parameters.AddWithValue("@qty", jumlahTambah);
                                    cmdBenih.Parameters.AddWithValue("@id_b", idBenihTerpilih);
                                    cmdBenih.ExecuteNonQuery();
                                }
                            }
                            else if (idPakanTerpilih > 0)
                            {
                                string queryPakan = "UPDATE pakan SET stok_pakan = jumlah_stok + @qty WHERE id_pakan = @id_pk";
                                using (var cmdPakan = new NpgsqlCommand(queryPakan, conn))
                                {
                                    cmdPakan.Parameters.AddWithValue("@qty", jumlahTambah);
                                    cmdPakan.Parameters.AddWithValue("@id_pk", idPakanTerpilih);
                                    cmdPakan.ExecuteNonQuery();
                                }
                            }

                            tx.Commit();
                            MessageBox.Show("Pengajuan supply BERHASIL DISETUJUI dan stok master bertambah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
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
            var dialog = MessageBox.Show($"Apakah Anda yakin ingin menolak pengajuan ID {idPengajuanTerpilih}?",
                                         "Konfirmasi Tolak", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string query = @"UPDATE pengiriman_supplier 
                                 SET status_verifikasi = 'Ditolak', tanggal_verifikasi = CURRENT_DATE
                                 WHERE id_pengiriman_supplier = @id";

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

                        MessageBox.Show("Pengajuan supply telah ditolak.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal menolak pengajuan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TBSupplier_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

