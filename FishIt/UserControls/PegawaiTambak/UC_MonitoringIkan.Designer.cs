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
            panel3 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            labelTotalHariPerAkun = new Label();
            label6 = new Label();
            panel6 = new Panel();
            labelTotalBulanPerAkun = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVMonitoringIkan).BeginInit();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // DGVMonitoringIkan
            // 
            DGVMonitoringIkan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVMonitoringIkan.Location = new Point(30, 236);
            DGVMonitoringIkan.Name = "DGVMonitoringIkan";
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
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(label2);
            panel3.Location = new Point(30, 22);
            panel3.Name = "panel3";
            panel3.Size = new Size(325, 55);
            panel3.TabIndex = 46;
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
            // panel5
            // 
            panel5.BackColor = Color.CornflowerBlue;
            panel5.Controls.Add(labelTotalHariPerAkun);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(200, 90);
            panel5.Name = "panel5";
            panel5.Size = new Size(155, 120);
            panel5.TabIndex = 48;
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
            // panel6
            // 
            panel6.BackColor = Color.CornflowerBlue;
            panel6.Controls.Add(labelTotalBulanPerAkun);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(30, 90);
            panel6.Name = "panel6";
            panel6.Size = new Size(155, 120);
            panel6.TabIndex = 47;
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
            Controls.Add(panel5);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(buttonTambahMonitoring);
            Controls.Add(DGVMonitoringIkan);
            Name = "UC_MonitoringIkan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVMonitoringIkan).EndInit();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVMonitoringIkan;
        private FontAwesome.Sharp.IconButton buttonTambahMonitoring;
        private Panel panel3;
        private Label label2;
        private Panel panel5;
        private Label labelTotalHariPerAkun;
        private Label label6;
        private Panel panel6;
        private Label labelTotalBulanPerAkun;
        private Label label8;
    }
}
