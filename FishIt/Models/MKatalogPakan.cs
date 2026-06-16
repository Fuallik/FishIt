using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MKatalogPakan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKatalog()
        {
            string query = @"
                SELECT  nama          AS ""Nama Pakan"",
                        jumlah_stok    AS ""Stok"",
                        tanggal_masuk  AS ""Tanggal Masuk""
                FROM pakan p
                WHERE EXISTS (
                    -- hanya tampilkan pakan yang punya minimal satu pengajuan
                    -- berstatus 'Disetujui' (sudah diverifikasi Admin)
                    SELECT 1 FROM pengiriman_supplier ps
                    WHERE ps.id_pakan = p.id_pakan
                      AND ps.status_verifikasi = 'Disetujui'
                )
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