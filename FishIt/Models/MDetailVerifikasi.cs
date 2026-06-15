using Npgsql;
using System.Configuration;

namespace FishIt.Models
{
    internal class MDetailVerifikasi
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        // Cukup UPDATE status; penambahan stok master ditangani TRIGGER di PostgreSQL.
        // Satu method untuk dua aksi (Disetujui / Ditolak), beda di parameter status.
        public void UbahStatus(int idPengajuan, string status)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                UPDATE pengiriman_supplier
                SET status_verifikasi = @status, tanggal_verifikasi = CURRENT_DATE
                WHERE id_pengiriman_supplier = @id", conn);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@id", idPengajuan);
            cmd.ExecuteNonQuery();
        }
    }
}