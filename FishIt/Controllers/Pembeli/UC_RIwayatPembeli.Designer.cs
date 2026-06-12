namespace FishIt
{
    partial class UC_RIwayatPembeli
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
            DGVRiwayatPembeli = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatPembeli).BeginInit();
            SuspendLayout();
            // 
            // DGVRiwayatPembeli
            // 
            DGVRiwayatPembeli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRiwayatPembeli.Location = new Point(3, 38);
            DGVRiwayatPembeli.Name = "DGVRiwayatPembeli";
            DGVRiwayatPembeli.RowHeadersWidth = 62;
            DGVRiwayatPembeli.Size = new Size(794, 559);
            DGVRiwayatPembeli.TabIndex = 2;
            // 
            // UC_RIwayatPembeli
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(DGVRiwayatPembeli);
            Name = "UC_RIwayatPembeli";
            Size = new Size(800, 600);
            Load += UC_RIwayatPembeli_Load;
            ((System.ComponentModel.ISupportInitialize)DGVRiwayatPembeli).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVRiwayatPembeli;
    }
}
