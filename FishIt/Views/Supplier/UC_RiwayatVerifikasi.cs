using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_RiwayatVerifikasi : UserControl, IRiwayatVerifikasi
    {
        private readonly CRiwayatVerifikasi _controller;

        public UC_RiwayatVerifikasi()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVRiwayat);
            new AutoScaleHelper(this);
            _controller = new CRiwayatVerifikasi(this);
        }

        private void UC_RiwayatVerifikasi_Load(object sender, EventArgs e) =>
            _controller.MuatRiwayat(Session.IdAkun);
        private void btnRefresh_Click(object sender, EventArgs e) =>
            _controller.MuatRiwayat(Session.IdAkun);

        public void SetRiwayat(DataTable data) => DGVRiwayat.DataSource = data;
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}