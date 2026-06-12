namespace FishIt
{
    partial class UC_VerifikasiSupply
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
            panelMonitoring = new Panel();
            btnDetailVerifikasi = new FontAwesome.Sharp.IconButton();
            labelJumlahAkun = new Label();
            label2 = new Label();
            DGVPengajuan = new DataGridView();
            TBIDPengajuan = new TextBox();
            panelMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).BeginInit();
            SuspendLayout();
            // 
            // panelMonitoring
            // 
            panelMonitoring.BackColor = Color.CornflowerBlue;
            panelMonitoring.Controls.Add(TBIDPengajuan);
            panelMonitoring.Controls.Add(btnDetailVerifikasi);
            panelMonitoring.Controls.Add(labelJumlahAkun);
            panelMonitoring.Controls.Add(label2);
            panelMonitoring.Location = new Point(20, 20);
            panelMonitoring.Name = "panelMonitoring";
            panelMonitoring.Size = new Size(760, 142);
            panelMonitoring.TabIndex = 1;
            // 
            // btnDetailVerifikasi
            // 
            btnDetailVerifikasi.BackColor = Color.RoyalBlue;
            btnDetailVerifikasi.FlatAppearance.BorderSize = 0;
            btnDetailVerifikasi.FlatStyle = FlatStyle.Flat;
            btnDetailVerifikasi.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnDetailVerifikasi.ForeColor = Color.White;
            btnDetailVerifikasi.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDetailVerifikasi.IconColor = Color.Black;
            btnDetailVerifikasi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDetailVerifikasi.Location = new Point(597, 92);
            btnDetailVerifikasi.Name = "btnDetailVerifikasi";
            btnDetailVerifikasi.Size = new Size(150, 40);
            btnDetailVerifikasi.TabIndex = 6;
            btnDetailVerifikasi.Text = "Verifikasi";
            btnDetailVerifikasi.UseVisualStyleBackColor = false;
            btnDetailVerifikasi.Click += btnDetailVerifikasi_Click;
            // 
            // labelJumlahAkun
            // 
            labelJumlahAkun.AutoSize = true;
            labelJumlahAkun.BackColor = Color.Transparent;
            labelJumlahAkun.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            labelJumlahAkun.ForeColor = Color.White;
            labelJumlahAkun.Location = new Point(16, 70);
            labelJumlahAkun.Name = "labelJumlahAkun";
            labelJumlahAkun.Size = new Size(196, 56);
            labelJumlahAkun.TabIndex = 5;
            labelJumlahAkun.Text = "Verifikasi Pengajuan\r\nPengiriman Supplier\r\n";
            labelJumlahAkun.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(16, 16);
            label2.Name = "label2";
            label2.Size = new Size(136, 32);
            label2.TabIndex = 3;
            label2.Text = "Monitoring";
            // 
            // DGVPengajuan
            // 
            DGVPengajuan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPengajuan.Location = new Point(20, 181);
            DGVPengajuan.Name = "DGVPengajuan";
            DGVPengajuan.RowHeadersWidth = 62;
            DGVPengajuan.Size = new Size(760, 402);
            DGVPengajuan.TabIndex = 2;
            // 
            // TBIDPengajuan
            // 
            TBIDPengajuan.BackColor = Color.RoyalBlue;
            TBIDPengajuan.BorderStyle = BorderStyle.FixedSingle;
            TBIDPengajuan.Location = new Point(597, 43);
            TBIDPengajuan.Name = "TBIDPengajuan";
            TBIDPengajuan.Size = new Size(150, 31);
            TBIDPengajuan.TabIndex = 7;
            TBIDPengajuan.TextChanged += TBIDPengajuan_TextChanged;
            // 
            // UC_VerifikasiSupply
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVPengajuan);
            Controls.Add(panelMonitoring);
            Name = "UC_VerifikasiSupply";
            Size = new Size(800, 600);
            Load += UC_VerifikasiSupply_Load;
            panelMonitoring.ResumeLayout(false);
            panelMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMonitoring;
        private FontAwesome.Sharp.IconButton btnDetailVerifikasi;
        private Label labelJumlahAkun;
        private Label label2;
        private DataGridView DGVPengajuan;
        private TextBox TBIDPengajuan;
    }
}
