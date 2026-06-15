using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KelolaAkun : UserControl, IKelolaAkun
    {
        private CKelolaAkun _controller;

        public UC_KelolaAkun()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahAkun, 25);
            PanelHelper.BuatMelengkung(panelStatistik, 25);
            PanelHelper.MakeButtonRounded(btnTambahAkun, 20);
            PanelHelper.MakeButtonRounded(btnHapus, 20);
            new AutoScaleHelper(this);

            _controller = new CKelolaAkun(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataRiwayat(DataTable data)
        {
            DGVRiwayatTambahAkun.DataSource = data;
            GridHelper.AturTemaModern(DGVRiwayatTambahAkun);
            if (DGVRiwayatTambahAkun.Columns["Aktivitas"] != null)
                DGVRiwayatTambahAkun.Columns["Aktivitas"].Width = 300;
        }

        public void SetRingkasan(int aktif, int tidakAktif)
        {
            lblHitungAkunAktif.Text = aktif.ToString();
            lblHitungAkunTidakAktif.Text = tidakAktif.ToString();
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show("Terjadi kesalahan: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTambahAkun_Click(object sender, EventArgs e)
        {
            using (var f = new FormTambahAkun())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            using (var f = new FormHapusAkun())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}