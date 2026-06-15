using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDetailBenih
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetBenih()
        {
            string query = @"
                SELECT b.id_benih, b.nama, b.jumlah_stok, j.nama_jenis_ikan
                FROM benih b
                JOIN jenis_ikan j ON b.id_jenis_ikan = j.id_jenis_ikan
                WHERE b.jumlah_stok > 0
                ORDER BY b.id_benih ASC";

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