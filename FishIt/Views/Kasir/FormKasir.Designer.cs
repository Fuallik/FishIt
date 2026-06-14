namespace FishIt
{
    partial class FormKasir
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
            panelSB = new Panel();
            buttonRiwayatPembayaran = new FontAwesome.Sharp.IconButton();
            buttonLogout = new FontAwesome.Sharp.IconButton();
            buttonKonfirmasiPembayaran = new FontAwesome.Sharp.IconButton();
            buttonDashboard = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panelContent = new Panel();
            panelTB = new Panel();
            panelUsername = new Panel();
            lblUsernameTopbar = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panelSB.SuspendLayout();
            panelTB.SuspendLayout();
            panelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonRiwayatPembayaran);
            panelSB.Controls.Add(buttonLogout);
            panelSB.Controls.Add(buttonKonfirmasiPembayaran);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Controls.Add(label1);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 712);
            panelSB.TabIndex = 9;
            // 
            // buttonRiwayatPembayaran
            // 
            buttonRiwayatPembayaran.BackColor = Color.Transparent;
            buttonRiwayatPembayaran.Dock = DockStyle.Top;
            buttonRiwayatPembayaran.FlatAppearance.BorderSize = 0;
            buttonRiwayatPembayaran.FlatStyle = FlatStyle.Flat;
            buttonRiwayatPembayaran.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRiwayatPembayaran.ForeColor = Color.White;
            buttonRiwayatPembayaran.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            buttonRiwayatPembayaran.IconColor = Color.White;
            buttonRiwayatPembayaran.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRiwayatPembayaran.IconSize = 30;
            buttonRiwayatPembayaran.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRiwayatPembayaran.Location = new Point(0, 140);
            buttonRiwayatPembayaran.Name = "buttonRiwayatPembayaran";
            buttonRiwayatPembayaran.Padding = new Padding(15, 0, 0, 0);
            buttonRiwayatPembayaran.Size = new Size(200, 40);
            buttonRiwayatPembayaran.TabIndex = 12;
            buttonRiwayatPembayaran.Text = "Riwayat Pembayaran";
            buttonRiwayatPembayaran.TextAlign = ContentAlignment.MiddleLeft;
            buttonRiwayatPembayaran.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRiwayatPembayaran.UseVisualStyleBackColor = false;
            buttonRiwayatPembayaran.Click += buttonRiwayatPembayaran_Click;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.Transparent;
            buttonLogout.BackgroundImageLayout = ImageLayout.Zoom;
            buttonLogout.Dock = DockStyle.Bottom;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.IconChar = FontAwesome.Sharp.IconChar.LongArrowLeft;
            buttonLogout.IconColor = Color.White;
            buttonLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLogout.IconSize = 30;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogout.Location = new Point(0, 662);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Padding = new Padding(15, 0, 0, 0);
            buttonLogout.Size = new Size(200, 50);
            buttonLogout.TabIndex = 11;
            buttonLogout.Text = "Logout";
            buttonLogout.TextAlign = ContentAlignment.MiddleLeft;
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // buttonKonfirmasiPembayaran
            // 
            buttonKonfirmasiPembayaran.BackColor = Color.Transparent;
            buttonKonfirmasiPembayaran.Dock = DockStyle.Top;
            buttonKonfirmasiPembayaran.FlatAppearance.BorderSize = 0;
            buttonKonfirmasiPembayaran.FlatStyle = FlatStyle.Flat;
            buttonKonfirmasiPembayaran.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKonfirmasiPembayaran.ForeColor = Color.White;
            buttonKonfirmasiPembayaran.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            buttonKonfirmasiPembayaran.IconColor = Color.White;
            buttonKonfirmasiPembayaran.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKonfirmasiPembayaran.IconSize = 30;
            buttonKonfirmasiPembayaran.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKonfirmasiPembayaran.Location = new Point(0, 100);
            buttonKonfirmasiPembayaran.Name = "buttonKonfirmasiPembayaran";
            buttonKonfirmasiPembayaran.Padding = new Padding(15, 0, 0, 0);
            buttonKonfirmasiPembayaran.Size = new Size(200, 40);
            buttonKonfirmasiPembayaran.TabIndex = 8;
            buttonKonfirmasiPembayaran.Text = "Konfirmasi Pembayaran";
            buttonKonfirmasiPembayaran.TextAlign = ContentAlignment.MiddleLeft;
            buttonKonfirmasiPembayaran.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKonfirmasiPembayaran.UseVisualStyleBackColor = false;
            buttonKonfirmasiPembayaran.Click += buttonKonfirmasiPembayaran_Click;
            // 
            // buttonDashboard
            // 
            buttonDashboard.BackColor = Color.Transparent;
            buttonDashboard.Dock = DockStyle.Top;
            buttonDashboard.FlatAppearance.BorderSize = 0;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboard.ForeColor = Color.White;
            buttonDashboard.IconChar = FontAwesome.Sharp.IconChar.Bars;
            buttonDashboard.IconColor = Color.White;
            buttonDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonDashboard.IconSize = 30;
            buttonDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.Location = new Point(0, 50);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Padding = new Padding(15, 0, 0, 0);
            buttonDashboard.Size = new Size(200, 50);
            buttonDashboard.TabIndex = 7;
            buttonDashboard.Text = " Dashboard";
            buttonDashboard.TextAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDashboard.UseVisualStyleBackColor = false;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 50);
            label1.TabIndex = 13;
            label1.Text = "FishIt";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.LightSteelBlue;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(802, 662);
            panelContent.TabIndex = 10;
            // 
            // panelTB
            // 
            panelTB.BackColor = Color.LightSteelBlue;
            panelTB.Controls.Add(panelUsername);
            panelTB.Dock = DockStyle.Top;
            panelTB.Location = new Point(200, 0);
            panelTB.Name = "panelTB";
            panelTB.Size = new Size(802, 50);
            panelTB.TabIndex = 2;
            // 
            // panelUsername
            // 
            panelUsername.Controls.Add(lblUsernameTopbar);
            panelUsername.Controls.Add(iconPictureBox1);
            panelUsername.Location = new Point(3, 3);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(796, 44);
            panelUsername.TabIndex = 0;
            // 
            // lblUsernameTopbar
            // 
            lblUsernameTopbar.BackColor = Color.Transparent;
            lblUsernameTopbar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsernameTopbar.ForeColor = Color.MidnightBlue;
            lblUsernameTopbar.Location = new Point(47, 6);
            lblUsernameTopbar.Name = "lblUsernameTopbar";
            lblUsernameTopbar.Size = new Size(746, 38);
            lblUsernameTopbar.TabIndex = 1;
            lblUsernameTopbar.Text = "Username";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.LightSteelBlue;
            iconPictureBox1.ForeColor = Color.MidnightBlue;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            iconPictureBox1.IconColor = Color.MidnightBlue;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 38;
            iconPictureBox1.Location = new Point(3, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(38, 38);
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelContent);
            Controls.Add(panelTB);
            Controls.Add(panelSB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKasir";
            Text = "FormKasir";
            WindowState = FormWindowState.Maximized;
            Load += FormKasir_Load;
            panelSB.ResumeLayout(false);
            panelTB.ResumeLayout(false);
            panelUsername.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelSB;
        private FontAwesome.Sharp.IconButton buttonLogout;
        private FontAwesome.Sharp.IconButton buttonKonfirmasiPembayaran;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private FontAwesome.Sharp.IconButton buttonRiwayatPembayaran;
        private Panel panelContent;
        private Panel panelTB;
        private Panel panelUsername;
        private Label lblUsernameTopbar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label1;
    }
}