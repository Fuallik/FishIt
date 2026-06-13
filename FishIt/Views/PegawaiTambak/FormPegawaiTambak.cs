using FishIt.UserControls.PegawaiTambak;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormPegawaiTambak : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> OriginalFonts = new Dictionary<Control, float>();
        private float originalFontSize;
        public FormPegawaiTambak()
        {
            InitializeComponent();
           new AutoScaleHelper(this);

            panelSubKelolaAkun.Visible = false;
            panelSubDataFishIt.Visible = false;
        }

        private void FormPegawaiTambak_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardPegawaiTambak());
        }

        private void LoadPage(System.Windows.Forms.UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;
            btn.BackColor = Color.RoyalBlue;
        }

        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;
            btn.BackColor = Color.CornflowerBlue;
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardPegawaiTambak());
            panelContent.Controls.Clear();

            UC_DashboardPegawaiTambak dashboard = new UC_DashboardPegawaiTambak();

            dashboard.Dock = DockStyle.Fill;

            panelContent.Controls.Add(dashboard);
        }

        private void buttonOperasi_Click(object sender, EventArgs e)
        {
            panelSubKelolaAkun.Visible = !panelSubKelolaAkun.Visible;

            buttonOperasi.MouseEnter += SidebarButton_MouseEnter;
            buttonOperasi.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonMonitoring_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_MonitoringIkan monitoring = new UC_MonitoringIkan();
            monitoring.Dock = DockStyle.Fill;

            panelContent.Controls.Add(monitoring);

            buttonMonitoring.MouseEnter += SidebarButton_MouseEnter;
            buttonMonitoring.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonPemberianPakan_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_PemberianPakan pemberianPakan = new UC_PemberianPakan();
            pemberianPakan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(pemberianPakan);

            buttonPemberianPakan.MouseEnter += SidebarButton_MouseEnter;
            buttonPemberianPakan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonPenebaran_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_PenebaranBenihIkan penebaranbenihikan = new UC_PenebaranBenihIkan();
            penebaranbenihikan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(penebaranbenihikan);

            buttonPenebaran.MouseEnter += SidebarButton_MouseEnter;
            buttonPenebaran.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonPanenIkan_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_PanenIkan panenIkan = new UC_PanenIkan();
            panenIkan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(panenIkan);

            buttonPanenIkan.MouseEnter += SidebarButton_MouseEnter;
            buttonPanenIkan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonInformasi_Click(object sender, EventArgs e)
        {
            panelSubDataFishIt.Visible = !panelSubDataFishIt.Visible;

            buttonInformasi.MouseEnter += SidebarButton_MouseEnter;
            buttonInformasi.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonStatusKolam_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_StatusKolam statusKolam = new UC_StatusKolam();
            statusKolam.Dock = DockStyle.Fill;

            panelContent.Controls.Add(statusKolam);

            buttonStatusKolam.MouseEnter += SidebarButton_MouseEnter;
            buttonStatusKolam.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonStok_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_InfoStok infoStok = new UC_InfoStok();
            infoStok.Dock = DockStyle.Fill;

            panelContent.Controls.Add(infoStok);

            buttonStok.MouseEnter += SidebarButton_MouseEnter;
            buttonStok.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();

            buttonLogout.MouseEnter += SidebarButton_MouseEnter;
            buttonLogout.MouseLeave += SidebarButton_MouseLeave;
        }
    }
}
