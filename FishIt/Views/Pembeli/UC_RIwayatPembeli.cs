using FishIt.Helpers;
using FishIt.Controllers.Pembeli;
using FishIt.Views.Pembeli;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_RIwayatPembeli : UserControl, IRiwayatPembeli
    {
        private CRiwayatPembeli _controller;

        public UC_RIwayatPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            _controller = new CRiwayatPembeli(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVRiwayatPembeli.DataSource = data;
            DGVRiwayatPembeli.Columns["id_order"].HeaderText = "ID Order";
            DGVRiwayatPembeli.Columns["tanggal_order"].HeaderText = "Tanggal Order";
            DGVRiwayatPembeli.Columns["total_harga"].HeaderText = "Total Harga";
            DGVRiwayatPembeli.Columns["nama_status"].HeaderText = "Status Order";
            DGVRiwayatPembeli.Columns["jenis_metode_pembayaran"].HeaderText = "Metode Pembayaran";
            GridHelper.AturTemaModern(DGVRiwayatPembeli);
        }

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat riwayat: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}