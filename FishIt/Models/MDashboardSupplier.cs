using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary> MODEL Dashboard Supplier: jumlah pengajuan per status_verifikasi. </summary>
    internal class MDashboardSupplier
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRingkasanPerStatus(int idAkun)
        {
            string query = @"
                SELECT status_verifikasi, COUNT(*) AS jumlah
                FROM pengiriman_supplier
                WHERE id_akun = @id_akun
                GROUP BY status_verifikasi";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}