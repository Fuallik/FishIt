using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace FishIt.Models
{
    internal class MInfoStok
    {
        private readonly string _connString;

        public MInfoStok()
        {
            _connString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        public DataTable GetStokPakan()
        {
            return GetDataTable("SELECT * FROM view_stok_pakan");
        }

        public DataTable GetStokBenih()
        {
            return GetDataTable("SELECT * FROM view_stok_benih");
        }

        public decimal HitungStok(string tipe, string mode)
        {
            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                using var cmd = new NpgsqlCommand("SELECT fn_info_stok(@tipe, @mode)", conn);
                cmd.Parameters.AddWithValue("@tipe", tipe);
                cmd.Parameters.AddWithValue("@mode", mode);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        private DataTable GetDataTable(string query)
        {
            using (var conn = new NpgsqlConnection(_connString))
            {
                conn.Open();
                using var cmd = new NpgsqlCommand(query, conn);
                using var adapter = new NpgsqlDataAdapter(cmd);
                var tabel = new DataTable();
                adapter.Fill(tabel);
                return tabel;
            }
        }
    }
}
