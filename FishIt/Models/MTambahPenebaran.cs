using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class DataPenebaran
    {
        public int Ekor; public int IdAkun; public int IdBenih; public int IdKolam;
    }

    internal class MTambahPenebaran
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKolam()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT id_kolam, nomor FROM kolam WHERE status_kolam IS DISTINCT FROM 'Tidak Terpakai' ORDER BY nomor", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public DataTable GetBenihByKolam(int idKolam)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT b.id_benih, b.nama
                FROM benih b
                WHERE b.id_jenis_ikan = (SELECT id_jenis_ikan FROM kolam WHERE id_kolam = @kolam)
                  AND b.jumlah_stok > 0
                ORDER BY b.nama", conn);
            cmd.Parameters.AddWithValue("@kolam", idKolam);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public int GetStokBenih(int idBenih)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT jumlah_stok FROM benih WHERE id_benih = @id", conn);
            cmd.Parameters.AddWithValue("@id", idBenih);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Simpan(DataPenebaran d)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_penebaran(@ekor, @akun, @benih, @kolam)", conn);
            cmd.Parameters.AddWithValue("@ekor", d.Ekor);
            cmd.Parameters.AddWithValue("@akun", d.IdAkun);
            cmd.Parameters.AddWithValue("@benih", d.IdBenih);
            cmd.Parameters.AddWithValue("@kolam", d.IdKolam);
            cmd.ExecuteNonQuery();
        }
    }
}