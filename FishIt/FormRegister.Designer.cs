namespace FishIt
{
    partial class FormRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TBKecamatan = new TextBox();
            labelJudul = new Label();
            labelRegister = new Label();
            TBNama = new TextBox();
            labelNama = new Label();
            labelUsername = new Label();
            TBUsername = new TextBox();
            labelPassword = new Label();
            TBPassword = new TextBox();
            labelTelpon = new Label();
            TBTelpon = new TextBox();
            labelAlamat = new Label();
            TBAlamat = new TextBox();
            buttonRegister = new Button();
            labelKelurahan = new Label();
            TBKelurahan = new TextBox();
            labelKecamatan = new Label();
            TBKonfirmasiPassword = new TextBox();
            labelKonfirmasiPassword = new Label();
            SuspendLayout();
            // 
            // TBKecamatan
            // 
            TBKecamatan.Location = new Point(62, 612);
            TBKecamatan.Name = "TBKecamatan";
            TBKecamatan.Size = new Size(335, 31);
            TBKecamatan.TabIndex = 16;
            TBKecamatan.TextChanged += TBKecamatan_TextChanged;
            // 
            // labelJudul
            // 
            labelJudul.AutoSize = true;
            labelJudul.BackColor = Color.Transparent;
            labelJudul.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJudul.ImageAlign = ContentAlignment.TopCenter;
            labelJudul.Location = new Point(161, 9);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(137, 54);
            labelJudul.TabIndex = 0;
            labelJudul.Text = "Fish It";
            labelJudul.TextAlign = ContentAlignment.MiddleCenter;
            labelJudul.Click += label1_Click;
            // 
            // labelRegister
            // 
            labelRegister.AutoSize = true;
            labelRegister.BackColor = Color.Transparent;
            labelRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelRegister.Location = new Point(174, 63);
            labelRegister.Name = "labelRegister";
            labelRegister.Size = new Size(107, 32);
            labelRegister.TabIndex = 1;
            labelRegister.Text = "Register";
            labelRegister.Click += labelRegister_Click;
            // 
            // TBNama
            // 
            TBNama.Location = new Point(62, 129);
            TBNama.Name = "TBNama";
            TBNama.Size = new Size(335, 31);
            TBNama.TabIndex = 2;
            TBNama.TextChanged += TBNama_TextChanged;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(62, 94);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(79, 32);
            labelNama.TabIndex = 4;
            labelNama.Text = "Nama";
            labelNama.Click += labelUsername_Click;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelUsername.Location = new Point(62, 163);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(124, 32);
            labelUsername.TabIndex = 6;
            labelUsername.Text = "Username";
            // 
            // TBUsername
            // 
            TBUsername.Location = new Point(62, 198);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(335, 31);
            TBUsername.TabIndex = 5;
            TBUsername.TextChanged += TBUsername_TextChanged;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelPassword.Location = new Point(62, 232);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(115, 32);
            labelPassword.TabIndex = 8;
            labelPassword.Text = "Password";
            // 
            // TBPassword
            // 
            TBPassword.Location = new Point(62, 267);
            TBPassword.Name = "TBPassword";
            TBPassword.Size = new Size(335, 31);
            TBPassword.TabIndex = 7;
            TBPassword.UseSystemPasswordChar = true;
            TBPassword.TextChanged += TBPassword_TextChanged;
            // 
            // labelTelpon
            // 
            labelTelpon.AutoSize = true;
            labelTelpon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelTelpon.Location = new Point(62, 370);
            labelTelpon.Name = "labelTelpon";
            labelTelpon.Size = new Size(131, 32);
            labelTelpon.TabIndex = 10;
            labelTelpon.Text = "No. Telpon";
            // 
            // TBTelpon
            // 
            TBTelpon.Location = new Point(62, 405);
            TBTelpon.Name = "TBTelpon";
            TBTelpon.Size = new Size(335, 31);
            TBTelpon.TabIndex = 9;
            TBTelpon.TextChanged += TBTelpon_TextChanged;
            // 
            // labelAlamat
            // 
            labelAlamat.AutoSize = true;
            labelAlamat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelAlamat.Location = new Point(62, 439);
            labelAlamat.Name = "labelAlamat";
            labelAlamat.Size = new Size(92, 32);
            labelAlamat.TabIndex = 12;
            labelAlamat.Text = "Alamat";
            // 
            // TBAlamat
            // 
            TBAlamat.Location = new Point(62, 474);
            TBAlamat.Name = "TBAlamat";
            TBAlamat.Size = new Size(335, 31);
            TBAlamat.TabIndex = 11;
            TBAlamat.TextChanged += TBAlamat_TextChanged;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.CornflowerBlue;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRegister.ForeColor = Color.White;
            buttonRegister.Location = new Point(145, 699);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(169, 50);
            buttonRegister.TabIndex = 13;
            buttonRegister.Text = "Buat Akun";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // labelKelurahan
            // 
            labelKelurahan.AutoSize = true;
            labelKelurahan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelKelurahan.Location = new Point(62, 508);
            labelKelurahan.Name = "labelKelurahan";
            labelKelurahan.Size = new Size(125, 32);
            labelKelurahan.TabIndex = 15;
            labelKelurahan.Text = "Kelurahan";
            // 
            // TBKelurahan
            // 
            TBKelurahan.Location = new Point(62, 543);
            TBKelurahan.Name = "TBKelurahan";
            TBKelurahan.Size = new Size(335, 31);
            TBKelurahan.TabIndex = 14;
            TBKelurahan.TextChanged += TBKelurahan_TextChanged;
            // 
            // labelKecamatan
            // 
            labelKecamatan.AutoSize = true;
            labelKecamatan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelKecamatan.Location = new Point(62, 577);
            labelKecamatan.Name = "labelKecamatan";
            labelKecamatan.Size = new Size(136, 32);
            labelKecamatan.TabIndex = 17;
            labelKecamatan.Text = "Kecamatan";
            // 
            // TBKonfirmasiPassword
            // 
            TBKonfirmasiPassword.Location = new Point(62, 336);
            TBKonfirmasiPassword.Name = "TBKonfirmasiPassword";
            TBKonfirmasiPassword.Size = new Size(335, 31);
            TBKonfirmasiPassword.TabIndex = 18;
            TBKonfirmasiPassword.UseSystemPasswordChar = true;
            // 
            // labelKonfirmasiPassword
            // 
            labelKonfirmasiPassword.AutoSize = true;
            labelKonfirmasiPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelKonfirmasiPassword.Location = new Point(62, 301);
            labelKonfirmasiPassword.Name = "labelKonfirmasiPassword";
            labelKonfirmasiPassword.Size = new Size(238, 32);
            labelKonfirmasiPassword.TabIndex = 19;
            labelKonfirmasiPassword.Text = "Konfirmasi Password";
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 800);
            Controls.Add(labelKonfirmasiPassword);
            Controls.Add(TBKonfirmasiPassword);
            Controls.Add(labelKecamatan);
            Controls.Add(TBKecamatan);
            Controls.Add(labelKelurahan);
            Controls.Add(TBKelurahan);
            Controls.Add(buttonRegister);
            Controls.Add(labelAlamat);
            Controls.Add(TBAlamat);
            Controls.Add(labelTelpon);
            Controls.Add(TBTelpon);
            Controls.Add(labelPassword);
            Controls.Add(TBPassword);
            Controls.Add(labelUsername);
            Controls.Add(TBUsername);
            Controls.Add(labelNama);
            Controls.Add(TBNama);
            Controls.Add(labelRegister);
            Controls.Add(labelJudul);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegister";
            Load += FormRegister_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelJudul;
        private Label labelRegister;
        private TextBox TBNama;
        private Label labelNama;
        private Label labelUsername;
        private TextBox TBUsername;
        private Label labelPassword;
        private TextBox TBPassword;
        private Label labelTelpon;
        private TextBox TBTelpon;
        private Label labelAlamat;
        private TextBox TBAlamat;
        private Button buttonRegister;
        private Label labelKelurahan;
        private TextBox TBKelurahan;
        private Label labelKecamatan;
        private TextBox TBKecamatan;
        private TextBox TBKonfirmasiPassword;
        private Label labelKonfirmasiPassword;
    }
}