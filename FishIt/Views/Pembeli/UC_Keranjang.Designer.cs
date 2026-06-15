namespace FishIt
{
    partial class UC_Keranjang
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
            DGVKeranjang = new DataGridView();
            btnCheckout = new FontAwesome.Sharp.IconButton();
            CBMetodePembayaran = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DGVKeranjang).BeginInit();
            SuspendLayout();
            // 
            // DGVKeranjang
            // 
            DGVKeranjang.AllowUserToAddRows = false;
            DGVKeranjang.AllowUserToDeleteRows = false;
            DGVKeranjang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVKeranjang.Location = new Point(3, 54);
            DGVKeranjang.Name = "DGVKeranjang";
            DGVKeranjang.ReadOnly = true;
            DGVKeranjang.RowHeadersWidth = 62;
            DGVKeranjang.Size = new Size(794, 541);
            DGVKeranjang.TabIndex = 1;
            DGVKeranjang.CellClick += DGVKeranjang_CellClick;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.CornflowerBlue;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.IconChar = FontAwesome.Sharp.IconChar.Check;
            btnCheckout.IconColor = Color.White;
            btnCheckout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCheckout.Location = new Point(609, 4);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(180, 45);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Checkout";
            btnCheckout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // CBMetodePembayaran
            // 
            CBMetodePembayaran.FormattingEnabled = true;
            CBMetodePembayaran.Location = new Point(408, 12);
            CBMetodePembayaran.Name = "CBMetodePembayaran";
            CBMetodePembayaran.Size = new Size(182, 33);
            CBMetodePembayaran.TabIndex = 3;
            // 
            // UC_Keranjang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(CBMetodePembayaran);
            Controls.Add(btnCheckout);
            Controls.Add(DGVKeranjang);
            Name = "UC_Keranjang";
            Size = new Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)DGVKeranjang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVKeranjang;
        private FontAwesome.Sharp.IconButton btnCheckout;
        private ComboBox CBMetodePembayaran;
    }
}
