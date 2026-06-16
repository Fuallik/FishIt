using Npgsql;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    /// <summary>
    /// MODEL untuk fitur Pengiriman Pesanan (Shipper).
    /// Semua akses database ada di sini; tidak tahu soal UI.
    /// id_akun shipper dikirim dari luar sebagai parameter (pola tim: Model tidak pakai Session).
    /// </summary>
    internal class MPengirimanPesanan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        /// <summary> Pengiriman aktif (Diproses/Dikirim) milik shipper tertentu. </summary>
        public DataTable GetPengirimanAktif(int idShipper)
        {
            string query = @"
                SELECT  p.id_pengiriman      AS ""ID"",
                        p.id_order           AS ""ID Order"",
                        a.nama               AS ""Pembeli"",
                        o.total_harga        AS ""Total Harga"",
                        p.tanggal_pengiriman AS ""Tgl Kirim"",
                        p.status_pengiriman  AS ""Status"",
                        p.catatan            AS ""Catatan""
                FROM pengiriman p
                JOIN orders o ON o.id_order = p.id_order
                JOIN akun   a ON a.id_akun  = o.id_akun
                WHERE p.id_akun = @id_shipper
                  AND p.status_pengiriman IN ('Diproses', 'Dikirim')
                ORDER BY p.tanggal_pengiriman ASC";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_shipper", idShipper);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Ubah status Diproses -> Dikirim. Guard status di WHERE mencegah race condition.
        /// Mengembalikan jumlah baris terpengaruh (0 = status sudah berubah dari sumber lain).
        /// </summary>
        public int MulaiKirim(int idPengiriman, int idShipper)
        {
            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Dikirim'
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Diproses'";
            return Eksekusi(query, idPengiriman, idShipper);
        }

        /// <summary> Ubah status Dikirim -> Diterima + isi tanggal_diterima. </summary>
        public int TandaiDiterima(int idPengiriman, int idShipper)
        {
            string query = @"
                UPDATE pengiriman
                SET status_pengiriman = 'Diterima',
                    tanggal_diterima  = CURRENT_DATE
                WHERE id_pengiriman = @id
                  AND id_akun = @id_shipper
                  AND status_pengiriman = 'Dikirim'";
            return Eksekusi(query, idPengiriman, idShipper);
        }

        private int Eksekusi(string query, int idPengiriman, int idShipper)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", idPengiriman);
            cmd.Parameters.AddWithValue("@id_shipper", idShipper);
            return cmd.ExecuteNonQuery();
        }
    }
}