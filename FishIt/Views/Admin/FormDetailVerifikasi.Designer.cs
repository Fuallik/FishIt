namespace FishIt
{
    partial class FormDetailVerifikasi
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
            label8 = new Label();
            TBStatus = new TextBox();
            labelKelurahan = new Label();
            TBTglKirim = new TextBox();
            labelAlamat = new Label();
            TBTipe = new TextBox();
            labelTelpon = new Label();
            TBKuantitas = new TextBox();
            labelUsername = new Label();
            TBSupplier = new TextBox();
            labelNama = new Label();
            TBIdPengajuan = new TextBox();
            lblHapusAkun = new Label();
            label1 = new Label();
            TBTglVerifikasi = new TextBox();
            btnACC = new FontAwesome.Sharp.IconButton();
            btnTolak = new FontAwesome.Sharp.IconButton();
            btnKembali = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            TBNamaIkan = new TextBox();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(81, 570);
            label8.Name = "label8";
            label8.Size = new Size(185, 32);
            label8.TabIndex = 35;
            label8.Text = "Status Verifikasi";
            // 
            // TBStatus
            // 
            TBStatus.BackColor = Color.White;
            TBStatus.BorderStyle = BorderStyle.None;
            TBStatus.Location = new Point(81, 605);
            TBStatus.Name = "TBStatus";
            TBStatus.Size = new Size(335, 24);
            TBStatus.TabIndex = 34;
            // 
            // labelKelurahan
            // 
            labelKelurahan.AutoSize = true;
            labelKelurahan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelKelurahan.Location = new Point(81, 490);
            labelKelurahan.Name = "labelKelurahan";
            labelKelurahan.Size = new Size(163, 32);
            labelKelurahan.TabIndex = 33;
            labelKelurahan.Text = "Tanggal Kirim";
            // 
            // TBTglKirim
            // 
            TBTglKirim.BackColor = Color.White;
            TBTglKirim.BorderStyle = BorderStyle.None;
            TBTglKirim.Location = new Point(81, 525);
            TBTglKirim.Name = "TBTglKirim";
            TBTglKirim.Size = new Size(335, 24);
            TBTglKirim.TabIndex = 32;
            // 
            // labelAlamat
            // 
            labelAlamat.AutoSize = true;
            labelAlamat.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelAlamat.Location = new Point(81, 408);
            labelAlamat.Name = "labelAlamat";
            labelAlamat.Size = new Size(61, 32);
            labelAlamat.TabIndex = 31;
            labelAlamat.Text = "TIpe";
            // 
            // TBTipe
            // 
            TBTipe.BackColor = Color.White;
            TBTipe.BorderStyle = BorderStyle.None;
            TBTipe.Location = new Point(81, 443);
            TBTipe.Name = "TBTipe";
            TBTipe.Size = new Size(335, 24);
            TBTipe.TabIndex = 30;
            // 
            // labelTelpon
            // 
            labelTelpon.AutoSize = true;
            labelTelpon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelTelpon.Location = new Point(81, 326);
            labelTelpon.Name = "labelTelpon";
            labelTelpon.Size = new Size(117, 32);
            labelTelpon.TabIndex = 29;
            labelTelpon.Text = "Kuantitas";
            // 
            // TBKuantitas
            // 
            TBKuantitas.BackColor = Color.White;
            TBKuantitas.BorderStyle = BorderStyle.None;
            TBKuantitas.Location = new Point(81, 361);
            TBKuantitas.Name = "TBKuantitas";
            TBKuantitas.Size = new Size(335, 24);
            TBKuantitas.TabIndex = 28;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelUsername.Location = new Point(81, 182);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(175, 32);
            labelUsername.TabIndex = 27;
            labelUsername.Text = "Nama Supplier";
            // 
            // TBSupplier
            // 
            TBSupplier.BackColor = Color.White;
            TBSupplier.BorderStyle = BorderStyle.None;
            TBSupplier.Location = new Point(81, 217);
            TBSupplier.Name = "TBSupplier";
            TBSupplier.Size = new Size(335, 24);
            TBSupplier.TabIndex = 26;
            TBSupplier.TextChanged += TBSupplier_TextChanged;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(81, 102);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(159, 32);
            labelNama.TabIndex = 25;
            labelNama.Text = "ID Pengajuan";
            // 
            // TBIdPengajuan
            // 
            TBIdPengajuan.BackColor = Color.White;
            TBIdPengajuan.BorderStyle = BorderStyle.None;
            TBIdPengajuan.Location = new Point(81, 137);
            TBIdPengajuan.Name = "TBIdPengajuan";
            TBIdPengajuan.Size = new Size(335, 24);
            TBIdPengajuan.TabIndex = 24;
            // 
            // lblHapusAkun
            // 
            lblHapusAkun.AutoSize = true;
            lblHapusAkun.BackColor = Color.Transparent;
            lblHapusAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHapusAkun.ImageAlign = ContentAlignment.TopCenter;
            lblHapusAkun.Location = new Point(31, 30);
            lblHapusAkun.Name = "lblHapusAkun";
            lblHapusAkun.Size = new Size(436, 54);
            lblHapusAkun.TabIndex = 23;
            lblHapusAkun.Text = "Konfirmasi Pengajuan\r\n";
            lblHapusAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(81, 642);
            label1.Name = "label1";
            label1.Size = new Size(236, 32);
            label1.TabIndex = 37;
            label1.Text = "Tanggal Terverifikasi";
            // 
            // TBTglVerifikasi
            // 
            TBTglVerifikasi.BackColor = Color.White;
            TBTglVerifikasi.BorderStyle = BorderStyle.None;
            TBTglVerifikasi.Location = new Point(81, 677);
            TBTglVerifikasi.Name = "TBTglVerifikasi";
            TBTglVerifikasi.Size = new Size(335, 24);
            TBTglVerifikasi.TabIndex = 36;
            // 
            // btnACC
            // 
            btnACC.IconChar = FontAwesome.Sharp.IconChar.None;
            btnACC.IconColor = Color.Black;
            btnACC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnACC.Location = new Point(340, 728);
            btnACC.Name = "btnACC";
            btnACC.Size = new Size(112, 34);
            btnACC.TabIndex = 38;
            btnACC.Text = "Setuju";
            btnACC.UseVisualStyleBackColor = true;
            btnACC.Click += btnACC_Click;
            // 
            // btnTolak
            // 
            btnTolak.BackColor = Color.CornflowerBlue;
            btnTolak.FlatAppearance.BorderSize = 0;
            btnTolak.FlatStyle = FlatStyle.Flat;
            btnTolak.IconChar = FontAwesome.Sharp.IconChar.None;
            btnTolak.IconColor = Color.Black;
            btnTolak.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTolak.Location = new Point(188, 728);
            btnTolak.Name = "btnTolak";
            btnTolak.Size = new Size(112, 34);
            btnTolak.TabIndex = 39;
            btnTolak.Text = "Tolak";
            btnTolak.UseVisualStyleBackColor = false;
            btnTolak.Click += btnTolak_Click;
            // 
            // btnKembali
            // 
            btnKembali.IconChar = FontAwesome.Sharp.IconChar.None;
            btnKembali.IconColor = Color.Black;
            btnKembali.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKembali.Location = new Point(31, 728);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(112, 34);
            btnKembali.TabIndex = 40;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = true;
            btnKembali.Click += btnKembali_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(81, 255);
            label2.Name = "label2";
            label2.Size = new Size(133, 32);
            label2.TabIndex = 42;
            label2.Text = "Nama Ikan";
            // 
            // TBNamaIkan
            // 
            TBNamaIkan.BackColor = Color.White;
            TBNamaIkan.BorderStyle = BorderStyle.None;
            TBNamaIkan.Location = new Point(81, 290);
            TBNamaIkan.Name = "TBNamaIkan";
            TBNamaIkan.Size = new Size(335, 24);
            TBNamaIkan.TabIndex = 41;
            // 
            // FormDetailVerifikasi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(478, 794);
            Controls.Add(label2);
            Controls.Add(TBNamaIkan);
            Controls.Add(btnKembali);
            Controls.Add(btnTolak);
            Controls.Add(btnACC);
            Controls.Add(label1);
            Controls.Add(TBTglVerifikasi);
            Controls.Add(label8);
            Controls.Add(TBStatus);
            Controls.Add(labelKelurahan);
            Controls.Add(TBTglKirim);
            Controls.Add(labelAlamat);
            Controls.Add(TBTipe);
            Controls.Add(labelTelpon);
            Controls.Add(TBKuantitas);
            Controls.Add(labelUsername);
            Controls.Add(TBSupplier);
            Controls.Add(labelNama);
            Controls.Add(TBIdPengajuan);
            Controls.Add(lblHapusAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetailVerifikasi";
            StartPosition = FormStartPosition.CenterScreen;
            Load += UC_DetailVerifikasi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private TextBox TBStatus;
        private Label labelKelurahan;
        private TextBox TBTglKirim;
        private Label labelAlamat;
        private TextBox TBTipe;
        private Label labelTelpon;
        private TextBox TBKuantitas;
        private Label labelUsername;
        private TextBox TBSupplier;
        private Label labelNama;
        private TextBox TBIdPengajuan;
        private Label lblHapusAkun;
        private Label label1;
        private TextBox TBTglVerifikasi;
        private FontAwesome.Sharp.IconButton btnACC;
        private FontAwesome.Sharp.IconButton btnTolak;
        private FontAwesome.Sharp.IconButton btnKembali;
        private Label label2;
        private TextBox TBNamaIkan;
    }
}
