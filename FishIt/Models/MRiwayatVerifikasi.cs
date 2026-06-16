using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary>
    /// MODEL Riwayat Verifikasi: semua pengajuan (benih & pakan, semua status)
    /// milik supplier tertentu. LEFT JOIN benih & pakan; COALESCE ambil nama yang terisi.
    /// </summary>
    internal class MRiwayatVerifikasi
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetRiwayat(int idAkun)
        {
            string query = @"
                SELECT  ps.tipe                 AS ""Tipe"",
                        COALESCE(b.nama, p.nama) AS ""Item"",
                        ps.kuantitas            AS ""Kuantitas"",
                        ps.tanggal_kirim        AS ""Tgl Ajukan"",
                        ps.status_verifikasi    AS ""Status"",
                        ps.tanggal_verifikasi   AS ""Tgl Verifikasi""
                FROM pengiriman_supplier ps
                LEFT JOIN benih b ON b.id_benih = ps.id_benih
                LEFT JOIN pakan p ON p.id_pakan = ps.id_pakan
                WHERE ps.id_akun = @id_akun
                ORDER BY ps.tanggal_kirim DESC";

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