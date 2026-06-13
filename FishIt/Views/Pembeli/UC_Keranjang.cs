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
    public partial class UC_Keranjang : UserControl
    {
        public UC_Keranjang()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
        }

        private void UC_Keranjang_Load(object sender, EventArgs e)
        {
            MuatDataKeranjang();

            CBMetodePembayaran.Items.Clear();
            CBMetodePembayaran.Items.Add("Cash");
            CBMetodePembayaran.Items.Add("QRIS");
            CBMetodePembayaran.DropDownStyle = ComboBoxStyle.DropDownList;

            CBMetodePembayaran.SelectedIndex = 0;
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void MuatDataKeranjang()
        {
            if (Session.IdAkun <= 0)
            {
                MessageBox.Show("Sesi pengguna tidak valid. Silakan login kembali.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = @"SELECT k.id_keranjang, i.nama_ikan, k.kuantitas, i.harga_per_kg, (k.kuantitas * i.harga_per_kg) AS subtotal 
                             FROM keranjang k 
                             JOIN ikan i ON k.id_ikan = i.id_ikan 
                             WHERE k.id_akun = @id_akun";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            DGVKeranjang.DataSource = dt;
                            DGVKeranjang.Columns["id_keranjang"].Visible = false;
                            DGVKeranjang.Columns["nama_ikan"].HeaderText = "Nama Ikan";
                            DGVKeranjang.Columns["kuantitas"].HeaderText = "Kuantitas";
                            DGVKeranjang.Columns["harga_per_kg"].HeaderText = "Harga Per Kg";
                            DGVKeranjang.Columns["subtotal"].HeaderText = "Subtotal";

                            GridHelper.AturTemaModern(DGVKeranjang);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data keranjang: " + ex.Message);
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (CBMetodePembayaran.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih metode pembayaran terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idMetodePembayaran = 1;
            if (CBMetodePembayaran.SelectedItem.ToString() == "QRIS")
            {
                idMetodePembayaran = 2;
            }
            bool isSuksesDatabase = false;

            using (var conn = new NpgsqlConnection(FormTambahAkun.Config.ConnString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        decimal totalHarga = 0;
                        string queryTotal = "SELECT SUM(k.kuantitas * i.harga_per_kg) FROM keranjang k JOIN ikan i ON k.id_ikan = i.id_ikan WHERE k.id_akun = @id_akun";
                        using (var cmdTotal = new NpgsqlCommand(queryTotal, conn))
                        {
                            cmdTotal.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            object res = cmdTotal.ExecuteScalar();
                            totalHarga = res != DBNull.Value ? Convert.ToDecimal(res) : 0;
                        }

                        if (totalHarga == 0)
                        {
                            MessageBox.Show("Keranjang belanja Anda masih kosong!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int idOrderBaru = 0;
                        string queryOrder = @"INSERT INTO orders (tanggal_order, total_harga, id_akun, id_metode_pembayaran, id_status_pembayaran, status_pembayaran, status_order) 
                                      VALUES (CURRENT_DATE, @total, @id_akun, @id_metode, 1, 'Pending Kasir', 'Menunggu Pembayaran') 
                                      RETURNING id_order";
                        using (var cmdOrder = new NpgsqlCommand(queryOrder, conn))
                        {
                            cmdOrder.Parameters.AddWithValue("@total", totalHarga);
                            cmdOrder.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmdOrder.Parameters.AddWithValue("@id_metode", idMetodePembayaran);
                            idOrderBaru = Convert.ToInt32(cmdOrder.ExecuteScalar());
                        }

                        string queryDetail = @"INSERT INTO detail_order (kuantitas, harga, id_ikan, id_order)
                                       SELECT k.kuantitas, i.harga_per_kg, k.id_ikan, @id_order
                                       FROM keranjang k
                                       JOIN ikan i ON k.id_ikan = i.id_ikan
                                       WHERE k.id_akun = @id_akun";
                        using (var cmdDetail = new NpgsqlCommand(queryDetail, conn))
                        {
                            cmdDetail.Parameters.AddWithValue("@id_order", idOrderBaru);
                            cmdDetail.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmdDetail.ExecuteNonQuery();
                        }

                        string queryHapus = "DELETE FROM keranjang WHERE id_akun = @id_akun";
                        using (var cmdHapus = new NpgsqlCommand(queryHapus, conn))
                        {
                            cmdHapus.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmdHapus.ExecuteNonQuery();
                        }

                        tx.Commit();
                        // WAJIB ADA: Ubah penanda sukses agar UI di bawah bisa jalan
                        isSuksesDatabase = true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Database Gagal: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // --- BLOK TAMPILAN / UI ---
            if (isSuksesDatabase)
            {
                MessageBox.Show("Checkout Berhasil! Antrean telah dikirim ke Kasir.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    Form FormInduk = this.FindForm();
                    Panel pnlKonten = (Panel)FormInduk.Controls.Find("panelKontenPembeli", true)[0];
                    PanelHelper.ShowUserControl(pnlKonten, new UC_RIwayatPembeli());
                }
                catch (Exception exUI)
                {
                    MessageBox.Show("Gagal membuka halaman riwayat secara otomatis: " + exUI.Message, "Eror Tampilan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void DGVKeranjang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Memastikan baris yang diklik adalah baris data yang valid (bukan header)
            if (e.RowIndex >= 0)
            {
                // Ambil data dari baris yang diklik
                DataGridViewRow row = DGVKeranjang.Rows[e.RowIndex];
                int idKeranjang = Convert.ToInt32(row.Cells["id_keranjang"].Value);
                string namaIkan = row.Cells["nama_ikan"].Value.ToString();

                // Tampilkan pop-up konfirmasi hapus
                DialogResult result = MessageBox.Show($"Apakah Anda yakin ingin menghapus '{namaIkan}' dari keranjang?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

                // Jika user memilih 'Yes', jalankan proses hapus ke database
                if (result == DialogResult.Yes)
                {
                    HapusItemKeranjang(idKeranjang);
                }
            }
        }
        private void HapusItemKeranjang(int idKeranjang)
        {
            string queryHapus = "DELETE FROM keranjang WHERE id_keranjang = @id_keranjang";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(queryHapus, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_keranjang", idKeranjang);
                        cmd.ExecuteNonQuery();
                    }

                    // Beri feedback sukses dan muat ulang data di Grid
                    MessageBox.Show("Item berhasil dihapus dari keranjang.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatDataKeranjang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menghapus item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CBMetodePembayaran_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
