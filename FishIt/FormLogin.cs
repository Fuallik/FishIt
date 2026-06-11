using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static PanelHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FishIt
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.ActiveControl = null;

            TBUsername.PlaceholderText = "Username";
            TBPassword.PlaceholderText = "Password";

            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;
            buttonRegister.ForeColor = Color.Blue;
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.MouseEnter += buttonRegister_MouseEnter;
            buttonRegister.MouseLeave += buttonRegister_MouseLeave;

            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnExit.ForeColor = Color.Black;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
        }
        public static class Config
        {
            public static string ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            labelLogin.Focus();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = Application.OpenForms.OfType<FormRegister>().FirstOrDefault();

            if (register == null)
            {
                register = new FormRegister();
                register.Show();
                this.Close();
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

            buttonRegister.MouseEnter += buttonRegister_MouseEnter;
            buttonRegister.MouseLeave += buttonRegister_MouseLeave;
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.MidnightBlue;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.ForeColor = Color.Black;

            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
        }

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void TBPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string query = @"SELECT r.nama_role, a.id_akun, a.username 
                             FROM akun a 
                             JOIN roles r ON a.id_role = r.id_role 
                             WHERE a.username=@u AND a.passwords=@p AND a.aktif = TRUE 
                             LIMIT 1";

            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(query, conn))
                    try
                    {
                        cmd.Parameters.AddWithValue("@u", TBUsername.Text);
                        cmd.Parameters.AddWithValue("@p", TBPassword.Text);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader.GetString(0);

                                Session.IdAkun = Convert.ToInt32(reader["id_akun"]);
                                Session.NamaUser = reader["username"].ToString();

                                this.Hide();

                                if (role == "admins")
                                {
                                    new FormAdmin().Show();
                                }

                                else if (role == "kasir")
                                {
                                    new FormKasir().Show();
                                }

                                else if (role == "pegawai tambak")
                                {
                                    new FormPegawaiTambak().Show();
                                }

                                else if (role == "shipper")
                                {
                                    new FormShipper().Show();
                                }

                                else if (role == "supplier")
                                {
                                    new FormSupplier().Show();
                                }

                                else if (role == "pembeli")
                                {
                                    new FormPembeli().Show();
                                }
                                else
                                {
                                    new FormMain().Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Login gagal!");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal memuat tabel ikan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
