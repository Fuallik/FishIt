using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MKelolaAkun
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM view_laporan_riwayat ORDER BY \"Waktu\" DESC", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int HitungAktif() => Count("SELECT COUNT(*) FROM akun WHERE aktif = true");
        public int HitungTidakAktif() => Count("SELECT COUNT(*) FROM akun WHERE aktif = false");

        private int Count(string query)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}