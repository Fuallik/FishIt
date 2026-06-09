namespace FishIt
{
    partial class UC_KelolaAkun
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelAkunTambak = new Panel();
            btnTambah = new FontAwesome.Sharp.IconButton();
            label3 = new Label();
            panelJumlahAkun = new Panel();
            label1 = new Label();
            labelAkunAktif = new Label();
            lblHitungAkunTidakAktif = new Label();
            panelStatistik = new Panel();
            lblHitungAkunAktif = new Label();
            label2 = new Label();
            labelJumlahAkun = new Label();
            DGVRiwayatTambahAkun = new DataGridView();
            panel1 = new Panel();
            btnHapusAkun = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panelAkunTambak.SuspendLayout();
            panelJumlahAkun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelAkunTambak
            // 
            panelAkunTambak.BackColor = Color.CornflowerBlue;
            panelAkunTambak.Controls.Add(btnTambah);
            panelAkunTambak.Controls.Add(label3);
            panelAkunTambak.Location = new Point(22, 182);
            panelAkunTambak.Name = "panelAkunTambak";
            panelAkunTambak.Size = new Size(240, 45);
            panelAkunTambak.TabIndex = 7;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.CornflowerBlue;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnTambah.IconColor = Color.White;
            btnTambah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTambah.Location = new Point(126, 2);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(110, 42);
            btnTambah.TabIndex = 14;
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 8);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 13;
            label3.Text = "Tambah";
            // 
            // panelJumlahAkun
            // 
            panelJumlahAkun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelJumlahAkun.BackColor = Color.CornflowerBlue;
            panelJumlahAkun.Controls.Add(label1);
            panelJumlahAkun.Controls.Add(labelAkunAktif);
            panelJumlahAkun.Controls.Add(lblHitungAkunTidakAktif);
            panelJumlahAkun.Controls.Add(panelStatistik);
            panelJumlahAkun.Controls.Add(lblHitungAkunAktif);
            panelJumlahAkun.Controls.Add(label2);
            panelJumlahAkun.Controls.Add(labelJumlahAkun);
            panelJumlahAkun.Location = new Point(22, 30);
            panelJumlahAkun.Name = "panelJumlahAkun";
            panelJumlahAkun.Size = new Size(757, 135);
            panelJumlahAkun.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(370, 95);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 9;
            label1.Text = "Akun Tidak Aktif\r\n";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelAkunAktif
            // 
            labelAkunAktif.AutoSize = true;
            labelAkunAktif.BackColor = Color.Transparent;
            labelAkunAktif.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAkunAktif.ForeColor = Color.White;
            labelAkunAktif.Location = new Point(392, 42);
            labelAkunAktif.Name = "labelAkunAktif";
            labelAkunAktif.Size = new Size(82, 21);
            labelAkunAktif.TabIndex = 7;
            labelAkunAktif.Text = "Akun Aktif\r\n";
            labelAkunAktif.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHitungAkunTidakAktif
            // 
            lblHitungAkunTidakAktif.BackColor = Color.Transparent;
            lblHitungAkunTidakAktif.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHitungAkunTidakAktif.ForeColor = Color.White;
            lblHitungAkunTidakAktif.Location = new Point(416, 54);
            lblHitungAkunTidakAktif.Name = "lblHitungAkunTidakAktif";
            lblHitungAkunTidakAktif.Size = new Size(36, 47);
            lblHitungAkunTidakAktif.TabIndex = 8;
            lblHitungAkunTidakAktif.Text = "0";
            // 
            // panelStatistik
            // 
            panelStatistik.BackColor = Color.RoyalBlue;
            panelStatistik.Location = new Point(501, 13);
            panelStatistik.Name = "panelStatistik";
            panelStatistik.Size = new Size(242, 110);
            panelStatistik.TabIndex = 6;
            // 
            // lblHitungAkunAktif
            // 
            lblHitungAkunAktif.BackColor = Color.Transparent;
            lblHitungAkunAktif.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHitungAkunAktif.ForeColor = Color.White;
            lblHitungAkunAktif.Location = new Point(416, 6);
            lblHitungAkunAktif.Name = "lblHitungAkunAktif";
            lblHitungAkunAktif.Size = new Size(36, 47);
            lblHitungAkunAktif.TabIndex = 5;
            lblHitungAkunAktif.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 2;
            label2.Text = "Kelola Akun";
            // 
            // labelJumlahAkun
            // 
            labelJumlahAkun.AutoSize = true;
            labelJumlahAkun.BackColor = Color.Transparent;
            labelJumlahAkun.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            labelJumlahAkun.ForeColor = Color.White;
            labelJumlahAkun.Location = new Point(15, 67);
            labelJumlahAkun.Name = "labelJumlahAkun";
            labelJumlahAkun.Size = new Size(158, 56);
            labelJumlahAkun.TabIndex = 4;
            labelJumlahAkun.Text = "Total Akun\r\nDalam Database\r\n";
            labelJumlahAkun.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DGVRiwayatTambahAkun
            // 
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(22, 243);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(757, 340);
            DGVRiwayatTambahAkun.TabIndex = 13;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(btnHapusAkun);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(279, 182);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 45);
            panel1.TabIndex = 14;
            // 
            // btnHapusAkun
            // 
            btnHapusAkun.BackColor = Color.CornflowerBlue;
            btnHapusAkun.FlatAppearance.BorderSize = 0;
            btnHapusAkun.FlatStyle = FlatStyle.Flat;
            btnHapusAkun.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            btnHapusAkun.IconColor = Color.White;
            btnHapusAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHapusAkun.Location = new Point(129, 2);
            btnHapusAkun.Name = "btnHapusAkun";
            btnHapusAkun.Size = new Size(110, 42);
            btnHapusAkun.TabIndex = 15;
            btnHapusAkun.UseVisualStyleBackColor = false;
            btnHapusAkun.Click += this.btnHapusAkun_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 8);
            label4.Name = "label4";
            label4.Size = new Size(70, 28);
            label4.TabIndex = 15;
            label4.Text = "Hapus";
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(iconButton2);
            panel2.Location = new Point(539, 182);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 45);
            panel2.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(4, 8);
            label5.Name = "label5";
            label5.Size = new Size(46, 28);
            label5.TabIndex = 17;
            label5.Text = "Edit";
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.CornflowerBlue;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(128, 2);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(110, 42);
            iconButton2.TabIndex = 16;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // UC_KelolaAkun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(DGVRiwayatTambahAkun);
            Controls.Add(panelAkunTambak);
            Controls.Add(panelJumlahAkun);
            Name = "UC_KelolaAkun";
            Size = new Size(800, 600);
            Load += UC_TambahAkun_Load;
            panelAkunTambak.ResumeLayout(false);
            panelAkunTambak.PerformLayout();
            panelJumlahAkun.ResumeLayout(false);
            panelJumlahAkun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelAkunTambak;
        private Panel panelJumlahAkun;
        private Label label1;
        private Label labelAkunAktif;
        private Label lblHitungAkunTidakAktif;
        private Panel panelStatistik;
        private Label lblHitungAkunAktif;
        private Label label2;
        private Label labelJumlahAkun;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnTambah;
        private DataGridView DGVRiwayatTambahAkun;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnHapusAkun;
        private Label label4;
        private Panel panel2;
        private Label label5;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}
