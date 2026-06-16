using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    internal class MRiwayatVerifikasi
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat(int idAkun)
        {
            string query = @"
                SELECT  tipe              AS ""Tipe"",
                        nama_item         AS ""Item"",
                        kuantitas         AS ""Kuantitas"",
                        tanggal_kirim     AS ""Tgl Ajukan"",
                        status_verifikasi AS ""Status"",
                        tanggal_verifikasi AS ""Tgl Verifikasi""
                FROM view_pengajuan_supplier
                WHERE id_akun = @id_akun
                ORDER BY tanggal_kirim DESC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}