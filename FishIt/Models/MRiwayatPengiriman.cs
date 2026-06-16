using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary> MODEL untuk Riwayat Pengiriman (Shipper). Read-only. </summary>
    internal class MRiwayatPengiriman
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat(int idShipper)
        {
            string query = @"
                SELECT  p.id_order          AS ""ID Order"",
                        a.nama              AS ""Pembeli"",
                        o.total_harga       AS ""Total Harga"",
                        p.tanggal_pengiriman AS ""Tgl Kirim"",
                        p.tanggal_diterima  AS ""Tgl Diterima"",
                        p.status_pengiriman AS ""Status""
                FROM pengiriman p
                JOIN orders o ON o.id_order = p.id_order
                JOIN akun   a ON a.id_akun  = o.id_akun
                WHERE p.id_akun = @id_shipper
                  AND p.status_pengiriman = 'Diterima'
                ORDER BY p.tanggal_diterima DESC";

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