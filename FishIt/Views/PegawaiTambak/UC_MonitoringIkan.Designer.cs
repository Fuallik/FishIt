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
            DGVMonitoringIkan = new DataGridView();
            buttonTambahMonitoring = new FontAwesome.Sharp.IconButton();
            panelMonitoring = new Panel();
            label2 = new Label();
            panelHari = new Panel();
            labelTotalHariPerAkun = new Label();
            label6 = new Label();
            panelBulan = new Panel();
            labelTotalBulanPerAkun = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVMonitoringIkan).BeginInit();
            panelMonitoring.SuspendLayout();
            panelHari.SuspendLayout();
            panelBulan.SuspendLayout();
            SuspendLayout();
            // 
            // DGVMonitoringIkan
            // 
            DGVMonitoringIkan.AllowUserToAddRows = false;
            DGVMonitoringIkan.AllowUserToDeleteRows = false;
            DGVMonitoringIkan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVMonitoringIkan.Location = new Point(30, 236);
            DGVMonitoringIkan.Name = "DGVMonitoringIkan";
            DGVMonitoringIkan.ReadOnly = true;
            DGVMonitoringIkan.RowHeadersWidth = 62;
            DGVMonitoringIkan.Size = new Size(740, 340);
            DGVMonitoringIkan.TabIndex = 18;
            // 
            // buttonTambahMonitoring
            // 
            buttonTambahMonitoring.BackColor = Color.CornflowerBlue;
            buttonTambahMonitoring.FlatAppearance.BorderSize = 0;
            buttonTambahMonitoring.FlatStyle = FlatStyle.Flat;
            buttonTambahMonitoring.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambahMonitoring.ForeColor = Color.White;
            buttonTambahMonitoring.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            buttonTambahMonitoring.IconColor = Color.White;
            buttonTambahMonitoring.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTambahMonitoring.IconSize = 100;
            buttonTambahMonitoring.Location = new Point(720, 160);
            buttonTambahMonitoring.Margin = new Padding(0);
            buttonTambahMonitoring.MaximumSize = new Size(100, 100);
            buttonTambahMonitoring.Name = "buttonTambahMonitoring";
            buttonTambahMonitoring.Size = new Size(50, 50);
            buttonTambahMonitoring.TabIndex = 45;
            buttonTambahMonitoring.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambahMonitoring.UseVisualStyleBackColor = false;
            buttonTambahMonitoring.Click += buttonTambahMonitoring_Click;
            // 
            // panelMonitoring
            // 
            panelMonitoring.BackColor = Color.CornflowerBlue;
            panelMonitoring.Controls.Add(label2);
            panelMonitoring.Location = new Point(30, 22);
            panelMonitoring.Name = "panelMonitoring";
            panelMonitoring.Size = new Size(325, 55);
            panelMonitoring.TabIndex = 46;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 9);
            label2.Name = "label2";
            label2.Size = new Size(325, 32);
            label2.TabIndex = 3;
            label2.Text = "Total Monitoring Per Akun";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHari
            // 
            panelHari.BackColor = Color.CornflowerBlue;
            panelHari.Controls.Add(labelTotalHariPerAkun);
            panelHari.Controls.Add(label6);
            panelHari.Location = new Point(200, 90);
            panelHari.Name = "panelHari";
            panelHari.Size = new Size(155, 120);
            panelHari.TabIndex = 48;
            // 
            // labelTotalHariPerAkun
            // 
            labelTotalHariPerAkun.BackColor = Color.Transparent;
            labelTotalHariPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalHariPerAkun.ForeColor = Color.White;
            labelTotalHariPerAkun.Location = new Point(0, 61);
            labelTotalHariPerAkun.Name = "labelTotalHariPerAkun";
            labelTotalHariPerAkun.Size = new Size(152, 32);
            labelTotalHariPerAkun.TabIndex = 5;
            labelTotalHariPerAkun.Text = "0";
            labelTotalHariPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 9);
            label6.Name = "label6";
            label6.Size = new Size(155, 32);
            label6.TabIndex = 3;
            label6.Text = "Hari Ini";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBulan
            // 
            panelBulan.BackColor = Color.CornflowerBlue;
            panelBulan.Controls.Add(labelTotalBulanPerAkun);
            panelBulan.Controls.Add(label8);
            panelBulan.Location = new Point(30, 90);
            panelBulan.Name = "panelBulan";
            panelBulan.Size = new Size(155, 120);
            panelBulan.TabIndex = 47;
            // 
            // labelTotalBulanPerAkun
            // 
            labelTotalBulanPerAkun.BackColor = Color.Transparent;
            labelTotalBulanPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalBulanPerAkun.ForeColor = Color.White;
            labelTotalBulanPerAkun.Location = new Point(0, 61);
            labelTotalBulanPerAkun.Name = "labelTotalBulanPerAkun";
            labelTotalBulanPerAkun.Size = new Size(155, 32);
            labelTotalBulanPerAkun.TabIndex = 5;
            labelTotalBulanPerAkun.Text = "0";
            labelTotalBulanPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 9);
            label8.Name = "label8";
            label8.Size = new Size(152, 32);
            label8.TabIndex = 3;
            label8.Text = "1 Bulan";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_MonitoringIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panelHari);
            Controls.Add(panelBulan);
            Controls.Add(panelMonitoring);
            Controls.Add(buttonTambahMonitoring);
            Controls.Add(DGVMonitoringIkan);
            Name = "UC_MonitoringIkan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVMonitoringIkan).EndInit();
            panelMonitoring.ResumeLayout(false);
            panelHari.ResumeLayout(false);
            panelBulan.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVMonitoringIkan;
        private FontAwesome.Sharp.IconButton buttonTambahMonitoring;
        private Panel panelMonitoring;
        private Label label2;
        private Panel panelHari;
        private Label labelTotalHariPerAkun;
        private Label label6;
        private Panel panelBulan;
        private Label labelTotalBulanPerAkun;
        private Label label8;
    }
}
