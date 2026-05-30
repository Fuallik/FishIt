namespace FishIt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelJudulLogin = new Label();
            buttonLogin = new Button();
            buttonRegister = new Button();
            labelInfo = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelJudulLogin
            // 
            labelJudulLogin.BackColor = Color.Transparent;
            labelJudulLogin.Font = new Font("Constantia", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelJudulLogin.ForeColor = Color.FromArgb(166, 124, 74);
            labelJudulLogin.Location = new Point(564, 198);
            labelJudulLogin.Name = "labelJudulLogin";
            labelJudulLogin.Size = new Size(404, 180);
            labelJudulLogin.TabIndex = 0;
            labelJudulLogin.Text = "Dengan satu Akun,\r\nkamu dapat \r\nmengelola Ikan-Mu!";
            labelJudulLogin.TextAlign = ContentAlignment.MiddleCenter;
            labelJudulLogin.Click += labelJudulLogin_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.BackColor = Color.CornflowerBlue;
            buttonLogin.Cursor = Cursors.Hand;
            buttonLogin.FlatAppearance.BorderSize = 0;
            buttonLogin.FlatStyle = FlatStyle.Flat;
            buttonLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonLogin.ForeColor = Color.White;
            buttonLogin.Location = new Point(678, 483);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(160, 40);
            buttonLogin.TabIndex = 1;
            buttonLogin.Text = "Login Akun";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonRegister
            // 
            buttonRegister.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRegister.BackColor = Color.Transparent;
            buttonRegister.Cursor = Cursors.Hand;
            buttonRegister.FlatAppearance.BorderSize = 0;
            buttonRegister.FlatStyle = FlatStyle.Flat;
            buttonRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRegister.ForeColor = Color.DodgerBlue;
            buttonRegister.Location = new Point(678, 529);
            buttonRegister.Name = "buttonRegister";
            buttonRegister.Size = new Size(160, 50);
            buttonRegister.TabIndex = 2;
            buttonRegister.Text = "Register Akun";
            buttonRegister.UseVisualStyleBackColor = false;
            buttonRegister.Click += buttonRegister_Click;
            // 
            // labelInfo
            // 
            labelInfo.BackColor = Color.Transparent;
            labelInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelInfo.ForeColor = Color.White;
            labelInfo.Location = new Point(65, 420);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(323, 32);
            labelInfo.TabIndex = 4;
            labelInfo.Text = "Bakso Kontol Bakso Kontol";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-20, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(504, 398);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1002, 712);
            Controls.Add(labelInfo);
            Controls.Add(buttonRegister);
            Controls.Add(buttonLogin);
            Controls.Add(labelJudulLogin);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelJudulLogin;
        private Button buttonLogin;
        private Button buttonRegister;
        private Label labelInfo;
        private PictureBox pictureBox1;
    }
}
