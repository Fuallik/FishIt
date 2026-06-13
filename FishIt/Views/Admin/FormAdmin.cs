using FishIt.Helpers;
using FishIt.Views.Admin;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            new AutoScaleHelper(this);

            panelSubKelolaAkun.Visible = false;
            panelSubDataFishIt.Visible = false;
            panelSubLaporan.Visible = false;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardAdmin());
            if (!string.IsNullOrEmpty(Session.Username))
            {
                lblUsernameTopbar.Text = Session.Username;
            }
            else
            {
                lblUsernameTopbar.Text = "Guest";
            }
        }

        private void LoadPage(System.Windows.Forms.UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLogoutAdmin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDashboard_Click_1(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardAdmin());
            panelContent.Controls.Clear();

            UC_DashboardAdmin dashboard = new UC_DashboardAdmin();

            dashboard.Dock = DockStyle.Fill;

            panelContent.Controls.Add(dashboard);
            buttonDashboard.MouseEnter += SidebarButton_MouseEnter;
            buttonDashboard.MouseLeave += SidebarButton_MouseLeave;
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

        private void buttonKelolaAkun_Click(object sender, EventArgs e)
        {
            panelSubKelolaAkun.Visible = !panelSubKelolaAkun.Visible;

            buttonKelolaAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonKelolaAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonTambahAkun_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_KelolaAkun tambahAkun = new UC_KelolaAkun();
            tambahAkun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(tambahAkun);

            buttonTambahAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonTambahAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLogoutAdmin_Click_1(object sender, EventArgs e)
        {
            Application.Restart();

            buttonLogoutAdmin.MouseEnter += SidebarButton_MouseEnter;
            buttonLogoutAdmin.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonIkan_Click(object sender, EventArgs e)
        {
            panelSubDataFishIt.Visible = !panelSubDataFishIt.Visible;

            buttonIkan.MouseEnter += SidebarButton_MouseEnter;
            buttonIkan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLaporan_Click(object sender, EventArgs e)
        {
            panelSubLaporan.Visible = !panelSubLaporan.Visible;

            buttonLaporan.MouseEnter += SidebarButton_MouseEnter;
            buttonLaporan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonMonitoring_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_Monitoring monitoring = new UC_Monitoring();
            monitoring.Dock = DockStyle.Fill;

            panelContent.Controls.Add(monitoring);

            buttonMonitoring.MouseEnter += SidebarButton_MouseEnter;
            buttonMonitoring.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonVerifikasi_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_VerifikasiSupply verifikasi = new UC_VerifikasiSupply();
            verifikasi.Dock = DockStyle.Fill;

            panelContent.Controls.Add(verifikasi);

            buttonVerifikasi.MouseEnter += SidebarButton_MouseEnter;
            buttonVerifikasi.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonPengiriman_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_Pengiriman pengiriman = new UC_Pengiriman();
            pengiriman.Dock = DockStyle.Fill;

            panelContent.Controls.Add(pengiriman);

            buttonPengiriman.MouseEnter += SidebarButton_MouseEnter;
            buttonPengiriman.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonStokIkan_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_StokIkan stokIkan = new UC_StokIkan();
            stokIkan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(stokIkan);

            buttonStokIkan.MouseEnter += SidebarButton_MouseEnter;
            buttonStokIkan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonKolam_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_DataKolam kolam = new UC_DataKolam();
            kolam.Dock = DockStyle.Fill;

            panelContent.Controls.Add(kolam);

            buttonKolam.MouseEnter += SidebarButton_MouseEnter;
            buttonKolam.MouseLeave += SidebarButton_MouseLeave;
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TBSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDataAkun_Click(object sender, EventArgs e)
        {
            UC_DataAkun akun = new UC_DataAkun();
            akun.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();
            panelContent.Controls.Add(akun);

            buttonKelolaAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonKelolaAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void btnPanen_Click(object sender, EventArgs e)
        {
            UC_HargaPanen panen = new UC_HargaPanen();
            panen.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();
            panelContent.Controls.Add(panen);

            buttonKelolaAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonKelolaAkun.MouseLeave += SidebarButton_MouseLeave;
        }
    }
}
