using FishIt.Helpers;
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

        // Nilai default untuk ikan yang dibuat otomatis lewat pengajuan benih.
        // Ikan baru ini belum punya harga/stok/kualitas sebenarnya, jadi diberi nilai
        // aman: harga 0, stok 0, kualitas C (id_kualitas = 3, kualitas terendah).
        private const decimal HARGA_DEFAULT = 0;
        private const decimal STOK_DEFAULT = 0;
        private const int ID_KUALITAS_DEFAULT = 3; // 3 = 'C'

        public UC_PengajuanBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
            new AutoScaleHelper(this);
        }

        private void UC_PengajuanBenih_Load(object sender, EventArgs e)
        {
            MuatComboJenisIkan();
            MuatComboNama();
            MuatRiwayatPengajuan();
        }

        // ====================================================================
        // MUAT DATA UNTUK COMBOBOX
        // ====================================================================

        /// <summary> Isi ComboBox jenis ikan (Air Tawar / Laut / Payau). </summary>
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

        /// <summary>
        /// Isi ComboBox "Nama" dari daftar ikan yang sudah ada.
        /// Satu nama dipakai untuk ikan sekaligus benih, jadi sumbernya tabel ikan.
        /// </summary>
        private void MuatComboNama()
        {
            cmbNama.Items.Clear();
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand("SELECT DISTINCT nama_ikan FROM ikan ORDER BY nama_ikan", conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            cmbNama.Items.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat daftar ikan: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Dipanggil saat supplier MEMILIH ikan dari dropdown.
        /// Kalau ikan itu sudah ada di database, jenis airnya diisi otomatis
        /// dan dropdown jenis dikunci -> supplier tidak bisa salah jenis.
        /// Kalau supplier mengetik nama baru, jenis dibuka lagi supaya bisa dipilih.
        /// </summary>
        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nama = cmbNama.Text.Trim();
            if (string.IsNullOrEmpty(nama)) return;

            string query = @"
                SELECT j.nama_jenis_ikan
                FROM ikan i
                JOIN jenis_ikan j ON j.id_jenis_ikan = i.id_jenis_ikan
                WHERE LOWER(i.nama_ikan) = LOWER(@nama)
                LIMIT 1";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        object hasil = cmd.ExecuteScalar();

                        if (hasil != null)
                        {
                            // Ikan sudah ada -> set jenis sesuai data & kunci supaya tak bisa diubah.
                            cmbJenisIkan.SelectedItem = hasil.ToString();
                            cmbJenisIkan.Enabled = false;
                        }
                        else
                        {
                            // Nama baru -> buka lagi biar supplier pilih jenisnya sendiri.
                            cmbJenisIkan.Enabled = true;
                        }
                    }
                }
                catch
                {
                    // Kalau gagal cek, biarkan jenis tetap bisa dipilih manual (jangan blokir supplier).
                    cmbJenisIkan.Enabled = true;
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
        // INTI: AJUKAN (pakai TRANSACTION — beberapa INSERT berantai yang
        // harus "semua berhasil atau semua batal")
        // ====================================================================

        private void btnAjukan_Click(object sender, EventArgs e)
        {
            // --- 1. Validasi input di sisi C# dulu ---
            string namaJenis = cmbJenisIkan.Text.Trim();
            string nama = cmbNama.Text.Trim();          // satu nama: dipakai utk ikan & benih
            string kuantitasStr = txtKuantitas.Text.Trim();

            if (string.IsNullOrEmpty(namaJenis) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kuantitasStr))
            {
                MessageBox.Show("Jenis ikan, nama, dan kuantitas wajib diisi.",
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
                        // --- 2. Jenis ikan: cari, kalau belum ada buat baru ---
                        int idJenis = AmbilAtauBuatJenisIkan(conn, tx, namaJenis);

                        // --- 3. Ikan: cari berdasarkan nama, kalau belum ada buat baru
                        //         dengan nilai default (harga 0, stok 0, kualitas C). ---
                        int idIkan = AmbilAtauBuatIkan(conn, tx, nama, idJenis);

                        // --- 4. Benih: cari berdasarkan nama, kalau belum ada buat baru
                        //         (butuh id_jenis_ikan DAN id_ikan, dua-duanya NOT NULL). ---
                        int idBenih = AmbilAtauBuatBenih(conn, tx, nama, idJenis, idIkan);

                        // --- 5. INSERT pengajuan. status 'Pending', kolom nama diisi nama benih. ---
                        string sqlPengajuan = @"
                            INSERT INTO pengiriman_supplier
                                (tanggal_kirim, tipe, kuantitas, status_verifikasi, id_akun, id_benih, id_pakan, nama)
                            VALUES
                                (CURRENT_DATE, 'Benih', @kuantitas, 'Pending', @id_akun, @id_benih, NULL, @nama)";
                        using (var cmd = new NpgsqlCommand(sqlPengajuan, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                            cmd.Parameters.AddWithValue("@id_akun", Session.IdAkun);
                            cmd.Parameters.AddWithValue("@id_benih", idBenih);
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.ExecuteNonQuery();
                        }

                        // --- 6. Semua sukses -> COMMIT ---
                        tx.Commit();

                        MessageBox.Show("Pengajuan benih berhasil dikirim!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtKuantitas.Clear();
                        cmbJenisIkan.Enabled = true;   // buka lagi kunci jenis setelah selesai
                        cmbNama.SelectedIndex = -1;     // kosongkan pilihan nama
                        MuatComboJenisIkan();
                        MuatComboNama();
                        MuatRiwayatPengajuan();
                    }
                    catch (Exception ex)
                    {
                        // Satu gagal -> batalkan semua. Tidak ada ikan/benih "setengah jadi".
                        tx.Rollback();
                        MessageBox.Show("Pengajuan gagal, semua perubahan dibatalkan.\n\nDetail: " + ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary> Cari id_jenis_ikan dari nama; kalau belum ada, buat baru. </summary>
        private int AmbilAtauBuatJenisIkan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_jenis_ikan FROM jenis_ikan WHERE LOWER(nama_jenis_ikan) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                    return Convert.ToInt32(hasil);
            }

            using (var cmd = new NpgsqlCommand(
                "INSERT INTO jenis_ikan (nama_jenis_ikan) VALUES (@nama) RETURNING id_jenis_ikan", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Cari id_ikan dari nama_ikan; kalau belum ada, buat ikan baru dengan
        /// nilai default (harga 0, stok 0, kualitas C). id_jenis_ikan dari langkah sebelumnya.
        /// </summary>
        private int AmbilAtauBuatIkan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama, int idJenis)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_ikan FROM ikan WHERE LOWER(nama_ikan) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                    return Convert.ToInt32(hasil);
            }

            using (var cmd = new NpgsqlCommand(
                @"INSERT INTO ikan (harga_per_kg, stok_ikan, nama_ikan, id_jenis_ikan, id_kualitas)
                  VALUES (@harga, @stok, @nama, @id_jenis, @id_kualitas) RETURNING id_ikan", conn, tx))
            {
                cmd.Parameters.AddWithValue("@harga", HARGA_DEFAULT);
                cmd.Parameters.AddWithValue("@stok", STOK_DEFAULT);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id_jenis", idJenis);
                cmd.Parameters.AddWithValue("@id_kualitas", ID_KUALITAS_DEFAULT);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Cari id_benih dari nama; kalau belum ada, buat baru.
        /// Benih butuh id_jenis_ikan DAN id_ikan (dua-duanya NOT NULL).
        /// </summary>
        private int AmbilAtauBuatBenih(NpgsqlConnection conn, NpgsqlTransaction tx, string nama, int idJenis, int idIkan)
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
                @"INSERT INTO benih (nama, jumlah_stok, id_jenis_ikan, id_ikan, tanggal_masuk)
                  VALUES (@nama, 0, @id_jenis, @id_ikan, CURRENT_DATE) RETURNING id_benih", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@id_jenis", idJenis);
                cmd.Parameters.AddWithValue("@id_ikan", idIkan);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}