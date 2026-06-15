using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MPanenIkan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPanen(int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM view_panen WHERE id_akun = @id", conn);
            cmd.Parameters.AddWithValue("@id", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public decimal HitungPanen(string periode, int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT fn_total_panen(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }
    }
}