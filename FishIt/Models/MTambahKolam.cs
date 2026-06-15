using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class DataKolamBaru
    {
        public string Nomor, Panjang, Lebar, Tinggi, Kapasitas;
        public int IdJenis;
    }

    internal class MTambahKolam
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetJenisIkan()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT id_jenis_ikan, nama_jenis_ikan FROM jenis_ikan ORDER BY nama_jenis_ikan", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public bool NomorSudahAda(string nomor)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT COUNT(*) FROM kolam WHERE LOWER(nomor) = LOWER(@nomor)", conn);
            cmd.Parameters.AddWithValue("@nomor", nomor);
            return System.Convert.ToInt64(cmd.ExecuteScalar()) > 0;
        }

        public void TambahKolam(string nomor, string ukuran, int kapasitas, int idJenis)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                INSERT INTO kolam (nomor, ukuran, kapasitas, status_kolam, id_jenis_ikan)
                VALUES (@nomor, @ukuran, @kapasitas, 'Kosong', @id_jenis)", conn);
            cmd.Parameters.AddWithValue("@nomor", nomor);
            cmd.Parameters.AddWithValue("@ukuran", ukuran);
            cmd.Parameters.AddWithValue("@kapasitas", kapasitas);
            cmd.Parameters.AddWithValue("@id_jenis", idJenis);
            cmd.ExecuteNonQuery();
        }
    }
}