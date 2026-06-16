using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDashboardShipper
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRingkasanPerStatus(int idShipper)
        {
            string query = "SELECT status_pengiriman, jumlah FROM fn_ringkasan_pengiriman(@id_shipper)";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_shipper", idShipper);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}