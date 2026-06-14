namespace FishIt
{
    partial class FormSupplier
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
            buttonRiwayatVerifikasi = new Button();
            buttonPengajuanPakan = new Button();
            buttonPengajuanBenih = new Button();
            buttonKatalogPakan = new Button();
            buttonKatalogBenih = new Button();
            buttonDashboardSupp = new Button();
            labelFish = new Label();
            buttonLogoutSupp = new Button();
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
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonRiwayatVerifikasi);
            panelSB.Controls.Add(buttonPengajuanPakan);
            panelSB.Controls.Add(buttonPengajuanBenih);
            panelSB.Controls.Add(buttonKatalogPakan);
            panelSB.Controls.Add(buttonKatalogBenih);
            panelSB.Controls.Add(buttonDashboardSupp);
            panelSB.Controls.Add(labelFish);
            panelSB.Controls.Add(buttonLogoutSupp);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 712);
            panelSB.TabIndex = 5;
            // 
            // buttonRiwayatVerifikasi
            // 
            buttonRiwayatVerifikasi.Dock = DockStyle.Top;
            buttonRiwayatVerifikasi.FlatAppearance.BorderSize = 0;
            buttonRiwayatVerifikasi.FlatStyle = FlatStyle.Flat;
            buttonRiwayatVerifikasi.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRiwayatVerifikasi.ForeColor = Color.White;
            buttonRiwayatVerifikasi.Location = new Point(0, 300);
            buttonRiwayatVerifikasi.Name = "buttonRiwayatVerifikasi";
            buttonRiwayatVerifikasi.Size = new Size(200, 50);
            buttonRiwayatVerifikasi.TabIndex = 12;
            buttonRiwayatVerifikasi.Text = "Riwayat Verifikasi";
            buttonRiwayatVerifikasi.UseVisualStyleBackColor = true;
            buttonRiwayatVerifikasi.Click += buttonRiwayatVerifikasi_Click;
            // 
            // buttonPengajuanPakan
            // 
            buttonPengajuanPakan.Dock = DockStyle.Top;
            buttonPengajuanPakan.FlatAppearance.BorderSize = 0;
            buttonPengajuanPakan.FlatStyle = FlatStyle.Flat;
            buttonPengajuanPakan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPengajuanPakan.ForeColor = Color.White;
            buttonPengajuanPakan.Location = new Point(0, 250);
            buttonPengajuanPakan.Name = "buttonPengajuanPakan";
            buttonPengajuanPakan.Size = new Size(200, 50);
            buttonPengajuanPakan.TabIndex = 11;
            buttonPengajuanPakan.Text = "Pengajuan Pakan";
            buttonPengajuanPakan.UseVisualStyleBackColor = true;
            buttonPengajuanPakan.Click += buttonPengajuanPakan_Click;
            // 
            // buttonPengajuanBenih
            // 
            buttonPengajuanBenih.Dock = DockStyle.Top;
            buttonPengajuanBenih.FlatAppearance.BorderSize = 0;
            buttonPengajuanBenih.FlatStyle = FlatStyle.Flat;
            buttonPengajuanBenih.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPengajuanBenih.ForeColor = Color.White;
            buttonPengajuanBenih.Location = new Point(0, 200);
            buttonPengajuanBenih.Name = "buttonPengajuanBenih";
            buttonPengajuanBenih.Size = new Size(200, 50);
            buttonPengajuanBenih.TabIndex = 10;
            buttonPengajuanBenih.Text = "Pengajuan Benih";
            buttonPengajuanBenih.UseVisualStyleBackColor = true;
            buttonPengajuanBenih.Click += buttonPengajuanBenih_Click;
            // 
            // buttonKatalogPakan
            // 
            buttonKatalogPakan.Dock = DockStyle.Top;
            buttonKatalogPakan.FlatAppearance.BorderSize = 0;
            buttonKatalogPakan.FlatStyle = FlatStyle.Flat;
            buttonKatalogPakan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKatalogPakan.ForeColor = Color.White;
            buttonKatalogPakan.Location = new Point(0, 150);
            buttonKatalogPakan.Name = "buttonKatalogPakan";
            buttonKatalogPakan.Size = new Size(200, 50);
            buttonKatalogPakan.TabIndex = 9;
            buttonKatalogPakan.Text = "Katalog Pakan";
            buttonKatalogPakan.UseVisualStyleBackColor = true;
            buttonKatalogPakan.Click += buttonKatalogPakan_Click;
            // 
            // buttonKatalogBenih
            // 
            buttonKatalogBenih.Dock = DockStyle.Top;
            buttonKatalogBenih.FlatAppearance.BorderSize = 0;
            buttonKatalogBenih.FlatStyle = FlatStyle.Flat;
            buttonKatalogBenih.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKatalogBenih.ForeColor = Color.White;
            buttonKatalogBenih.Location = new Point(0, 100);
            buttonKatalogBenih.Name = "buttonKatalogBenih";
            buttonKatalogBenih.Size = new Size(200, 50);
            buttonKatalogBenih.TabIndex = 8;
            buttonKatalogBenih.Text = "Katalog Benih";
            buttonKatalogBenih.UseVisualStyleBackColor = true;
            buttonKatalogBenih.Click += buttonKatalogBenih_Click;
            // 
            // buttonDashboardSupp
            // 
            buttonDashboardSupp.Dock = DockStyle.Top;
            buttonDashboardSupp.FlatAppearance.BorderSize = 0;
            buttonDashboardSupp.FlatStyle = FlatStyle.Flat;
            buttonDashboardSupp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboardSupp.ForeColor = Color.White;
            buttonDashboardSupp.Location = new Point(0, 50);
            buttonDashboardSupp.Name = "buttonDashboardSupp";
            buttonDashboardSupp.Size = new Size(200, 50);
            buttonDashboardSupp.TabIndex = 7;
            buttonDashboardSupp.Text = "Dashboard";
            buttonDashboardSupp.UseVisualStyleBackColor = true;
            buttonDashboardSupp.Click += buttonKatalogSupp_Click;
            // 
            // labelFish
            // 
            labelFish.Dock = DockStyle.Top;
            labelFish.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFish.ForeColor = Color.White;
            labelFish.Location = new Point(0, 0);
            labelFish.Name = "labelFish";
            labelFish.Size = new Size(200, 50);
            labelFish.TabIndex = 13;
            labelFish.Text = "FishIt";
            labelFish.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogoutSupp
            // 
            buttonLogoutSupp.BackColor = Color.CornflowerBlue;
            buttonLogoutSupp.Dock = DockStyle.Bottom;
            buttonLogoutSupp.FlatAppearance.BorderSize = 0;
            buttonLogoutSupp.FlatStyle = FlatStyle.Flat;
            buttonLogoutSupp.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogoutSupp.ForeColor = Color.White;
            buttonLogoutSupp.Location = new Point(0, 662);
            buttonLogoutSupp.Name = "buttonLogoutSupp";
            buttonLogoutSupp.Size = new Size(200, 50);
            buttonLogoutSupp.TabIndex = 6;
            buttonLogoutSupp.Text = "LogOut";
            buttonLogoutSupp.UseVisualStyleBackColor = false;
            buttonLogoutSupp.Click += buttonLogoutSupp_Click;
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.LightSteelBlue;
            panelNB.Controls.Add(panelUsername);
            panelNB.Dock = DockStyle.Top;
            panelNB.ForeColor = Color.LightSteelBlue;
            panelNB.Location = new Point(200, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(802, 50);
            panelNB.TabIndex = 4;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.LightSteelBlue;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(802, 662);
            panelContent.TabIndex = 6;
            panelContent.Paint += panelContent_Paint;
            // 
            // panelUsername
            // 
            panelUsername.Controls.Add(lblUsernameTopbar);
            panelUsername.Controls.Add(iconPictureBox1);
            panelUsername.Location = new Point(6, 3);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(796, 44);
            panelUsername.TabIndex = 7;
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
            // FormSupplier
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelContent);
            Controls.Add(panelNB);
            Controls.Add(panelSB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormSupplier";
            Text = "FormSupplier";
            WindowState = FormWindowState.Maximized;
            Load += FormSupplier_Load;
            panelSB.ResumeLayout(false);
            panelNB.ResumeLayout(false);
            panelUsername.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSB;
        private Button buttonLogoutSupp;
        private Panel panelNB;
        private Button buttonDashboardSupp;
        private Button buttonPengajuanBenih;
        private Button buttonKatalogPakan;
        private Button buttonKatalogBenih;
        private Button buttonPengajuanPakan;
        private Panel panelContent;
        private Button buttonRiwayatVerifikasi;
        private Label labelFish;
        private Panel panelUsername;
        private Label lblUsernameTopbar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}