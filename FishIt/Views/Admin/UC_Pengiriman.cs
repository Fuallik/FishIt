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
    public partial class UC_Pengiriman : UserControl
    {
        public UC_Pengiriman()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVPengiriman);   // ganti nama DGV sesuai Designer-mu
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        // OnLoad selalu kepicu saat UC tampil (lebih aman daripada andalkan event Load yang harus di-wire)
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MuatData();
        }

        private void MuatData()
        {
            MuatGrid();
            MuatKartu();
        }

        // ---- GRID: semua pengiriman ----
        private void MuatGrid()
        {
            // akun di-JOIN DUA KALI dengan alias beda:
            //   a       -> shipper (pengiriman.id_akun)
            //   pembeli -> pembeli  (orders.id_akun)
            string query = @"
                SELECT p.id_pengiriman        AS ""ID"",
                       p.id_order             AS ""ID Order"",
                       a.nama                  AS ""Shipper"",
                       pembeli.nama            AS ""Pembeli"",
                       o.total_harga           AS ""Total"",
                       p.tanggal_pengiriman    AS ""Tgl Kirim"",
                       p.tanggal_diterima      AS ""Tgl Diterima"",
                       p.status_pengiriman     AS ""Status""
                FROM pengiriman p
                JOIN akun a       ON a.id_akun = p.id_akun        -- shipper
                JOIN orders o     ON o.id_order = p.id_order
                JOIN akun pembeli ON pembeli.id_akun = o.id_akun  -- pembeli
                ORDER BY p.id_pengiriman DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVPengiriman.DataSource = tabel;

                    GridHelper.AturTemaModern(DGVPengiriman);
                    if (DGVPengiriman.Columns.Contains("ID"))
                        DGVPengiriman.Columns["ID"].Visible = false;   // ID disembunyikan
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data pengiriman: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- KARTU: jumlah per status ----
        private void MuatKartu()
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    labelDiproses.Text = HitungStatus(conn, "Diproses").ToString();   // ganti nama label
                    labelDikirim.Text = HitungStatus(conn, "Dikirim").ToString();
                    labelDiterima.Text = HitungStatus(conn, "Diterima").ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Satu helper dipakai 3 kartu, beda di parameter status
        private int HitungStatus(NpgsqlConnection conn, string status)
        {
            using var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM pengiriman WHERE status_pengiriman = @status", conn);
            cmd.Parameters.AddWithValue("@status", status);
            return Convert.ToInt32(cmd.ExecuteScalar());   // COUNT(*) -> ambil nilai tunggal
        }
    }
}
