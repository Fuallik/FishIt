namespace FishIt
{
    partial class UC_RiwayatVerifikasi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblJudul = new Label();
            DGVRiwayat = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayat).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblJudul.Location = new Point(23, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(285, 45);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Riwayat Verifikasi";
            // 
            // DGVRiwayat
            // 
            DGVRiwayat.AllowUserToAddRows = false;
            DGVRiwayat.AllowUserToDeleteRows = false;
            DGVRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayat.Location = new Point(23, 80);
            DGVRiwayat.Name = "DGVRiwayat";
            DGVRiwayat.ReadOnly = true;
            DGVRiwayat.RowHeadersWidth = 62;
            DGVRiwayat.Size = new Size(754, 400);
            DGVRiwayat.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(127, 140, 141);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(657, 495);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // UC_RiwayatVerifikasi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(btnRefresh);
            Controls.Add(DGVRiwayat);
            Controls.Add(lblJudul);
            Name = "UC_RiwayatVerifikasi";
            Size = new Size(800, 600);
            Load += UC_RiwayatVerifikasi_Load;
            ((System.ComponentModel.ISupportInitialize)DGVRiwayat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private DataGridView DGVRiwayat;
        private Button btnRefresh;
    }
}