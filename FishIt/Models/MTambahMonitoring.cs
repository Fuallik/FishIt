using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class DataMonitoring
    {
        public decimal Berat; public string Kondisi; public int Mati;
        public string Catatan; public bool Siap; public int IdAkun; public int IdKolam;
    }

    internal class MTambahMonitoring
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

        public void Simpan(DataMonitoring d)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_monitoring(@berat, @kondisi, @mati, @catatan, @siap, @akun, @kolam)", conn);
            cmd.Parameters.AddWithValue("@berat", d.Berat);
            cmd.Parameters.AddWithValue("@kondisi", d.Kondisi);
            cmd.Parameters.AddWithValue("@mati", d.Mati);
            cmd.Parameters.AddWithValue("@catatan", d.Catatan);
            cmd.Parameters.AddWithValue("@siap", d.Siap);
            cmd.Parameters.AddWithValue("@akun", d.IdAkun);
            cmd.Parameters.AddWithValue("@kolam", d.IdKolam);
            cmd.ExecuteNonQuery();
        }
    }
}