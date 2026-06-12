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
            DGVPakan = new DataGridView();
            buttonPemberianPakan = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            labelTotalAkumulasiPerAkun = new Label();
            label3 = new Label();
            panel6 = new Panel();
            labelTotalPerBulanPerAkun = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVPakan).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // DGVPakan
            // 
            DGVPakan.AllowUserToAddRows = false;
            DGVPakan.AllowUserToDeleteRows = false;
            DGVPakan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPakan.Location = new Point(30, 236);
            DGVPakan.Name = "DGVPakan";
            DGVPakan.ReadOnly = true;
            DGVPakan.RowHeadersWidth = 62;
            DGVPakan.Size = new Size(740, 340);
            DGVPakan.TabIndex = 28;
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
            buttonPemberianPakan.Location = new Point(720, 161);
            buttonPemberianPakan.Margin = new Padding(0);
            buttonPemberianPakan.MaximumSize = new Size(100, 100);
            buttonPemberianPakan.Name = "buttonPemberianPakan";
            buttonPemberianPakan.Size = new Size(50, 50);
            buttonPemberianPakan.TabIndex = 45;
            buttonPemberianPakan.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonPemberianPakan.UseVisualStyleBackColor = false;
            buttonPemberianPakan.Click += buttonPemberianPakan_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(371, 55);
            panel1.TabIndex = 46;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 9);
            label1.Name = "label1";
            label1.Size = new Size(371, 32);
            label1.TabIndex = 3;
            label1.Text = "Total Pemberian Pakan Akun Anda";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(labelTotalAkumulasiPerAkun);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(30, 91);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 120);
            panel2.TabIndex = 48;
            // 
            // labelTotalAkumulasiPerAkun
            // 
            labelTotalAkumulasiPerAkun.BackColor = Color.Transparent;
            labelTotalAkumulasiPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalAkumulasiPerAkun.ForeColor = Color.White;
            labelTotalAkumulasiPerAkun.Location = new Point(0, 61);
            labelTotalAkumulasiPerAkun.Name = "labelTotalAkumulasiPerAkun";
            labelTotalAkumulasiPerAkun.Size = new Size(177, 32);
            labelTotalAkumulasiPerAkun.TabIndex = 5;
            labelTotalAkumulasiPerAkun.Text = "0";
            labelTotalAkumulasiPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 9);
            label3.Name = "label3";
            label3.Size = new Size(180, 32);
            label3.TabIndex = 3;
            label3.Text = "Akumulasi";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BackColor = Color.CornflowerBlue;
            panel6.Controls.Add(labelTotalPerBulanPerAkun);
            panel6.Controls.Add(label7);
            panel6.Location = new Point(221, 91);
            panel6.Name = "panel6";
            panel6.Size = new Size(180, 120);
            panel6.TabIndex = 47;
            // 
            // labelTotalPerBulanPerAkun
            // 
            labelTotalPerBulanPerAkun.BackColor = Color.Transparent;
            labelTotalPerBulanPerAkun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalPerBulanPerAkun.ForeColor = Color.White;
            labelTotalPerBulanPerAkun.Location = new Point(0, 61);
            labelTotalPerBulanPerAkun.Name = "labelTotalPerBulanPerAkun";
            labelTotalPerBulanPerAkun.Size = new Size(180, 32);
            labelTotalPerBulanPerAkun.TabIndex = 5;
            labelTotalPerBulanPerAkun.Text = "0";
            labelTotalPerBulanPerAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(0, 9);
            label7.Name = "label7";
            label7.Size = new Size(180, 32);
            label7.TabIndex = 3;
            label7.Text = "1 Bulan";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_PemberianPakan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(panel2);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Controls.Add(buttonPemberianPakan);
            Controls.Add(DGVPakan);
            Name = "UC_PemberianPakan";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVPakan).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DGVPakan;
        private FontAwesome.Sharp.IconButton buttonPemberianPakan;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label labelTotalAkumulasiPerAkun;
        private Label label3;
        private Panel panel6;
        private Label labelTotalPerBulanPerAkun;
        private Label label7;
    }
}
