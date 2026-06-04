using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormSupplier : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> OriginalFonts = new Dictionary<Control, float>();
        private float originalFontSize;
        public FormSupplier()
        {
            InitializeComponent();
            originalFormSize = this.ClientSize;

            SaveFonts(this);
            SaveBounds(this);

            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ActiveControl = null;

            this.Resize += new System.EventHandler(this.FormSupplier_Resize);

            this.WindowState = FormWindowState.Maximized;

        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardSupplier());
            DebugControls(this);
            panelContent.Visible = true;
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();

            page.Dock = DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        private void FormSupplier_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;

            float scale = Math.Min(xRatio, yRatio);

            ResizeControls(this, xRatio, yRatio);
            ResizeFonts(this, scale);

        }

        private void SaveFonts(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                OriginalFonts[control] = control.Font.Size;

                if (control.HasChildren)
                    SaveFonts(control);
            }
        }
        private void ResizeFonts(Control parent, float scale)
        {
            foreach (Control control in parent.Controls)
            {
                if (OriginalFonts.ContainsKey(control))
                {
                    float newSize = OriginalFonts[control] * scale;

                    if (newSize < 1.0f) newSize = 1.0f;

                    control.Font = new Font(
                        control.Font.FontFamily,
                        newSize,
                        control.Font.Style
                    );
                }

                if (control.HasChildren)
                    ResizeFonts(control, scale);
            }
        }
        private void SaveBounds(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                ControlBounds[control] = control.Bounds;

                if (control.HasChildren)
                    SaveBounds(control);
            }
        }

        private void ResizeControls(Control parent, float xRatio, float yRatio)
        {
            foreach (Control control in parent.Controls)
            {
                if (ControlBounds.ContainsKey(control))
                {
                    Rectangle r = ControlBounds[control];

                    control.SetBounds(
                        (int)(r.X * xRatio),
                        (int)(r.Y * yRatio),
                        (int)(r.Width * xRatio),
                        (int)(r.Height * yRatio)
                    );
                }

                if (control.HasChildren)
                    ResizeControls(control, xRatio, yRatio);
            }
        }

        private void DebugControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                Console.WriteLine(c.Name + " - " + c.Font.Size);

                if (c.HasChildren)
                    DebugControls(c);
            }
        }

        private void buttonKatalogSupp_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardSupplier());
        }

        private void buttonLogoutSupp_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonKatalogBenih_Click(object sender, EventArgs e)
        {

        }

        private void buttonKatalogPakan_Click(object sender, EventArgs e)
        {

        }

        private void buttonPengajuanBenih_Click(object sender, EventArgs e)
        {

        }

        private void buttonPengajuanPakan_Click(object sender, EventArgs e)
        {

        }

        private void buttonRiwayatVerifikasi_Click(object sender, EventArgs e)
        {

        }
    }
}
