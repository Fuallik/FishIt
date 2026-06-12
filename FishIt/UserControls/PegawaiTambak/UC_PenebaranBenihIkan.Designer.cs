namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_PenebaranBenihIkan
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
            DGVPenebaran = new DataGridView();
            buttonTambah = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            labelTotalPerBulanPerAkun = new Label();
            label4 = new Label();
            panel6 = new Panel();
            labelTotalAkumulasiPerAkun = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVPenebaran).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // DGVPenebaran
            // 
            DGVPenebaran.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPenebaran.Location = new Point(30, 236);
            DGVPenebaran.Name = "DGVPenebaran";
            DGVPenebaran.RowHeadersWidth = 62;
            DGVPenebaran.Size = new Size(740, 340);
            DGVPenebaran.TabIndex = 33;
            // 
            // buttonTambah
            // 
            buttonTambah.BackColor = Color.CornflowerBlue;
            buttonTambah.FlatAppearance.BorderSize = 0;
            buttonTambah.FlatStyle = FlatStyle.Flat;
            buttonTambah.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonTambah.ForeColor = Color.White;
            buttonTambah.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            buttonTambah.IconColor = Color.White;
            buttonTambah.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonTambah.IconSize = 100;
            buttonTambah.Location = new Point(720, 167);
            buttonTambah.Margin = new Padding(0);
            buttonTambah.MaximumSize = new Size(100, 100);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(50, 50);
            buttonTambah.TabIndex = 45;
            buttonTambah.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambah.UseVisualStyleBackColor = false;
            buttonTambah.Click += buttonTambah_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 85);
            panel1.TabIndex = 46;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(330, 85);
            label1.TabIndex = 3;
            label1.Text = "Total Penebaran Benih Ikan Akun Anda";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = Color.CornflowerBlue;
            panel5.Controls.Add(labelTotalPerBulanPerAkun);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(205, 106);
            panel5.Name = "panel5";
            panel5.Size = new Size(155, 110);
            panel5.TabIndex = 47;
            // 
            // labelTotalPerBulanPerAkun
            // 
            labelTotalPerBulanPerAkun.BackColor = Color.Transparent;
            labelTotalPerBulanPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPerBulanPerAkun.ForeColor = Color.White;
            labelTotalPerBulanPerAkun.Location = new Point(0, 61);
            labelTotalPerBulanPerAkun.Name = "labelTotalPerBulanPerAkun";
            labelTotalPerBulanPerAkun.Size = new Size(155, 32);
            labelTotalPerBulanPerAkun.TabIndex = 5;
            labelTotalPerBulanPerAkun.Text = "0";
            labelTotalPerBulanPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 14);
            label4.Name = "label4";
            label4.Size = new Size(155, 32);
            label4.TabIndex = 3;
            label4.Text = "1 Bulan";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.CornflowerBlue;
            panel6.Controls.Add(labelTotalAkumulasiPerAkun);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(30, 106);
            panel6.Name = "panel6";
            panel6.Size = new Size(155, 110);
            panel6.TabIndex = 48;
            // 
            // labelTotalAkumulasiPerAkun
            // 
            labelTotalAkumulasiPerAkun.BackColor = Color.Transparent;
            labelTotalAkumulasiPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalAkumulasiPerAkun.ForeColor = Color.White;
            labelTotalAkumulasiPerAkun.Location = new Point(0, 61);
            labelTotalAkumulasiPerAkun.Name = "labelTotalAkumulasiPerAkun";
            labelTotalAkumulasiPerAkun.Size = new Size(155, 32);
            labelTotalAkumulasiPerAkun.TabIndex = 5;
            labelTotalAkumulasiPerAkun.Text = "0";
            labelTotalAkumulasiPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 14);
            label8.Name = "label8";
            label8.Size = new Size(155, 32);
            label8.TabIndex = 3;
            label8.Text = "Akumulasi";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_PenebaranBenihIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(buttonTambah);
            Controls.Add(DGVPenebaran);
            Name = "UC_PenebaranBenihIkan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVPenebaran).EndInit();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVPenebaran;
        private FontAwesome.Sharp.IconButton buttonTambah;
        private Panel panel1;
        private Label label1;
        private Panel panel5;
        private Label labelTotalPerBulanPerAkun;
        private Label label4;
        private Panel panel6;
        private Label labelTotalAkumulasiPerAkun;
        private Label label8;
    }
}
