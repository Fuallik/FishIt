namespace FishIt.Views.Admin
{
    partial class FormHapusKolam
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
            btnSave = new FontAwesome.Sharp.IconButton();
            labelNama = new Label();
            lblTambahAkun = new Label();
            CBIdKolam = new ComboBox();
            btnBatal = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
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
            btnSave.Location = new Point(281, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(169, 50);
            btnSave.TabIndex = 53;
            btnSave.Text = "Simpan";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(74, 124);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(114, 32);
            labelNama.TabIndex = 47;
            labelNama.Text = "ID Kolam";
            // 
            // lblTambahAkun
            // 
            lblTambahAkun.AutoSize = true;
            lblTambahAkun.BackColor = Color.Transparent;
            lblTambahAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTambahAkun.ImageAlign = ContentAlignment.TopCenter;
            lblTambahAkun.Location = new Point(101, 43);
            lblTambahAkun.Name = "lblTambahAkun";
            lblTambahAkun.Size = new Size(274, 54);
            lblTambahAkun.TabIndex = 45;
            lblTambahAkun.Text = "Hapus Kolam";
            lblTambahAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CBIdKolam
            // 
            CBIdKolam.FormattingEnabled = true;
            CBIdKolam.Location = new Point(74, 159);
            CBIdKolam.Name = "CBIdKolam";
            CBIdKolam.Size = new Size(325, 33);
            CBIdKolam.TabIndex = 55;
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
            btnBatal.Location = new Point(21, 250);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(169, 50);
            btnBatal.TabIndex = 54;
            btnBatal.Text = "Kembali";
            btnBatal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // FormHapusKolam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 355);
            Controls.Add(CBIdKolam);
            Controls.Add(btnBatal);
            Controls.Add(btnSave);
            Controls.Add(labelNama);
            Controls.Add(lblTambahAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHapusKolam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormHapusKolam";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CBJenisIkan;
        private FontAwesome.Sharp.IconButton btnBatalTambahAkun;
        private FontAwesome.Sharp.IconButton btnSave;
        private Label label4;
        private Label label2;
        private TextBox TBKapasitas;
        private Label label3;
        private TextBox TBUkuran;
        private Label labelNama;
        private TextBox TBNama;
        private Label lblTambahAkun;
        private ComboBox CBIdKolam;
        private FontAwesome.Sharp.IconButton btnBatal;
    }
}