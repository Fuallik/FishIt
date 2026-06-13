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
            panelJumlahAkun = new Panel();
            label1 = new Label();
            labelAkunAktif = new Label();
            lblHitungAkunTidakAktif = new Label();
            panelStatistik = new Panel();
            lblHitungAkunAktif = new Label();
            label2 = new Label();
            labelJumlahAkun = new Label();
            DGVRiwayatTambahAkun = new DataGridView();
            btnTambahAkun = new FontAwesome.Sharp.IconButton();
            btnHapus = new FontAwesome.Sharp.IconButton();
            panelJumlahAkun.SuspendLayout();
            panelStatistik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            SuspendLayout();
            // 
            // panelJumlahAkun
            // 
            panelJumlahAkun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelJumlahAkun.BackColor = Color.CornflowerBlue;
            panelJumlahAkun.Controls.Add(panelStatistik);
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
            label1.Location = new Point(58, 89);
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
            labelAkunAktif.Location = new Point(79, 41);
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
            lblHitungAkunTidakAktif.Location = new Point(63, 47);
            lblHitungAkunTidakAktif.Name = "lblHitungAkunTidakAktif";
            lblHitungAkunTidakAktif.Size = new Size(117, 47);
            lblHitungAkunTidakAktif.TabIndex = 8;
            lblHitungAkunTidakAktif.Text = "0";
            lblHitungAkunTidakAktif.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelStatistik
            // 
            panelStatistik.BackColor = Color.RoyalBlue;
            panelStatistik.Controls.Add(label1);
            panelStatistik.Controls.Add(lblHitungAkunAktif);
            panelStatistik.Controls.Add(labelAkunAktif);
            panelStatistik.Controls.Add(lblHitungAkunTidakAktif);
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
            lblHitungAkunAktif.Location = new Point(58, 0);
            lblHitungAkunAktif.Name = "lblHitungAkunAktif";
            lblHitungAkunAktif.Size = new Size(123, 47);
            lblHitungAkunAktif.TabIndex = 5;
            lblHitungAkunAktif.Text = "0";
            lblHitungAkunAktif.TextAlign = ContentAlignment.MiddleCenter;
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
            DGVRiwayatTambahAkun.AllowUserToAddRows = false;
            DGVRiwayatTambahAkun.AllowUserToDeleteRows = false;
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(22, 243);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.ReadOnly = true;
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(757, 340);
            DGVRiwayatTambahAkun.TabIndex = 13;
            // 
            // btnTambahAkun
            // 
            btnTambahAkun.BackColor = Color.CornflowerBlue;
            btnTambahAkun.FlatAppearance.BorderSize = 0;
            btnTambahAkun.FlatStyle = FlatStyle.Flat;
            btnTambahAkun.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambahAkun.ForeColor = Color.White;
            btnTambahAkun.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnTambahAkun.IconColor = Color.White;
            btnTambahAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTambahAkun.ImageAlign = ContentAlignment.MiddleRight;
            btnTambahAkun.Location = new Point(22, 183);
            btnTambahAkun.Name = "btnTambahAkun";
            btnTambahAkun.Size = new Size(365, 45);
            btnTambahAkun.TabIndex = 15;
            btnTambahAkun.Text = "Tambah Akun";
            btnTambahAkun.TextAlign = ContentAlignment.MiddleLeft;
            btnTambahAkun.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTambahAkun.UseVisualStyleBackColor = false;
            btnTambahAkun.Click += btnTambahAkun_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.CornflowerBlue;
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.IconChar = FontAwesome.Sharp.IconChar.UserMinus;
            btnHapus.IconColor = Color.White;
            btnHapus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHapus.ImageAlign = ContentAlignment.MiddleRight;
            btnHapus.Location = new Point(414, 183);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(365, 45);
            btnHapus.TabIndex = 16;
            btnHapus.Text = "Hapus Akun";
            btnHapus.TextAlign = ContentAlignment.MiddleLeft;
            btnHapus.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // UC_KelolaAkun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(btnHapus);
            Controls.Add(btnTambahAkun);
            Controls.Add(DGVRiwayatTambahAkun);
            Controls.Add(panelJumlahAkun);
            Name = "UC_KelolaAkun";
            Size = new Size(800, 600);
            Load += UC_TambahAkun_Load;
            panelJumlahAkun.ResumeLayout(false);
            panelJumlahAkun.PerformLayout();
            panelStatistik.ResumeLayout(false);
            panelStatistik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelJumlahAkun;
        private Label label1;
        private Label labelAkunAktif;
        private Label lblHitungAkunTidakAktif;
        private Panel panelStatistik;
        private Label lblHitungAkunAktif;
        private Label label2;
        private Label labelJumlahAkun;
        private DataGridView DGVRiwayatTambahAkun;
        private FontAwesome.Sharp.IconButton btnTambahAkun;
        private FontAwesome.Sharp.IconButton btnHapus;
    }
}
