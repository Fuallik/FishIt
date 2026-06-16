using FishIt.Helpers;
using FishIt.Controllers.Kasir;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.Views.Kasir
{
    public partial class UC_RiwayatPembayaran : UserControl, IRiwayatPembayaran
    {
        private CRiwayatPembayaran _controller;

        public UC_RiwayatPembayaran()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVDetail);
            GridHelper.AturTemaModern(DGVRiwayat);
            PanelHelper.BuatMelengkung(panel1, 20);
            PanelHelper.BuatMelengkung(panel6, 20);

            _controller = new CRiwayatPembayaran(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        private void DGVRiwayat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idOrder = Convert.ToInt32(DGVRiwayat.Rows[e.RowIndex].Cells["id_order"].Value);
            decimal total = Convert.ToDecimal(DGVRiwayat.Rows[e.RowIndex].Cells["total_harga"].Value);
            labelTotal.Text = "Rp " + total.ToString("N2");

            _controller.MuatDetail(idOrder);
        }
        public void SetDataGrid(DataTable data)
        {
            DGVRiwayat.DataSource = data;
            if (DGVRiwayat.Columns["id_order"] != null) DGVRiwayat.Columns["id_order"].HeaderText = "ID Order";
            if (DGVRiwayat.Columns["tanggal_order"] != null) DGVRiwayat.Columns["tanggal_order"].HeaderText = "Tanggal Transaksi";
            if (DGVRiwayat.Columns["nama_pembeli"] != null) DGVRiwayat.Columns["nama_pembeli"].HeaderText = "Nama Pembeli";
            if (DGVRiwayat.Columns["total_harga"] != null) DGVRiwayat.Columns["total_harga"].HeaderText = "Total Bayar";
            GridHelper.AturTemaModern(DGVRiwayat);
        }

        public void SetDetail(DataTable data)
        {
            DGVDetail.DataSource = data;
            GridHelper.AturTemaModern(DGVDetail);
        }

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat riwayat pembayaran: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}