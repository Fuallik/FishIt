using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MDataAkun
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetDataAkun()
        {
            string query = @"
                SELECT a.id_akun, a.username, a.nama, a.no_telp, a.alamat, r.nama_role, a.aktif
                FROM akun a
                JOIN roles r ON a.id_role = r.id_role
                ORDER BY a.id_akun ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public int HitungAktif() => Count("SELECT COUNT(*) FROM akun WHERE aktif = true");
        public int HitungTidakAktif() => Count("SELECT COUNT(*) FROM akun WHERE aktif = false");

        // Satu method buat semua role, beda di parameter id_role
        public int HitungRole(int idRole)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM akun WHERE id_role = @r", conn);
            cmd.Parameters.AddWithValue("@r", idRole);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int Count(string query)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}