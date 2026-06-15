using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_Pengiriman : UserControl, IPengiriman
    {
        private CPengiriman _controller;

        public UC_Pengiriman()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelDiproses, 20);
            PanelHelper.BuatMelengkung(panelDikirim, 20);
            PanelHelper.BuatMelengkung(panelDiterima, 20);
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVPengiriman);

            _controller = new CPengiriman(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVPengiriman.DataSource = data;
            GridHelper.AturTemaModern(DGVPengiriman);
            if (DGVPengiriman.Columns.Contains("ID"))
                DGVPengiriman.Columns["ID"].Visible = false;
        }

        public void SetRingkasan(int diproses, int dikirim, int diterima)
        {
            labelDiproses.Text = diproses.ToString();
            labelDikirim.Text = dikirim.ToString();
            labelDiterima.Text = diterima.ToString();
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show("Gagal memuat data: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}