using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary> MODEL Katalog Pakan: semua pakan + stok (tanpa JOIN). </summary>
    internal class MKatalogPakan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKatalog()
        {
            string query = @"
                SELECT  nama        AS ""Nama Pakan"",
                        jumlah_stok  AS ""Stok""
                FROM pakan
                ORDER BY nama";

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