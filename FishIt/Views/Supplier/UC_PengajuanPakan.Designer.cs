namespace FishIt
{
    partial class UC_PengajuanPakan
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
            lblPakan = new Label();
            cmbPakan = new ComboBox();
            lblKuantitas = new Label();
            txtKuantitas = new TextBox();
            btnAjukan = new Button();
            lblRiwayat = new Label();
            DGVPengajuan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblJudul.Location = new Point(23, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(275, 45);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Pengajuan Pakan";
            // 
            // lblPakan
            // 
            lblPakan.AutoSize = true;
            lblPakan.Font = new Font("Segoe UI", 10F);
            lblPakan.Location = new Point(23, 80);
            lblPakan.Name = "lblPakan";
            lblPakan.Size = new Size(120, 28);
            lblPakan.TabIndex = 1;
            lblPakan.Text = "Nama Pakan";
            // 
            // cmbPakan
            // 
            cmbPakan.Font = new Font("Segoe UI", 10F);
            cmbPakan.Location = new Point(23, 108);
            cmbPakan.Name = "cmbPakan";
            cmbPakan.Size = new Size(300, 36);
            cmbPakan.TabIndex = 2;
            // 
            // lblKuantitas
            // 
            lblKuantitas.AutoSize = true;
            lblKuantitas.Font = new Font("Segoe UI", 10F);
            lblKuantitas.Location = new Point(23, 160);
            lblKuantitas.Name = "lblKuantitas";
            lblKuantitas.Size = new Size(132, 28);
            lblKuantitas.TabIndex = 3;
            lblKuantitas.Text = "Kuantitas (kg)";
            // 
            // txtKuantitas
            // 
            txtKuantitas.Font = new Font("Segoe UI", 10F);
            txtKuantitas.Location = new Point(23, 188);
            txtKuantitas.Name = "txtKuantitas";
            txtKuantitas.Size = new Size(300, 34);
            txtKuantitas.TabIndex = 4;
            // 
            // btnAjukan
            // 
            btnAjukan.BackColor = Color.FromArgb(39, 174, 96);
            btnAjukan.FlatStyle = FlatStyle.Flat;
            btnAjukan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAjukan.ForeColor = Color.White;
            btnAjukan.Location = new Point(23, 240);
            btnAjukan.Name = "btnAjukan";
            btnAjukan.Size = new Size(300, 45);
            btnAjukan.TabIndex = 5;
            btnAjukan.Text = "Ajukan Pengiriman Pakan";
            btnAjukan.UseVisualStyleBackColor = false;
            btnAjukan.Click += btnAjukan_Click;
            // 
            // lblRiwayat
            // 
            lblRiwayat.AutoSize = true;
            lblRiwayat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRiwayat.Location = new Point(360, 75);
            lblRiwayat.Name = "lblRiwayat";
            lblRiwayat.Size = new Size(243, 30);
            lblRiwayat.TabIndex = 6;
            lblRiwayat.Text = "Pengajuan Pakan Saya";
            // 
            // DGVPengajuan
            // 
            DGVPengajuan.AllowUserToAddRows = false;
            DGVPengajuan.AllowUserToDeleteRows = false;
            DGVPengajuan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPengajuan.Location = new Point(360, 110);
            DGVPengajuan.Name = "DGVPengajuan";
            DGVPengajuan.ReadOnly = true;
            DGVPengajuan.RowHeadersWidth = 62;
            DGVPengajuan.Size = new Size(420, 460);
            DGVPengajuan.TabIndex = 7;
            // 
            // UC_PengajuanPakan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVPengajuan);
            Controls.Add(lblRiwayat);
            Controls.Add(btnAjukan);
            Controls.Add(txtKuantitas);
            Controls.Add(lblKuantitas);
            Controls.Add(cmbPakan);
            Controls.Add(lblPakan);
            Controls.Add(lblJudul);
            Name = "UC_PengajuanPakan";
            Size = new Size(800, 600);
            Load += UC_PengajuanPakan_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblPakan;
        private ComboBox cmbPakan;
        private Label lblKuantitas;
        private TextBox txtKuantitas;
        private Button btnAjukan;
        private Label lblRiwayat;
        private DataGridView DGVPengajuan;
    }
}