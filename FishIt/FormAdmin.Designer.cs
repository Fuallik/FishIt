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
            label1 = new Label();
            buttonLogOut = new Button();
            buttonKlAkun = new Button();
            panelSubKelolaAkun = new Panel();
            buttonHapusAkun = new Button();
            buttonEditAkun = new Button();
            buttonTambahAKun = new Button();
            buttonKelolaDataKolam = new Button();
            buttonVerifikasiSupply = new Button();
            buttonLaporanMonitoring = new Button();
            panelSB = new Panel();
            buttonLogoutAdmin = new Button();
            buttonDashboard = new Button();
            panelNB = new Panel();
            panelContent = new Panel();
            panelSubKelolaAkun.SuspendLayout();
            panelSB.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(336, 224);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 0;
            label1.Text = "INI ADMIN";
            // 
            // buttonLogOut
            // 
            buttonLogOut.Location = new Point(389, 342);
            buttonLogOut.Name = "buttonLogOut";
            buttonLogOut.Size = new Size(112, 34);
            buttonLogOut.TabIndex = 1;
            buttonLogOut.Text = "Log Out";
            buttonLogOut.UseVisualStyleBackColor = true;
            buttonLogOut.Click += buttonLogOut_Click;
            // 
            // buttonKlAkun
            // 
            buttonKlAkun.BackColor = Color.CornflowerBlue;
            buttonKlAkun.Dock = DockStyle.Top;
            buttonKlAkun.FlatAppearance.BorderSize = 0;
            buttonKlAkun.FlatStyle = FlatStyle.Flat;
            buttonKlAkun.Location = new Point(0, 50);
            buttonKlAkun.Name = "buttonKlAkun";
            buttonKlAkun.Size = new Size(200, 50);
            buttonKlAkun.TabIndex = 1;
            buttonKlAkun.Text = "Kelola Akun";
            buttonKlAkun.UseVisualStyleBackColor = false;
            buttonKlAkun.Click += buttonKlAkun_Click;
            // 
            // panelSubKelolaAkun
            // 
            panelSubKelolaAkun.AutoScroll = true;
            panelSubKelolaAkun.Controls.Add(buttonHapusAkun);
            panelSubKelolaAkun.Controls.Add(buttonEditAkun);
            panelSubKelolaAkun.Controls.Add(buttonTambahAKun);
            panelSubKelolaAkun.Dock = DockStyle.Top;
            panelSubKelolaAkun.Location = new Point(0, 100);
            panelSubKelolaAkun.Name = "panelSubKelolaAkun";
            panelSubKelolaAkun.Size = new Size(200, 120);
            panelSubKelolaAkun.TabIndex = 2;
            panelSubKelolaAkun.Visible = false;
            // 
            // buttonHapusAkun
            // 
            buttonHapusAkun.BackColor = Color.CornflowerBlue;
            buttonHapusAkun.Dock = DockStyle.Top;
            buttonHapusAkun.FlatAppearance.BorderSize = 0;
            buttonHapusAkun.FlatStyle = FlatStyle.Flat;
            buttonHapusAkun.Location = new Point(0, 80);
            buttonHapusAkun.Name = "buttonHapusAkun";
            buttonHapusAkun.Size = new Size(200, 40);
            buttonHapusAkun.TabIndex = 4;
            buttonHapusAkun.Text = "Hapus Akun";
            buttonHapusAkun.UseVisualStyleBackColor = false;
            buttonHapusAkun.Click += buttonHapusAkun_Click;
            // 
            // buttonEditAkun
            // 
            buttonEditAkun.BackColor = Color.CornflowerBlue;
            buttonEditAkun.Dock = DockStyle.Top;
            buttonEditAkun.FlatAppearance.BorderSize = 0;
            buttonEditAkun.FlatStyle = FlatStyle.Flat;
            buttonEditAkun.Location = new Point(0, 40);
            buttonEditAkun.Name = "buttonEditAkun";
            buttonEditAkun.Size = new Size(200, 40);
            buttonEditAkun.TabIndex = 3;
            buttonEditAkun.Text = "Edit Akun";
            buttonEditAkun.UseVisualStyleBackColor = false;
            buttonEditAkun.Click += buttonEditAkun_Click;
            // 
            // buttonTambahAKun
            // 
            buttonTambahAKun.BackColor = Color.CornflowerBlue;
            buttonTambahAKun.Dock = DockStyle.Top;
            buttonTambahAKun.FlatAppearance.BorderSize = 0;
            buttonTambahAKun.FlatStyle = FlatStyle.Flat;
            buttonTambahAKun.Location = new Point(0, 0);
            buttonTambahAKun.Name = "buttonTambahAKun";
            buttonTambahAKun.Size = new Size(200, 40);
            buttonTambahAKun.TabIndex = 2;
            buttonTambahAKun.Text = "Tambah Akun";
            buttonTambahAKun.UseVisualStyleBackColor = false;
            buttonTambahAKun.Click += buttonTambahAkun_Click;
            // 
            // buttonKelolaDataKolam
            // 
            buttonKelolaDataKolam.BackColor = Color.CornflowerBlue;
            buttonKelolaDataKolam.Dock = DockStyle.Top;
            buttonKelolaDataKolam.FlatAppearance.BorderSize = 0;
            buttonKelolaDataKolam.FlatStyle = FlatStyle.Flat;
            buttonKelolaDataKolam.Location = new Point(0, 220);
            buttonKelolaDataKolam.Name = "buttonKelolaDataKolam";
            buttonKelolaDataKolam.Size = new Size(200, 50);
            buttonKelolaDataKolam.TabIndex = 3;
            buttonKelolaDataKolam.Text = "Kelola Data Kolam";
            buttonKelolaDataKolam.UseVisualStyleBackColor = false;
            buttonKelolaDataKolam.Click += buttonKelolaDataKolam_Click;
            // 
            // buttonVerifikasiSupply
            // 
            buttonVerifikasiSupply.BackColor = Color.CornflowerBlue;
            buttonVerifikasiSupply.Dock = DockStyle.Top;
            buttonVerifikasiSupply.FlatAppearance.BorderSize = 0;
            buttonVerifikasiSupply.FlatStyle = FlatStyle.Flat;
            buttonVerifikasiSupply.Location = new Point(0, 270);
            buttonVerifikasiSupply.Name = "buttonVerifikasiSupply";
            buttonVerifikasiSupply.Size = new Size(200, 50);
            buttonVerifikasiSupply.TabIndex = 4;
            buttonVerifikasiSupply.Text = "Verifikasi Supply";
            buttonVerifikasiSupply.UseVisualStyleBackColor = false;
            buttonVerifikasiSupply.Click += buttonVerifikasiSupply_Click;
            // 
            // buttonLaporanMonitoring
            // 
            buttonLaporanMonitoring.BackColor = Color.CornflowerBlue;
            buttonLaporanMonitoring.Dock = DockStyle.Top;
            buttonLaporanMonitoring.FlatAppearance.BorderSize = 0;
            buttonLaporanMonitoring.FlatStyle = FlatStyle.Flat;
            buttonLaporanMonitoring.Location = new Point(0, 320);
            buttonLaporanMonitoring.Name = "buttonLaporanMonitoring";
            buttonLaporanMonitoring.Size = new Size(200, 50);
            buttonLaporanMonitoring.TabIndex = 5;
            buttonLaporanMonitoring.Text = "Laporan Monitoring";
            buttonLaporanMonitoring.UseVisualStyleBackColor = false;
            buttonLaporanMonitoring.Click += buttonLaporanMonitoring_Click;
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogoutAdmin);
            panelSB.Controls.Add(buttonLaporanMonitoring);
            panelSB.Controls.Add(buttonVerifikasiSupply);
            panelSB.Controls.Add(buttonKelolaDataKolam);
            panelSB.Controls.Add(panelSubKelolaAkun);
            panelSB.Controls.Add(buttonKlAkun);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 50);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 662);
            panelSB.TabIndex = 3;
            panelSB.Paint += panelSB_Paint;
            // 
            // buttonLogoutAdmin
            // 
            buttonLogoutAdmin.BackColor = Color.CornflowerBlue;
            buttonLogoutAdmin.Dock = DockStyle.Bottom;
            buttonLogoutAdmin.FlatAppearance.BorderSize = 0;
            buttonLogoutAdmin.FlatStyle = FlatStyle.Flat;
            buttonLogoutAdmin.Location = new Point(0, 612);
            buttonLogoutAdmin.Name = "buttonLogoutAdmin";
            buttonLogoutAdmin.Size = new Size(200, 50);
            buttonLogoutAdmin.TabIndex = 6;
            buttonLogoutAdmin.Text = "LogOut";
            buttonLogoutAdmin.UseVisualStyleBackColor = false;
            buttonLogoutAdmin.Click += buttonLogoutAdmin_Click;
            // 
            // buttonDashboard
            // 
            buttonDashboard.Dock = DockStyle.Top;
            buttonDashboard.FlatAppearance.BorderSize = 0;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboard.ForeColor = Color.White;
            buttonDashboard.Location = new Point(0, 0);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(200, 50);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.UseVisualStyleBackColor = true;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.CornflowerBlue;
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(0, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(1002, 50);
            panelNB.TabIndex = 2;
            panelNB.Paint += panel1_Paint;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(802, 662);
            panelContent.TabIndex = 4;
            panelContent.Paint += panelCT_Paint;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(panelContent);
            Controls.Add(panelSB);
            Controls.Add(panelNB);
            Controls.Add(buttonLogOut);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdmin";
            WindowState = FormWindowState.Maximized;
            Load += FormAdmin_Load;
            panelSubKelolaAkun.ResumeLayout(false);
            panelSB.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonLogOut;
        private Button buttonKlAkun;
        private Panel panelSubKelolaAkun;
        private Button buttonHapusAkun;
        private Button buttonEditAkun;
        private Button buttonTambahAKun;
        private Button buttonKelolaDataKolam;
        private Button buttonVerifikasiSupply;
        private Button buttonLaporanMonitoring;
        private Panel panelSB;
        private Panel panelNB;
        private Button buttonLogoutAdmin;
        private Button buttonDashboard;
        private Panel panelContent;
    }
}