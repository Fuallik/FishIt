namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_MonitoringIkan
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
            DGVRiwayatTambahAkun = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            panel4 = new Panel();
            labelTotalMonitoringBulan = new Label();
            label5 = new Label();
            panel2 = new Panel();
            labelTotalMonitoringHariIni = new Label();
            label3 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // DGVRiwayatTambahAkun
            // 
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(30, 236);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(740, 340);
            DGVRiwayatTambahAkun.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(25, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(287, 55);
            panel1.TabIndex = 19;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(287, 32);
            label1.TabIndex = 3;
            label1.Text = "Total Monitoring";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.CornflowerBlue;
            panel4.Controls.Add(labelTotalMonitoringBulan);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(25, 94);
            panel4.Name = "panel4";
            panel4.Size = new Size(135, 120);
            panel4.TabIndex = 37;
            // 
            // labelTotalMonitoringBulan
            // 
            labelTotalMonitoringBulan.BackColor = Color.Transparent;
            labelTotalMonitoringBulan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalMonitoringBulan.ForeColor = Color.White;
            labelTotalMonitoringBulan.Location = new Point(0, 61);
            labelTotalMonitoringBulan.Name = "labelTotalMonitoringBulan";
            labelTotalMonitoringBulan.Size = new Size(135, 32);
            labelTotalMonitoringBulan.TabIndex = 5;
            labelTotalMonitoringBulan.Text = "0";
            labelTotalMonitoringBulan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 9);
            label5.Name = "label5";
            label5.Size = new Size(135, 32);
            label5.TabIndex = 3;
            label5.Text = "1 Bulan";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(labelTotalMonitoringHariIni);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(177, 94);
            panel2.Name = "panel2";
            panel2.Size = new Size(135, 120);
            panel2.TabIndex = 38;
            // 
            // labelTotalMonitoringHariIni
            // 
            labelTotalMonitoringHariIni.BackColor = Color.Transparent;
            labelTotalMonitoringHariIni.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalMonitoringHariIni.ForeColor = Color.White;
            labelTotalMonitoringHariIni.Location = new Point(0, 61);
            labelTotalMonitoringHariIni.Name = "labelTotalMonitoringHariIni";
            labelTotalMonitoringHariIni.Size = new Size(135, 32);
            labelTotalMonitoringHariIni.TabIndex = 5;
            labelTotalMonitoringHariIni.Text = "0";
            labelTotalMonitoringHariIni.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 9);
            label3.Name = "label3";
            label3.Size = new Size(135, 32);
            label3.TabIndex = 3;
            label3.Text = "Hari Ini";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // iconButton2
            // 
            iconButton2.BackColor = Color.CornflowerBlue;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.IconSize = 100;
            iconButton2.Location = new Point(720, 164);
            iconButton2.Margin = new Padding(0);
            iconButton2.MaximumSize = new Size(100, 100);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(50, 50);
            iconButton2.TabIndex = 45;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = false;
            // 
            // UC_MonitoringIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(iconButton2);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(DGVRiwayatTambahAkun);
            Name = "UC_MonitoringIkan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVRiwayatTambahAkun;
        private Panel panel1;
        private Label label1;
        private Panel panel4;
        private Label labelTotalMonitoringBulan;
        private Label label5;
        private Panel panel2;
        private Label labelTotalMonitoringHariIni;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}
