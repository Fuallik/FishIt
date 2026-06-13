using FishIt.Helpers;
using FishIt.Views.Admin;   // untuk form tambah/hapus kolam, yang belum dibuat
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
    public partial class UC_DataKolam : UserControl
    {
        public UC_DataKolam()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVKolam);   // ganti nama DGV sesuai Designer-mu
        }

        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

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

        // ---- GRID: semua kolam + nama jenis ikannya ----
        private void MuatGrid()
        {
            // JOIN ke jenis_ikan supaya yang tampil nama jenis, bukan angka id
            string query = @"
                SELECT k.id_kolam        AS ""ID"",
                       k.nomor            AS ""Nomor"",
                       k.ukuran           AS ""Ukuran"",
                       k.kapasitas        AS ""Kapasitas"",
                       k.status_kolam     AS ""Status"",
                       j.nama_jenis_ikan  AS ""Jenis Ikan""
                FROM kolam k
                JOIN jenis_ikan j ON j.id_jenis_ikan = k.id_jenis_ikan
                ORDER BY k.nomor ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand(query, conn);
                    using var adapter = new NpgsqlDataAdapter(cmd);
                    var tabel = new DataTable();
                    adapter.Fill(tabel);
                    DGVKolam.DataSource = tabel;

                    GridHelper.AturTemaModern(DGVKolam);
                    if (DGVKolam.Columns.Contains("ID"))
                        DGVKolam.Columns["ID"].Visible = false;   // id disembunyikan
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data kolam: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- KARTU: total kolam di database ----
        private void MuatKartu()
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM kolam", conn);
                    long total = (long)cmd.ExecuteScalar();   // COUNT(*) = bigint -> long
                    labelKolam.Text = total.ToString();   // ganti nama label
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat ringkasan: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- TOMBOL: buka form lalu refresh ----
        private void btnTambah_Click(object sender, EventArgs e)
        {
            FormTambahKolam form = new FormTambahKolam();   // form ini BELUM ADA, perlu dibuat
            if (form.ShowDialog() == DialogResult.OK)
                MuatData();   // refresh kalau ada kolam baru ditambah
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            FormHapusKolam form = new FormHapusKolam();      // form ini BELUM ADA, perlu dibuat
            if (form.ShowDialog() == DialogResult.OK)
                MuatData();
        }
    }
}
