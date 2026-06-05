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
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> OriginalFonts = new Dictionary<Control, float>();
        private float originalFontSize;
        public FormPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ActiveControl = null;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPembeli_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardAdmin());;
            panelContent.Visible = false;
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();

            page.Dock = DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
