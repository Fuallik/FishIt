using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDetailPakan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPakan()
        {
            string query = "SELECT id_pakan, nama, jumlah_stok FROM pakan WHERE jumlah_stok > 0 ORDER BY id_pakan ASC";

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