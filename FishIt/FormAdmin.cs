using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FontAwesome.Sharp;

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

            panelSubKelolaAkun.Visible = false;
            panelSubDataFishIt.Visible = false;
            panelSubLaporan.Visible = false;
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

            UC_DataFishIt kelolaDataKolam = new UC_DataFishIt();

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

            UC_Laporan laporanMonitoring = new UC_Laporan();

            laporanMonitoring.Dock = DockStyle.Fill;

            panelContent.Controls.Add(laporanMonitoring);
        }

        private void buttonLogoutAdmin_Click(object sender, EventArgs e)
        {
            Application.Restart();
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
            panelContent.Controls.Clear();

            UC_KelolaAkun akun = new UC_KelolaAkun();

            akun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(akun);

            panelSubKelolaAkun.Visible = !panelSubKelolaAkun.Visible;

            buttonKelolaAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonKelolaAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonTambahAkun_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_TambahAkun tambahAkun = new UC_TambahAkun();
            tambahAkun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(tambahAkun);

            buttonTambahAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonTambahAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonHapusAkun_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_HapusAkun hapusAkun = new UC_HapusAkun();
            hapusAkun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(hapusAkun);

            buttonHapusAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonHapusAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonEditAkun_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_EditAkun editAkun = new UC_EditAkun();
            editAkun.Dock = DockStyle.Fill;

            panelContent.Controls.Add(editAkun);

            buttonEditAkun.MouseEnter += SidebarButton_MouseEnter;
            buttonEditAkun.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLogoutAdmin_Click_1(object sender, EventArgs e)
        {
            Application.Restart();

            buttonLogoutAdmin.MouseEnter += SidebarButton_MouseEnter;
            buttonLogoutAdmin.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonIkan_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_DataFishIt fishIt = new UC_DataFishIt();
            fishIt.Dock = DockStyle.Fill;

            panelContent.Controls.Add(fishIt);

            panelSubDataFishIt.Visible = !panelSubDataFishIt.Visible;

            buttonIkan.MouseEnter += SidebarButton_MouseEnter;
            buttonIkan.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonLaporan_Click(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_Laporan laporan = new UC_Laporan();
            laporan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(laporan);

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

        private void buttonBenih_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_DataBenih benih = new UC_DataBenih();
            benih.Dock = DockStyle.Fill;

            panelContent.Controls.Add(benih);

            buttonBenih.MouseEnter += SidebarButton_MouseEnter;
            buttonBenih.MouseLeave += SidebarButton_MouseLeave;
        }

        private void buttonPakan_Click_1(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();

            UC_DataPakan pakan = new UC_DataPakan();
            pakan.Dock = DockStyle.Fill;

            panelContent.Controls.Add(pakan);

            buttonPakan.MouseEnter += SidebarButton_MouseEnter;
            buttonPakan.MouseLeave += SidebarButton_MouseLeave;
        }
    }
}
