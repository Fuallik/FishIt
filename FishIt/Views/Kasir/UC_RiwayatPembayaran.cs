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

namespace FishIt.Views.Kasir
{
    public partial class UC_RiwayatPembayaran : UserControl
    {
        private int idOrderTerpilih = 0;

        public UC_RiwayatPembayaran()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVDetail);
            GridHelper.AturTemaModern(DGVRiwayat);
            PanelHelper.BuatMelengkung(panel1, 20);
            PanelHelper.BuatMelengkung(panel6, 20);
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void UC_RiwayatPembayaran_Load(object sender, EventArgs e)
        {
            LoadRiwayatPembayaran();
        }

        // 1. TAMPILKAN SEMUA ORDER YANG STATUSNYA SELESAI / LUNAS
        private void LoadRiwayatPembayaran()
        {
            // HAPUS o.status_order DARI SELECT
            string query = @"SELECT o.id_order, o.tanggal_order, a.nama AS nama_pembeli, o.total_harga
                             FROM orders o
                             JOIN akun a ON o.id_akun = a.id_akun
                             WHERE o.id_status_pembayaran = 2
                             ORDER BY o.tanggal_order DESC, o.id_order DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DGVRiwayat.DataSource = dt;

                        // Opsional: Merapikan header kolom tabel utama
                        if (DGVRiwayat.Columns["id_order"] != null) DGVRiwayat.Columns["id_order"].HeaderText = "ID Order";
                        if (DGVRiwayat.Columns["tanggal_order"] != null) DGVRiwayat.Columns["tanggal_order"].HeaderText = "Tanggal Transaksi";
                        if (DGVRiwayat.Columns["nama_pembeli"] != null) DGVRiwayat.Columns["nama_pembeli"].HeaderText = "Nama Pembeli";
                        if (DGVRiwayat.Columns["total_harga"] != null) DGVRiwayat.Columns["total_harga"].HeaderText = "Total Bayar";
                        
                        // BARIS PENGATURAN HEADER STATUS DIHAPUS
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat pembayaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 2. KETIKA KASIR KLIK SALAH SATU BARIS RIWAYAT
        private void DGVRiwayat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil ID Order dan Total Harga dari baris yang diklik
                idOrderTerpilih = Convert.ToInt32(DGVRiwayat.Rows[e.RowIndex].Cells["id_order"].Value);
                decimal totalHarga = Convert.ToDecimal(DGVRiwayat.Rows[e.RowIndex].Cells["total_harga"].Value);

                // Update teks label total dengan format Rupiah
                labelTotal.Text = "Rp " + totalHarga.ToString("N2");

                // Ambil rincian item ikan untuk order ini
                LoadDetailRiwayat(idOrderTerpilih);
            }
        }

        // 3. AMBIL DATA RINCIAN ITEM IKAN YANG SUDAH DIBELI
        private void LoadDetailRiwayat(int idOrder)
        {
            // Query mengambil daftar ikan, kuantitas, harga, dan subtotal dari detail_order
            string query = @"
                    SELECT 
                    i.nama_ikan AS ""Nama Ikan"",
                    d.kuantitas AS ""Jumlah (kg)"",
                    d.harga AS ""Harga/kg"",
                    ROUND((d.kuantitas * d.harga)::numeric, 2) AS ""Subtotal""
                FROM detail_order d
                JOIN ikan i ON i.id_ikan = d.id_ikan
                WHERE d.id_order = @id_order;";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        // Masukkan parameter ID order yang dipilih
                        cmd.Parameters.AddWithValue("@id_order", idOrder);

                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // PENTING: Masukkan data ke DGVDetail, bukan DGVRiwayat
                            DGVDetail.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat detail pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
