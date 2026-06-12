namespace FishIt.UserControls.Shipper
{
    partial class UC_PengirimanPesanan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
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
            lblJudul = new Label();
            DGVPengiriman = new DataGridView();
            btnMulaiKirim = new Button();
            btnTandaiDiterima = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVPengiriman).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblJudul.Location = new Point(23, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(285, 37);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Pengiriman Pesanan";
            // 
            // DGVPengiriman
            // 
            DGVPengiriman.AllowUserToAddRows = false;
            DGVPengiriman.AllowUserToDeleteRows = false;
            DGVPengiriman.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPengiriman.Location = new Point(23, 80);
            DGVPengiriman.Name = "DGVPengiriman";
            DGVPengiriman.ReadOnly = true;
            DGVPengiriman.Size = new Size(754, 380);
            DGVPengiriman.TabIndex = 1;
            // 
            // btnMulaiKirim
            // 
            btnMulaiKirim.BackColor = Color.FromArgb(41, 128, 185);
            btnMulaiKirim.FlatStyle = FlatStyle.Flat;
            btnMulaiKirim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMulaiKirim.ForeColor = Color.White;
            btnMulaiKirim.Location = new Point(23, 480);
            btnMulaiKirim.Name = "btnMulaiKirim";
            btnMulaiKirim.Size = new Size(160, 45);
            btnMulaiKirim.TabIndex = 2;
            btnMulaiKirim.Text = "Mulai Kirim";
            btnMulaiKirim.UseVisualStyleBackColor = false;
            btnMulaiKirim.Click += btnMulaiKirim_Click;
            // 
            // btnTandaiDiterima
            // 
            btnTandaiDiterima.BackColor = Color.FromArgb(39, 174, 96);
            btnTandaiDiterima.FlatStyle = FlatStyle.Flat;
            btnTandaiDiterima.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTandaiDiterima.ForeColor = Color.White;
            btnTandaiDiterima.Location = new Point(199, 480);
            btnTandaiDiterima.Name = "btnTandaiDiterima";
            btnTandaiDiterima.Size = new Size(180, 45);
            btnTandaiDiterima.TabIndex = 3;
            btnTandaiDiterima.Text = "Tandai Diterima";
            btnTandaiDiterima.UseVisualStyleBackColor = false;
            btnTandaiDiterima.Click += btnTandaiDiterima_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(127, 140, 141);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(657, 480);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 45);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // UC_PengirimanPesanan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(btnTandaiDiterima);
            Controls.Add(btnMulaiKirim);
            Controls.Add(DGVPengiriman);
            Controls.Add(lblJudul);
            Name = "UC_PengirimanPesanan";
            Size = new Size(800, 600);
            Load += UC_PengirimanPesanan_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPengiriman).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private DataGridView DGVPengiriman;
        private Button btnMulaiKirim;
        private Button btnTandaiDiterima;
        private Button btnRefresh;
    }
}