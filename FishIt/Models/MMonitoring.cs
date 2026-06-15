using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MMonitoring
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetMonitoring()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM view_monitoring_ikan", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int HitungMonitoring(string periode)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT fn_total_monitoring(@periode)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}