using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MMonitoringIkan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetMonitoring(int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM view_monitoring_ikan WHERE id_akun = @id", conn);
            cmd.Parameters.AddWithValue("@id", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public int HitungMonitoring(string periode, int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT fn_total_monitoring(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}