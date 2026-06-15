using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDataKolam
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKolam()
        {
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

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int HitungKolam()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM kolam", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}