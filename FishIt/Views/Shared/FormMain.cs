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
            FormLogin login = Application.OpenForms.OfType<FormLogin>().FirstOrDefault();

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
            FormRegister register = Application.OpenForms.OfType<FormRegister>().FirstOrDefault();

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
        private void buttonRegister_MouseEnter(object sender, EventArgs e)
        {
            buttonRegister.ForeColor = Color.MidnightBlue;
        }

        private void buttonRegister_MouseLeave(object sender, EventArgs e)
        {
            buttonRegister.ForeColor = Color.RoyalBlue;
        }
    }
}
