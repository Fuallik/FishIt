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
            TBIDPengajuan = new TextBox();
            labelJumlahAkun = new Label();
            label2 = new Label();
            DGVPengajuan = new DataGridView();
            panelMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).BeginInit();
            SuspendLayout();
            // 
            // panelMonitoring
            // 
            panelMonitoring.BackColor = Color.CornflowerBlue;
            panelMonitoring.Controls.Add(TBIDPengajuan);
            panelMonitoring.Controls.Add(labelJumlahAkun);
            panelMonitoring.Controls.Add(label2);
            panelMonitoring.Location = new Point(20, 20);
            panelMonitoring.Name = "panelMonitoring";
            panelMonitoring.Size = new Size(760, 142);
            panelMonitoring.TabIndex = 1;
            // 
            // TBIDPengajuan
            // 
            TBIDPengajuan.BackColor = Color.RoyalBlue;
            TBIDPengajuan.BorderStyle = BorderStyle.FixedSingle;
            TBIDPengajuan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBIDPengajuan.ForeColor = Color.White;
            TBIDPengajuan.Location = new Point(565, 95);
            TBIDPengajuan.Name = "TBIDPengajuan";
            TBIDPengajuan.Size = new Size(181, 31);
            TBIDPengajuan.TabIndex = 7;
            TBIDPengajuan.TextChanged += TBIDPengajuan_TextChanged;
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
        private Label labelJumlahAkun;
        private Label label2;
        private DataGridView DGVPengajuan;
        private TextBox TBIDPengajuan;
    }
}
