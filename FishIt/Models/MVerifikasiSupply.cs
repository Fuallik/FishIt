using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    public class DetailPengajuan
    {
        public int IdPengajuan { get; set; }
        public int IdBenih { get; set; }
        public int IdPakan { get; set; }
        public string NamaSupplier { get; set; }
        public string NamaBarang { get; set; }
        public int Kuantitas { get; set; }
        public string Tipe { get; set; }
        public string TanggalKirim { get; set; }
        public string StatusVerifikasi { get; set; }
        public string TanggalVerifikasi { get; set; }
    }

    internal class MVerifikasiSupply
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetPengajuanPending()
        {
            string query = @"
                SELECT p.id_pengiriman_supplier AS ""ID Pengiriman Supplier"",
                       a.nama                     AS ""Nama Supplier"",
                       p.nama                     AS ""Nama Barang"",
                       p.kuantitas                AS ""Kuantitas"",
                       p.tipe                     AS ""Tipe"",
                       p.tanggal_kirim            AS ""Tanggal Kirim"",
                       p.status_verifikasi        AS ""Status Verifikasi"",
                       p.tanggal_verifikasi       AS ""Tanggal Verifikasi""
                FROM pengiriman_supplier p
                JOIN akun a ON p.id_akun = a.id_akun
                WHERE p.status_verifikasi = 'Pending'
                ORDER BY p.id_pengiriman_supplier ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public DetailPengajuan CariPengajuan(int id)
        {
            string query = @"
                SELECT p.id_pengiriman_supplier, p.id_benih, p.id_pakan,
                       a.nama AS nama_supplier, p.nama AS nama_barang, p.kuantitas,
                       p.tipe, p.tanggal_kirim, p.status_verifikasi, p.tanggal_verifikasi
                FROM pengiriman_supplier p
                JOIN akun a ON p.id_akun = a.id_akun
                WHERE p.id_pengiriman_supplier = @id AND p.status_verifikasi = 'Pending'";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;

            return new DetailPengajuan
            {
                IdPengajuan = Convert.ToInt32(r["id_pengiriman_supplier"]),
                IdBenih = r["id_benih"] == DBNull.Value ? 0 : Convert.ToInt32(r["id_benih"]),
                IdPakan = r["id_pakan"] == DBNull.Value ? 0 : Convert.ToInt32(r["id_pakan"]),
                NamaSupplier = r["nama_supplier"].ToString(),
                NamaBarang = r["nama_barang"].ToString(),
                Kuantitas = Convert.ToInt32(r["kuantitas"]),
                Tipe = r["tipe"].ToString(),
                StatusVerifikasi = r["status_verifikasi"].ToString(),
                TanggalKirim = FormatTanggal(r["tanggal_kirim"]),
                TanggalVerifikasi = r["tanggal_verifikasi"] == DBNull.Value
                    ? "Belum Diverifikasi" : FormatTanggal(r["tanggal_verifikasi"])
            };
        }

        private string FormatTanggal(object nilai)
        {
            if (nilai is DateOnly d) return d.ToString("yyyy-MM-dd");
            return Convert.ToDateTime(nilai).ToString("yyyy-MM-dd");
        }
    }
}