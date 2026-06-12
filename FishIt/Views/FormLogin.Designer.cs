namespace FishIt
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            labelLogin = new Label();
            TBUsername = new TextBox();
            TBPassword = new TextBox();
            buttonRegister = new Button();
            buttonLogin = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            labelJudul = new Label();
            labelPassword = new Label();
            labelUsername = new Label();
            btnExit = new Button();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLogin.ImageAlign = ContentAlignment.TopCenter;
            labelLogin.Location = new Point(179, 83);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(86, 32);
            labelLogin.TabIndex = 0;
            labelLogin.Text = "Log In";
            labelLogin.TextAlign = ContentAlignment.MiddleCenter;
            labelLogin.Click += labelLogin_Click;
            // 
            // TBUsername
            // 
            TBUsername.BackColor = Color.White;
            TBUsername.BorderStyle = BorderStyle.None;
            TBUsername.Location = new Point(56, 250);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(335, 24);
            TBUsername.TabIndex = 2;
            // 
            // TBPassword
            // 
            TBPassword.Anchor = AnchorStyles.None;
            TBPassword.BackColor = Color.White;
            TBPassword.BorderStyle = BorderStyle.None;
            TBPassword.Location = new Point(56, 345);
            TBPassword.Name = "TBPassword";
            TBPassword.Size = new Size(338, 24);
            TBPassword.TabIndex = 4;
            TBPassword.UseSystemPasswordChar = true;
            TBPassword.TextChanged += TBPassword_TextChanged;
            // 
            // buttonRegister
            // 
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.ForeColor = Color.RoyalBlue;
            buttonRegister.Location = new Point(148, 552);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(169, 34);
            buttonRegister.TabIndex = 6;
            buttonRegister.Text = "belum punya akun";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.CornflowerBlue;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(148, 592);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(169, 50);
            buttonLogin.TabIndex = 7;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // labelJudul
            // 
            labelJudul.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelJudul.AutoSize = true;
            labelJudul.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelJudul.ImageAlign = ContentAlignment.TopCenter;
            labelJudul.Location = new Point(155, 29);
            labelJudul.Name = "labelJudul";
            labelJudul.Size = new Size(137, 54);
            labelJudul.TabIndex = 8;
            labelJudul.Text = "Fish It";
            labelJudul.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelPassword.ForeColor = Color.Black;
            labelPassword.Location = new Point(56, 310);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(115, 32);
            labelPassword.TabIndex = 5;
            labelPassword.Text = "Password";
            labelPassword.Click += labelPassword_Click;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelUsername.Location = new Point(56, 200);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(124, 32);
            labelUsername.TabIndex = 3;
            labelUsername.Text = "Username";
            labelUsername.Click += label1_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BackgroundImage = (Image)resources.GetObject("btnExit.BackgroundImage");
            btnExit.BackgroundImageLayout = ImageLayout.Zoom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Location = new Point(415, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 30);
            btnExit.TabIndex = 10;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += button1_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(457, 663);
            Controls.Add(btnExit);
            Controls.Add(labelJudul);
            Controls.Add(buttonLogin);
            Controls.Add(buttonRegister);
            Controls.Add(labelPassword);
            Controls.Add(TBPassword);
            Controls.Add(labelUsername);
            Controls.Add(TBUsername);
            Controls.Add(labelLogin);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin;
        private TextBox TBUsername;
        private TextBox TBPassword;
        private Button buttonRegister;
        private Button buttonLogin;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label labelJudul;
        private Label labelPassword;
        private Label labelUsername;
        private Button btnExit;
    }
}