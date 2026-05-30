using Npgsql;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FishIt
{    
    public partial class Form1 : Form
    {
        private Size originalFormSize;
        private Dictionary<Control, Rectangle> ControlBounds = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> OriginalFonts = new Dictionary<Control, float>();
        private float originalFontSize;
        public Form1()
        {
            InitializeComponent();

            // 1. Gunakan ClientSize, bukan Size (karena perhitungan di Resize pakai ClientSize)
            originalFormSize = this.ClientSize;

            // 2. Simpan SEMUA data ukuran dan font asli di sini (HANYA SEKALI)
            SaveFonts(this);
            SaveBounds(this);
            originalFontSize = buttonLogin.Font.Size;

            // 3. Konfigurasi UI lainnya
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ActiveControl = null;

            // Background transparan
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonRegister.ForeColor = Color.Blue;
            buttonRegister.UseVisualStyleBackColor = false;

            buttonRegister.MouseEnter += buttonRegister_MouseEnter;
            buttonRegister.MouseLeave += buttonRegister_MouseLeave;

            // 4. DAFTARKAN EVENT RESIZE SETELAH SEMUA UKURAN ASLI DISIMPAN
            this.Resize += new System.EventHandler(this.Form1_Resize);

            // 5. Baru lakukan Maximize. 
            // Ini akan otomatis memicu Form1_Resize dan memperbesar semuanya dengan benar.
            this.WindowState = FormWindowState.Maximized;
        }
        public class Database
        {
            private string _connString;

            public Database(string connString)
            {
                _connString = connString;
            }

            public NpgsqlConnection GetConnection()
            {
                return new NpgsqlConnection(_connString);
            }
        }

        public static class Config
        {
            public static string ConnString =
                "Host=localhost;" +
                "Port=5432;" +
                "Database=FishIt;" +
                "Username=postgres;" +
                "Password=1234";
        }

        internal static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new Form1());
            }
        }

        private void labelJudulLogin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // HAPUS KODE INI: originalFormSize = this.ClientSize;
            // HAPUS KODE INI: SaveFonts(this);
            // HAPUS KODE INI: SaveBounds(this);

            // Biarkan fungsi yang lain tetap berjalan
            UpdateButtonRadius();
            DebugControls(this);
        }

        private void Form1_Resize(object sender, EventArgs e)
        { 
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;

            float scale = Math.Min(xRatio, yRatio);

            ResizeControls(this, xRatio, yRatio);
            ResizeFonts(this, scale);

            UpdateButtonRadius();
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


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormLogin login = Application.OpenForms
        .OfType<FormLogin>()
        .FirstOrDefault();

            if (login == null)
            { 
                login = new FormLogin();
                login.Show();
            }
            else
            {
                login.BringToFront();
                login.Focus();
            }
        }

        private void buttonLogin_MouseEnter(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.MidnightBlue;
        }

        private void buttonLogin_MouseLeave(object sender, EventArgs e)
        {
            buttonLogin.BackColor = Color.MidnightBlue;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = Application.OpenForms
        .OfType<FormRegister>()
        .FirstOrDefault();

            if (register == null)
            {
                register = new FormRegister();
                register.Show();
            }
            else
            {
                register.BringToFront();
                register.Focus();
            }
        }
        // HOVER -> GREEN
        private void buttonRegister_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.ForeColor = Color.MidnightBlue;
        }

        // KEMBALI NORMAL
        private void buttonRegister_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.ForeColor = Color.RoyalBlue;
        }
        private void UpdateButtonRadius()
        {
            GraphicsPath path = new GraphicsPath();

            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(buttonLogin.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(buttonLogin.Width - radius, buttonLogin.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, buttonLogin.Height - radius, radius, radius, 90, 90);

            path.CloseAllFigures();

            buttonLogin.Region = new Region(path);
        }
    }
}
