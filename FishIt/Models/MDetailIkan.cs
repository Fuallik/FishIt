using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDetailIkan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetIkan()
        {
            string query = @"
                SELECT i.nama_ikan, j.nama_jenis_ikan, k.kualitas_ikan, i.harga_per_kg, i.stok_ikan
                FROM ikan i
                JOIN jenis_ikan j ON i.id_jenis_ikan = j.id_jenis_ikan
                JOIN kualitas k   ON i.id_kualitas = k.id_kualitas
                WHERE i.stok_ikan > 0";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}