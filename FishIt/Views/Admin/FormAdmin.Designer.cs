namespace FishIt
{
    partial class FormAdmin
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
            buttonLogoutAdmin = new FontAwesome.Sharp.IconButton();
            panelSubLaporan = new Panel();
            buttonPengiriman = new FontAwesome.Sharp.IconButton();
            buttonVerifikasi = new FontAwesome.Sharp.IconButton();
            buttonMonitoring = new FontAwesome.Sharp.IconButton();
            buttonLaporan = new FontAwesome.Sharp.IconButton();
            panelSubDataFishIt = new Panel();
            buttonKolam = new FontAwesome.Sharp.IconButton();
            buttonStokIkan = new FontAwesome.Sharp.IconButton();
            buttonIkan = new FontAwesome.Sharp.IconButton();
            panelSubKelolaAkun = new Panel();
            btnDataAkun = new FontAwesome.Sharp.IconButton();
            buttonTambahAkun = new FontAwesome.Sharp.IconButton();
            buttonKelolaAkun = new FontAwesome.Sharp.IconButton();
            buttonDashboard = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panelTB = new Panel();
            panelContent = new Panel();
            panelSB.SuspendLayout();
            panelSubLaporan.SuspendLayout();
            panelSubDataFishIt.SuspendLayout();
            panelSubKelolaAkun.SuspendLayout();
            SuspendLayout();
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogoutAdmin);
            panelSB.Controls.Add(panelSubLaporan);
            panelSB.Controls.Add(buttonLaporan);
            panelSB.Controls.Add(panelSubDataFishIt);
            panelSB.Controls.Add(buttonIkan);
            panelSB.Controls.Add(panelSubKelolaAkun);
            panelSB.Controls.Add(buttonKelolaAkun);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Controls.Add(label1);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 712);
            panelSB.TabIndex = 3;
            panelSB.Paint += panelSB_Paint;
            // 
            // buttonLogoutAdmin
            // 
            buttonLogoutAdmin.BackColor = Color.Transparent;
            buttonLogoutAdmin.BackgroundImageLayout = ImageLayout.Zoom;
            buttonLogoutAdmin.Dock = DockStyle.Bottom;
            buttonLogoutAdmin.FlatAppearance.BorderSize = 0;
            buttonLogoutAdmin.FlatStyle = FlatStyle.Flat;
            buttonLogoutAdmin.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogoutAdmin.ForeColor = Color.White;
            buttonLogoutAdmin.IconChar = FontAwesome.Sharp.IconChar.LongArrowLeft;
            buttonLogoutAdmin.IconColor = Color.White;
            buttonLogoutAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLogoutAdmin.IconSize = 30;
            buttonLogoutAdmin.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogoutAdmin.Location = new Point(0, 662);
            buttonLogoutAdmin.Name = "buttonLogoutAdmin";
            buttonLogoutAdmin.Padding = new Padding(15, 0, 0, 0);
            buttonLogoutAdmin.Size = new Size(200, 50);
            buttonLogoutAdmin.TabIndex = 11;
            buttonLogoutAdmin.Text = "Logout";
            buttonLogoutAdmin.TextAlign = ContentAlignment.MiddleLeft;
            buttonLogoutAdmin.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogoutAdmin.UseVisualStyleBackColor = false;
            buttonLogoutAdmin.Click += buttonLogoutAdmin_Click_1;
            // 
            // panelSubLaporan
            // 
            panelSubLaporan.Controls.Add(buttonPengiriman);
            panelSubLaporan.Controls.Add(buttonVerifikasi);
            panelSubLaporan.Controls.Add(buttonMonitoring);
            panelSubLaporan.Dock = DockStyle.Top;
            panelSubLaporan.Location = new Point(0, 418);
            panelSubLaporan.Name = "panelSubLaporan";
            panelSubLaporan.Size = new Size(200, 127);
            panelSubLaporan.TabIndex = 0;
            // 
            // buttonPengiriman
            // 
            buttonPengiriman.BackColor = Color.Transparent;
            buttonPengiriman.Dock = DockStyle.Top;
            buttonPengiriman.FlatAppearance.BorderSize = 0;
            buttonPengiriman.FlatStyle = FlatStyle.Flat;
            buttonPengiriman.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonPengiriman.ForeColor = Color.White;
            buttonPengiriman.IconChar = FontAwesome.Sharp.IconChar.TruckFast;
            buttonPengiriman.IconColor = Color.White;
            buttonPengiriman.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonPengiriman.IconSize = 30;
            buttonPengiriman.ImageAlign = ContentAlignment.MiddleLeft;
            buttonPengiriman.Location = new Point(0, 80);
            buttonPengiriman.Name = "buttonPengiriman";
            buttonPengiriman.Padding = new Padding(50, 0, 0, 0);
            buttonPengiriman.Size = new Size(200, 40);
            buttonPengiriman.TabIndex = 11;
            buttonPengiriman.Text = "Pengiriman";
            buttonPengiriman.TextAlign = ContentAlignment.MiddleLeft;
            buttonPengiriman.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonPengiriman.UseVisualStyleBackColor = false;
            buttonPengiriman.Click += buttonPengiriman_Click;
            // 
            // buttonVerifikasi
            // 
            buttonVerifikasi.BackColor = Color.Transparent;
            buttonVerifikasi.Dock = DockStyle.Top;
            buttonVerifikasi.FlatAppearance.BorderSize = 0;
            buttonVerifikasi.FlatStyle = FlatStyle.Flat;
            buttonVerifikasi.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonVerifikasi.ForeColor = Color.White;
            buttonVerifikasi.IconChar = FontAwesome.Sharp.IconChar.Check;
            buttonVerifikasi.IconColor = Color.White;
            buttonVerifikasi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonVerifikasi.IconSize = 30;
            buttonVerifikasi.ImageAlign = ContentAlignment.MiddleLeft;
            buttonVerifikasi.Location = new Point(0, 40);
            buttonVerifikasi.Name = "buttonVerifikasi";
            buttonVerifikasi.Padding = new Padding(50, 0, 0, 0);
            buttonVerifikasi.Size = new Size(200, 40);
            buttonVerifikasi.TabIndex = 10;
            buttonVerifikasi.Text = "Verifikasi Supply";
            buttonVerifikasi.TextAlign = ContentAlignment.MiddleLeft;
            buttonVerifikasi.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonVerifikasi.UseVisualStyleBackColor = false;
            buttonVerifikasi.Click += buttonVerifikasi_Click;
            // 
            // buttonMonitoring
            // 
            buttonMonitoring.BackColor = Color.Transparent;
            buttonMonitoring.Dock = DockStyle.Top;
            buttonMonitoring.FlatAppearance.BorderSize = 0;
            buttonMonitoring.FlatStyle = FlatStyle.Flat;
            buttonMonitoring.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonMonitoring.ForeColor = Color.White;
            buttonMonitoring.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            buttonMonitoring.IconColor = Color.White;
            buttonMonitoring.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonMonitoring.IconSize = 30;
            buttonMonitoring.ImageAlign = ContentAlignment.MiddleLeft;
            buttonMonitoring.Location = new Point(0, 0);
            buttonMonitoring.Name = "buttonMonitoring";
            buttonMonitoring.Padding = new Padding(50, 0, 0, 0);
            buttonMonitoring.Size = new Size(200, 40);
            buttonMonitoring.TabIndex = 9;
            buttonMonitoring.Text = "Monitoring";
            buttonMonitoring.TextAlign = ContentAlignment.MiddleLeft;
            buttonMonitoring.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonMonitoring.UseVisualStyleBackColor = false;
            buttonMonitoring.Click += buttonMonitoring_Click;
            // 
            // buttonLaporan
            // 
            buttonLaporan.BackColor = Color.Transparent;
            buttonLaporan.Dock = DockStyle.Top;
            buttonLaporan.FlatAppearance.BorderSize = 0;
            buttonLaporan.FlatStyle = FlatStyle.Flat;
            buttonLaporan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLaporan.ForeColor = Color.White;
            buttonLaporan.IconChar = FontAwesome.Sharp.IconChar.Book;
            buttonLaporan.IconColor = Color.White;
            buttonLaporan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLaporan.IconSize = 30;
            buttonLaporan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLaporan.Location = new Point(0, 368);
            buttonLaporan.Name = "buttonLaporan";
            buttonLaporan.Padding = new Padding(15, 0, 0, 0);
            buttonLaporan.Size = new Size(200, 50);
            buttonLaporan.TabIndex = 10;
            buttonLaporan.Text = "Laporan";
            buttonLaporan.TextAlign = ContentAlignment.MiddleLeft;
            buttonLaporan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLaporan.UseVisualStyleBackColor = false;
            buttonLaporan.Click += buttonLaporan_Click;
            // 
            // panelSubDataFishIt
            // 
            panelSubDataFishIt.Controls.Add(buttonKolam);
            panelSubDataFishIt.Controls.Add(buttonStokIkan);
            panelSubDataFishIt.Dock = DockStyle.Top;
            panelSubDataFishIt.Location = new Point(0, 281);
            panelSubDataFishIt.Name = "panelSubDataFishIt";
            panelSubDataFishIt.Size = new Size(200, 87);
            panelSubDataFishIt.TabIndex = 0;
            // 
            // buttonKolam
            // 
            buttonKolam.BackColor = Color.Transparent;
            buttonKolam.Dock = DockStyle.Top;
            buttonKolam.FlatAppearance.BorderSize = 0;
            buttonKolam.FlatStyle = FlatStyle.Flat;
            buttonKolam.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKolam.ForeColor = Color.White;
            buttonKolam.IconChar = FontAwesome.Sharp.IconChar.Water;
            buttonKolam.IconColor = Color.White;
            buttonKolam.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKolam.IconSize = 30;
            buttonKolam.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKolam.Location = new Point(0, 40);
            buttonKolam.Name = "buttonKolam";
            buttonKolam.Padding = new Padding(50, 0, 0, 0);
            buttonKolam.Size = new Size(200, 47);
            buttonKolam.TabIndex = 14;
            buttonKolam.Text = "Data Kolam";
            buttonKolam.TextAlign = ContentAlignment.MiddleLeft;
            buttonKolam.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKolam.UseVisualStyleBackColor = false;
            buttonKolam.Click += buttonKolam_Click_1;
            // 
            // buttonStokIkan
            // 
            buttonStokIkan.BackColor = Color.Transparent;
            buttonStokIkan.Dock = DockStyle.Top;
            buttonStokIkan.FlatAppearance.BorderSize = 0;
            buttonStokIkan.FlatStyle = FlatStyle.Flat;
            buttonStokIkan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStokIkan.ForeColor = Color.White;
            buttonStokIkan.IconChar = FontAwesome.Sharp.IconChar.FishFins;
            buttonStokIkan.IconColor = Color.White;
            buttonStokIkan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonStokIkan.IconSize = 30;
            buttonStokIkan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonStokIkan.Location = new Point(0, 0);
            buttonStokIkan.Name = "buttonStokIkan";
            buttonStokIkan.Padding = new Padding(50, 0, 0, 0);
            buttonStokIkan.Size = new Size(200, 40);
            buttonStokIkan.TabIndex = 13;
            buttonStokIkan.Text = "Stok Ikan";
            buttonStokIkan.TextAlign = ContentAlignment.MiddleLeft;
            buttonStokIkan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonStokIkan.UseVisualStyleBackColor = false;
            buttonStokIkan.Click += buttonStokIkan_Click_1;
            // 
            // buttonIkan
            // 
            buttonIkan.BackColor = Color.Transparent;
            buttonIkan.Dock = DockStyle.Top;
            buttonIkan.FlatAppearance.BorderSize = 0;
            buttonIkan.FlatStyle = FlatStyle.Flat;
            buttonIkan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonIkan.ForeColor = Color.White;
            buttonIkan.IconChar = FontAwesome.Sharp.IconChar.Archive;
            buttonIkan.IconColor = Color.White;
            buttonIkan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonIkan.IconSize = 30;
            buttonIkan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonIkan.Location = new Point(0, 231);
            buttonIkan.Name = "buttonIkan";
            buttonIkan.Padding = new Padding(15, 0, 0, 0);
            buttonIkan.Size = new Size(200, 50);
            buttonIkan.TabIndex = 9;
            buttonIkan.Text = "Data FishIt";
            buttonIkan.TextAlign = ContentAlignment.MiddleLeft;
            buttonIkan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonIkan.UseVisualStyleBackColor = false;
            buttonIkan.Click += buttonIkan_Click;
            // 
            // panelSubKelolaAkun
            // 
            panelSubKelolaAkun.Controls.Add(btnDataAkun);
            panelSubKelolaAkun.Controls.Add(buttonTambahAkun);
            panelSubKelolaAkun.Dock = DockStyle.Top;
            panelSubKelolaAkun.Location = new Point(0, 150);
            panelSubKelolaAkun.Name = "panelSubKelolaAkun";
            panelSubKelolaAkun.Size = new Size(200, 81);
            panelSubKelolaAkun.TabIndex = 0;
            // 
            // btnDataAkun
            // 
            btnDataAkun.BackColor = Color.Transparent;
            btnDataAkun.Dock = DockStyle.Top;
            btnDataAkun.FlatAppearance.BorderSize = 0;
            btnDataAkun.FlatStyle = FlatStyle.Flat;
            btnDataAkun.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDataAkun.ForeColor = Color.White;
            btnDataAkun.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            btnDataAkun.IconColor = Color.White;
            btnDataAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDataAkun.IconSize = 30;
            btnDataAkun.ImageAlign = ContentAlignment.MiddleLeft;
            btnDataAkun.Location = new Point(0, 40);
            btnDataAkun.Name = "btnDataAkun";
            btnDataAkun.Padding = new Padding(50, 0, 0, 0);
            btnDataAkun.Size = new Size(200, 40);
            btnDataAkun.TabIndex = 9;
            btnDataAkun.Text = "Data Akun";
            btnDataAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnDataAkun.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDataAkun.UseVisualStyleBackColor = false;
            btnDataAkun.Click += btnDataAkun_Click;
            // 
            // buttonTambahAkun
            // 
            buttonTambahAkun.BackColor = Color.Transparent;
            buttonTambahAkun.Dock = DockStyle.Top;
            buttonTambahAkun.FlatAppearance.BorderSize = 0;
            buttonTambahAkun.FlatStyle = FlatStyle.Flat;
            buttonTambahAkun.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonTambahAkun.ForeColor = Color.White;
            buttonTambahAkun.IconChar = FontAwesome.Sharp.IconChar.Users;
            buttonTambahAkun.IconColor = Color.White;
            buttonTambahAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTambahAkun.IconSize = 30;
            buttonTambahAkun.ImageAlign = ContentAlignment.MiddleLeft;
            buttonTambahAkun.Location = new Point(0, 0);
            buttonTambahAkun.Name = "buttonTambahAkun";
            buttonTambahAkun.Padding = new Padding(50, 0, 0, 0);
            buttonTambahAkun.Size = new Size(200, 40);
            buttonTambahAkun.TabIndex = 8;
            buttonTambahAkun.Text = "Kelola Akun";
            buttonTambahAkun.TextAlign = ContentAlignment.MiddleLeft;
            buttonTambahAkun.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambahAkun.UseVisualStyleBackColor = false;
            buttonTambahAkun.Click += buttonTambahAkun_Click_1;
            // 
            // buttonKelolaAkun
            // 
            buttonKelolaAkun.BackColor = Color.Transparent;
            buttonKelolaAkun.Dock = DockStyle.Top;
            buttonKelolaAkun.FlatAppearance.BorderSize = 0;
            buttonKelolaAkun.FlatStyle = FlatStyle.Flat;
            buttonKelolaAkun.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKelolaAkun.ForeColor = Color.White;
            buttonKelolaAkun.IconChar = FontAwesome.Sharp.IconChar.User;
            buttonKelolaAkun.IconColor = Color.White;
            buttonKelolaAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKelolaAkun.IconSize = 30;
            buttonKelolaAkun.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKelolaAkun.Location = new Point(0, 100);
            buttonKelolaAkun.Name = "buttonKelolaAkun";
            buttonKelolaAkun.Padding = new Padding(15, 0, 0, 0);
            buttonKelolaAkun.Size = new Size(200, 50);
            buttonKelolaAkun.TabIndex = 8;
            buttonKelolaAkun.Text = "Akun";
            buttonKelolaAkun.TextAlign = ContentAlignment.MiddleLeft;
            buttonKelolaAkun.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKelolaAkun.UseVisualStyleBackColor = false;
            buttonKelolaAkun.Click += buttonKelolaAkun_Click;
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
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.TextAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDashboard.UseVisualStyleBackColor = false;
            buttonDashboard.Click += buttonDashboard_Click_1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 50);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTB
            // 
            panelTB.BackColor = Color.LightSteelBlue;
            panelTB.Dock = DockStyle.Top;
            panelTB.Location = new Point(200, 0);
            panelTB.Name = "panelTB";
            panelTB.Size = new Size(802, 50);
            panelTB.TabIndex = 0;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.LightSteelBlue;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(802, 662);
            panelContent.TabIndex = 1;
            panelContent.Paint += panelContent_Paint_1;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelContent);
            Controls.Add(panelTB);
            Controls.Add(panelSB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            WindowState = FormWindowState.Maximized;
            Load += FormAdmin_Load;
            panelSB.ResumeLayout(false);
            panelSubLaporan.ResumeLayout(false);
            panelSubDataFishIt.ResumeLayout(false);
            panelSubKelolaAkun.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelSB;
        private Panel panelNB;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private FontAwesome.Sharp.IconButton buttonKelolaAkun;
        private Panel panelSubKelolaAkun;
        private FontAwesome.Sharp.IconButton buttonTambahAkun;
        private FontAwesome.Sharp.IconButton buttonIkan;
        private Panel panelSubDataFishIt;
        private Panel panelSubLaporan;
        private FontAwesome.Sharp.IconButton buttonLaporan;
        private FontAwesome.Sharp.IconButton buttonLogoutAdmin;
        private FontAwesome.Sharp.IconButton buttonPengiriman;
        private FontAwesome.Sharp.IconButton buttonVerifikasi;
        private FontAwesome.Sharp.IconButton buttonMonitoring;
        private FontAwesome.Sharp.IconButton buttonKolam;
        private FontAwesome.Sharp.IconButton buttonStokIkan;
        private Label label1;
        private Panel panelTB;
        private Panel panelContent;
        private FontAwesome.Sharp.IconButton btnDataAkun;
    }
}