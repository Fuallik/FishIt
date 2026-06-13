namespace FishIt
{
    partial class FormTambahPemberianPakan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label1 = new Label();
            CBKolam = new ComboBox();
            btnBatalTambahMonitoring = new FontAwesome.Sharp.IconButton();
            btnSaveTambahMonitoring = new FontAwesome.Sharp.IconButton();
            labelNama = new Label();
            lblTambahAkun = new Label();
            CBPakan = new ComboBox();
            NUBJumlahPakan = new NumericUpDown();
            panel1 = new Panel();
            label3 = new Label();
            labelStokPakan = new Label();
            ((System.ComponentModel.ISupportInitialize)NUBJumlahPakan).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(82, 271);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(333, 32);
            label2.TabIndex = 63;
            label2.Text = "Jumlah Pakan";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(82, 196);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 61;
            label1.Text = "Pakan";
            // 
            // CBKolam
            // 
            CBKolam.FormattingEnabled = true;
            CBKolam.Location = new Point(82, 152);
            CBKolam.Margin = new Padding(0);
            CBKolam.Name = "CBKolam";
            CBKolam.Size = new Size(333, 33);
            CBKolam.TabIndex = 60;
            CBKolam.SelectedIndexChanged += CBKolam_SelectedIndexChanged;
            // 
            // btnBatalTambahMonitoring
            // 
            btnBatalTambahMonitoring.BackColor = Color.Red;
            btnBatalTambahMonitoring.FlatAppearance.BorderSize = 0;
            btnBatalTambahMonitoring.FlatStyle = FlatStyle.Flat;
            btnBatalTambahMonitoring.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatalTambahMonitoring.ForeColor = Color.White;
            btnBatalTambahMonitoring.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnBatalTambahMonitoring.IconColor = Color.White;
            btnBatalTambahMonitoring.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBatalTambahMonitoring.IconSize = 35;
            btnBatalTambahMonitoring.Location = new Point(36, 450);
            btnBatalTambahMonitoring.Name = "btnBatalTambahMonitoring";
            btnBatalTambahMonitoring.Size = new Size(169, 50);
            btnBatalTambahMonitoring.TabIndex = 59;
            btnBatalTambahMonitoring.Text = "Kembali";
            btnBatalTambahMonitoring.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatalTambahMonitoring.UseVisualStyleBackColor = false;
            btnBatalTambahMonitoring.Click += btnBatalTambahMonitoring_Click;
            // 
            // btnSaveTambahMonitoring
            // 
            btnSaveTambahMonitoring.BackColor = Color.Green;
            btnSaveTambahMonitoring.FlatAppearance.BorderSize = 0;
            btnSaveTambahMonitoring.FlatStyle = FlatStyle.Flat;
            btnSaveTambahMonitoring.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveTambahMonitoring.ForeColor = Color.White;
            btnSaveTambahMonitoring.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveTambahMonitoring.IconColor = Color.White;
            btnSaveTambahMonitoring.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveTambahMonitoring.IconSize = 35;
            btnSaveTambahMonitoring.Location = new Point(296, 450);
            btnSaveTambahMonitoring.Name = "btnSaveTambahMonitoring";
            btnSaveTambahMonitoring.Size = new Size(169, 50);
            btnSaveTambahMonitoring.TabIndex = 58;
            btnSaveTambahMonitoring.Text = "Simpan";
            btnSaveTambahMonitoring.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveTambahMonitoring.UseVisualStyleBackColor = false;
            btnSaveTambahMonitoring.Click += btnSaveTambahMonitoring_Click;
            // 
            // labelNama
            // 
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(82, 117);
            labelNama.Margin = new Padding(0);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(333, 32);
            labelNama.TabIndex = 57;
            labelNama.Text = "Kolam";
            // 
            // lblTambahAkun
            // 
            lblTambahAkun.BackColor = Color.Transparent;
            lblTambahAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahAkun.ImageAlign = ContentAlignment.TopCenter;
            lblTambahAkun.Location = new Point(-2, 20);
            lblTambahAkun.Name = "lblTambahAkun";
            lblTambahAkun.Size = new Size(505, 54);
            lblTambahAkun.TabIndex = 56;
            lblTambahAkun.Text = "Pemberian Pakan";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CBPakan
            // 
            CBPakan.FormattingEnabled = true;
            CBPakan.Location = new Point(82, 228);
            CBPakan.Margin = new Padding(0);
            CBPakan.Name = "CBPakan";
            CBPakan.Size = new Size(333, 33);
            CBPakan.TabIndex = 69;
            CBPakan.SelectedIndexChanged += CBPakan_SelectedIndexChanged;
            // 
            // NUBJumlahPakan
            // 
            NUBJumlahPakan.DecimalPlaces = 2;
            NUBJumlahPakan.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NUBJumlahPakan.Location = new Point(82, 303);
            NUBJumlahPakan.Margin = new Padding(0);
            NUBJumlahPakan.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUBJumlahPakan.Name = "NUBJumlahPakan";
            NUBJumlahPakan.Size = new Size(333, 31);
            NUBJumlahPakan.TabIndex = 70;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(labelStokPakan);
            panel1.Location = new Point(180, 350);
            panel1.Name = "panel1";
            panel1.Size = new Size(135, 86);
            panel1.TabIndex = 71;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(135, 32);
            label3.TabIndex = 6;
            label3.Text = "Sisa Stok";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelStokPakan
            // 
            labelStokPakan.BackColor = Color.Transparent;
            labelStokPakan.Dock = DockStyle.Bottom;
            labelStokPakan.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStokPakan.ForeColor = Color.White;
            labelStokPakan.Location = new Point(0, 32);
            labelStokPakan.Name = "labelStokPakan";
            labelStokPakan.Size = new Size(135, 54);
            labelStokPakan.TabIndex = 5;
            labelStokPakan.Text = "0";
            labelStokPakan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTambahPemberianPakan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 550);
            Controls.Add(panel1);
            Controls.Add(NUBJumlahPakan);
            Controls.Add(CBPakan);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CBKolam);
            Controls.Add(btnBatalTambahMonitoring);
            Controls.Add(btnSaveTambahMonitoring);
            Controls.Add(labelNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahPemberianPakan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahPemberianPakan";
            ((System.ComponentModel.ISupportInitialize)NUBJumlahPakan).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private ComboBox CBKolam;
        private FontAwesome.Sharp.IconButton btnBatalTambahMonitoring;
        private FontAwesome.Sharp.IconButton btnSaveTambahMonitoring;
        private Label labelNama;
        private Label lblTambahAkun;
        private ComboBox CBPakan;
        private NumericUpDown NUBJumlahPakan;
        private Panel panel1;
        private Label labelStokPakan;
        private Label label3;
    }
}