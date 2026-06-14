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
    public partial class UC_KonfirmasiPembayaran : UserControl
    {
        private int idOrderTerpilih = 0;

        public UC_KonfirmasiPembayaran()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVAntrean);
            PanelHelper.BuatMelengkung(panel6, 20);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatAntrean();
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void MuatAntrean()
        {
            string query = @"
        SELECT o.id_order              AS ""ID"",
               a.nama                   AS ""Pembeli"",
               o.tanggal_order          AS ""Tanggal"",
               o.total_harga            AS ""Total"",
               m.jenis_metode_pembayaran AS ""Metode""
        FROM orders o
        JOIN akun a ON a.id_akun = o.id_akun
        JOIN metode_pembayaran m ON m.id_metode_pembayaran = o.id_metode_pembayaran
        WHERE o.id_status_pembayaran = 1     -- belum dikonfirmasi
        ORDER BY o.id_order ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVAntrean.DataSource = tabel;       // ganti nama DGV sesuai Designer-mu

                    GridHelper.AturTemaModern(DGVAntrean);
                    // kolom ID disembunyikan, dipakai logika bukan dilihat
                    if (DGVAntrean.Columns.Contains("ID"))
                        DGVAntrean.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat antrean: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TampilkanItem(int idOrder)
        {
            string query = @"
        SELECT i.nama_ikan          AS ""Nama Ikan"",
               d.kuantitas          AS ""Jumlah (kg)"",
               d.harga              AS ""Harga/kg"",
               ROUND((d.kuantitas * d.harga)::numeric, 2) AS ""Subtotal""
        FROM detail_order d
        JOIN ikan i ON i.id_ikan = d.id_ikan
        WHERE d.id_order = @id_order";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_order", idOrder);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVDetail.DataSource = tabel;
                    GridHelper.AturTemaModern(DGVDetail);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat item: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonKonfirmasi_Click(object sender, EventArgs e)
        {
            if (idOrderTerpilih == 0)
            {
                MessageBox.Show("Pilih order di antrean dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var konfirmasi = MessageBox.Show($"Konfirmasi pembayaran untuk order #{idOrderTerpilih}?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi != DialogResult.Yes) return;

            // QUERY BARU: 
            // 1. UPDATE status pesanan menjadi Lunas (2)
            // 2. INSERT otomatis ke tabel pengiriman. 
            // Menggunakan SELECT ... FROM akun WHERE id_role = 4 untuk mencari Shipper otomatis.
            string query = @"
                            UPDATE orders
                            SET id_status_pembayaran = 2,
                                status_order = 'Diproses'
                            WHERE id_order = @id AND id_status_pembayaran = 1;

                            UPDATE ikan
                            SET stok_ikan = stok_ikan - sub.total_kg
                            FROM (
                                SELECT id_ikan, SUM(kuantitas) AS total_kg
                                FROM detail_order
                                WHERE id_order = @id
                                GROUP BY id_ikan
                            ) sub
                            WHERE ikan.id_ikan = sub.id_ikan;

                            INSERT INTO pengiriman (tanggal_pengiriman, status_pengiriman, id_akun, id_order)
                            SELECT CURRENT_DATE, 'Diproses', id_akun, @id
                            FROM akun
                            WHERE id_role = 4 AND aktif = true
                            LIMIT 1;
                        ";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idOrderTerpilih);

                    // ExecuteNonQuery akan mengembalikan jumlah baris yang berubah (Update + Insert)
                    int baris = cmd.ExecuteNonQuery();

                    if (baris > 0)
                    {
                        MessageBox.Show("Pembayaran dikonfirmasi (Lunas) & Pesanan otomatis diteruskan ke Shipper!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        idOrderTerpilih = 0;
                        labelTotal.Text = "0";
                        DGVDetail.DataSource = null;   // kosongkan panel item
                        MuatAntrean();                 // refresh antrean
                    }
                    else
                    {
                        MessageBox.Show("Order sudah dikonfirmasi sebelumnya atau tidak ditemukan. Coba refresh.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal konfirmasi: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DGVAntrean_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // klik header diabaikan

            idOrderTerpilih = Convert.ToInt32(DGVAntrean.Rows[e.RowIndex].Cells["ID"].Value);

            // kartu Total ambil dari kolom "Total" baris itu
            labelTotal.Text = DGVAntrean.Rows[e.RowIndex].Cells["Total"].Value.ToString();

            TampilkanItem(idOrderTerpilih);
        }
    }
}
