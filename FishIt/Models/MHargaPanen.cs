using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    // Hasil pencarian entri katalog (spesies + kualitas)
    internal class HasilKatalog
    {
        public bool Ditemukan { get; set; }
        public int IdIkan { get; set; }
        public decimal Harga { get; set; }
    }

    internal class MHargaPanen
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetAntrean()
        {
            string query = @"
                SELECT p.id_panen        AS ""ID"",
                       i.nama_ikan         AS ""Ikan"",
                       i.id_jenis_ikan     AS ""ID Jenis"",
                       p.kualitas          AS ""Kualitas"",
                       ku.id_kualitas      AS ""ID Kualitas"",
                       k.nomor             AS ""Kolam"",
                       p.jumlah_kg         AS ""Jumlah (kg)"",
                       p.tanggal_panen     AS ""Tgl Panen"",
                       a.nama              AS ""Dipanen Oleh""
                FROM panen p
                JOIN ikan i      ON i.id_ikan = p.id_ikan
                JOIN kolam k     ON k.id_kolam = p.id_kolam
                JOIN akun a      ON a.id_akun = p.id_akun
                JOIN kualitas ku ON ku.kualitas_ikan = p.kualitas
                WHERE p.sudah_dihargai = FALSE
                ORDER BY p.tanggal_panen ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        // Cari entri katalog cocok spesies + kualitas
        public HasilKatalog CariKatalog(string nama, int idJenis, int idKualitas)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT id_ikan, harga_per_kg FROM ikan
                WHERE nama_ikan = @nama AND id_jenis_ikan = @jenis AND id_kualitas = @kualitas
                LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@nama", nama);
            cmd.Parameters.AddWithValue("@jenis", idJenis);
            cmd.Parameters.AddWithValue("@kualitas", idKualitas);

            using var r = cmd.ExecuteReader();
            if (r.Read())
                return new HasilKatalog
                {
                    Ditemukan = true,
                    IdIkan = Convert.ToInt32(r["id_ikan"]),
                    Harga = Convert.ToDecimal(r["harga_per_kg"])
                };
            return new HasilKatalog { Ditemukan = false };
        }

        // Transaksi: tambah stok / buat entri katalog + tandai panen diproses.
        // return false = panen sudah diproses sebelumnya (guard = 0 baris).
        public bool ProsesHarga(int idPanen, HasilKatalog katalog, decimal harga,
                                string nama, int idJenis, int idKualitas, decimal jumlahKg)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                if (katalog.Ditemukan)
                {
                    using var cmdStok = new NpgsqlCommand(
                        "UPDATE ikan SET stok_ikan = stok_ikan + @kg WHERE id_ikan = @id", conn, tx);
                    cmdStok.Parameters.AddWithValue("@kg", jumlahKg);
                    cmdStok.Parameters.AddWithValue("@id", katalog.IdIkan);
                    cmdStok.ExecuteNonQuery();
                }
                else
                {
                    using var cmdNew = new NpgsqlCommand(@"
                        INSERT INTO ikan (harga_per_kg, stok_ikan, nama_ikan, id_jenis_ikan, id_kualitas)
                        VALUES (@harga, @kg, @nama, @jenis, @kualitas)", conn, tx);
                    cmdNew.Parameters.AddWithValue("@harga", harga);
                    cmdNew.Parameters.AddWithValue("@kg", jumlahKg);
                    cmdNew.Parameters.AddWithValue("@nama", nama);
                    cmdNew.Parameters.AddWithValue("@jenis", idJenis);
                    cmdNew.Parameters.AddWithValue("@kualitas", idKualitas);
                    cmdNew.ExecuteNonQuery();
                }

                int baris;
                using (var cmdTandai = new NpgsqlCommand(
                    "UPDATE panen SET sudah_dihargai = TRUE WHERE id_panen = @id AND sudah_dihargai = FALSE", conn, tx))
                {
                    cmdTandai.Parameters.AddWithValue("@id", idPanen);
                    baris = cmdTandai.ExecuteNonQuery();
                }

                if (baris == 0) { tx.Rollback(); return false; }

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw;   // biar Controller yang tampilkan pesan error
            }
        }
    }
}