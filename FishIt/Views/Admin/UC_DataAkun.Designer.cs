namespace FishIt
{
    partial class UC_DataAkun
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
            panelUtama = new Panel();
            DGVDataAkun = new DataGridView();
            panelAkunPembeli = new Panel();
            TotalPembeliKelola = new Label();
            lblPembeliKelola = new Label();
            panelAkunSupplier = new Panel();
            TotalShipperKelola = new Label();
            lblShipperKelola = new Label();
            panelShipper = new Panel();
            TotalSupplierKelola = new Label();
            lblSupplierKelola = new Label();
            panelAkunKasir = new Panel();
            TotalKasirKelola = new Label();
            lblKasirKelola = new Label();
            panelAkunTambak = new Panel();
            TotalTambakKelola = new Label();
            label3 = new Label();
            panelJumlahAkun = new Panel();
            label1 = new Label();
            labelAkunAktif = new Label();
            lblHitungAkunTidakAKtif = new Label();
            panelStatistik = new Panel();
            lblHitungAkunAktif = new Label();
            label2 = new Label();
            labelJumlahAkun = new Label();
            panelUtama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDataAkun).BeginInit();
            panelAkunPembeli.SuspendLayout();
            panelAkunSupplier.SuspendLayout();
            panelShipper.SuspendLayout();
            panelAkunKasir.SuspendLayout();
            panelAkunTambak.SuspendLayout();
            panelJumlahAkun.SuspendLayout();
            panelStatistik.SuspendLayout();
            SuspendLayout();
            // 
            // panelUtama
            // 
            panelUtama.BackColor = Color.LightSteelBlue;
            panelUtama.Controls.Add(DGVDataAkun);
            panelUtama.Controls.Add(panelAkunPembeli);
            panelUtama.Controls.Add(panelAkunSupplier);
            panelUtama.Controls.Add(panelShipper);
            panelUtama.Controls.Add(panelAkunKasir);
            panelUtama.Controls.Add(panelAkunTambak);
            panelUtama.Controls.Add(panelJumlahAkun);
            panelUtama.Dock = DockStyle.Fill;
            panelUtama.Location = new Point(0, 0);
            panelUtama.Margin = new Padding(0);
            panelUtama.Name = "panelUtama";
            panelUtama.Padding = new Padding(20);
            panelUtama.Size = new Size(800, 600);
            panelUtama.TabIndex = 1;
            panelUtama.Paint += panelUtama_Paint;
            // 
            // DGVDataAkun
            // 
            DGVDataAkun.AllowUserToAddRows = false;
            DGVDataAkun.AllowUserToDeleteRows = false;
            DGVDataAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDataAkun.Location = new Point(23, 319);
            DGVDataAkun.Name = "DGVDataAkun";
            DGVDataAkun.ReadOnly = true;
            DGVDataAkun.RowHeadersWidth = 62;
            DGVDataAkun.Size = new Size(754, 258);
            DGVDataAkun.TabIndex = 5;
            DGVDataAkun.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panelAkunPembeli
            // 
            panelAkunPembeli.BackColor = Color.CornflowerBlue;
            panelAkunPembeli.Controls.Add(TotalPembeliKelola);
            panelAkunPembeli.Controls.Add(lblPembeliKelola);
            panelAkunPembeli.Location = new Point(640, 175);
            panelAkunPembeli.Name = "panelAkunPembeli";
            panelAkunPembeli.Size = new Size(140, 120);
            panelAkunPembeli.TabIndex = 4;
            // 
            // TotalPembeliKelola
            // 
            TotalPembeliKelola.BackColor = Color.Transparent;
            TotalPembeliKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalPembeliKelola.ForeColor = Color.White;
            TotalPembeliKelola.Location = new Point(3, 51);
            TotalPembeliKelola.Name = "TotalPembeliKelola";
            TotalPembeliKelola.Size = new Size(134, 32);
            TotalPembeliKelola.TabIndex = 6;
            TotalPembeliKelola.Text = "0";
            TotalPembeliKelola.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPembeliKelola
            // 
            lblPembeliKelola.AutoSize = true;
            lblPembeliKelola.BackColor = Color.Transparent;
            lblPembeliKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPembeliKelola.ForeColor = Color.White;
            lblPembeliKelola.Location = new Point(21, 6);
            lblPembeliKelola.Name = "lblPembeliKelola";
            lblPembeliKelola.Size = new Size(100, 32);
            lblPembeliKelola.TabIndex = 5;
            lblPembeliKelola.Text = "Pembeli";
            // 
            // panelAkunSupplier
            // 
            panelAkunSupplier.BackColor = Color.CornflowerBlue;
            panelAkunSupplier.Controls.Add(TotalShipperKelola);
            panelAkunSupplier.Controls.Add(lblShipperKelola);
            panelAkunSupplier.Location = new Point(487, 175);
            panelAkunSupplier.Name = "panelAkunSupplier";
            panelAkunSupplier.Size = new Size(140, 120);
            panelAkunSupplier.TabIndex = 4;
            // 
            // TotalShipperKelola
            // 
            TotalShipperKelola.BackColor = Color.Transparent;
            TotalShipperKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalShipperKelola.ForeColor = Color.White;
            TotalShipperKelola.Location = new Point(3, 51);
            TotalShipperKelola.Name = "TotalShipperKelola";
            TotalShipperKelola.Size = new Size(134, 32);
            TotalShipperKelola.TabIndex = 6;
            TotalShipperKelola.Text = "0";
            TotalShipperKelola.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShipperKelola
            // 
            lblShipperKelola.AutoSize = true;
            lblShipperKelola.BackColor = Color.Transparent;
            lblShipperKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShipperKelola.ForeColor = Color.White;
            lblShipperKelola.Location = new Point(23, 6);
            lblShipperKelola.Name = "lblShipperKelola";
            lblShipperKelola.Size = new Size(97, 32);
            lblShipperKelola.TabIndex = 5;
            lblShipperKelola.Text = "Shipper";
            // 
            // panelShipper
            // 
            panelShipper.BackColor = Color.CornflowerBlue;
            panelShipper.Controls.Add(TotalSupplierKelola);
            panelShipper.Controls.Add(lblSupplierKelola);
            panelShipper.Location = new Point(331, 175);
            panelShipper.Name = "panelShipper";
            panelShipper.Size = new Size(140, 120);
            panelShipper.TabIndex = 4;
            // 
            // TotalSupplierKelola
            // 
            TotalSupplierKelola.BackColor = Color.Transparent;
            TotalSupplierKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalSupplierKelola.ForeColor = Color.White;
            TotalSupplierKelola.Location = new Point(3, 51);
            TotalSupplierKelola.Name = "TotalSupplierKelola";
            TotalSupplierKelola.Size = new Size(134, 32);
            TotalSupplierKelola.TabIndex = 6;
            TotalSupplierKelola.Text = "0";
            TotalSupplierKelola.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSupplierKelola
            // 
            lblSupplierKelola.AutoSize = true;
            lblSupplierKelola.BackColor = Color.Transparent;
            lblSupplierKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSupplierKelola.ForeColor = Color.White;
            lblSupplierKelola.Location = new Point(21, 6);
            lblSupplierKelola.Name = "lblSupplierKelola";
            lblSupplierKelola.Size = new Size(103, 32);
            lblSupplierKelola.TabIndex = 5;
            lblSupplierKelola.Text = "Supplier";
            // 
            // panelAkunKasir
            // 
            panelAkunKasir.BackColor = Color.CornflowerBlue;
            panelAkunKasir.Controls.Add(TotalKasirKelola);
            panelAkunKasir.Controls.Add(lblKasirKelola);
            panelAkunKasir.Location = new Point(176, 175);
            panelAkunKasir.Name = "panelAkunKasir";
            panelAkunKasir.Size = new Size(140, 120);
            panelAkunKasir.TabIndex = 4;
            // 
            // TotalKasirKelola
            // 
            TotalKasirKelola.BackColor = Color.Transparent;
            TotalKasirKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalKasirKelola.ForeColor = Color.White;
            TotalKasirKelola.Location = new Point(3, 51);
            TotalKasirKelola.Name = "TotalKasirKelola";
            TotalKasirKelola.Size = new Size(134, 32);
            TotalKasirKelola.TabIndex = 6;
            TotalKasirKelola.Text = "0";
            TotalKasirKelola.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblKasirKelola
            // 
            lblKasirKelola.AutoSize = true;
            lblKasirKelola.BackColor = Color.Transparent;
            lblKasirKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKasirKelola.ForeColor = Color.White;
            lblKasirKelola.Location = new Point(36, 6);
            lblKasirKelola.Name = "lblKasirKelola";
            lblKasirKelola.Size = new Size(67, 32);
            lblKasirKelola.TabIndex = 5;
            lblKasirKelola.Text = "Kasir";
            // 
            // panelAkunTambak
            // 
            panelAkunTambak.BackColor = Color.CornflowerBlue;
            panelAkunTambak.Controls.Add(TotalTambakKelola);
            panelAkunTambak.Controls.Add(label3);
            panelAkunTambak.Location = new Point(23, 175);
            panelAkunTambak.Name = "panelAkunTambak";
            panelAkunTambak.Size = new Size(140, 120);
            panelAkunTambak.TabIndex = 3;
            // 
            // TotalTambakKelola
            // 
            TotalTambakKelola.BackColor = Color.Transparent;
            TotalTambakKelola.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalTambakKelola.ForeColor = Color.White;
            TotalTambakKelola.Location = new Point(0, 51);
            TotalTambakKelola.Name = "TotalTambakKelola";
            TotalTambakKelola.Size = new Size(140, 32);
            TotalTambakKelola.TabIndex = 4;
            TotalTambakKelola.Text = "0";
            TotalTambakKelola.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 5);
            label3.Name = "label3";
            label3.Size = new Size(99, 32);
            label3.TabIndex = 3;
            label3.Text = "Tambak";
            // 
            // panelJumlahAkun
            // 
            panelJumlahAkun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelJumlahAkun.BackColor = Color.CornflowerBlue;
            panelJumlahAkun.Controls.Add(panelStatistik);
            panelJumlahAkun.Controls.Add(label2);
            panelJumlahAkun.Controls.Add(labelJumlahAkun);
            panelJumlahAkun.Location = new Point(23, 23);
            panelJumlahAkun.Name = "panelJumlahAkun";
            panelJumlahAkun.Size = new Size(757, 135);
            panelJumlahAkun.TabIndex = 0;
            panelJumlahAkun.Paint += panelJumlahAkun_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(71, 91);
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
            labelAkunAktif.Location = new Point(86, 41);
            labelAkunAktif.Name = "labelAkunAktif";
            labelAkunAktif.Size = new Size(82, 21);
            labelAkunAktif.TabIndex = 7;
            labelAkunAktif.Text = "Akun Aktif\r\n";
            labelAkunAktif.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHitungAkunTidakAKtif
            // 
            lblHitungAkunTidakAKtif.BackColor = Color.Transparent;
            lblHitungAkunTidakAKtif.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHitungAkunTidakAKtif.ForeColor = Color.White;
            lblHitungAkunTidakAKtif.Location = new Point(61, 54);
            lblHitungAkunTidakAKtif.Name = "lblHitungAkunTidakAKtif";
            lblHitungAkunTidakAKtif.Size = new Size(133, 47);
            lblHitungAkunTidakAKtif.TabIndex = 8;
            lblHitungAkunTidakAKtif.Text = "0";
            lblHitungAkunTidakAKtif.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelStatistik
            // 
            panelStatistik.BackColor = Color.RoyalBlue;
            panelStatistik.Controls.Add(label1);
            panelStatistik.Controls.Add(lblHitungAkunAktif);
            panelStatistik.Controls.Add(labelAkunAktif);
            panelStatistik.Controls.Add(lblHitungAkunTidakAKtif);
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
            lblHitungAkunAktif.Location = new Point(61, 0);
            lblHitungAkunAktif.Name = "lblHitungAkunAktif";
            lblHitungAkunAktif.Size = new Size(133, 47);
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
            label2.Size = new Size(130, 32);
            label2.TabIndex = 2;
            label2.Text = "Data Akun";
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
            // UC_DataAkun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(panelUtama);
            Name = "UC_DataAkun";
            Size = new Size(800, 600);
            Load += UC_KelolaAkun_Load;
            panelUtama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVDataAkun).EndInit();
            panelAkunPembeli.ResumeLayout(false);
            panelAkunPembeli.PerformLayout();
            panelAkunSupplier.ResumeLayout(false);
            panelAkunSupplier.PerformLayout();
            panelShipper.ResumeLayout(false);
            panelShipper.PerformLayout();
            panelAkunKasir.ResumeLayout(false);
            panelAkunKasir.PerformLayout();
            panelAkunTambak.ResumeLayout(false);
            panelAkunTambak.PerformLayout();
            panelJumlahAkun.ResumeLayout(false);
            panelJumlahAkun.PerformLayout();
            panelStatistik.ResumeLayout(false);
            panelStatistik.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelUtama;
        private Panel panelJumlahAkun;
        private Panel panelAkunTambak;
        private Label label2;
        private Label labelJumlahAkun;
        private Label lblHitungAkunAktif;
        private Panel panelAkunPembeli;
        private Panel panelAkunSupplier;
        private Panel panelShipper;
        private Panel panelAkunKasir;
        private Panel panelStatistik;
        private Label lblHitungAkunTidakAKtif;
        private Label labelAkunAktif;
        private Label label1;
        private DataGridView DGVDataAkun;
        private Label label3;
        private Label TotalShipperKelola;
        private Label lblShipperKelola;
        private Label TotalSupplierKelola;
        private Label lblSupplierKelola;
        private Label TotalKasirKelola;
        private Label lblKasirKelola;
        private Label TotalTambakKelola;
        private Label TotalPembeliKelola;
        private Label lblPembeliKelola;
    }
}
