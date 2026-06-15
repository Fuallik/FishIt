using Npgsql;
using System;
using System.Configuration;

namespace FishIt.Models
{
    internal class MStokIkan
    {
        private readonly string _connString =
            ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        public decimal TotalIkan() => Scalar("SELECT COALESCE(SUM(stok_ikan), 0) FROM ikan");
        public decimal TotalBenih() => Scalar("SELECT COALESCE(SUM(jumlah_stok), 0) FROM benih");
        public decimal TotalPakan() => Scalar("SELECT COALESCE(SUM(jumlah_stok), 0) FROM pakan");

        private decimal Scalar(string query)
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();
            using var cmd = new NpgsqlCommand(query, conn);
            return Convert.ToDecimal(cmd.ExecuteScalar());
        }
    }
}