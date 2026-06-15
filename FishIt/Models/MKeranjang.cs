using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;

namespace FishIt.Models
{
    // Hasil dari function checkout (kolom is_sukses + pesan)
    internal class HasilCheckout
    {
        public bool Sukses { get; set; }
        public string Pesan { get; set; }
    }

    internal class MKeranjang
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public DataTable GetKeranjang(int idAkun)
        {
            string query = @"
                SELECT k.id_keranjang, i.nama_ikan, k.kuantitas, i.harga_per_kg,
                       (k.kuantitas * i.harga_per_kg) AS subtotal
                FROM keranjang k
                JOIN ikan i ON k.id_ikan = i.id_ikan
                WHERE k.id_akun = @id_akun";

            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_akun", idAkun);
            using var ad = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public void HapusItem(int idKeranjang)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "DELETE FROM keranjang WHERE id_keranjang = @id", conn);
            cmd.Parameters.AddWithValue("@id", idKeranjang);
            cmd.ExecuteNonQuery();
        }

        // Panggil function checkout di PostgreSQL; baca is_sukses + pesan dari baris hasilnya
        public HasilCheckout Checkout(int idAkun, int idMetode)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM public.proses_checkout_func(@id_akun, @id_metode)", conn);
            cmd.Parameters.Add("@id_akun", NpgsqlDbType.Integer).Value = idAkun;
            cmd.Parameters.Add("@id_metode", NpgsqlDbType.Integer).Value = idMetode;

            using var r = cmd.ExecuteReader();
            if (r.Read())
                return new HasilCheckout { Sukses = r.GetBoolean(0), Pesan = r.GetString(1) };

            return new HasilCheckout { Sukses = false, Pesan = "Gagal memproses transaksi." };
        }
    }
}