using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MRiwayatPembeli
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat(int idAkun)
        {
            string query = @"
                SELECT o.id_order, o.tanggal_order, o.total_harga,
                       s.nama_status, m.jenis_metode_pembayaran
                FROM orders o
                JOIN status_pembayaran s ON o.id_status_pembayaran = s.id_status_pembayaran
                JOIN metode_pembayaran m ON o.id_metode_pembayaran = m.id_metode_pembayaran
                WHERE o.id_akun = @id_akun
                ORDER BY o.id_order DESC";

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