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
            panel1 = new Panel();
            label1 = new Label();
            DGVRiwayatTambahAkun = new DataGridView();
            panel5 = new Panel();
            labelTotalPanenAkumulasi = new Label();
            label8 = new Label();
            buttonTambahPanen = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(32, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 55);
            panel1.TabIndex = 24;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 32);
            label1.TabIndex = 3;
            label1.Text = "Total Panen";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGVRiwayatTambahAkun
            // 
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(30, 236);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(740, 340);
            DGVRiwayatTambahAkun.TabIndex = 23;
            // 
            // panel5
            // 
            panel5.BackColor = Color.CornflowerBlue;
            panel5.Controls.Add(labelTotalPanenAkumulasi);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(32, 98);
            panel5.Name = "panel5";
            panel5.Size = new Size(221, 110);
            panel5.TabIndex = 36;
            // 
            // labelTotalPanenAkumulasi
            // 
            labelTotalPanenAkumulasi.BackColor = Color.Transparent;
            labelTotalPanenAkumulasi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPanenAkumulasi.ForeColor = Color.White;
            labelTotalPanenAkumulasi.Location = new Point(0, 61);
            labelTotalPanenAkumulasi.Name = "labelTotalPanenAkumulasi";
            labelTotalPanenAkumulasi.Size = new Size(221, 32);
            labelTotalPanenAkumulasi.TabIndex = 5;
            labelTotalPanenAkumulasi.Text = "0";
            labelTotalPanenAkumulasi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 9);
            label8.Name = "label8";
            label8.Size = new Size(221, 32);
            label8.TabIndex = 3;
            label8.Text = "Akumulasi";
            label8.TextAlign = ContentAlignment.MiddleCenter;
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
            buttonTambahPanen.Location = new Point(720, 158);
            buttonTambahPanen.Margin = new Padding(0);
            buttonTambahPanen.MaximumSize = new Size(100, 100);
            buttonTambahPanen.Name = "buttonTambahPanen";
            buttonTambahPanen.Size = new Size(50, 50);
            buttonTambahPanen.TabIndex = 45;
            buttonTambahPanen.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambahPanen.UseVisualStyleBackColor = false;
            // 
            // UC_PanenIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(buttonTambahPanen);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(DGVRiwayatTambahAkun);
            Name = "UC_PanenIkan";
            Size = new Size(800, 600);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DataGridView DGVRiwayatTambahAkun;
        private Label labelBeratPanen;
        private Panel panel5;
        private Label labelTotalPanenAkumulasi;
        private Label label8;
        private FontAwesome.Sharp.IconButton buttonTambahPanen;
    }
}
