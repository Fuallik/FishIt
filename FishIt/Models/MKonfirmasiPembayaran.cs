using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    // Hasil konfirmasi (biar Controller bisa kasih pesan yang tepat)
    internal enum HasilKonfirmasi { Sukses, SudahDikonfirmasi, TanpaShipper }

    internal class MKonfirmasiPembayaran
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetAntrean()
        {
            string query = @"
                SELECT o.id_order               AS ""ID"",
                       a.nama                    AS ""Pembeli"",
                       o.tanggal_order           AS ""Tanggal"",
                       o.total_harga             AS ""Total"",
                       m.jenis_metode_pembayaran AS ""Metode""
                FROM orders o
                JOIN akun a ON a.id_akun = o.id_akun
                JOIN metode_pembayaran m ON m.id_metode_pembayaran = o.id_metode_pembayaran
                WHERE o.id_status_pembayaran = 1
                ORDER BY o.id_order ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public DataTable GetItem(int idOrder)
        {
            string query = @"
                SELECT i.nama_ikan AS ""Nama Ikan"",
                       d.kuantitas AS ""Jumlah (kg)"",
                       d.harga     AS ""Harga/kg"",
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

        public HasilKonfirmasi Konfirmasi(int idOrder)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                int bOrder;
                using (var cmd = new NpgsqlCommand(@"
                    UPDATE orders SET id_status_pembayaran = 2, status_order = 'Diproses'
                    WHERE id_order = @id AND id_status_pembayaran = 1", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", idOrder);
                    bOrder = cmd.ExecuteNonQuery();
                }
                if (bOrder == 0) { tx.Rollback(); return HasilKonfirmasi.SudahDikonfirmasi; }

                using (var cmd = new NpgsqlCommand(@"
                    UPDATE ikan SET stok_ikan = stok_ikan - sub.total_kg
                    FROM (SELECT id_ikan, SUM(kuantitas) AS total_kg
                          FROM detail_order WHERE id_order = @id GROUP BY id_ikan) sub
                    WHERE ikan.id_ikan = sub.id_ikan", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", idOrder);
                    cmd.ExecuteNonQuery();
                }

                int bKirim;
                using (var cmd = new NpgsqlCommand(@"
                    INSERT INTO pengiriman (tanggal_pengiriman, status_pengiriman, id_akun, id_order)
                    SELECT CURRENT_DATE, 'Diproses', id_akun, @id
                    FROM akun WHERE id_role = 4 AND aktif = true LIMIT 1", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@id", idOrder);
                    bKirim = cmd.ExecuteNonQuery();
                }
                if (bKirim == 0) { tx.Rollback(); return HasilKonfirmasi.TanpaShipper; }

                tx.Commit();
                return HasilKonfirmasi.Sukses;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}