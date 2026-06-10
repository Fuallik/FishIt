namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_RiwayatMonitoring
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
            panel3 = new Panel();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // DGVRiwayatTambahAkun
            // 
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(30, 106);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(740, 470);
            DGVRiwayatTambahAkun.TabIndex = 40;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(30, 21);
            panel3.Name = "panel3";
            panel3.Size = new Size(740, 55);
            panel3.TabIndex = 43;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 9);
            label6.Name = "label6";
            label6.Size = new Size(737, 32);
            label6.TabIndex = 3;
            label6.Text = "Riwayat Monitoring";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_RiwayatMonitoring
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panel3);
            Controls.Add(DGVRiwayatTambahAkun);
            Name = "UC_RiwayatMonitoring";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVRiwayatTambahAkun;
        private Panel panel3;
        private Label label6;
    }
}
