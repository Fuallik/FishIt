namespace FishIt.Views.Admin
{
    partial class FormTambahKolam
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
            btnBatal = new FontAwesome.Sharp.IconButton();
            btnSave = new FontAwesome.Sharp.IconButton();
            label4 = new Label();
            label2 = new Label();
            TBKapasitas = new TextBox();
            label3 = new Label();
            TBPanjang = new TextBox();
            labelNama = new Label();
            TBNama = new TextBox();
            lblTambahAkun = new Label();
            CBJenisIkan = new ComboBox();
            label1 = new Label();
            label5 = new Label();
            TBLebar = new TextBox();
            label6 = new Label();
            TBTinggi = new TextBox();
            SuspendLayout();
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
            btnBatal.Location = new Point(25, 450);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(169, 50);
            btnBatal.TabIndex = 43;
            btnBatal.Text = "Kembali";
            btnBatal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnSave.IconColor = Color.White;
            btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSave.IconSize = 35;
            btnSave.Location = new Point(285, 450);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(169, 50);
            btnSave.TabIndex = 42;
            btnSave.Text = "Simpan";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(78, 313);
            label4.Name = "label4";
            label4.Size = new Size(121, 32);
            label4.TabIndex = 33;
            label4.Text = "Jenis Ikan";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(78, 244);
            label2.Name = "label2";
            label2.Size = new Size(117, 32);
            label2.TabIndex = 31;
            label2.Text = "Kapasitas";
            // 
            // TBKapasitas
            // 
            TBKapasitas.BackColor = Color.White;
            TBKapasitas.BorderStyle = BorderStyle.None;
            TBKapasitas.Location = new Point(78, 279);
            TBKapasitas.Name = "TBKapasitas";
            TBKapasitas.Size = new Size(335, 24);
            TBKapasitas.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(78, 175);
            label3.Name = "label3";
            label3.Size = new Size(94, 32);
            label3.TabIndex = 29;
            label3.Text = "Ukuran";
            // 
            // TBPanjang
            // 
            TBPanjang.BackColor = Color.White;
            TBPanjang.BorderStyle = BorderStyle.None;
            TBPanjang.Location = new Point(156, 209);
            TBPanjang.Name = "TBPanjang";
            TBPanjang.Size = new Size(38, 24);
            TBPanjang.TabIndex = 28;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(78, 106);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(79, 32);
            labelNama.TabIndex = 27;
            labelNama.Text = "Nama";
            // 
            // TBNama
            // 
            TBNama.BorderStyle = BorderStyle.None;
            TBNama.Location = new Point(78, 141);
            TBNama.Name = "TBNama";
            TBNama.Size = new Size(335, 24);
            TBNama.TabIndex = 26;
            // 
            // lblTambahAkun
            // 
            lblTambahAkun.AutoSize = true;
            lblTambahAkun.BackColor = Color.Transparent;
            lblTambahAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahAkun.ImageAlign = ContentAlignment.TopCenter;
            lblTambahAkun.Location = new Point(106, 26);
            lblTambahAkun.Name = "lblTambahAkun";
            lblTambahAkun.Size = new Size(304, 54);
            lblTambahAkun.TabIndex = 25;
            lblTambahAkun.Text = "Tambah Kolam";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CBJenisIkan
            // 
            CBJenisIkan.FormattingEnabled = true;
            CBJenisIkan.Location = new Point(78, 348);
            CBJenisIkan.Name = "CBJenisIkan";
            CBJenisIkan.Size = new Size(335, 33);
            CBJenisIkan.TabIndex = 44;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            label1.Location = new Point(78, 212);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 45;
            label1.Text = "Panjang :";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            label5.Location = new Point(200, 212);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 47;
            label5.Text = "Lebar :";
            // 
            // TBLebar
            // 
            TBLebar.BackColor = Color.White;
            TBLebar.BorderStyle = BorderStyle.None;
            TBLebar.Location = new Point(267, 208);
            TBLebar.Name = "TBLebar";
            TBLebar.Size = new Size(47, 24);
            TBLebar.TabIndex = 46;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);
            label6.Location = new Point(320, 211);
            label6.Name = "label6";
            label6.Size = new Size(68, 20);
            label6.TabIndex = 49;
            label6.Text = "Tinggi :";
            // 
            // TBTinggi
            // 
            TBTinggi.BackColor = Color.White;
            TBTinggi.BorderStyle = BorderStyle.None;
            TBTinggi.Location = new Point(394, 210);
            TBTinggi.Name = "TBTinggi";
            TBTinggi.Size = new Size(53, 24);
            TBTinggi.TabIndex = 48;
            // 
            // FormTambahKolam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 542);
            Controls.Add(label6);
            Controls.Add(TBTinggi);
            Controls.Add(label5);
            Controls.Add(TBLebar);
            Controls.Add(label1);
            Controls.Add(CBJenisIkan);
            Controls.Add(btnBatal);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(TBKapasitas);
            Controls.Add(label3);
            Controls.Add(TBPanjang);
            Controls.Add(labelNama);
            Controls.Add(TBNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahKolam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahKolam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton btnBatal;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label4;
        private Label label2;
        private TextBox TBKapasitas;
        private Label label3;
        private TextBox TBPanjang;
        private Label labelNama;
        private TextBox TBNama;
        private Label lblTambahAkun;
        private ComboBox CBJenisIkan;
        private Label label1;
        private Label label5;
        private TextBox TBLebar;
        private Label label6;
        private TextBox TBTinggi;
    }
}