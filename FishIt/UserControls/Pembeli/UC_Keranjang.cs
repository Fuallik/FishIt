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
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void MuatDataKeranjang()
        {
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
                            DGVKeranjang.Columns["id_keranjang"].HeaderText = "ID Keranjang";
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
                        string queryOrder = @"INSERT INTO orders (tanggal_order, total_harga, id_akun, id_metode_pembayaran, id_status_pembayaran) 
                                              VALUES (CURRENT_DATE, @total, @id_akun, 1, 1) 
                                              RETURNING id_order";
                        using (var cmdOrder = new NpgsqlCommand(queryOrder, conn))
                        {
                            cmdOrder.Parameters.AddWithValue("@total", totalHarga);
                            cmdOrder.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            idOrderBaru = Convert.ToInt32(cmdOrder.ExecuteScalar());
                        }

                        // 3. Masuk ke detail_order
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

                        // 4. Bersihkan keranjang sementara
                        string queryHapus = "DELETE FROM keranjang WHERE id_akun = @id_akun";
                        using (var cmdHapus = new NpgsqlCommand(queryHapus, conn))
                        {
                            cmdHapus.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmdHapus.ExecuteNonQuery();
                        }

                        tx.Commit();
                        MessageBox.Show("Checkout Berhasil! Antrean telah dikirim ke Kasir.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // TRICK UX: Setelah sukses checkout, otomatis alihkan panel konten utama ke halaman Riwayat
                        Form FormInduk = this.FindForm();
                        Panel pnlKonten = (Panel)FormInduk.Controls.Find("panelKontenPembeli", true)[0];

                        PanelHelper.ShowUserControl(pnlKonten, new UC_RIwayatPembeli());
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback(); // Hanya jalan kalau query SQL di atas ada yang gagal
                        MessageBox.Show("Database Gagal: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Langsung keluar, jangan lanjut ke UI bawah
                    }
                }
            }
            if (isSuksesDatabase)
            {
                MessageBox.Show("Checkout Berhasil! Antrean telah dikirim ke Kasir.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    Form FormInduk = this.FindForm();
                    // TIPS: Pastikan nama "panelKontenPembeli" ini sama persis dengan (Name) panel di Form Utama kamu!
                    Panel pnlKonten = (Panel)FormInduk.Controls.Find("panelKontenPembeli", true)[0];

                    PanelHelper.ShowUserControl(pnlKonten, new UC_RIwayatPembeli());
                }
                catch (Exception exUI)
                {
                    // Jika eror, yang eror cuma perpindahan halaman visualnya saja, databasemu tetap aman!
                    MessageBox.Show("Gagal membuka halaman riwayat secara otomatis: " + exUI.Message, "Eror Tampilan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

    }
}
