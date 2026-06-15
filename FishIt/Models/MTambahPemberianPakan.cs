using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class DataPemberianPakan
    {
        public decimal Jumlah; public int IdAkun; public int IdPakan; public int IdKolam;
    }

    internal class MTambahPemberianPakan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKolam()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT k.id_kolam, k.nomor FROM kolam k WHERE fn_isi_kolam(k.id_kolam) > 0 ORDER BY k.nomor", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public DataTable GetPakan()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT id_pakan, nama FROM pakan WHERE jumlah_stok > 0 ORDER BY nama", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public decimal GetStokPakan(int idPakan)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT jumlah_stok FROM pakan WHERE id_pakan = @id", conn);
            cmd.Parameters.AddWithValue("@id", idPakan);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }

        public void Simpan(DataPemberianPakan d)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_pemberian_pakan(@jumlah, @akun, @pakan, @kolam)", conn);
            cmd.Parameters.AddWithValue("@jumlah", d.Jumlah);
            cmd.Parameters.AddWithValue("@akun", d.IdAkun);
            cmd.Parameters.AddWithValue("@pakan", d.IdPakan);
            cmd.Parameters.AddWithValue("@kolam", d.IdKolam);
            cmd.ExecuteNonQuery();
        }
    }
}