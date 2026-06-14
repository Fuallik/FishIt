namespace FishIt
{
    partial class FormPembeli
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
            label1 = new Label();
            panelKontenPembeli = new Panel();
            panelTB = new Panel();
            panelUsername = new Panel();
            lblUsernameTopbar = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panelSB = new Panel();
            buttonLogoutAdmin = new FontAwesome.Sharp.IconButton();
            buttonRiwayat = new FontAwesome.Sharp.IconButton();
            buttonKeranjang = new FontAwesome.Sharp.IconButton();
            buttonKatalogIkan = new FontAwesome.Sharp.IconButton();
            buttonDashboard = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            panelTB.SuspendLayout();
            panelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            panelSB.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 240);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 0;
            label1.Text = "INI PEMBELI";
            label1.Click += label1_Click;
            // 
            // panelKontenPembeli
            // 
            panelKontenPembeli.BackColor = Color.LightSteelBlue;
            panelKontenPembeli.Dock = DockStyle.Fill;
            panelKontenPembeli.Location = new Point(200, 50);
            panelKontenPembeli.Name = "panelKontenPembeli";
            panelKontenPembeli.Size = new Size(802, 662);
            panelKontenPembeli.TabIndex = 5;
            panelKontenPembeli.Paint += panelContent_Paint_1;
            // 
            // panelTB
            // 
            panelTB.BackColor = Color.LightSteelBlue;
            panelTB.Controls.Add(panelUsername);
            panelTB.Dock = DockStyle.Top;
            panelTB.Location = new Point(200, 0);
            panelTB.Name = "panelTB";
            panelTB.Size = new Size(802, 50);
            panelTB.TabIndex = 4;
            // 
            // panelUsername
            // 
            panelUsername.Controls.Add(lblUsernameTopbar);
            panelUsername.Controls.Add(iconPictureBox1);
            panelUsername.Location = new Point(3, 3);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(796, 44);
            panelUsername.TabIndex = 1;
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
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogoutAdmin);
            panelSB.Controls.Add(buttonRiwayat);
            panelSB.Controls.Add(buttonKeranjang);
            panelSB.Controls.Add(buttonKatalogIkan);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Controls.Add(label2);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 712);
            panelSB.TabIndex = 6;
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
            buttonLogoutAdmin.Click += buttonLogoutAdmin_Click;
            // 
            // buttonRiwayat
            // 
            buttonRiwayat.BackColor = Color.Transparent;
            buttonRiwayat.Dock = DockStyle.Top;
            buttonRiwayat.FlatAppearance.BorderSize = 0;
            buttonRiwayat.FlatStyle = FlatStyle.Flat;
            buttonRiwayat.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRiwayat.ForeColor = Color.White;
            buttonRiwayat.IconChar = FontAwesome.Sharp.IconChar.ArrowsSpin;
            buttonRiwayat.IconColor = Color.White;
            buttonRiwayat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRiwayat.IconSize = 30;
            buttonRiwayat.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRiwayat.Location = new Point(0, 200);
            buttonRiwayat.Name = "buttonRiwayat";
            buttonRiwayat.Padding = new Padding(15, 0, 0, 0);
            buttonRiwayat.Size = new Size(200, 50);
            buttonRiwayat.TabIndex = 10;
            buttonRiwayat.Text = "Riwayat";
            buttonRiwayat.TextAlign = ContentAlignment.MiddleLeft;
            buttonRiwayat.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRiwayat.UseVisualStyleBackColor = false;
            buttonRiwayat.Click += buttonRiwayat_Click;
            // 
            // buttonKeranjang
            // 
            buttonKeranjang.BackColor = Color.Transparent;
            buttonKeranjang.Dock = DockStyle.Top;
            buttonKeranjang.FlatAppearance.BorderSize = 0;
            buttonKeranjang.FlatStyle = FlatStyle.Flat;
            buttonKeranjang.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKeranjang.ForeColor = Color.White;
            buttonKeranjang.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            buttonKeranjang.IconColor = Color.White;
            buttonKeranjang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKeranjang.IconSize = 30;
            buttonKeranjang.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKeranjang.Location = new Point(0, 150);
            buttonKeranjang.Name = "buttonKeranjang";
            buttonKeranjang.Padding = new Padding(15, 0, 0, 0);
            buttonKeranjang.Size = new Size(200, 50);
            buttonKeranjang.TabIndex = 9;
            buttonKeranjang.Text = "Keranjang";
            buttonKeranjang.TextAlign = ContentAlignment.MiddleLeft;
            buttonKeranjang.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKeranjang.UseVisualStyleBackColor = false;
            buttonKeranjang.Click += buttonKeranjang_Click;
            // 
            // buttonKatalogIkan
            // 
            buttonKatalogIkan.BackColor = Color.Transparent;
            buttonKatalogIkan.Dock = DockStyle.Top;
            buttonKatalogIkan.FlatAppearance.BorderSize = 0;
            buttonKatalogIkan.FlatStyle = FlatStyle.Flat;
            buttonKatalogIkan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKatalogIkan.ForeColor = Color.White;
            buttonKatalogIkan.IconChar = FontAwesome.Sharp.IconChar.FishFins;
            buttonKatalogIkan.IconColor = Color.White;
            buttonKatalogIkan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKatalogIkan.IconSize = 30;
            buttonKatalogIkan.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKatalogIkan.Location = new Point(0, 100);
            buttonKatalogIkan.Name = "buttonKatalogIkan";
            buttonKatalogIkan.Padding = new Padding(15, 0, 0, 0);
            buttonKatalogIkan.Size = new Size(200, 50);
            buttonKatalogIkan.TabIndex = 8;
            buttonKatalogIkan.Text = "Katalog Ikan";
            buttonKatalogIkan.TextAlign = ContentAlignment.MiddleLeft;
            buttonKatalogIkan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKatalogIkan.UseVisualStyleBackColor = false;
            buttonKatalogIkan.Click += buttonKatalogIkan_Click;
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
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(200, 50);
            label2.TabIndex = 0;
            label2.Text = "FishIt";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormPembeli
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelKontenPembeli);
            Controls.Add(panelTB);
            Controls.Add(panelSB);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPembeli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPembeli";
            WindowState = FormWindowState.Maximized;
            Load += FormPembeli_Load;
            panelTB.ResumeLayout(false);
            panelUsername.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            panelSB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panelKontenPembeli;
        private Panel panelTB;
        private Panel panelSB;
        private FontAwesome.Sharp.IconButton buttonLogoutAdmin;
        private FontAwesome.Sharp.IconButton buttonRiwayat;
        private FontAwesome.Sharp.IconButton buttonKeranjang;
        private FontAwesome.Sharp.IconButton buttonKatalogIkan;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private Label label2;
        private Panel panelUsername;
        private Label lblUsernameTopbar;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}