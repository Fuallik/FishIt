namespace FishIt
{
    partial class FormShipper
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
            buttonPengirimanPesanan = new Button();
            buttonRiwayatPengirimanPesanan = new Button();
            panelSB = new Panel();
            buttonLogoutAdmin = new Button();
            buttonDashboardShipper = new Button();
            labelFish = new Label();
            panelNB = new Panel();
            panelContent = new Panel();
            panelUsername = new Panel();
            lblUsernameTopbar = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panelSB.SuspendLayout();
            panelNB.SuspendLayout();
            panelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonPengirimanPesanan
            // 
            buttonPengirimanPesanan.BackColor = Color.CornflowerBlue;
            buttonPengirimanPesanan.Dock = DockStyle.Top;
            buttonPengirimanPesanan.FlatAppearance.BorderSize = 0;
            buttonPengirimanPesanan.FlatStyle = FlatStyle.Flat;
            buttonPengirimanPesanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPengirimanPesanan.ForeColor = Color.White;
            buttonPengirimanPesanan.Location = new Point(0, 100);
            buttonPengirimanPesanan.Name = "buttonPengirimanPesanan";
            buttonPengirimanPesanan.Size = new Size(200, 50);
            buttonPengirimanPesanan.TabIndex = 1;
            buttonPengirimanPesanan.Text = "Pengiriman Pesanan";
            buttonPengirimanPesanan.UseVisualStyleBackColor = false;
            buttonPengirimanPesanan.Click += buttonPengirimanPesanan_Click;
            // 
            // buttonRiwayatPengirimanPesanan
            // 
            buttonRiwayatPengirimanPesanan.BackColor = Color.CornflowerBlue;
            buttonRiwayatPengirimanPesanan.Dock = DockStyle.Top;
            buttonRiwayatPengirimanPesanan.FlatAppearance.BorderSize = 0;
            buttonRiwayatPengirimanPesanan.FlatStyle = FlatStyle.Flat;
            buttonRiwayatPengirimanPesanan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRiwayatPengirimanPesanan.ForeColor = Color.White;
            buttonRiwayatPengirimanPesanan.Location = new Point(0, 150);
            buttonRiwayatPengirimanPesanan.Name = "buttonRiwayatPengirimanPesanan";
            buttonRiwayatPengirimanPesanan.Size = new Size(200, 50);
            buttonRiwayatPengirimanPesanan.TabIndex = 3;
            buttonRiwayatPengirimanPesanan.Text = "Riwayat Pengiriman Pesanan";
            buttonRiwayatPengirimanPesanan.UseVisualStyleBackColor = false;
            buttonRiwayatPengirimanPesanan.Click += buttonRiwayatPengirimanPesanan_Click;
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogoutAdmin);
            panelSB.Controls.Add(buttonRiwayatPengirimanPesanan);
            panelSB.Controls.Add(buttonPengirimanPesanan);
            panelSB.Controls.Add(buttonDashboardShipper);
            panelSB.Controls.Add(labelFish);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 712);
            panelSB.TabIndex = 8;
            // 
            // buttonLogoutAdmin
            // 
            buttonLogoutAdmin.BackColor = Color.CornflowerBlue;
            buttonLogoutAdmin.Dock = DockStyle.Bottom;
            buttonLogoutAdmin.FlatAppearance.BorderSize = 0;
            buttonLogoutAdmin.FlatStyle = FlatStyle.Flat;
            buttonLogoutAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogoutAdmin.ForeColor = Color.White;
            buttonLogoutAdmin.Location = new Point(0, 662);
            buttonLogoutAdmin.Name = "buttonLogoutAdmin";
            buttonLogoutAdmin.Size = new Size(200, 50);
            buttonLogoutAdmin.TabIndex = 6;
            buttonLogoutAdmin.Text = "LogOut";
            buttonLogoutAdmin.UseVisualStyleBackColor = false;
            buttonLogoutAdmin.Click += buttonLogoutAdmin_Click;
            // 
            // buttonDashboardShipper
            // 
            buttonDashboardShipper.Dock = DockStyle.Top;
            buttonDashboardShipper.FlatAppearance.BorderSize = 0;
            buttonDashboardShipper.FlatStyle = FlatStyle.Flat;
            buttonDashboardShipper.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboardShipper.ForeColor = Color.White;
            buttonDashboardShipper.Location = new Point(0, 50);
            buttonDashboardShipper.Name = "buttonDashboardShipper";
            buttonDashboardShipper.Size = new Size(200, 50);
            buttonDashboardShipper.TabIndex = 0;
            buttonDashboardShipper.Text = "Dashboard";
            buttonDashboardShipper.UseVisualStyleBackColor = true;
            buttonDashboardShipper.Click += buttonDashboard_Click;
            // 
            // labelFish
            // 
            labelFish.Dock = DockStyle.Top;
            labelFish.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFish.ForeColor = Color.White;
            labelFish.Location = new Point(0, 0);
            labelFish.Name = "labelFish";
            labelFish.Size = new Size(200, 50);
            labelFish.TabIndex = 7;
            labelFish.Text = "FishIt";
            labelFish.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.LightSteelBlue;
            panelNB.Controls.Add(panelUsername);
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(200, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(802, 50);
            panelNB.TabIndex = 7;
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
            // panelUsername
            // 
            panelUsername.Controls.Add(lblUsernameTopbar);
            panelUsername.Controls.Add(iconPictureBox1);
            panelUsername.Location = new Point(6, 3);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(796, 44);
            panelUsername.TabIndex = 11;
            // 
            // lblUsernameTopbar
            // 
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
            // FormShipper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelContent);
            Controls.Add(panelNB);
            Controls.Add(panelSB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormShipper";
            Text = "FormShipper";
            Load += FormShipper_Load;
            panelSB.ResumeLayout(false);
            panelNB.ResumeLayout(false);
            panelUsername.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonLogOut;
        private Label label1;
        private Button buttonPengirimanPesanan;
        private Button buttonRiwayatPengirimanPesanan;
        private Panel panelSB;
        private Button buttonLogoutAdmin;
        private Button buttonDashboardShipper;
        private Panel panelNB;
        private Panel panelContent;
        private Label labelFish;
        private Panel panelUsername;
        private Label lblUsernameTopbar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}