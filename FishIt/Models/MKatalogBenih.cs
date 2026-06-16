using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary> MODEL Katalog Benih: semua benih + jenis ikannya (JOIN). </summary>
    internal class MKatalogBenih
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKatalog()
        {
            string query = @"
                SELECT  b.nama           AS ""Nama Benih"",
                        j.nama_jenis_ikan AS ""Jenis Ikan"",
                        b.jumlah_stok     AS ""Stok"",
                        b.tanggal_masuk   AS ""Tanggal Masuk""
                FROM benih b
                JOIN jenis_ikan j ON j.id_jenis_ikan = b.id_jenis_ikan
                ORDER BY b.nama";

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