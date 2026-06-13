namespace FishIt
{
    partial class UC_DataKolam
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
            DGVKolam = new DataGridView();
            btnHapus = new FontAwesome.Sharp.IconButton();
            btnTambah = new FontAwesome.Sharp.IconButton();
            panelJumlahKolam = new Panel();
            panelStatistik = new Panel();
            labelAkunAktif = new Label();
            labelKolam = new Label();
            label2 = new Label();
            labelJumlahAkun = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVKolam).BeginInit();
            panelJumlahKolam.SuspendLayout();
            panelStatistik.SuspendLayout();
            SuspendLayout();
            // 
            // DGVKolam
            // 
            DGVKolam.AllowUserToAddRows = false;
            DGVKolam.AllowUserToDeleteRows = false;
            DGVKolam.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVKolam.Location = new Point(21, 240);
            DGVKolam.Name = "DGVKolam";
            DGVKolam.ReadOnly = true;
            DGVKolam.RowHeadersWidth = 62;
            DGVKolam.Size = new Size(757, 338);
            DGVKolam.TabIndex = 6;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.CornflowerBlue;
            btnHapus.FlatAppearance.BorderSize = 0;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHapus.ForeColor = Color.White;
            btnHapus.IconChar = FontAwesome.Sharp.IconChar.MinusCircle;
            btnHapus.IconColor = Color.White;
            btnHapus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnHapus.ImageAlign = ContentAlignment.MiddleRight;
            btnHapus.Location = new Point(413, 178);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(365, 45);
            btnHapus.TabIndex = 18;
            btnHapus.Text = "Hapus Kolam";
            btnHapus.TextAlign = ContentAlignment.MiddleLeft;
            btnHapus.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.CornflowerBlue;
            btnTambah.FlatAppearance.BorderSize = 0;
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTambah.ForeColor = Color.White;
            btnTambah.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            btnTambah.IconColor = Color.White;
            btnTambah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTambah.ImageAlign = ContentAlignment.MiddleRight;
            btnTambah.Location = new Point(21, 178);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(365, 45);
            btnTambah.TabIndex = 17;
            btnTambah.Text = "Tambah Kolam";
            btnTambah.TextAlign = ContentAlignment.MiddleLeft;
            btnTambah.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // panelJumlahKolam
            // 
            panelJumlahKolam.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelJumlahKolam.BackColor = Color.CornflowerBlue;
            panelJumlahKolam.Controls.Add(panelStatistik);
            panelJumlahKolam.Controls.Add(label2);
            panelJumlahKolam.Controls.Add(labelJumlahAkun);
            panelJumlahKolam.Location = new Point(21, 27);
            panelJumlahKolam.Name = "panelJumlahKolam";
            panelJumlahKolam.Size = new Size(757, 135);
            panelJumlahKolam.TabIndex = 19;
            // 
            // panelStatistik
            // 
            panelStatistik.BackColor = Color.RoyalBlue;
            panelStatistik.Controls.Add(labelAkunAktif);
            panelStatistik.Controls.Add(labelKolam);
            panelStatistik.Location = new Point(501, 13);
            panelStatistik.Name = "panelStatistik";
            panelStatistik.Size = new Size(242, 110);
            panelStatistik.TabIndex = 6;
            // 
            // labelAkunAktif
            // 
            labelAkunAktif.BackColor = Color.Transparent;
            labelAkunAktif.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAkunAktif.ForeColor = Color.White;
            labelAkunAktif.Location = new Point(0, 61);
            labelAkunAktif.Name = "labelAkunAktif";
            labelAkunAktif.Size = new Size(242, 49);
            labelAkunAktif.TabIndex = 7;
            labelAkunAktif.Text = "Kolam";
            labelAkunAktif.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelKolam
            // 
            labelKolam.BackColor = Color.Transparent;
            labelKolam.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelKolam.ForeColor = Color.White;
            labelKolam.Location = new Point(0, 14);
            labelKolam.Name = "labelKolam";
            labelKolam.Size = new Size(242, 47);
            labelKolam.TabIndex = 5;
            labelKolam.Text = "0";
            labelKolam.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 13);
            label2.Name = "label2";
            label2.Size = new Size(157, 32);
            label2.TabIndex = 2;
            label2.Text = "Kelola Kolam";
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
            labelJumlahAkun.Text = "Total Kolam\r\nDalam Database\r\n";
            labelJumlahAkun.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UC_DataKolam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panelJumlahKolam);
            Controls.Add(btnHapus);
            Controls.Add(btnTambah);
            Controls.Add(DGVKolam);
            Name = "UC_DataKolam";
            Size = new Size(800, 600);
            Load += UC_DataKolam_Load;
            ((System.ComponentModel.ISupportInitialize)DGVKolam).EndInit();
            panelJumlahKolam.ResumeLayout(false);
            panelJumlahKolam.PerformLayout();
            panelStatistik.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVKolam;
        private FontAwesome.Sharp.IconButton btnHapus;
        private FontAwesome.Sharp.IconButton btnTambah;
        private Panel panelJumlahKolam;
        private Label labelAkunAktif;
        private Panel panelStatistik;
        private Label labelKolam;
        private Label label2;
        private Label labelJumlahAkun;
    }
}
