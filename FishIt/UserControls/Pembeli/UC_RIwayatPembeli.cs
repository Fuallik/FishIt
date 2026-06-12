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
    public partial class UC_RIwayatPembeli : UserControl
    {
        public UC_RIwayatPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
        }
        
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        private void UC_RIwayatPembeli_Load(object sender, EventArgs e)
        {
            MuatRiwayat();
        }
        private void MuatRiwayat()
        {
            string query = @"SELECT o.id_order, o.tanggal_order, o.total_harga, s.nama_status, m.jenis_metode_pembayaran
                             FROM orders o
                             JOIN status_pembayaran s ON o.id_status_pembayaran = s.id_status_pembayaran
                             JOIN metode_pembayaran m ON o.id_metode_pembayaran = m.id_metode_pembayaran
                             WHERE o.id_akun = @id_akun
                             ORDER BY o.id_order DESC";

            using (var conn = new NpgsqlConnection(FormTambahAkun.Config.ConnString))
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
                            DGVRiwayatPembeli.DataSource = dt;
                            DGVRiwayatPembeli.Columns["id_order"].HeaderText = "ID Order";
                            DGVRiwayatPembeli.Columns["tanggal_order"].HeaderText = "Tanggal Order";
                            DGVRiwayatPembeli.Columns["total_harga"].HeaderText = "Total Harga";
                            DGVRiwayatPembeli.Columns["nama_status"].HeaderText = "Status Order";
                            DGVRiwayatPembeli.Columns["jenis_metode_pembayaran"].HeaderText = "Metode Pembayaran";

                            GridHelper.AturTemaModern(DGVRiwayatPembeli);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message);
                }
            }
        }
    }
}
