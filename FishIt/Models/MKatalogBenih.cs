using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
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
                WHERE EXISTS (
                    -- hanya tampilkan benih yang punya minimal satu pengajuan
                    -- berstatus 'Disetujui' (sudah diverifikasi Admin)
                    SELECT 1 FROM pengiriman_supplier ps
                    WHERE ps.id_benih = b.id_benih
                      AND ps.status_verifikasi = 'Disetujui'
                )
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