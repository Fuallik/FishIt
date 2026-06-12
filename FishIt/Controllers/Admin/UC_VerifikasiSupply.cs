using FishIt.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_VerifikasiSupply : UserControl
    {
        public UC_VerifikasiSupply()
        {
            InitializeComponent();
            TBIDPengajuan.MaxLength = 50;
            TBIDPengajuan.PlaceholderText = "Ketik ID Pengajuan di sini...";
            TBIDPengajuan.KeyDown += TBIDPengajuan_KeyDown;

            new AutoScaleHelper(this);
        }

        private void UC_VerifikasiSupply_Load(object sender, EventArgs e)
        {
            MuatPengajuanSupplier();
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }
        private void MuatPengajuanSupplier()
        {
            string query = @"SELECT p.id_pengiriman_supplier, a.nama,  p.nama, p.kuantitas, p.tipe, p.tanggal_kirim, p.status_verifikasi, p.tanggal_verifikasi
                             FROM pengiriman_supplier p
                             JOIN akun a ON p.id_akun = a.id_akun
                             WHERE p.status_verifikasi = 'Pending'
                             ORDER BY p.id_pengiriman_supplier ASC";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                try
                {
                    conn.Open();
                    using (var da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DGVPengajuan.DataSource = dt;

                        GridHelper.AturTemaModern(DGVPengajuan);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data pengajuan: " + ex.Message);
                }
            }
        }
        private void TBIDPengajuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string idInputText = TBIDPengajuan.Text.Trim();

                if (string.IsNullOrWhiteSpace(idInputText))
                {
                    MessageBox.Show("ID Pengajuan tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string query = @"SELECT p.id_pengiriman_supplier, p.id_benih, p.id_pakan, a.nama AS nama_supplier, 
                                p.nama AS nama_barang, p.kuantitas, p.tipe, p.tanggal_kirim, p.status_verifikasi, p.tanggal_verifikasi
                                FROM pengiriman_supplier p
                                JOIN akun a ON p.id_akun = a.id_akun
                                WHERE p.id_pengiriman_supplier = @id_p AND p.status_verifikasi = 'Pending'";

                using (var conn = new NpgsqlConnection(Config.ConnString))
                {
                    try
                    {
                        conn.Open();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_p", Convert.ToInt32(idInputText));

                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int idPengajuan = Convert.ToInt32(reader["id_pengiriman_supplier"]);
                                    int idBenih = reader["id_benih"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id_benih"]);
                                    int idPakan = reader["id_pakan"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id_pakan"]);

                                    string namaSupplier = reader["nama_supplier"].ToString();
                                    string namaPengiriman = reader["nama_barang"].ToString();
                                    int kuantitas = Convert.ToInt32(reader["kuantitas"]);
                                    string tipe = reader["tipe"].ToString();
                                   
                                    string statusVerifikasi = reader["status_verifikasi"].ToString();
                                   


                                    string tanggalKirim = "";
                                    if (reader["tanggal_kirim"] is DateOnly dateKirim)
                                    {
                                        tanggalKirim = dateKirim.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        tanggalKirim = Convert.ToDateTime(reader["tanggal_kirim"]).ToString("yyyy-MM-dd");
                                    }

                                    string tanggalVerifikasi = "Belum Diverifikasi";
                                    if (reader["tanggal_verifikasi"] != DBNull.Value)
                                    {
                                        if (reader["tanggal_verifikasi"] is DateOnly dateVerif)
                                        {
                                            tanggalVerifikasi = dateVerif.ToString("yyyy-MM-dd");
                                        }
                                        else
                                        {
                                            tanggalVerifikasi = Convert.ToDateTime(reader["tanggal_verifikasi"]).ToString("yyyy-MM-dd");
                                        }
                                    }
                                    using (FormDetailVerifikasi popUp = new FormDetailVerifikasi(idPengajuan, idBenih, idPakan, namaPengiriman, kuantitas, tipe, tanggalKirim, statusVerifikasi, tanggalVerifikasi, namaSupplier))
                                    {
                                        popUp.StartPosition = FormStartPosition.CenterParent;
                                        if (popUp.ShowDialog() == DialogResult.OK)
                                        {
                                            TBIDPengajuan.Clear();
                                            MuatPengajuanSupplier();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show($"Pengajuan dengan ID '{idInputText}' tidak ditemukan atau sudah diproses!",
                                                    "Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TBIDPengajuan.Clear();
                                    TBIDPengajuan.Focus();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat detail pengajuan:\n" + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDetailVerifikasi_Click(object sender, EventArgs e)
        {

        }

        private void TBIDPengajuan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
