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
            // Panggil FUNCTION database (mengembalikan tabel status + jumlah).
            // Kolom hasil: status_pengiriman, jumlah — sama seperti query lama,
            // jadi Controller tidak perlu diubah.
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