using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_PengajuanPakan : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_PengajuanPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
        }

        private void UC_PengajuanPakan_Load(object sender, EventArgs e)
        {
            MuatComboPakan();
            MuatRiwayatPengajuan();
        }

        private void MuatComboPakan()
        {
            cmbPakan.Items.Clear();
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT nama FROM pakan ORDER BY nama", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbPakan.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat pakan: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MuatRiwayatPengajuan()
        {
            string query = @"
                SELECT  ps.id_pengiriman_supplier  AS ""ID"",
                        p.nama                       AS ""Pakan"",
                        ps.kuantitas                 AS ""Kuantitas"",
                        ps.tanggal_kirim             AS ""Tgl Ajukan"",
                        ps.status_verifikasi         AS ""Status""
                FROM pengiriman_supplier ps
                JOIN pakan p ON p.id_pakan = ps.id_pakan
                WHERE ps.id_akun = @id_akun
                  AND ps.tipe = 'Pakan'
                ORDER BY ps.tanggal_kirim DESC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            var tabel = new DataTable();
                            adapter.Fill(tabel);
                            DGVPengajuan.DataSource = tabel;
                        }
                    }
                    if (DGVPengajuan.Columns.Contains("ID"))
                        DGVPengajuan.Columns["ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAjukan_Click(object sender, EventArgs e)
        {
            string namaPakan = cmbPakan.Text.Trim();
            string kuantitasStr = txtKuantitas.Text.Trim();

            if (string.IsNullOrEmpty(namaPakan) || string.IsNullOrEmpty(kuantitasStr))
            {
                MessageBox.Show("Nama pakan dan kuantitas wajib diisi.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(kuantitasStr, out decimal kuantitas) || kuantitas <= 0)
            {
                MessageBox.Show("Kuantitas harus berupa angka lebih dari 0.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        int idPakan = AmbilAtauBuatPakan(conn, tx, namaPakan);

                        string sqlPengajuan = @"
                            INSERT INTO pengiriman_supplier
                                (tanggal_kirim, tipe, kuantitas, status_verifikasi, id_akun, id_benih, id_pakan, nama)
                            VALUES
                                (CURRENT_DATE, 'Pakan', @kuantitas, 'Pending', @id_akun, NULL, @id_pakan, @nama)";
                        using (var cmd = new NpgsqlCommand(sqlPengajuan, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                            cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmd.Parameters.AddWithValue("@id_pakan", idPakan);
                            cmd.Parameters.AddWithValue("@nama", namaPakan);  // isi kolom 'nama' (NOT NULL) dgn nama pakan
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();

                        MessageBox.Show("Pengajuan pakan berhasil dikirim!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtKuantitas.Clear();
                        MuatComboPakan();
                        MuatRiwayatPengajuan();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Pengajuan gagal, semua perubahan dibatalkan.\n\nDetail: " + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int AmbilAtauBuatPakan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_pakan FROM pakan WHERE LOWER(nama) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                    return Convert.ToInt32(hasil);
            }

            using (var cmd = new NpgsqlCommand(
                "INSERT INTO pakan (nama, jumlah_stok) VALUES (@nama, 0) RETURNING id_pakan", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}