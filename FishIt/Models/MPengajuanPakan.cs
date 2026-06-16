using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MPengajuanPakan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetDaftarPakan()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT DISTINCT nama FROM pakan ORDER BY nama", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public DataTable GetRiwayat(int idAkun)
        {
            string query = @"
                SELECT  ps.id_pengiriman_supplier AS ""ID"",
                        p.nama                      AS ""Pakan"",
                        ps.kuantitas                AS ""Kuantitas"",
                        ps.tanggal_kirim            AS ""Tgl Ajukan"",
                        ps.status_verifikasi        AS ""Status""
                FROM pengiriman_supplier ps
                JOIN pakan p ON p.id_pakan = ps.id_pakan
                WHERE ps.id_akun = @id_akun AND ps.tipe = 'Pakan'
                ORDER BY ps.tanggal_kirim DESC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public void Ajukan(int idAkun, string namaPakan, decimal kuantitas)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                int idPakan = AmbilAtauBuatPakan(conn, tx, namaPakan);

                string sql = @"
                    INSERT INTO pengiriman_supplier
                        (tanggal_kirim, tipe, kuantitas, status_verifikasi, id_akun, id_benih, id_pakan, nama)
                    VALUES
                        (CURRENT_DATE, 'Pakan', @kuantitas, 'Pending', @id_akun, NULL, @id_pakan, @nama)";
                using (var cmd = new NpgsqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@kuantitas", kuantitas);
                    cmd.Parameters.AddWithValue("@id_akun", idAkun);
                    cmd.Parameters.AddWithValue("@id_pakan", idPakan);
                    cmd.Parameters.AddWithValue("@nama", namaPakan);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;       
            }
        }

        private int AmbilAtauBuatPakan(NpgsqlConnection conn, NpgsqlTransaction tx, string nama)
        {
            using (var cmd = new NpgsqlCommand(
                "SELECT id_pakan FROM pakan WHERE LOWER(nama) = LOWER(@nama)", conn, tx))
            {
                cmd.Parameters.AddWithValue("@nama", nama);
                object hasil = cmd.ExecuteScalar();
                if (hasil != null) return Convert.ToInt32(hasil);
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