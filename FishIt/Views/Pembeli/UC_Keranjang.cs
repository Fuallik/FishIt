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

            // Tentukan ID Metode Pembayaran
            int idMetodePembayaran = CBMetodePembayaran.SelectedItem.ToString() == "QRIS" ? 2 : 1;

            bool isSuksesDatabase = false;
            string pesanResult = "Gagal memproses transaksi.";

            // Query untuk memanggil function kita di PostgreSQL
            string queryFunc = "SELECT * FROM public.proses_checkout_func(@id_akun, @id_metode)";

            using (var conn = new NpgsqlConnection(FormLogin.Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(queryFunc, conn))
                    {
                        // Daftarkan parameter input seperti biasa
                        cmd.Parameters.Add("@id_akun", NpgsqlTypes.NpgsqlDbType.Integer).Value = Session.IdAkun;
                        cmd.Parameters.Add("@id_metode", NpgsqlTypes.NpgsqlDbType.Integer).Value = idMetodePembayaran;

                        // Jalankan perintah dan baca baris hasilnya
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Ambil kolom ke-0 (is_sukses) dan kolom ke-1 (pesan) dari hasil function
                                isSuksesDatabase = reader.GetBoolean(0);
                                pesanResult = reader.GetString(1);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Koneksi Database Gagal: " + ex.Message, "Error Kontroler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // --- BLOK UI TAMPILAN ---
            if (isSuksesDatabase)
            {
                MessageBox.Show(pesanResult, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                // Menampilkan pesan gagal yang dikirimkan langsung dari logic PostgreSQL (misal: keranjang kosong)
                MessageBox.Show(pesanResult, "Gagal Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
