using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MRiwayatPembayaran
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat()
        {
            string query = @"
                SELECT o.id_order, 
                       o.tanggal_order, 
                       a.nama, 
                       o.total_harga, 
                       m.jenis_metode_pembayaran AS ""Metode Pembayaran""
                FROM orders o
                JOIN akun a ON o.id_akun = a.id_akun
                JOIN metode_pembayaran m ON m.id_metode_pembayaran = o.id_metode_pembayaran
                WHERE o.id_status_pembayaran = 2
                ORDER BY o.tanggal_order DESC, o.id_order DESC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public DataTable GetDetail(int idOrder)
        {
            string query = @"
                SELECT i.nama_ikan AS ""Nama Ikan"",
                       d.kuantitas AS ""Jumlah (kg)"",
                       d.harga AS ""Harga/kg"",
                       ROUND((d.kuantitas * d.harga)::numeric, 2) AS ""Subtotal""
                FROM detail_order d
                JOIN ikan i ON i.id_ikan = d.id_ikan
                WHERE d.id_order = @id_order";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_order", idOrder);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}