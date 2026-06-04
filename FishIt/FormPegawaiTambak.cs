using FishIt.UserControls.PegawaiTambak;
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
            // 1. Gunakan ClientSize, bukan Size (karena perhitungan di Resize pakai ClientSize)
            originalFormSize = this.ClientSize;

            // 2. Simpan SEMUA data ukuran dan font asli di sini (HANYA SEKALI)
            SaveFonts(this);
            SaveBounds(this);
            //originalFontSize = buttonLogin.Font.Size;

            // 3. Konfigurasi UI lainnya
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ActiveControl = null;
            // 4. DAFTARKAN EVENT RESIZE SETELAH SEMUA UKURAN ASLI DISIMPAN
            this.Resize += new System.EventHandler(this.FormPegawaiTambak_Resize);

            // 5. Baru lakukan Maximize. 
            // Ini akan otomatis memicu FormPegawaiTambak_Resize dan memperbesar semuanya dengan benar.
            this.WindowState = FormWindowState.Maximized;
        }

        private void FormPegawaiTambak_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardPegawaiTambak());
            DebugControls(this);
            panelContent.Visible = false;
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panelContent.Controls.Add(page);
        }

        private void FormPegawaiTambak_Resize(object sender, EventArgs e)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;

            float scale = Math.Min(xRatio, yRatio);

            ResizeControls(this, xRatio, yRatio);
            ResizeFonts(this, scale);

            //UpdateButtonRadius();
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
                    // Ambil ukuran asli, kalikan dengan skala (scale)
                    float newSize = OriginalFonts[control] * scale;

                    // Pastikan font tidak menjadi lebih kecil dari 1 (mencegah error crash)
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

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardPegawaiTambak());
            panelContent.Controls.Clear();

            UC_DashboardPegawaiTambak dashboard = new UC_DashboardPegawaiTambak();

            dashboard.Dock = DockStyle.Fill;

            panelContent.Controls.Add(dashboard);
        }

        private void buttonPanenIkan_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_PanenIkan());
            panelContent.Controls.Clear();

            UC_PanenIkan panenIkan = new UC_PanenIkan();

            panenIkan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(panenIkan);
        }

        private void buttonPenebaran_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_PenebaranBenihIkan());
            panelContent.Controls.Clear();

            UC_PenebaranBenihIkan penebaran = new UC_PenebaranBenihIkan();

            penebaran.Dock = DockStyle.Fill;

            panelContent.Controls.Add(penebaran);
        }

        private void buttonPemberianPakan_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_PemberianPakan());
            panelContent.Controls.Clear();

            UC_PemberianPakan pemberianPakan = new UC_PemberianPakan();

            pemberianPakan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(pemberianPakan);
        }

        private void buttonMonitoring_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Monitoring());
            panelContent.Controls.Clear();

            UC_Monitoring monitoring = new UC_Monitoring();

            monitoring.Dock = DockStyle.Fill;

            panelContent.Controls.Add(monitoring);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
