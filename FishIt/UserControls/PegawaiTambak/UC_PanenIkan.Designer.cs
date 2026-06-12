namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_PanenIkan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGVPanen = new DataGridView();
            buttonTambahPanen = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            labelAkumulasiPerAkun = new Label();
            label4 = new Label();
            panel4 = new Panel();
            labelPerTahunPerAkun = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVPanen).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // DGVPanen
            // 
            DGVPanen.AllowUserToAddRows = false;
            DGVPanen.AllowUserToDeleteRows = false;
            DGVPanen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPanen.Location = new Point(30, 236);
            DGVPanen.Name = "DGVPanen";
            DGVPanen.ReadOnly = true;
            DGVPanen.RowHeadersWidth = 62;
            DGVPanen.Size = new Size(740, 340);
            DGVPanen.TabIndex = 23;
            // 
            // buttonTambahPanen
            // 
            buttonTambahPanen.BackColor = Color.CornflowerBlue;
            buttonTambahPanen.FlatAppearance.BorderSize = 0;
            buttonTambahPanen.FlatStyle = FlatStyle.Flat;
            buttonTambahPanen.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambahPanen.ForeColor = Color.White;
            buttonTambahPanen.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            buttonTambahPanen.IconColor = Color.White;
            buttonTambahPanen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTambahPanen.IconSize = 100;
            buttonTambahPanen.Location = new Point(720, 151);
            buttonTambahPanen.Margin = new Padding(0);
            buttonTambahPanen.MaximumSize = new Size(100, 100);
            buttonTambahPanen.Name = "buttonTambahPanen";
            buttonTambahPanen.Size = new Size(50, 50);
            buttonTambahPanen.TabIndex = 45;
            buttonTambahPanen.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambahPanen.UseVisualStyleBackColor = false;
            buttonTambahPanen.Click += buttonTambahPanen_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(30, 19);
            panel2.Name = "panel2";
            panel2.Size = new Size(319, 55);
            panel2.TabIndex = 46;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 9);
            label2.Name = "label2";
            label2.Size = new Size(316, 32);
            label2.TabIndex = 3;
            label2.Text = "Total Panen Akun Anda";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(labelAkumulasiPerAkun);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(30, 90);
            panel3.Name = "panel3";
            panel3.Size = new Size(150, 110);
            panel3.TabIndex = 47;
            // 
            // labelAkumulasiPerAkun
            // 
            labelAkumulasiPerAkun.BackColor = Color.Transparent;
            labelAkumulasiPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAkumulasiPerAkun.ForeColor = Color.White;
            labelAkumulasiPerAkun.Location = new Point(0, 61);
            labelAkumulasiPerAkun.Name = "labelAkumulasiPerAkun";
            labelAkumulasiPerAkun.Size = new Size(150, 32);
            labelAkumulasiPerAkun.TabIndex = 5;
            labelAkumulasiPerAkun.Text = "0";
            labelAkumulasiPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 9);
            label4.Name = "label4";
            label4.Size = new Size(150, 32);
            label4.TabIndex = 3;
            label4.Text = "Akumulasi";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.CornflowerBlue;
            panel4.Controls.Add(labelPerTahunPerAkun);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(199, 90);
            panel4.Name = "panel4";
            panel4.Size = new Size(150, 110);
            panel4.TabIndex = 48;
            // 
            // labelPerTahunPerAkun
            // 
            labelPerTahunPerAkun.BackColor = Color.Transparent;
            labelPerTahunPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPerTahunPerAkun.ForeColor = Color.White;
            labelPerTahunPerAkun.Location = new Point(0, 61);
            labelPerTahunPerAkun.Name = "labelPerTahunPerAkun";
            labelPerTahunPerAkun.Size = new Size(150, 32);
            labelPerTahunPerAkun.TabIndex = 5;
            labelPerTahunPerAkun.Text = "0";
            labelPerTahunPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 9);
            label6.Name = "label6";
            label6.Size = new Size(150, 32);
            label6.TabIndex = 3;
            label6.Text = "1 Tahun";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_PanenIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(buttonTambahPanen);
            Controls.Add(DGVPanen);
            Name = "UC_PanenIkan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVPanen).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVPanen;
        private Label labelBeratPanen;
        private FontAwesome.Sharp.IconButton buttonTambahPanen;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label labelAkumulasiPerAkun;
        private Label label4;
        private Panel panel4;
        private Label labelPerTahunPerAkun;
        private Label label6;
    }
}
