using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_Monitoring : UserControl, IMonitoring
    {
        private CMonitoring _controller;

        public UC_Monitoring()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelMonitoring, 25);
            PanelHelper.BuatMelengkung(panelSatuBulan, 25);
            PanelHelper.BuatMelengkung(panelHariIni, 25);
            new AutoScaleHelper(this);

            _controller = new CMonitoring(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVMonitoring.DataSource = data;
            GridHelper.AturTemaModern(DGVMonitoring);
        }

        public void SetRingkasan(int hariIni, int satuBulan)
        {
            lblHariIni.Text = hariIni.ToString();
            lblSatuBulan.Text = satuBulan.ToString();
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show("Terjadi kesalahan: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}