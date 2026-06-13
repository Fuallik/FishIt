namespace FishIt.Views.Admin
{
    partial class UC_HargaPanen
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
            btnSimpan = new FontAwesome.Sharp.IconButton();
            TBHarga = new TextBox();
            labelIkanTerpilih = new Label();
            ((System.ComponentModel.ISupportInitialize)DGVPanen).BeginInit();
            SuspendLayout();
            // 
            // DGVPanen
            // 
            DGVPanen.AllowUserToAddRows = false;
            DGVPanen.AllowUserToDeleteRows = false;
            DGVPanen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPanen.Location = new Point(3, 67);
            DGVPanen.Name = "DGVPanen";
            DGVPanen.ReadOnly = true;
            DGVPanen.RowHeadersWidth = 62;
            DGVPanen.Size = new Size(794, 530);
            DGVPanen.TabIndex = 0;
            // 
            // btnSimpan
            // 
            btnSimpan.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSimpan.IconColor = Color.Black;
            btnSimpan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSimpan.Location = new Point(660, 13);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(120, 40);
            btnSimpan.TabIndex = 1;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // TBHarga
            // 
            TBHarga.Location = new Point(467, 18);
            TBHarga.Name = "TBHarga";
            TBHarga.Size = new Size(150, 31);
            TBHarga.TabIndex = 2;
            // 
            // labelIkanTerpilih
            // 
            labelIkanTerpilih.AutoSize = true;
            labelIkanTerpilih.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIkanTerpilih.ForeColor = Color.White;
            labelIkanTerpilih.Location = new Point(276, 15);
            labelIkanTerpilih.Name = "labelIkanTerpilih";
            labelIkanTerpilih.Size = new Size(153, 32);
            labelIkanTerpilih.TabIndex = 3;
            labelIkanTerpilih.Text = "Nama Panen";
            // 
            // UC_HargaPanen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(labelIkanTerpilih);
            Controls.Add(TBHarga);
            Controls.Add(btnSimpan);
            Controls.Add(DGVPanen);
            Name = "UC_HargaPanen";
            Size = new Size(800, 600);
            Load += UC_HargaPanen_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPanen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGVPanen;
        private FontAwesome.Sharp.IconButton btnSimpan;
        private TextBox TBHarga;
        private Label labelIkanTerpilih;
    }
}
