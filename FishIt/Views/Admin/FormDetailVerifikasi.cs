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
    public partial class FormDetailVerifikasi : Form
    {
        private int idPengajuanTerpilih = 0;
        private int idBenihTerpilih = 0;
        private int idPakanTerpilih = 0;
        public FormDetailVerifikasi(int idPengajuan, int idBenih, int idPakan, string namaBarang, int kuantitas, string tipe, string tanggalKirim, string statusVerifikasi, string tanggalVerifikasi, string namaSupplier)
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
                // Cukup Update statusnya saja, sisanya serahkan ke Trigger PostgreSQL!
                string queryUpdate = @"UPDATE pengiriman_supplier 
                               SET status_verifikasi = 'Disetujui', tanggal_verifikasi = CURRENT_DATE 
                               WHERE id_pengiriman_supplier = @id";

                using (var conn = new NpgsqlConnection(Config.ConnString)) // Menggunakan config universal
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(queryUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", idPengajuanTerpilih);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pengajuan supply BERHASIL DISETUJUI dan stok master bertambah otomatis!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memproses ACC: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

