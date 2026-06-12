namespace FishIt.Views.Kasir
{
    partial class UC_RiwayatPembayaran
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
            panel6 = new Panel();
            DGVRiwayat = new DataGridView();
            panel1 = new Panel();
            labelTotal = new Label();
            label1 = new Label();
            DGVDetail = new DataGridView();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayat).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDetail).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(471, 41);
            label8.TabIndex = 3;
            label8.Text = "Riwayat Pembayaran";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.CornflowerBlue;
            panel6.Controls.Add(label8);
            panel6.Location = new Point(158, 33);
            panel6.Name = "panel6";
            panel6.Size = new Size(474, 44);
            panel6.TabIndex = 65;
            // 
            // DGVRiwayat
            // 
            DGVRiwayat.AllowUserToAddRows = false;
            DGVRiwayat.AllowUserToDeleteRows = false;
            DGVRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayat.Location = new Point(30, 217);
            DGVRiwayat.Name = "DGVRiwayat";
            DGVRiwayat.ReadOnly = true;
            DGVRiwayat.RowHeadersWidth = 62;
            DGVRiwayat.Size = new Size(354, 352);
            DGVRiwayat.TabIndex = 64;
            DGVRiwayat.CellClick += DGVRiwayat_CellClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(labelTotal);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(277, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(240, 78);
            panel1.TabIndex = 66;
            // 
            // labelTotal
            // 
            labelTotal.BackColor = Color.Transparent;
            labelTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.ForeColor = Color.White;
            labelTotal.Location = new Point(0, 41);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(240, 31);
            labelTotal.TabIndex = 5;
            labelTotal.Text = "0";
            labelTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(234, 41);
            label1.TabIndex = 3;
            label1.Text = "Total Pembayaran";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGVDetail
            // 
            DGVDetail.AllowUserToAddRows = false;
            DGVDetail.AllowUserToDeleteRows = false;
            DGVDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDetail.Location = new Point(402, 217);
            DGVDetail.Name = "DGVDetail";
            DGVDetail.ReadOnly = true;
            DGVDetail.RowHeadersWidth = 62;
            DGVDetail.Size = new Size(354, 352);
            DGVDetail.TabIndex = 67;
            // 
            // UC_RiwayatPembayaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVDetail);
            Controls.Add(panel1);
            Controls.Add(DGVRiwayat);
            Controls.Add(panel6);
            Name = "UC_RiwayatPembayaran";
            Size = new Size(800, 600);
            Load += UC_RiwayatPembayaran_Load;
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVRiwayat).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label8;
        private Panel panel6;
        private DataGridView DGVRiwayat;
        private Panel panel1;
        private Label labelTotal;
        private Label label1;
        private DataGridView DGVDetail;
    }
}
