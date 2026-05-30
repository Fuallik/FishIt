using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
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
            // Background transparan
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.FlatAppearance.BorderSize = 0;

            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseOverBackColor = Color.Transparent;
            buttonRegister.FlatAppearance.MouseDownBackColor = Color.Transparent;

            // Warna awal tulisan
            buttonRegister.ForeColor = Color.Blue;

            // Support transparan
            buttonRegister.UseVisualStyleBackColor = false;

            // Event hover & click
            buttonRegister.MouseEnter += buttonRegister_MouseEnter;
            buttonRegister.MouseLeave += buttonRegister_MouseLeave;
        }
        public static class Config
        {
            public static string ConnString =
                "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=FishIt";
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
            FormRegister register = Application.OpenForms
        .OfType<FormRegister>()
        .FirstOrDefault();

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

        private void labelPassword_Click(object sender, EventArgs e)
        {

        }

        private void TBPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(Config.ConnString))
            {
                conn.Open();

                string query =
                    "SELECT nama_role FROM roles r JOIN akun a on a.id_role = r.id_role WHERE username=@u AND passwords=@p LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", TBUsername.Text);
                    cmd.Parameters.AddWithValue("@p", TBPassword.Text);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader.GetString(0);

                            MessageBox.Show("Login berhasil sebagai " + role);

                            this.Hide(); // tutup form login

                            if (role == "admins")
                            {
                                new FormAdmin().Show();
                            }
                            else if (role == "pembeli")
                            {
                                new FormPembeli().Show();
                            }
                            else
                            {
                                new Form1().Show(); // fallback
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login gagal!");
                        }
                    }
                }
            }
        }
    }
}
