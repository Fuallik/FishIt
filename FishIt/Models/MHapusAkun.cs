using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    public class DetailAkunHapus
    {
        public string Nama, Alamat, Telp, Kelurahan, Kecamatan;
    }

    internal class MHapusAkun
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DetailAkunHapus CariAkun(string username)
        {
            string query = @"
                SELECT a.nama, a.alamat, a.no_telp, kl.nama_kelurahan, kc.nama_kecamatan
                FROM akun a
                JOIN kelurahan kl ON a.id_kelurahan = kl.id_kelurahan
                JOIN kecamatan kc ON kl.id_kecamatan = kc.id_kecamatan
                WHERE LOWER(a.username) = LOWER(@u) AND a.aktif = TRUE";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.Add("@u", NpgsqlDbType.Varchar).Value = username;

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new DetailAkunHapus
            {
                Nama = r["nama"].ToString(),
                Alamat = r["alamat"].ToString(),
                Telp = r["no_telp"].ToString(),
                Kelurahan = r["nama_kelurahan"].ToString(),
                Kecamatan = r["nama_kecamatan"].ToString()
            };
        }

        public void HapusAkun(string username)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand("CALL sp_hapus_akun(@u)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@u", NpgsqlDbType.Varchar).Value = username;
            cmd.ExecuteNonQuery();
        }
    }
}