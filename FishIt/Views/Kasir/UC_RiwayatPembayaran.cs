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
            // Mencari orders dengan id_status_pembayaran = 2 (Selesai)
            string query = @"SELECT o.id_order, o.tanggal_order, a.nama AS nama_pembeli, o.total_harga, o.status_order
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
                        if (DGVRiwayat.Columns["status_order"] != null) DGVRiwayat.Columns["status_order"].HeaderText = "Status";
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
                labelTotal.Text = "Rp " + totalHarga.ToString("N0");

                // Ambil rincian item ikan untuk order ini
                LoadDetailRiwayat(idOrderTerpilih);
            }
        }

        // 3. AMBIL DATA RINCIAN ITEM IKAN YANG SUDAH DIBELI
        private void LoadDetailRiwayat(int idOrder)
        {
            string query = @"SELECT i.nama_ikan, d.kuantitas, d.harga, (d.kuantitas * d.harga) AS subtotal
                             FROM detail_order d
                             JOIN ikan i ON d.id_ikan = i.id_ikan
                             WHERE d.id_order = @id_order";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_order", idOrder);
                        using (var da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            DGVDetail.DataSource = dt;

                            // Opsional: Merapikan header kolom tabel rincian
                            if (DGVDetail.Columns["nama_ikan"] != null) DGVDetail.Columns["nama_ikan"].HeaderText = "Nama Ikan";
                            if (DGVDetail.Columns["kuantitas"] != null) DGVDetail.Columns["kuantitas"].HeaderText = "Jumlah (Kg)";
                            if (DGVDetail.Columns["harga"] != null) DGVDetail.Columns["harga"].HeaderText = "Harga Satuan";
                            if (DGVDetail.Columns["subtotal"] != null) DGVDetail.Columns["subtotal"].HeaderText = "Subtotal";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat rincian barang: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
