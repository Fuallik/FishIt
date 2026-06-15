using FishIt.Helpers;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_PenebaranBenihIkan : UserControl, IPenebaran
    {
        private CPenebaran _controller;

        public UC_PenebaranBenihIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPenebaran);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panel1, 25);
            PanelHelper.BuatMelengkung(panel5, 25);
            PanelHelper.BuatMelengkung(panel6, 25);
            PanelHelper.MakeButtonRounded(buttonTambah, 25);

            _controller = new CPenebaran(this);
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); _controller.MuatData(); }

        public void SetDataGrid(DataTable data)
        {
            DGVPenebaran.DataSource = data;
            if (DGVPenebaran.Columns.Contains("id_akun")) DGVPenebaran.Columns["id_akun"].Visible = false;
        }
        public void SetRingkasan(long akumulasi, long bulan)
        {
            labelTotalAkumulasiPerAkun.Text = akumulasi + " ekor";
            labelTotalPerBulanPerAkun.Text = bulan + " ekor";
        }
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat data: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            using (var f = new FormTambahPenebaranBenih())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}