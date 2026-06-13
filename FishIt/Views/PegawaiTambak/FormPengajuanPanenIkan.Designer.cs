namespace FishIt
{
    partial class FormPengajuanPanenIkan
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
            NUDBerat = new NumericUpDown();
            label1 = new Label();
            CBKolam = new ComboBox();
            btnSimpan = new FontAwesome.Sharp.IconButton();
            labelNama = new Label();
            lblTambahAkun = new Label();
            CBIkan = new ComboBox();
            label5 = new Label();
            NUBEkor = new NumericUpDown();
            label2 = new Label();
            CBKualitas = new ComboBox();
            label3 = new Label();
            btnBatal = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label4 = new Label();
            labelIkan = new Label();
            ((System.ComponentModel.ISupportInitialize)NUDBerat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUBEkor).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // NUDBerat
            // 
            NUDBerat.DecimalPlaces = 2;
            NUDBerat.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NUDBerat.Location = new Point(82, 308);
            NUDBerat.Margin = new Padding(0);
            NUDBerat.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUDBerat.Name = "NUDBerat";
            NUDBerat.Size = new Size(333, 31);
            NUDBerat.TabIndex = 62;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(82, 276);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 61;
            label1.Text = "Jumlah (Kg)";
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
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Green;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSimpan.ForeColor = Color.White;
            btnSimpan.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSimpan.IconColor = Color.White;
            btnSimpan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSimpan.IconSize = 35;
            btnSimpan.Location = new Point(296, 650);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(169, 50);
            btnSimpan.TabIndex = 58;
            btnSimpan.Text = "Simpan";
            btnSimpan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
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
            lblTambahAkun.Text = "Pengajuan Katalog Ikan";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CBIkan
            // 
            CBIkan.FormattingEnabled = true;
            CBIkan.Location = new Point(82, 231);
            CBIkan.Margin = new Padding(0);
            CBIkan.Name = "CBIkan";
            CBIkan.Size = new Size(333, 33);
            CBIkan.TabIndex = 70;
            CBIkan.SelectedIndexChanged += CBIkan_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(82, 196);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(333, 32);
            label5.TabIndex = 69;
            label5.Text = "Ikan";
            // 
            // NUBEkor
            // 
            NUBEkor.Location = new Point(82, 385);
            NUBEkor.Margin = new Padding(0);
            NUBEkor.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUBEkor.Name = "NUBEkor";
            NUBEkor.Size = new Size(333, 31);
            NUBEkor.TabIndex = 72;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(82, 353);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(333, 32);
            label2.TabIndex = 71;
            label2.Text = "Jumlah Ekor";
            // 
            // CBKualitas
            // 
            CBKualitas.FormattingEnabled = true;
            CBKualitas.Items.AddRange(new object[] { "A", "B", "C" });
            CBKualitas.Location = new Point(82, 465);
            CBKualitas.Margin = new Padding(0);
            CBKualitas.Name = "CBKualitas";
            CBKualitas.Size = new Size(333, 33);
            CBKualitas.TabIndex = 74;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(82, 430);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(333, 32);
            label3.TabIndex = 73;
            label3.Text = "Kualitas";
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.Red;
            btnBatal.FlatAppearance.BorderSize = 0;
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatal.ForeColor = Color.White;
            btnBatal.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnBatal.IconColor = Color.White;
            btnBatal.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBatal.IconSize = 35;
            btnBatal.Location = new Point(36, 650);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(169, 50);
            btnBatal.TabIndex = 75;
            btnBatal.Text = "Kembali";
            btnBatal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(labelIkan);
            panel1.Location = new Point(177, 529);
            panel1.Name = "panel1";
            panel1.Size = new Size(135, 86);
            panel1.TabIndex = 76;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(135, 32);
            label4.TabIndex = 6;
            label4.Text = "Total Ikan";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelIkan
            // 
            labelIkan.BackColor = Color.Transparent;
            labelIkan.Dock = DockStyle.Bottom;
            labelIkan.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIkan.ForeColor = Color.White;
            labelIkan.Location = new Point(0, 32);
            labelIkan.Name = "labelIkan";
            labelIkan.Size = new Size(135, 54);
            labelIkan.TabIndex = 5;
            labelIkan.Text = "0";
            labelIkan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormTambahPanenIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 765);
            Controls.Add(panel1);
            Controls.Add(btnBatal);
            Controls.Add(CBKualitas);
            Controls.Add(label3);
            Controls.Add(NUBEkor);
            Controls.Add(label2);
            Controls.Add(CBIkan);
            Controls.Add(label5);
            Controls.Add(NUDBerat);
            Controls.Add(label1);
            Controls.Add(CBKolam);
            Controls.Add(btnSimpan);
            Controls.Add(labelNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahPanenIkan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahPanenIkan";
            ((System.ComponentModel.ISupportInitialize)NUDBerat).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUBEkor).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private TextBox TBCatatan;
        private NumericUpDown NUDMati;
        private ComboBox CBKondisi;
        private NumericUpDown NUDBerat;
        private Label label1;
        private ComboBox CBKolam;
        private FontAwesome.Sharp.IconButton btnSimpan;
        private Label labelNama;
        private Label lblTambahAkun;
        private ComboBox CBIkan;
        private Label label5;
        private NumericUpDown NUBEkor;
        private Label label2;
        private ComboBox CBKualitas;
        private Label label3;
        private FontAwesome.Sharp.IconButton btnBatal;
        private Panel panel1;
        private Label labelIkan;
    }
}