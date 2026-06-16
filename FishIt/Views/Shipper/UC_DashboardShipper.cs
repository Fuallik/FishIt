using FishIt.Helpers;
using FishIt.Controllers.Shipper;
using FishIt.Views.Shipper;
using System;
using System.Windows.Forms;

namespace FishIt.UserControls.Shipper
{
    public partial class UC_DashboardShipper : UserControl, IDashboardShipper
    {
        private readonly CDashboardShipper _controller;

        public UC_DashboardShipper()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelDiproses, 20);
            PanelHelper.BuatMelengkung(panelDikirim, 20);
            PanelHelper.BuatMelengkung(panelSelesai, 20);
            new AutoScaleHelper(this);
            _controller = new CDashboardShipper(this);
        }

        private void UC_DashboardShipper_Load(object sender, EventArgs e)
        {
            _controller.MuatRingkasan(Session.IdAkun, Session.Username);
        }

        public void SetRingkasan(int diproses, int dikirim, int diterima)
        {
            lblAngkaDiproses.Text = diproses.ToString();
            lblAngkaDikirim.Text = dikirim.ToString();
            lblAngkaSelesai.Text = diterima.ToString();
        }

        public void SetUsername(string username)
        {
            lblUsername.Text = username;
        }

        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}