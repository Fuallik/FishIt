using Npgsql;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_PengajuanBenih : UserControl
    {
        public static class Config
        {
            public static string ConnString =
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public UC_PengajuanBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
        }

        private void UC_PengajuanBenih_Load(object sender, EventArgs e)
        {
            MuatComboJenisIkan();
            MuatComboBenih();
            MuatRiwayatPengajuan();
        }

        // ====================================================================
        // BAGIAN MUAT DATA UNTUK COMBOBOX (biar supplier bisa PILIH yang sudah ada)
        // ====================================================================

        /// <summary> Isi ComboBox jenis ikan dari tabel jenis_ikan. </summary>
        private void MuatComboJenisIkan()
        {
            cmbJenisIkan.Items.Clear();
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT nama_jenis_ikan FROM jenis_ikan ORDER BY nama_jenis_ikan", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbJenisIkan.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat jenis ikan: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary> Isi ComboBox benih dari tabel benih. </summary>
        private void MuatComboBenih()
        {
            cmbBenih.Items.Clear();
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT nama FROM benih ORDER BY nama", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbBenih.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat benih: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary> Tampilkan daftar pengajuan benih milik supplier yang login. </summary>
        private void MuatRiwayatPengajuan()
        {
            string query = @"
                SELECT  ps.id_pengiriman_supplier  AS ""ID"",
                        b.nama                       AS ""Benih"",
                        ps.kuantitas                 AS ""Kuantitas"",
                        ps.tanggal_kirim             AS ""Tgl Ajukan"",
                        ps.status_verifikasi         AS ""Status""
                FROM pengiriman_supplier ps
                JOIN benih b ON b.id_benih = ps.id_benih
                WHERE ps.id_akun = @id_akun
                  AND ps.tipe = 'Benih'
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

        // ====================================================================
        // BAGIAN INTI: AJUKAN (pakai TRANSACTION karena ada beberapa INSERT
        // yang saling bergantung dan harus "semua berhasil atau semua batal")
        // ====================================================================

        private void btnAjukan_Click(object sender, EventArgs e)
        {
            // --- 1. Validasi input dasar di sisi C# dulu (biar tidak bolak-balik ke DB) ---
            string namaJenis = cmbJenisIkan.Text.Trim();
            string namaBenih = cmbBenih.Text.Trim();
            string kuantitasStr = txtKuantitas.Text.Trim();

            if (string.IsNullOrEmpty(namaJenis) || string.IsNullOrEmpty(namaBenih) || string.IsNullOrEmpty(kuantitasStr))
            {
                MessageBox.Show("Jenis ikan, nama benih, dan kuantitas wajib diisi.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kuantitas harus angka > 0. decimal karena kolomnya numeric(10,2).
            if (!decimal.TryParse(kuantitasStr, out decimal kuantitas) || kuantitas <= 0)
            {
                MessageBox.Show("Kuantitas harus berupa angka lebih dari 0.",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                conn.Open();
                // Transaction dibuka di sisi C#. Semua perintah di bawah memakai transaksi yang sama.
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // --- 2. Cari id_jenis_ikan. Kalau belum ada, INSERT lalu ambil id-nya. ---
                        int idJenis = AmbilAtauBuatJenisIkan(conn, tx, namaJenis);

                        // --- 3. Cari id_benih. Kalau belum ada, INSERT (pakai idJenis di atas). ---
                        int idBenih = AmbilAtauBuatBenih(conn, tx, namaBenih, idJenis);

                        // --- 4. INSERT pengajuan ke pengiriman_supplier ---
                        //     status awal 'Menunggu' (belum diverifikasi admin).
                        string sqlPengajuan = @"
                            INSERT INTO pengiriman_supplier
                                (tanggal_kirim, tipe, kuantitas, status_verifikasi, id_akun, id_benih, id_pakan)
                            VALUES
                                (CURRENT_DATE, 'Benih', @kuantitas, 'Menunggu', @id_akun, @id_benih, NULL)";
                        using (var cmd = new NpgsqlCommand(sqlPengajuan, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                            cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmd.Parameters.AddWithValue("@id_benih", idBenih);
                            cmd.ExecuteNonQuery();
                        }

                        // --- 5. Kalau semua langkah di atas sukses, baru COMMIT (disimpan permanen). ---
                        tx.Commit();

                        MessageBox.Show("Pengajuan benih berhasil dikirim!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Bersihkan form & refresh tampilan
                        txtKuantitas.Clear();
                        MuatComboJenisIkan();
                        MuatComboBenih();
                        MuatRiwayatPengajuan();
                    }
                    catch (Exception ex)
                    {
                        // Kalau ADA SATU SAJA langkah yang gagal, batalkan SEMUANYA.
                        // Jadi tidak ada jenis_ikan/benih "setengah jadi" yang nyangkut tanpa pengajuan.
                        tx.Rollback();
                        MessageBox.Show("Pengajuan gagal, semua perubahan dibatalkan.\n\nDetail: " + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Cari id_jenis_ikan berdasarkan nama. Kalau belum ada, buat baru lalu kembalikan id-nya.
        /// Semua perintah memakai koneksi + transaksi yang sedang berjalan (conn, tx).
        /// </summary>
        private int AmbilAtauBuatJenisIkan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama)
        {
            // Coba cari dulu (case-insensitive biar 'Lele' = 'lele').
            using (var cmd = new NpgsqlCommand(
                "SELECT id_jenis_ikan FROM jenis_ikan WHERE LOWER(nama_jenis_ikan) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                    return Convert.ToInt32(hasil); // sudah ada, pakai yang ini
            }

            // Belum ada -> INSERT baru. RETURNING langsung mengembalikan id yang baru dibuat.
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO jenis_ikan (nama_jenis_ikan) VALUES (@nama) RETURNING id_jenis_ikan", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Cara kerja sama seperti jenis ikan, tapi untuk benih.
        /// Benih baru butuh id_jenis_ikan (FK NOT NULL), makanya idJenis dikirim ke sini.
        /// jumlah_stok diisi 0 dulu karena benih baru belum punya stok masuk.
        /// </summary>
        private int AmbilAtauBuatBenih(NpgsqlConnection conn, NpgsqlTransaction tx, string nama, int idJenis)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_benih FROM benih WHERE LOWER(nama) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                    return Convert.ToInt32(hasil);
            }

            using (var cmd = new NpgsqlCommand(
                @"INSERT INTO benih (nama, jumlah_stok, tanggal_masuk, id_jenis_ikan)
                  VALUES (@nama, 0, CURRENT_DATE, @id_jenis) RETURNING id_benih", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id_jenis", idJenis);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}