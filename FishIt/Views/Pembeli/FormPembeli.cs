using FishIt.Helpers;
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
    public partial class FormPembeli : Form
    {
        public FormPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
        }

        private void FormPembeli_Load(object sender, EventArgs e)
        {
            panelKontenPembeli.Visible = true;
            LoadPage(new UC_DashboardPembeli());
            if (!string.IsNullOrEmpty(Session.Username))
            {
                lblUsernameTopbar.Text = Session.Username;
            }
            else
            {
                lblUsernameTopbar.Text = "Guest";
            }
        }
        private void LoadPage(UserControl page)
        {
            panelKontenPembeli.Controls.Clear();

            page.Dock = DockStyle.Fill;

            panelKontenPembeli.Controls.Add(page);
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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {

        }

        private void buttonKatalogIkan_Click(object sender, EventArgs e)
        {
            panelKontenPembeli.Controls.Clear();

            UC_KatalogIkanPembeli katalogIkan = new UC_KatalogIkanPembeli();
            katalogIkan.Dock = DockStyle.Fill;

            panelKontenPembeli.Controls.Add(katalogIkan);

            buttonKatalogIkan.MouseEnter += SidebarButton_MouseEnter;
            buttonKatalogIkan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonKeranjang_Click(object sender, EventArgs e)
        {
            panelKontenPembeli.Controls.Clear();

            UC_Keranjang keranjang = new UC_Keranjang();
            keranjang.Dock = DockStyle.Fill;

            panelKontenPembeli.Controls.Add(keranjang);

            buttonKeranjang.MouseEnter += SidebarButton_MouseEnter;
            buttonKeranjang.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonRiwayat_Click(object sender, EventArgs e)
        {
            panelKontenPembeli.Controls.Clear();

            UC_RIwayatPembeli riwayat = new UC_RIwayatPembeli();
            riwayat.Dock = DockStyle.Fill;

            panelKontenPembeli.Controls.Add(riwayat);

            buttonRiwayat.MouseEnter += SidebarButton_MouseEnter;
            buttonRiwayat.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLogoutAdmin_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void panelContent_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
