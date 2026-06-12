namespace FishIt
{
    partial class UC_Monitoring
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
            panelSatuBulan = new Panel();
            lblSatuBulan = new Label();
            label3 = new Label();
            panelHariIni = new Panel();
            lblHariIni = new Label();
            label1 = new Label();
            labelJumlahAkun = new Label();
            label2 = new Label();
            DGVMonitoring = new DataGridView();
            panelMonitoring.SuspendLayout();
            panelSatuBulan.SuspendLayout();
            panelHariIni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVMonitoring).BeginInit();
            SuspendLayout();
            // 
            // panelMonitoring
            // 
            panelMonitoring.BackColor = Color.CornflowerBlue;
            panelMonitoring.Controls.Add(panelSatuBulan);
            panelMonitoring.Controls.Add(panelHariIni);
            panelMonitoring.Controls.Add(labelJumlahAkun);
            panelMonitoring.Controls.Add(label2);
            panelMonitoring.Location = new Point(20, 20);
            panelMonitoring.Name = "panelMonitoring";
            panelMonitoring.Size = new Size(760, 150);
            panelMonitoring.TabIndex = 0;
            // 
            // panelSatuBulan
            // 
            panelSatuBulan.BackColor = Color.RoyalBlue;
            panelSatuBulan.Controls.Add(lblSatuBulan);
            panelSatuBulan.Controls.Add(label3);
            panelSatuBulan.Location = new Point(340, 10);
            panelSatuBulan.Name = "panelSatuBulan";
            panelSatuBulan.Size = new Size(200, 130);
            panelSatuBulan.TabIndex = 8;
            // 
            // lblSatuBulan
            // 
            lblSatuBulan.AutoSize = true;
            lblSatuBulan.BackColor = Color.Transparent;
            lblSatuBulan.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSatuBulan.ForeColor = Color.White;
            lblSatuBulan.Location = new Point(77, 18);
            lblSatuBulan.Name = "lblSatuBulan";
            lblSatuBulan.Size = new Size(54, 65);
            lblSatuBulan.TabIndex = 12;
            lblSatuBulan.Text = "0";
            lblSatuBulan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(53, 91);
            label3.Name = "label3";
            label3.Size = new Size(94, 32);
            label3.TabIndex = 11;
            label3.Text = "1 Bulan";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelHariIni
            // 
            panelHariIni.BackColor = Color.RoyalBlue;
            panelHariIni.Controls.Add(lblHariIni);
            panelHariIni.Controls.Add(label1);
            panelHariIni.Location = new Point(550, 10);
            panelHariIni.Name = "panelHariIni";
            panelHariIni.Size = new Size(200, 130);
            panelHariIni.TabIndex = 7;
            // 
            // lblHariIni
            // 
            lblHariIni.AutoSize = true;
            lblHariIni.BackColor = Color.Transparent;
            lblHariIni.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHariIni.ForeColor = Color.White;
            lblHariIni.Location = new Point(75, 17);
            lblHariIni.Name = "lblHariIni";
            lblHariIni.Size = new Size(54, 65);
            lblHariIni.TabIndex = 13;
            lblHariIni.Text = "0";
            lblHariIni.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(54, 91);
            label1.Name = "label1";
            label1.Size = new Size(90, 32);
            label1.TabIndex = 10;
            label1.Text = "Hari Ini\r\n";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelJumlahAkun
            // 
            labelJumlahAkun.AutoSize = true;
            labelJumlahAkun.BackColor = Color.Transparent;
            labelJumlahAkun.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            labelJumlahAkun.ForeColor = Color.White;
            labelJumlahAkun.Location = new Point(16, 83);
            labelJumlahAkun.Name = "labelJumlahAkun";
            labelJumlahAkun.Size = new Size(242, 56);
            labelJumlahAkun.TabIndex = 5;
            labelJumlahAkun.Text = "Total Laporan Monitoring\r\nPegawai Tambak\r\n";
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
            // DGVMonitoring
            // 
            DGVMonitoring.AllowUserToAddRows = false;
            DGVMonitoring.AllowUserToDeleteRows = false;
            DGVMonitoring.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVMonitoring.Location = new Point(20, 186);
            DGVMonitoring.Name = "DGVMonitoring";
            DGVMonitoring.ReadOnly = true;
            DGVMonitoring.RowHeadersWidth = 62;
            DGVMonitoring.Size = new Size(760, 396);
            DGVMonitoring.TabIndex = 1;
            // 
            // UC_Monitoring
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVMonitoring);
            Controls.Add(panelMonitoring);
            Name = "UC_Monitoring";
            Size = new Size(800, 600);
            Load += UC_Monitoring_Load;
            panelMonitoring.ResumeLayout(false);
            panelMonitoring.PerformLayout();
            panelSatuBulan.ResumeLayout(false);
            panelSatuBulan.PerformLayout();
            panelHariIni.ResumeLayout(false);
            panelHariIni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVMonitoring).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMonitoring;
        private DataGridView DGVMonitoring;
        private Label label2;
        private Label labelJumlahAkun;
        private Panel panelHariIni;
        private Panel panelSatuBulan;
        private Label label3;
        private Label label1;
        private Label lblSatuBulan;
        private Label lblHariIni;
    }
}
