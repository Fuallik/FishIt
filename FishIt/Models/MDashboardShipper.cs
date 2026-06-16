using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary>
    /// MODEL untuk Dashboard Shipper. Mengembalikan jumlah pengiriman per status
    /// untuk shipper tertentu, dalam bentuk DataTable (kolom: status_pengiriman, jumlah).
    /// </summary>
    internal class MDashboardShipper
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRingkasanPerStatus(int idShipper)
        {
            string query = @"
                SELECT status_pengiriman, COUNT(*) AS jumlah
                FROM pengiriman
                WHERE id_akun = @id_shipper
                GROUP BY status_pengiriman";

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