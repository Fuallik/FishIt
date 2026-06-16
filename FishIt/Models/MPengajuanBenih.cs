using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary>
    /// MODEL Pengajuan Benih. Paling kompleks: saat mengajukan, sistem membuat
    /// rantai data jenis_ikan -> ikan -> benih -> pengiriman_supplier dalam SATU transaksi.
    /// Juga menyediakan data untuk dropdown & auto-isi jenis air.
    /// </summary>
    internal class MPengajuanBenih
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        // Default untuk ikan yang dibuat otomatis lewat pengajuan benih.
        private const decimal HARGA_DEFAULT = 0;
        private const decimal STOK_DEFAULT = 0;
        private const int ID_KUALITAS_DEFAULT = 3; // 'C'

        public DataTable GetDaftarJenisIkan()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT nama_jenis_ikan FROM jenis_ikan ORDER BY nama_jenis_ikan", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public DataTable GetDaftarNamaIkan()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT DISTINCT nama_ikan FROM ikan ORDER BY nama_ikan", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        /// <summary>
        /// Daftar nama ikan yang JENIS-nya sesuai (untuk menyaring dropdown nama
        /// setelah supplier memilih jenis ikan). Mis. pilih "Air Tawar" -> hanya
        /// Lele, Nila, dst.
        /// </summary>
        public DataTable GetNamaIkanByJenis(string namaJenis)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT DISTINCT i.nama_ikan
                FROM ikan i
                JOIN jenis_ikan j ON j.id_jenis_ikan = i.id_jenis_ikan
                WHERE LOWER(j.nama_jenis_ikan) = LOWER(@jenis)
                ORDER BY i.nama_ikan", conn);
            cmd.Parameters.AddWithValue("@jenis", namaJenis);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        /// <summary>
        /// Untuk auto-isi jenis air: cari nama jenis ikan dari sebuah nama ikan yang sudah ada.
        /// Mengembalikan null kalau ikan belum terdaftar (berarti nama baru).
        /// </summary>
        public string GetJenisIkanByNama(string namaIkan)
        {
            string query = @"
                SELECT j.nama_jenis_ikan
                FROM ikan i
                JOIN jenis_ikan j ON j.id_jenis_ikan = i.id_jenis_ikan
                WHERE LOWER(i.nama_ikan) = LOWER(@nama)
                LIMIT 1";
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nama", namaIkan);
            object hasil = cmd.ExecuteScalar();
            return hasil?.ToString();
        }

        public DataTable GetRiwayat(int idAkun)
        {
            string query = @"
                SELECT  ps.id_pengiriman_supplier AS ""ID"",
                        b.nama                      AS ""Benih"",
                        ps.kuantitas                AS ""Kuantitas"",
                        ps.tanggal_kirim            AS ""Tgl Ajukan"",
                        ps.status_verifikasi        AS ""Status""
                FROM pengiriman_supplier ps
                JOIN benih b ON b.id_benih = ps.id_benih
                WHERE ps.id_akun = @id_akun AND ps.tipe = 'Benih'
                ORDER BY ps.tanggal_kirim DESC";
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        /// <summary>
        /// Proses pengajuan benih dalam satu transaksi berlapis:
        /// jenis_ikan -> ikan (default harga/stok/kualitas) -> benih -> pengiriman_supplier.
        /// Satu nama dipakai untuk nama_ikan sekaligus nama benih.
        /// </summary>
        public void Ajukan(int idAkun, string namaJenis, string nama, decimal kuantitas)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                int idJenis = AmbilAtauBuatJenisIkan(conn, tx, namaJenis);
                int idIkan = AmbilAtauBuatIkan(conn, tx, nama, idJenis);
                int idBenih = AmbilAtauBuatBenih(conn, tx, nama, idJenis, idIkan);

                string sql = @"
                    INSERT INTO pengiriman_supplier
                        (tanggal_kirim, tipe, kuantitas, status_verifikasi, id_akun, id_benih, id_pakan, nama)
                    VALUES
                        (CURRENT_DATE, 'Benih', @kuantitas, 'Pending', @id_akun, @id_benih, NULL, @nama)";
                using (var cmd = new NpgsqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                    cmd.Parameters.AddWithValue("@id_akun", idAkun);
                    cmd.Parameters.AddWithValue("@id_benih", idBenih);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch (PostgresException pgEx) when (pgEx.SqlState == "P0001")
            {
                // P0001 = RAISE EXCEPTION dari trigger (mis. konsistensi jenis ikan).
                // Ambil pesan asli trigger yang sudah ramah, lempar sebagai pesan bersih.
                tx.Rollback();
                throw new Exception(pgEx.MessageText);
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        private int AmbilAtauBuatJenisIkan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_jenis_ikan FROM jenis_ikan WHERE LOWER(nama_jenis_ikan) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object h = cmd.ExecuteScalar();
                if (h != null) return Convert.ToInt32(h);
            }
            using (var cmd = new NpgsqlCommand(
                "INSERT INTO jenis_ikan (nama_jenis_ikan) VALUES (@nama) RETURNING id_jenis_ikan", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int AmbilAtauBuatIkan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama, int idJenis)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_ikan FROM ikan WHERE LOWER(nama_ikan) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object h = cmd.ExecuteScalar();
                if (h != null) return Convert.ToInt32(h);
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

        private int AmbilAtauBuatBenih(NpgsqlConnection conn, NpgsqlTransaction tx, string nama, int idJenis, int idIkan)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_benih FROM benih WHERE LOWER(nama) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object h = cmd.ExecuteScalar();
                if (h != null) return Convert.ToInt32(h);
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