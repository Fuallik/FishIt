using FishIt.Helpers;
using FishIt.Controllers.Shipper;
using FishIt.Views.Shipper;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    public partial class UC_RiwayatPengirimanPesanan : UserControl, IRiwayatPengiriman
    {
        private readonly CRiwayatPengiriman _controller;

        public UC_RiwayatPengirimanPesanan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVRiwayat);
            new AutoScaleHelper(this);
            _controller = new CRiwayatPengiriman(this);
        }

        private void UC_RiwayatPengirimanPesanan_Load(object sender, EventArgs e)
        {
            _controller.MuatRiwayat(Session.IdAkun);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _controller.MuatRiwayat(Session.IdAkun);
        }

        // ---- IMPLEMENTASI INTERFACE ----

        public void SetDataRiwayat(DataTable data)
        {
            DGVRiwayat.DataSource = data;
        }

        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}