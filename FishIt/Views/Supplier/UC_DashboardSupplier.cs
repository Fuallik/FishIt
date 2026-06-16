using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_DashboardSupplier : UserControl, IDashboardSupplier
    {
        private readonly CDashboardSupplier _controller;

        public UC_DashboardSupplier()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelMenunggu, 20);
            PanelHelper.BuatMelengkung(panelDisetujui, 20);
            PanelHelper.BuatMelengkung(panelDitolak, 20);
            new AutoScaleHelper(this);
            _controller = new CDashboardSupplier(this);
        }

        private void UC_DashboardSupplier_Load(object sender, EventArgs e)
        {
            _controller.MuatRingkasan(Session.IdAkun, Session.Username);
        }

        // ---- IMPLEMENTASI INTERFACE ----

        public void SetRingkasan(int menunggu, int disetujui, int ditolak)
        {
            lblAngkaMenunggu.Text = menunggu.ToString();
            lblAngkaDisetujui.Text = disetujui.ToString();
            lblAngkaDitolak.Text = ditolak.ToString();
        }

        public void SetUsername(string username) => lblUsername.Text = username;

        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}