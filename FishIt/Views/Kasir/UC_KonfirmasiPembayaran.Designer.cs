namespace FishIt
{
    partial class UC_KonfirmasiPembayaran
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
            DGVAntrean = new DataGridView();
            label8 = new Label();
            labelTotal = new Label();
            panel6 = new Panel();
            buttonKonfirmasi = new Button();
            label2 = new Label();
            DGVDetail = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVAntrean).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDetail).BeginInit();
            SuspendLayout();
            // 
            // DGVAntrean
            // 
            DGVAntrean.AllowUserToAddRows = false;
            DGVAntrean.AllowUserToDeleteRows = false;
            DGVAntrean.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVAntrean.Location = new Point(30, 222);
            DGVAntrean.Name = "DGVAntrean";
            DGVAntrean.ReadOnly = true;
            DGVAntrean.RowHeadersWidth = 62;
            DGVAntrean.Size = new Size(360, 352);
            DGVAntrean.TabIndex = 54;
            DGVAntrean.CellClick += DGVAntrean_CellClick;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(234, 41);
            label8.TabIndex = 3;
            label8.Text = "Total Pembayaran";
            label8.TextAlign = ContentAlignment.MiddleCenter;
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
            // panel6
            // 
            panel6.BackColor = Color.CornflowerBlue;
            panel6.Controls.Add(labelTotal);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(30, 36);
            panel6.Name = "panel6";
            panel6.Size = new Size(240, 78);
            panel6.TabIndex = 57;
            // 
            // buttonKonfirmasi
            // 
            buttonKonfirmasi.BackColor = Color.FromArgb(39, 174, 96);
            buttonKonfirmasi.FlatStyle = FlatStyle.Flat;
            buttonKonfirmasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonKonfirmasi.ForeColor = Color.White;
            buttonKonfirmasi.Location = new Point(517, 36);
            buttonKonfirmasi.Name = "buttonKonfirmasi";
            buttonKonfirmasi.Size = new Size(248, 45);
            buttonKonfirmasi.TabIndex = 61;
            buttonKonfirmasi.Text = "Konfirmasi Pembayaran";
            buttonKonfirmasi.UseVisualStyleBackColor = false;
            buttonKonfirmasi.Click += buttonKonfirmasi_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(74, 170);
            label2.Name = "label2";
            label2.Size = new Size(264, 38);
            label2.TabIndex = 3;
            label2.Text = "Antrean Pembayaran";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGVDetail
            // 
            DGVDetail.AllowUserToAddRows = false;
            DGVDetail.AllowUserToDeleteRows = false;
            DGVDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDetail.Location = new Point(405, 222);
            DGVDetail.Name = "DGVDetail";
            DGVDetail.ReadOnly = true;
            DGVDetail.RowHeadersWidth = 62;
            DGVDetail.Size = new Size(360, 352);
            DGVDetail.TabIndex = 62;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(445, 170);
            label1.Name = "label1";
            label1.Size = new Size(280, 38);
            label1.TabIndex = 63;
            label1.Text = "Detail Pembayaran";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_KonfirmasiPembayaran
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(label1);
            Controls.Add(DGVDetail);
            Controls.Add(label2);
            Controls.Add(buttonKonfirmasi);
            Controls.Add(DGVAntrean);
            Controls.Add(panel6);
            Name = "UC_KonfirmasiPembayaran";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVAntrean).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVDetail).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVAntrean;
        private Label label8;
        private Label labelTotal;
        private Panel panel6;
        private Button buttonKonfirmasi;
        private Label label2;
        private DataGridView DGVDetail;
        private Label label1;
    }
}
