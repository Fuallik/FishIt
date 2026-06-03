using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormAdmin : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> OriginalFonts = new Dictionary<Control, float>();
        private float originalFontSize;
        public FormAdmin()
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
            this.Resize += new System.EventHandler(this.FormAdmin_Resize);

            // 5. Baru lakukan Maximize. 
            // Ini akan otomatis memicu FormAdmin_Resize dan memperbesar semuanya dengan benar.
            this.WindowState = FormWindowState.Maximized;
        }
         
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardAdmin());
            DebugControls(this);
            panelContent.Visible = true;
        }

        private void LoadPage(UserControl page)
        {
            panelContent.Controls.Clear();

            page.Dock = DockStyle.Fill;

            panelContent.Controls.Add(page);
        }

        private void FormAdmin_Resize(object sender, EventArgs e)
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


        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_DashboardAdmin());
            panelContent.Controls.Clear();

            UC_DashboardAdmin dashboard = new UC_DashboardAdmin();

            dashboard.Dock = DockStyle.Fill;

            panelContent.Controls.Add(dashboard);
        }

        private void panelCT_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonKlAkun_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_KelolaAkun akun = new UC_KelolaAkun();

            akun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(akun);

            panelSubKelolaAkun.Visible = !panelSubKelolaAkun.Visible;
        }

        private void buttonTambahAkun_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_TambahAkun());
        }

        private void buttonEditAkun_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_EditAkun());
        }

        private void buttonHapusAkun_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_HapusAkun());
        }

        private void panelSB_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonKelolaDataKolam_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_KelolaDataKolam kelolaDataKolam = new UC_KelolaDataKolam();

            kelolaDataKolam.Dock = DockStyle.Fill;

            panelContent.Controls.Add(kelolaDataKolam);
        }

        private void buttonVerifikasiSupply_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_VerifikasiSupply verifikasiSupply = new UC_VerifikasiSupply();

            verifikasiSupply.Dock = DockStyle.Fill;

            panelContent.Controls.Add(verifikasiSupply);
        }

        private void buttonLaporanMonitoring_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_LaporanMonitoring laporanMonitoring = new UC_LaporanMonitoring();

            laporanMonitoring.Dock = DockStyle.Fill;

            panelContent.Controls.Add(laporanMonitoring);
        }

        private void buttonLogoutAdmin_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
