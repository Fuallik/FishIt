namespace FishIt
{
    partial class FormTambahMonitoring
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
            btnBatalTambahMonitoring = new FontAwesome.Sharp.IconButton();
            btnSaveTambahMonitoring = new FontAwesome.Sharp.IconButton();
            labelNama = new Label();
            lblTambahAkun = new Label();
            CBKolam = new ComboBox();
            label1 = new Label();
            NUDBerat = new NumericUpDown();
            label2 = new Label();
            CBKondisi = new ComboBox();
            NUDMati = new NumericUpDown();
            label3 = new Label();
            TBCatatan = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)NUDBerat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUDMati).BeginInit();
            SuspendLayout();
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
            btnBatalTambahMonitoring.Location = new Point(36, 732);
            btnBatalTambahMonitoring.Name = "btnBatalTambahMonitoring";
            btnBatalTambahMonitoring.Size = new Size(169, 50);
            btnBatalTambahMonitoring.TabIndex = 46;
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
            btnSaveTambahMonitoring.Location = new Point(296, 732);
            btnSaveTambahMonitoring.Name = "btnSaveTambahMonitoring";
            btnSaveTambahMonitoring.Size = new Size(169, 50);
            btnSaveTambahMonitoring.TabIndex = 45;
            btnSaveTambahMonitoring.Text = "Simpan";
            btnSaveTambahMonitoring.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSaveTambahMonitoring.UseVisualStyleBackColor = false;
            btnSaveTambahMonitoring.Click += btnSaveTambahMonitoring_Click;
            // 
            // labelNama
            // 
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(82, 118);
            labelNama.Margin = new Padding(0);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(333, 32);
            labelNama.TabIndex = 27;
            labelNama.Text = "Kolam";
            // 
            // lblTambahAkun
            // 
            lblTambahAkun.BackColor = Color.Transparent;
            lblTambahAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahAkun.ImageAlign = ContentAlignment.TopCenter;
            lblTambahAkun.Location = new Point(-2, 21);
            lblTambahAkun.Name = "lblTambahAkun";
            lblTambahAkun.Size = new Size(505, 54);
            lblTambahAkun.TabIndex = 25;
            lblTambahAkun.Text = "Monitoring";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CBKolam
            // 
            CBKolam.FormattingEnabled = true;
            CBKolam.Location = new Point(82, 153);
            CBKolam.Margin = new Padding(0);
            CBKolam.Name = "CBKolam";
            CBKolam.Size = new Size(333, 33);
            CBKolam.TabIndex = 47;
            CBKolam.SelectedIndexChanged += CBKolam_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(82, 197);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(333, 32);
            label1.TabIndex = 48;
            label1.Text = "Berat";
            // 
            // NUDBerat
            // 
            NUDBerat.DecimalPlaces = 2;
            NUDBerat.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            NUDBerat.Location = new Point(82, 229);
            NUDBerat.Margin = new Padding(0);
            NUDBerat.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUDBerat.Name = "NUDBerat";
            NUDBerat.Size = new Size(333, 31);
            NUDBerat.TabIndex = 49;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(82, 272);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(333, 32);
            label2.TabIndex = 50;
            label2.Text = "Kondisi Kolam";
            // 
            // CBKondisi
            // 
            CBKondisi.DisplayMember = "Baik";
            CBKondisi.FormattingEnabled = true;
            CBKondisi.Items.AddRange(new object[] { "Siap Panen", "Belum Siap Panen" });
            CBKondisi.Location = new Point(82, 304);
            CBKondisi.Margin = new Padding(0);
            CBKondisi.Name = "CBKondisi";
            CBKondisi.Size = new Size(333, 33);
            CBKondisi.TabIndex = 51;
            // 
            // NUDMati
            // 
            NUDMati.Location = new Point(82, 381);
            NUDMati.Margin = new Padding(0);
            NUDMati.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NUDMati.Name = "NUDMati";
            NUDMati.Size = new Size(333, 31);
            NUDMati.TabIndex = 53;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(82, 349);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(333, 32);
            label3.TabIndex = 52;
            label3.Text = "Ikan Mati";
            // 
            // TBCatatan
            // 
            TBCatatan.Location = new Point(82, 459);
            TBCatatan.Multiline = true;
            TBCatatan.Name = "TBCatatan";
            TBCatatan.Size = new Size(333, 185);
            TBCatatan.TabIndex = 54;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(82, 424);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(333, 32);
            label4.TabIndex = 55;
            label4.Text = "Catatan";
            // 
            // FormTambahMonitoring
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 810);
            Controls.Add(label4);
            Controls.Add(TBCatatan);
            Controls.Add(NUDMati);
            Controls.Add(label3);
            Controls.Add(CBKondisi);
            Controls.Add(label2);
            Controls.Add(NUDBerat);
            Controls.Add(label1);
            Controls.Add(CBKolam);
            Controls.Add(btnBatalTambahMonitoring);
            Controls.Add(btnSaveTambahMonitoring);
            Controls.Add(labelNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahMonitoring";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahMonitoring";
            ((System.ComponentModel.ISupportInitialize)NUDBerat).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUDMati).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBatalTambahMonitoring;
        private FontAwesome.Sharp.IconButton btnSaveTambahMonitoring;
        private Label labelNama;
        private Label lblTambahAkun;
        private ComboBox CBKolam;
        private Label label1;
        private NumericUpDown NUDBerat;
        private Label label2;
        private ComboBox CBKondisi;
        private NumericUpDown NUDMati;
        private Label label3;
        private TextBox TBCatatan;
        private Label label4;
    }
}