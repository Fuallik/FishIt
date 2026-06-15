using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class DataPanen
    {
        public decimal Kg; public int Ekor; public string Kualitas;
        public int IdAkun; public int IdIkan; public int IdKolam;
    }

    internal class MPengajuanPanen
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        // Kolam yang monitoring terakhirnya siap_panen = TRUE & masih ada isinya
        public DataTable GetKolam()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT k.id_kolam, k.nomor
                FROM kolam k
                WHERE (SELECT m.siap_panen FROM monitoring m
                       WHERE m.id_kolam = k.id_kolam
                       ORDER BY m.tanggal DESC, m.id_monitoring DESC LIMIT 1) = TRUE
                  AND fn_isi_kolam(k.id_kolam) > 0
                ORDER BY k.nomor", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        // FIX: buang JOIN kolam + filter status_kolam basi; cukup andalkan fn_sisa_ikan > 0
        public DataTable GetIkanByKolam(int idKolam)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                SELECT DISTINCT i.id_ikan, i.nama_ikan AS label
                FROM ikan i
                JOIN benih b ON b.id_ikan = i.id_ikan
                JOIN penebaran p ON p.id_benih = b.id_benih
                WHERE p.id_kolam = @kolam
                  AND fn_sisa_ikan(@kolam, i.id_ikan) > 0
                ORDER BY label", conn);
            cmd.Parameters.AddWithValue("@kolam", idKolam);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable(); ad.Fill(dt); return dt;
        }

        public int GetSisaKolam(int idKolam)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT fn_isi_kolam(@kolam)", conn);
            cmd.Parameters.AddWithValue("@kolam", idKolam);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public void Simpan(DataPanen d)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_panen(@kg, @ekor, @kualitas, @akun, @ikan, @kolam)", conn);
            cmd.Parameters.AddWithValue("@kg", d.Kg);
            cmd.Parameters.AddWithValue("@ekor", d.Ekor);
            cmd.Parameters.AddWithValue("@kualitas", d.Kualitas);
            cmd.Parameters.AddWithValue("@akun", d.IdAkun);
            cmd.Parameters.AddWithValue("@ikan", d.IdIkan);
            cmd.Parameters.AddWithValue("@kolam", d.IdKolam);
            cmd.ExecuteNonQuery();
        }
    }
}