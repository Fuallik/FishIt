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
                string query = @"SELECT p.id_pengiriman_supplier, a.nama, p.nama AS nama_ikan, p.kuantitas, p.tipe, p.tanggal_kirim, p.status_verifikasi, p.tanggal_verifikasi
                         FROM pengiriman_supplier p
                         JOIN akun a ON p.id_akun = a.id_akun
                         WHERE p.id_pengiriman_supplier = @id_p AND p.status_verifikasi = 'Pending' ";

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
                                    string namaSupplier = reader["nama"].ToString();
                                    string namaPengiriman = reader["nama"].ToString();
                                    int kuantitas = Convert.ToInt32(reader["kuantitas"]);
                                    string tipe = reader["tipe"].ToString();
                                    string tanggalKirim = Convert.ToDateTime(reader["tanggal_kirim"]).ToString("yyyy-MM-dd");
                                    string statusVerifikasi = reader["status_verifikasi"].ToString();
                                    string tanggalVerifikasi = reader["tanggal_verifikasi"] == DBNull.Value ? "Belum Diverifikasi" : Convert.ToDateTime(reader["tanggal_verifikasi"]).ToString("yyyy-MM-dd");

                                    // 4. Buka USER CONTROL DETAIL dan kirim datanya lewat Constructor
                                    Form FormInduk = this.FindForm();
                                    Panel pnlKonten = (Panel)FormInduk.Controls.Find("panelKontenAdmin", true)[0]; // Sesuaikan nama panel adminmu

                                    // Kita oper semua data ke Constructor UC Detail
                                    UC_DetailVerifikasi ucDetail = new UC_DetailVerifikasi(
                                        idPengajuan, kuantitas, tipe, tanggalKirim, statusVerifikasi, tanggalVerifikasi, namaSupplier
                                    );

                                    // Tampilkan UC Detail ke panel utama
                                    PanelHelper.ShowUserControl(pnlKonten, ucDetail);
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
