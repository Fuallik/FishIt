using FishIt.Helpers;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_PanenIkan : UserControl, IPanenIkan
    {
        private CPanenIkan _controller;

        public UC_PanenIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPanen);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panel2, 25);
            PanelHelper.BuatMelengkung(panel3, 25);
            PanelHelper.BuatMelengkung(panel4, 25);
            PanelHelper.MakeButtonRounded(buttonTambahPanen, 25);

            _controller = new CPanenIkan(this);
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); _controller.MuatData(); }

        public void SetDataGrid(DataTable data)
        {
            DGVPanen.DataSource = data;
            if (DGVPanen.Columns.Contains("id_akun")) DGVPanen.Columns["id_akun"].Visible = false;
        }
        public void SetRingkasan(decimal akumulasi, decimal tahun)
        {
            labelAkumulasiPerAkun.Text = akumulasi.ToString("N2") + " kg";
            labelPerTahunPerAkun.Text = tahun.ToString("N2") + " kg";
        }
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat data: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void buttonTambahPanen_Click(object sender, EventArgs e)
        {
            using (var f = new FormPengajuanPanenIkan())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}