namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_PemberianPakan
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
            DGVRiwayatTambahAkun = new DataGridView();
            panel3 = new Panel();
            label6 = new Label();
            panel4 = new Panel();
            labelTotalPemberianPakanBulan = new Label();
            label5 = new Label();
            panel5 = new Panel();
            labelTotalPemberianPakanAkumulasi = new Label();
            label8 = new Label();
            buttonPemberianPakan = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // DGVRiwayatTambahAkun
            // 
            DGVRiwayatTambahAkun.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatTambahAkun.Location = new Point(30, 236);
            DGVRiwayatTambahAkun.Name = "DGVRiwayatTambahAkun";
            DGVRiwayatTambahAkun.RowHeadersWidth = 62;
            DGVRiwayatTambahAkun.Size = new Size(740, 340);
            DGVRiwayatTambahAkun.TabIndex = 28;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(30, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(280, 55);
            panel3.TabIndex = 31;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 9);
            label6.Name = "label6";
            label6.Size = new Size(281, 32);
            label6.TabIndex = 3;
            label6.Text = "Total Pemberian Pakan";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.CornflowerBlue;
            panel4.Controls.Add(labelTotalPemberianPakanBulan);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(176, 94);
            panel4.Name = "panel4";
            panel4.Size = new Size(135, 120);
            panel4.TabIndex = 34;
            // 
            // labelTotalPemberianPakanBulan
            // 
            labelTotalPemberianPakanBulan.BackColor = Color.Transparent;
            labelTotalPemberianPakanBulan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPemberianPakanBulan.ForeColor = Color.White;
            labelTotalPemberianPakanBulan.Location = new Point(0, 61);
            labelTotalPemberianPakanBulan.Name = "labelTotalPemberianPakanBulan";
            labelTotalPemberianPakanBulan.Size = new Size(135, 32);
            labelTotalPemberianPakanBulan.TabIndex = 5;
            labelTotalPemberianPakanBulan.Text = "0";
            labelTotalPemberianPakanBulan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 9);
            label5.Name = "label5";
            label5.Size = new Size(135, 32);
            label5.TabIndex = 3;
            label5.Text = "1 Bulan";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.CornflowerBlue;
            panel5.Controls.Add(labelTotalPemberianPakanAkumulasi);
            panel5.Controls.Add(label8);
            panel5.Location = new Point(30, 94);
            panel5.Name = "panel5";
            panel5.Size = new Size(135, 120);
            panel5.TabIndex = 35;
            // 
            // labelTotalPemberianPakanAkumulasi
            // 
            labelTotalPemberianPakanAkumulasi.BackColor = Color.Transparent;
            labelTotalPemberianPakanAkumulasi.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPemberianPakanAkumulasi.ForeColor = Color.White;
            labelTotalPemberianPakanAkumulasi.Location = new Point(0, 61);
            labelTotalPemberianPakanAkumulasi.Name = "labelTotalPemberianPakanAkumulasi";
            labelTotalPemberianPakanAkumulasi.Size = new Size(135, 32);
            labelTotalPemberianPakanAkumulasi.TabIndex = 5;
            labelTotalPemberianPakanAkumulasi.Text = "0";
            labelTotalPemberianPakanAkumulasi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 9);
            label8.Name = "label8";
            label8.Size = new Size(135, 32);
            label8.TabIndex = 3;
            label8.Text = "Akumulasi";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonPemberianPakan
            // 
            buttonPemberianPakan.BackColor = Color.CornflowerBlue;
            buttonPemberianPakan.FlatAppearance.BorderSize = 0;
            buttonPemberianPakan.FlatStyle = FlatStyle.Flat;
            buttonPemberianPakan.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPemberianPakan.ForeColor = Color.White;
            buttonPemberianPakan.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            buttonPemberianPakan.IconColor = Color.White;
            buttonPemberianPakan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonPemberianPakan.IconSize = 100;
            buttonPemberianPakan.Location = new Point(720, 164);
            buttonPemberianPakan.Margin = new Padding(0);
            buttonPemberianPakan.MaximumSize = new Size(100, 100);
            buttonPemberianPakan.Name = "buttonPemberianPakan";
            buttonPemberianPakan.Size = new Size(50, 50);
            buttonPemberianPakan.TabIndex = 45;
            buttonPemberianPakan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonPemberianPakan.UseVisualStyleBackColor = false;
            // 
            // UC_PemberianPakan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(buttonPemberianPakan);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(DGVRiwayatTambahAkun);
            Controls.Add(panel3);
            Name = "UC_PemberianPakan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatTambahAkun).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVRiwayatTambahAkun;
        private Panel panel3;
        private Label label6;
        private Panel panel4;
        private Label labelTotalPemberianPakanBulan;
        private Label label5;
        private Panel panel5;
        private Label labelTotalPemberianPakanAkumulasi;
        private Label label8;
        private FontAwesome.Sharp.IconButton buttonPemberianPakan;
    }
}
