using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_StokIkan : UserControl, IStokIkan
    {
        private CStokIkan _controller;

        public UC_StokIkan()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahIkan, 25);
            PanelHelper.BuatMelengkung(panelJumlahBenih, 25);
            PanelHelper.BuatMelengkung(panelJumlahPakan, 25);
            PanelHelper.BuatMelengkung(panelStatistikIkan, 25);
            PanelHelper.BuatMelengkung(panelStatistikBenih, 25);
            PanelHelper.BuatMelengkung(panelStatistikPakan, 25);
            PanelHelper.MakeButtonRounded(btnDetailIkan, 20);
            PanelHelper.MakeButtonRounded(btnDetailBenih, 20);
            PanelHelper.MakeButtonRounded(btnDetailPakan, 20);
            new AutoScaleHelper(this);

            _controller = new CStokIkan(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetRingkasan(decimal totalIkan, decimal totalBenih, decimal totalPakan)
        {
            lblHitungIkan.Text = totalIkan.ToString();
            lblHitungBenih.Text = totalBenih.ToString("0");   // ekor bulat
            lblHitungPakan.Text = totalPakan.ToString();
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show("Gagal memuat data: " + pesan, "Database Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDetailIkan_Click(object sender, EventArgs e) { new FormDetailIkan().ShowDialog(); }
        private void btnDetailBenih_Click(object sender, EventArgs e) { new FormDetailBenih().ShowDialog(); }
        private void btnDetailPakan_Click(object sender, EventArgs e) { new FormDetailPakan().ShowDialog(); }
    }
}