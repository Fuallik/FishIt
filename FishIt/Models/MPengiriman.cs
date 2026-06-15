using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MPengiriman
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPengiriman()
        {
            string query = @"
                SELECT p.id_pengiriman      AS ""ID"",
                       p.id_order            AS ""ID Order"",
                       a.nama                AS ""Shipper"",
                       pembeli.nama          AS ""Pembeli"",
                       o.total_harga         AS ""Total"",
                       p.tanggal_pengiriman  AS ""Tgl Kirim"",
                       p.tanggal_diterima    AS ""Tgl Diterima"",
                       p.status_pengiriman   AS ""Status""
                FROM pengiriman p
                JOIN akun a       ON a.id_akun = p.id_akun
                JOIN orders o     ON o.id_order = p.id_order
                JOIN akun pembeli ON pembeli.id_akun = o.id_akun
                ORDER BY p.id_pengiriman DESC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int HitungStatus(string status)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM pengiriman WHERE status_pengiriman = @status", conn);
            cmd.Parameters.AddWithValue("@status", status);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}