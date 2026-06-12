namespace FishIt
{
    partial class UC_PengajuanBenih
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
            lblJenisIkan = new Label();
            cmbJenisIkan = new ComboBox();
            lblBenih = new Label();
            cmbBenih = new ComboBox();
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
            lblJudul.Size = new Size(250, 37);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Pengajuan Benih";
            // 
            // lblJenisIkan
            // 
            lblJenisIkan.AutoSize = true;
            lblJenisIkan.Font = new Font("Segoe UI", 10F);
            lblJenisIkan.Location = new Point(23, 75);
            lblJenisIkan.Name = "lblJenisIkan";
            lblJenisIkan.Size = new Size(80, 25);
            lblJenisIkan.TabIndex = 1;
            lblJenisIkan.Text = "Jenis Ikan";
            // 
            // cmbJenisIkan
            // 
            // DropDown (bukan DropDownList) supaya bisa diketik manual ATAU dipilih.
            cmbJenisIkan.DropDownStyle = ComboBoxStyle.DropDown;
            cmbJenisIkan.Font = new Font("Segoe UI", 10F);
            cmbJenisIkan.Location = new Point(23, 103);
            cmbJenisIkan.Name = "cmbJenisIkan";
            cmbJenisIkan.Size = new Size(300, 33);
            cmbJenisIkan.TabIndex = 2;
            // 
            // lblBenih
            // 
            lblBenih.AutoSize = true;
            lblBenih.Font = new Font("Segoe UI", 10F);
            lblBenih.Location = new Point(23, 150);
            lblBenih.Name = "lblBenih";
            lblBenih.Size = new Size(120, 25);
            lblBenih.TabIndex = 3;
            lblBenih.Text = "Nama Benih";
            // 
            // cmbBenih
            // 
            cmbBenih.DropDownStyle = ComboBoxStyle.DropDown;
            cmbBenih.Font = new Font("Segoe UI", 10F);
            cmbBenih.Location = new Point(23, 178);
            cmbBenih.Name = "cmbBenih";
            cmbBenih.Size = new Size(300, 33);
            cmbBenih.TabIndex = 4;
            // 
            // lblKuantitas
            // 
            lblKuantitas.AutoSize = true;
            lblKuantitas.Font = new Font("Segoe UI", 10F);
            lblKuantitas.Location = new Point(23, 225);
            lblKuantitas.Name = "lblKuantitas";
            lblKuantitas.Size = new Size(150, 25);
            lblKuantitas.TabIndex = 5;
            lblKuantitas.Text = "Kuantitas (kg)";
            // 
            // txtKuantitas
            // 
            txtKuantitas.Font = new Font("Segoe UI", 10F);
            txtKuantitas.Location = new Point(23, 253);
            txtKuantitas.Name = "txtKuantitas";
            txtKuantitas.Size = new Size(300, 31);
            txtKuantitas.TabIndex = 6;
            // 
            // btnAjukan
            // 
            btnAjukan.BackColor = Color.FromArgb(39, 174, 96);
            btnAjukan.FlatStyle = FlatStyle.Flat;
            btnAjukan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAjukan.ForeColor = Color.White;
            btnAjukan.Location = new Point(23, 305);
            btnAjukan.Name = "btnAjukan";
            btnAjukan.Size = new Size(300, 45);
            btnAjukan.TabIndex = 7;
            btnAjukan.Text = "Ajukan Pengiriman Benih";
            btnAjukan.UseVisualStyleBackColor = false;
            btnAjukan.Click += btnAjukan_Click;
            // 
            // lblRiwayat
            // 
            lblRiwayat.AutoSize = true;
            lblRiwayat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRiwayat.Location = new Point(360, 75);
            lblRiwayat.Name = "lblRiwayat";
            lblRiwayat.Size = new Size(200, 30);
            lblRiwayat.TabIndex = 8;
            lblRiwayat.Text = "Pengajuan Benih Saya";
            // 
            // DGVPengajuan
            // 
            DGVPengajuan.AllowUserToAddRows = false;
            DGVPengajuan.AllowUserToDeleteRows = false;
            DGVPengajuan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPengajuan.Location = new Point(360, 110);
            DGVPengajuan.Name = "DGVPengajuan";
            DGVPengajuan.ReadOnly = true;
            DGVPengajuan.Size = new Size(420, 460);
            DGVPengajuan.TabIndex = 9;
            // 
            // UC_PengajuanBenih
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(DGVPengajuan);
            Controls.Add(lblRiwayat);
            Controls.Add(btnAjukan);
            Controls.Add(txtKuantitas);
            Controls.Add(lblKuantitas);
            Controls.Add(cmbBenih);
            Controls.Add(lblBenih);
            Controls.Add(cmbJenisIkan);
            Controls.Add(lblJenisIkan);
            Controls.Add(lblJudul);
            Name = "UC_PengajuanBenih";
            Size = new Size(800, 600);
            Load += UC_PengajuanBenih_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPengajuan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private Label lblJenisIkan;
        private ComboBox cmbJenisIkan;
        private Label lblBenih;
        private ComboBox cmbBenih;
        private Label lblKuantitas;
        private TextBox txtKuantitas;
        private Button btnAjukan;
        private Label lblRiwayat;
        private DataGridView DGVPengajuan;
    }
}