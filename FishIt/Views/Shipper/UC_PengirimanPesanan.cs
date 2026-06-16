using FishIt.Helpers;
using FishIt.Controllers.Shipper;
using FishIt.Views.Shipper;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    // View implement IPengirimanPesanan. Tugasnya hanya tampilan + meneruskan aksi ke Controller.
    // Tidak ada query database di sini — semua di Model.
    public partial class UC_PengirimanPesanan : UserControl, IPengirimanPesanan
    {
        private readonly CPengirimanPesanan _controller;

        public UC_PengirimanPesanan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengiriman);
            new AutoScaleHelper(this);
            _controller = new CPengirimanPesanan(this);
        }

        private void UC_PengirimanPesanan_Load(object sender, EventArgs e)
        {
            _controller.MuatData(Session.IdAkun);
        }

        /// <summary> Ambil id_pengiriman + status baris terpilih. -1 kalau belum pilih. </summary>
        private int AmbilIdTerpilih(out string statusSekarang)
        {
            statusSekarang = "";
            if (DGVPengiriman.CurrentRow == null) return -1;

            var rowId = DGVPengiriman.CurrentRow.Cells["ID"].Value;
            if (rowId == null || rowId == DBNull.Value) return -1;

            statusSekarang = DGVPengiriman.CurrentRow.Cells["Status"].Value?.ToString() ?? "";
            return Convert.ToInt32(rowId);
        }

        private void btnMulaiKirim_Click(object sender, EventArgs e)
        {
            int id = AmbilIdTerpilih(out string status);
            if (id == -1)
            {
                TampilkanPesanInfo("Pilih dulu baris pengiriman yang mau dikirim.");
                return;
            }
            if (status != "Diproses")
            {
                TampilkanPesanInfo("Hanya pesanan berstatus 'Diproses' yang bisa mulai dikirim.");
                return;
            }
            _controller.MulaiKirim(id, Session.IdAkun);
        }

        private void btnTandaiDiterima_Click(object sender, EventArgs e)
        {
            int id = AmbilIdTerpilih(out string status);
            if (id == -1)
            {
                TampilkanPesanInfo("Pilih dulu baris pengiriman yang mau ditandai diterima.");
                return;
            }
            if (status != "Dikirim")
            {
                TampilkanPesanInfo("Hanya pesanan berstatus 'Dikirim' yang bisa ditandai diterima.");
                return;
            }
            _controller.TandaiDiterima(id, Session.IdAkun);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _controller.MuatData(Session.IdAkun);
        }

        // ---- IMPLEMENTASI INTERFACE ----

        public void SetDataPengiriman(DataTable data)
        {
            DGVPengiriman.DataSource = data;
            if (DGVPengiriman.Columns.Contains("ID"))
                DGVPengiriman.Columns["ID"].Visible = false;
        }

        public void TampilkanPesanInfo(string pesan) =>
            MessageBox.Show(pesan, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void TampilkanPesanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}