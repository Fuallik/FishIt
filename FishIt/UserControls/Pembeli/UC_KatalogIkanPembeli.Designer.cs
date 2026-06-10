namespace FishIt
{
    partial class UC_KatalogIkanPembeli
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
            DGVKatalogIkan = new DataGridView();
            colTambah = new DataGridViewButtonColumn();
            numericJumlah = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)DGVKatalogIkan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericJumlah).BeginInit();
            SuspendLayout();
            // 
            // DGVKatalogIkan
            // 
            DGVKatalogIkan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVKatalogIkan.Columns.AddRange(new DataGridViewColumn[] { colTambah });
            DGVKatalogIkan.Location = new Point(3, 54);
            DGVKatalogIkan.Name = "DGVKatalogIkan";
            DGVKatalogIkan.RowHeadersWidth = 62;
            DGVKatalogIkan.Size = new Size(794, 541);
            DGVKatalogIkan.TabIndex = 0;
            DGVKatalogIkan.CellContentClick += dgvStokIkan_CellContentClick;
            // 
            // colTambah
            // 
            colTambah.HeaderText = "Tambahkan";
            colTambah.MinimumWidth = 8;
            colTambah.Name = "colTambah";
            colTambah.Text = "+ Keranjang";
            colTambah.UseColumnTextForButtonValue = true;
            colTambah.Width = 150;
            // 
            // numericJumlah
            // 
            numericJumlah.Location = new Point(599, 12);
            numericJumlah.Name = "numericJumlah";
            numericJumlah.Size = new Size(180, 31);
            numericJumlah.TabIndex = 1;
            // 
            // UC_KatalogIkanPembeli
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(numericJumlah);
            Controls.Add(DGVKatalogIkan);
            Name = "UC_KatalogIkanPembeli";
            Size = new Size(800, 600);
            Load += UC_KatalogIkanPembeli_Load;
            ((System.ComponentModel.ISupportInitialize)DGVKatalogIkan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericJumlah).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVKatalogIkan;
        private DataGridViewButtonColumn colTambah;
        private NumericUpDown numericJumlah;
    }
}
