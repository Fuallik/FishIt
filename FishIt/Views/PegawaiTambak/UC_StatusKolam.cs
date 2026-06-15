using FishIt.Helpers;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_StatusKolam : UserControl, IStatusKolam
    {
        private CStatusKolam _controller;

        public UC_StatusKolam()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVStatusKolam);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panel1, 25);
            PanelHelper.BuatMelengkung(panel2, 25);
            PanelHelper.BuatMelengkung(panel3, 25);
            PanelHelper.BuatMelengkung(panel4, 25);

            _controller = new CStatusKolam(this);
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); _controller.MuatData(); }

        public void SetDataGrid(DataTable data) => DGVStatusKolam.DataSource = data;
        public void SetRingkasan(int terisi, int kosong, int tidakTerpakai)
        {
            labelTerisi.Text = terisi.ToString();
            labelKosong.Text = kosong.ToString();
            labelTidakTerpakai.Text = tidakTerpakai.ToString();
        }
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat status kolam: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}