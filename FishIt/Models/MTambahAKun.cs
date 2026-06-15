using Npgsql;
using NpgsqlTypes;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    // DTO input akun baru (internal: cuma View->Controller->Model, tak lewat method public)
    internal class DataAkunBaru
    {
        public string Username, Password, Konfirmasi, Nama, Alamat, Telpon, Kelurahan, Kecamatan;
        public int IdRole;
    }

    internal class MTambahAkun
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRoles()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT id_role, nama_role FROM roles WHERE nama_role != 'pembeli' ORDER BY nama_role ASC", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        // Panggil stored procedure; ambil id baru dari OUT param. Return id user baru.
        public int TambahAkun(DataAkunBaru d)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_akun(@p_username, @p_nama, @p_passwords, @p_alamat, @p_no_telp, " +
                "@p_aktif, @p_id_role, @p_nama_kelurahan, @p_nama_kecamatan, @p_id_baru)", conn);
            cmd.CommandType = CommandType.Text;   // CALL pakai Text, bukan StoredProcedure

            cmd.Parameters.Add("@p_username", NpgsqlDbType.Varchar).Value = d.Username;
            cmd.Parameters.Add("@p_nama", NpgsqlDbType.Varchar).Value = d.Nama;
            cmd.Parameters.Add("@p_passwords", NpgsqlDbType.Varchar).Value = d.Password;
            cmd.Parameters.Add("@p_alamat", NpgsqlDbType.Varchar).Value = d.Alamat;
            cmd.Parameters.Add("@p_no_telp", NpgsqlDbType.Varchar).Value = d.Telpon;
            cmd.Parameters.Add("@p_aktif", NpgsqlDbType.Boolean).Value = true;
            cmd.Parameters.Add("@p_id_role", NpgsqlDbType.Integer).Value = d.IdRole;
            cmd.Parameters.Add("@p_nama_kelurahan", NpgsqlDbType.Varchar).Value = d.Kelurahan;
            cmd.Parameters.Add("@p_nama_kecamatan", NpgsqlDbType.Varchar).Value = d.Kecamatan;

            var pIdBaru = new NpgsqlParameter("@p_id_baru", NpgsqlDbType.Integer)
            {
                Direction = ParameterDirection.InputOutput,
                Value = DBNull.Value
            };
            cmd.Parameters.Add(pIdBaru);

            cmd.ExecuteNonQuery();
            return Convert.ToInt32(pIdBaru.Value);
        }
    }
}