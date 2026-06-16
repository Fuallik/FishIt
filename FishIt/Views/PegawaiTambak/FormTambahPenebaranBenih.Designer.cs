namespace FishIt
{
    partial class FormTambahPenebaranBenih
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
            CBBenihIkan = new ComboBox();
            label2 = new Label();
            CBKolam = new ComboBox();
            btnBatalTambah = new FontAwesome.Sharp.IconButton();
            btnSaveTambah = new FontAwesome.Sharp.IconButton();
            labelNama = new Label();
            lblTambahAkun = new Label();
            label1 = new Label();
            NUBEkor = new NumericUpDown();
            panel1 = new Panel();
            label3 = new Label();
            labelStok = new Label();
            ((System.ComponentModel.ISupportInitialize)NUBEkor).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CBBenihIkan
            // 
            CBBenihIkan.DisplayMember = "Baik";
            CBBenihIkan.DropDownStyle = ComboBoxStyle.DropDownList;
            CBBenihIkan.FormattingEnabled = true;
            CBBenihIkan.Location = new Point(82, 228);
            CBBenihIkan.Margin = new Padding(0);
            CBBenihIkan.Name = "CBBenihIkan";
            CBBenihIkan.Size = new Size(333, 33);
            CBBenihIkan.TabIndex = 64;
            CBBenihIkan.SelectedIndexChanged += CBBenihIkan_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(82, 196);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(333, 32);
            label2.TabIndex = 63;
            label2.Text = "Benih Ikan";
            // 
            // CBKolam
            // 
            CBKolam.DropDownStyle = ComboBoxStyle.DropDownList;
            CBKolam.FormattingEnabled = true;
            CBKolam.Location = new Point(82, 152);
            CBKolam.Margin = new Padding(0);
            CBKolam.Name = "CBKolam";
            CBKolam.Size = new Size(333, 33);
            CBKolam.TabIndex = 60;
            CBKolam.SelectedIndexChanged += CBKolam_SelectedIndexChanged;
            // 
            // btnBatalTambah
            // 
            btnBatalTambah.BackColor = Color.Red;
            btnBatalTambah.FlatAppearance.BorderSize = 0;
            btnBatalTambah.FlatStyle = FlatStyle.Flat;
            btnBatalTambah.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatalTambah.ForeColor = Color.White;
            btnBatalTambah.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnBatalTambah.IconColor = Color.White;
            btnBatalTambah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBatalTambah.IconSize = 35;
            btnBatalTambah.Location = new Point(36, 550);
            btnBatalTambah.Name = "btnBatalTambah";
            btnBatalTambah.Size = new Size(169, 50);
            btnBatalTambah.TabIndex = 59;
            btnBatalTambah.Text = "Kembali";
            btnBatalTambah.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatalTambah.UseVisualStyleBackColor = false;
            btnBatalTambah.Click += btnBatalTambahMonitoring_Click;
            // 
            // btnSaveTambah
            // 
            btnSaveTambah.BackColor = Color.Green;
            btnSaveTambah.FlatAppearance.BorderSize = 0;
            btnSaveTambah.FlatStyle = FlatStyle.Flat;
            btnSaveTambah.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveTambah.ForeColor = Color.White;
            btnSaveTambah.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSaveTambah.IconColor = Color.White;
            btnSaveTambah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSaveTambah.IconSize = 35;
            btnSaveTambah.Location = new Point(296, 550);
            btnSaveTambah.Name = "btnSaveTambah";
            btnSaveTambah.Size = new Size(169, 50);
            btnSaveTambah.TabIndex = 58;
            btnSaveTambah.Text = "Simpan";
            btnSaveTambah.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveTambah.UseVisualStyleBackColor = false;
            btnSaveTambah.Click += btnSaveTambahMonitoring_Click;
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
            lblTambahAkun.Text = "Penebaran Benih Ikan";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(82, 273);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 69;
            label1.Text = "Jumlah Ekor";
            // 
            // NUBEkor
            // 
            NUBEkor.Location = new Point(82, 308);
            NUBEkor.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            NUBEkor.Name = "NUBEkor";
            NUBEkor.Size = new Size(333, 31);
            NUBEkor.TabIndex = 70;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(labelStok);
            panel1.Location = new Point(180, 398);
            panel1.Name = "panel1";
            panel1.Size = new Size(135, 86);
            panel1.TabIndex = 72;
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
            // labelStok
            // 
            labelStok.BackColor = Color.Transparent;
            labelStok.Dock = DockStyle.Bottom;
            labelStok.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStok.ForeColor = Color.White;
            labelStok.Location = new Point(0, 32);
            labelStok.Name = "labelStok";
            labelStok.Size = new Size(135, 54);
            labelStok.TabIndex = 5;
            labelStok.Text = "0";
            labelStok.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTambahPenebaranBenih
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 683);
            Controls.Add(panel1);
            Controls.Add(NUBEkor);
            Controls.Add(label1);
            Controls.Add(CBBenihIkan);
            Controls.Add(label2);
            Controls.Add(CBKolam);
            Controls.Add(btnBatalTambah);
            Controls.Add(btnSaveTambah);
            Controls.Add(labelNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahPenebaranBenih";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahPenebaranBenih";
            ((System.ComponentModel.ISupportInitialize)NUBEkor).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox CBBenihIkan;
        private Label label2;
        private ComboBox CBKolam;
        private FontAwesome.Sharp.IconButton btnBatalTambah;
        private FontAwesome.Sharp.IconButton btnSaveTambah;
        private Label labelNama;
        private Label lblTambahAkun;
        private Label label1;
        private NumericUpDown NUBEkor;
        private Panel panel1;
        private Label label3;
        private Label labelStok;
    }
}