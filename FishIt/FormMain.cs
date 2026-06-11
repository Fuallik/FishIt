using Npgsql;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FishIt
{    
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;

            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;

            buttonRegister.ForeColor = Color.Blue;

            buttonRegister.UseVisualStyleBackColor = false;

            buttonRegister.MouseEnter += buttonRegister_MouseEnter;
            buttonRegister.MouseLeave += buttonRegister_MouseLeave;

            new AutoScaleHelper(this);
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        internal static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new FormMain());
            }
        }

        private void labelJudulLogin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
