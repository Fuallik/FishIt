using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MPenebaran
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPenebaran(int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM view_penebaran WHERE id_akun = @id", conn);
            cmd.Parameters.AddWithValue("@id", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public long HitungPenebaran(string periode, int idAkun)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT fn_total_penebaran(@periode, @id_akun)", conn);
            cmd.Parameters.AddWithValue("@periode", periode);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            return Convert.ToInt64(cmd.ExecuteScalar());
        }
    }
}