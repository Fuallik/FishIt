using FishIt.Helpers;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_PemberianPakan : UserControl, IPemberianPakan
    {
        private CPemberianPakan _controller;

        public UC_PemberianPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPakan);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panel1, 25);
            PanelHelper.BuatMelengkung(panel2, 25);
            PanelHelper.BuatMelengkung(panel6, 25);
            PanelHelper.MakeButtonRounded(buttonPemberianPakan, 25);

            _controller = new CPemberianPakan(this);
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); _controller.MuatData(); }

        public void SetDataGrid(DataTable data)
        {
            DGVPakan.DataSource = data;
            if (DGVPakan.Columns.Contains("id_akun")) DGVPakan.Columns["id_akun"].Visible = false;
        }
        public void SetRingkasan(decimal akumulasi, decimal bulan)
        {
            labelTotalAkumulasiPerAkun.Text = akumulasi.ToString("N2") + " kg";
            labelTotalPerBulanPerAkun.Text = bulan.ToString("N2") + " kg";
        }
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat data: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void buttonPemberianPakan_Click(object sender, EventArgs e)
        {
            using (var f = new FormTambahPemberianPakan())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}