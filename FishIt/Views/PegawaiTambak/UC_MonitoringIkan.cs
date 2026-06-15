using FishIt.Helpers;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_MonitoringIkan : UserControl, IMonitoringIkan
    {
        private CMonitoringIkan _controller;

        public UC_MonitoringIkan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVMonitoringIkan);
            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panelMonitoring, 25);
            PanelHelper.BuatMelengkung(panelHari, 25);
            PanelHelper.BuatMelengkung(panelBulan, 25);
            PanelHelper.MakeButtonRounded(buttonTambahMonitoring, 25);

            _controller = new CMonitoringIkan(this);
        }

        protected override void OnLoad(EventArgs e) { base.OnLoad(e); _controller.MuatData(); }

        public void SetDataGrid(DataTable data)
        {
            DGVMonitoringIkan.DataSource = data;
            if (DGVMonitoringIkan.Columns.Contains("id_akun"))
                DGVMonitoringIkan.Columns["id_akun"].Visible = false;
        }
        public void SetRingkasan(int totalBulan, int totalHari)
        {
            labelTotalBulanPerAkun.Text = totalBulan.ToString();
            labelTotalHariPerAkun.Text = totalHari.ToString();
        }
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat data: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void buttonTambahMonitoring_Click(object sender, EventArgs e)
        {
            using (var f = new FormTambahMonitoring())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}