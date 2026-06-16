using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MPengirimanPesanan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPengirimanAktif(int idShipper)
        {
            string query = @"
                SELECT  p.id_pengiriman      AS ""ID"",
                        p.id_order           AS ""ID Order"",
                        a.nama               AS ""Pembeli"",
                        o.total_harga        AS ""Total Harga"",
                        p.tanggal_pengiriman AS ""Tgl Kirim"",
                        p.status_pengiriman  AS ""Status"",
                        p.catatan            AS ""Catatan""
                FROM pengiriman p
                JOIN orders o ON o.id_order = p.id_order
                JOIN akun   a ON a.id_akun  = o.id_akun
                WHERE p.id_akun = @id_shipper
                  AND p.status_pengiriman IN ('Diproses', 'Dikirim')
                ORDER BY p.tanggal_pengiriman ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_shipper", idShipper);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int MulaiKirim(int idPengiriman, int idShipper)
        {
            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Dikirim'
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Diproses'";
            return Eksekusi(query, idPengiriman, idShipper);
        }

        public int TandaiDiterima(int idPengiriman, int idShipper)
        {
            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Diterima',
                    tanggal_diterima  = CURRENT_DATE
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Dikirim'";
            return Eksekusi(query, idPengiriman, idShipper);
        }

        private int Eksekusi(string query, int idPengiriman, int idShipper)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idPengiriman);
            cmd.Parameters.AddWithValue("@id_shipper", idShipper);
            return cmd.ExecuteNonQuery();
        }
    }
}