using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MHapusKolam
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKolamKosong()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT id_kolam, nomor FROM kolam WHERE fn_status_kolam(id_kolam) = 'Kosong' ORDER BY nomor", conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }


        public int HapusKolam(int idKolam)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(@"
                UPDATE kolam SET status_kolam = 'Tidak Terpakai'
                WHERE id_kolam = @id AND fn_status_kolam(id_kolam) = 'Kosong'", conn);
            cmd.Parameters.AddWithValue("@id", idKolam);
            return cmd.ExecuteNonQuery();
        }
    }
}