namespace FishIt.Views.Admin
{
    partial class UC_VerifikasiPanen
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
            DGVVerifikasiPanen = new DataGridView();
            panel3 = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            labelPending = new Label();
            label3 = new Label();
            buttonTambah = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVVerifikasiPanen).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // DGVVerifikasiPanen
            // 
            DGVVerifikasiPanen.AllowUserToAddRows = false;
            DGVVerifikasiPanen.AllowUserToDeleteRows = false;
            DGVVerifikasiPanen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVVerifikasiPanen.Location = new Point(30, 236);
            DGVVerifikasiPanen.Name = "DGVVerifikasiPanen";
            DGVVerifikasiPanen.ReadOnly = true;
            DGVVerifikasiPanen.RowHeadersWidth = 62;
            DGVVerifikasiPanen.Size = new Size(740, 340);
            DGVVerifikasiPanen.TabIndex = 50;
            // 
            // panel3
            // 
            panel3.BackColor = Color.CornflowerBlue;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(30, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(330, 55);
            panel3.TabIndex = 51;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 9);
            label6.Name = "label6";
            label6.Size = new Size(330, 32);
            label6.TabIndex = 3;
            label6.Text = "Verifikasi Panen";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.CornflowerBlue;
            panel2.Controls.Add(labelPending);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(30, 99);
            panel2.Name = "panel2";
            panel2.Size = new Size(155, 110);
            panel2.TabIndex = 52;
            // 
            // labelPending
            // 
            labelPending.BackColor = Color.Transparent;
            labelPending.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPending.ForeColor = Color.White;
            labelPending.Location = new Point(0, 61);
            labelPending.Name = "labelPending";
            labelPending.Size = new Size(155, 32);
            labelPending.TabIndex = 5;
            labelPending.Text = "0";
            labelPending.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 14);
            label3.Name = "label3";
            label3.Size = new Size(155, 32);
            label3.TabIndex = 3;
            label3.Text = "Pending";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            buttonTambah.Location = new Point(720, 159);
            buttonTambah.Margin = new Padding(0);
            buttonTambah.MaximumSize = new Size(100, 100);
            buttonTambah.Name = "buttonTambah";
            buttonTambah.Size = new Size(50, 50);
            buttonTambah.TabIndex = 54;
            buttonTambah.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTambah.UseVisualStyleBackColor = false;
            // 
            // UC_VerifikasiPanen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVVerifikasiPanen);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(buttonTambah);
            Name = "UC_VerifikasiPanen";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVVerifikasiPanen).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVVerifikasiPanen;
        private Panel panel3;
        private Label label6;
        private Panel panel2;
        private Label labelPending;
        private Label label3;
        private FontAwesome.Sharp.IconButton buttonTambah;
    }
}
