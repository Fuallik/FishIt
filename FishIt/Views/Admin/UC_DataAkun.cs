using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_DataAkun : UserControl, IDataAkun
    {
        private CDataAkun _controller;

        public UC_DataAkun()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahAkun, 25);
            PanelHelper.BuatMelengkung(panelAkunTambak, 25);
            PanelHelper.BuatMelengkung(panelAkunKasir, 25);
            PanelHelper.BuatMelengkung(panelShipper, 25);
            PanelHelper.BuatMelengkung(panelAkunSupplier, 25);
            PanelHelper.BuatMelengkung(panelAkunPembeli, 25);
            PanelHelper.BuatMelengkung(panelStatistik, 25);
            new AutoScaleHelper(this);

            _controller = new CDataAkun(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVDataAkun.DataSource = data;
            DGVDataAkun.Columns["id_akun"].HeaderText = "ID Pengguna";
            DGVDataAkun.Columns["username"].HeaderText = "Nama Pengguna";
            DGVDataAkun.Columns["nama"].HeaderText = "Nama Lengkap";
            DGVDataAkun.Columns["no_telp"].HeaderText = "No. Telepon";
            DGVDataAkun.Columns["alamat"].HeaderText = "Alamat";
            DGVDataAkun.Columns["nama_role"].HeaderText = "Hak Akses";
            DGVDataAkun.Columns["aktif"].HeaderText = "Status Aktif";
            GridHelper.AturTemaModern(DGVDataAkun);
        }

        public void SetRingkasan(int aktif, int tidakAktif, int tambak,
                                 int kasir, int supplier, int shipper, int pembeli)
        {
            lblHitungAkunAktif.Text = aktif.ToString();
            lblHitungAkunTidakAKtif.Text = tidakAktif.ToString();
            TotalTambakKelola.Text = tambak.ToString();
            TotalKasirKelola.Text = kasir.ToString();
            TotalSupplierKelola.Text = supplier.ToString();
            TotalShipperKelola.Text = shipper.ToString();
            TotalPembeliKelola.Text = pembeli.ToString();
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show("Gagal memuat data: " + pesan, "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}