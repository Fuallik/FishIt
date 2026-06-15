namespace FishIt
{
    partial class FormDetailPakan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGVPakan = new DataGridView();
            btnKembali = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVPakan).BeginInit();
            SuspendLayout();
            // 
            // DGVPakan
            // 
            DGVPakan.AllowUserToAddRows = false;
            DGVPakan.AllowUserToDeleteRows = false;
            DGVPakan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPakan.Location = new Point(3, 3);
            DGVPakan.Name = "DGVPakan";
            DGVPakan.ReadOnly = true;
            DGVPakan.RowHeadersWidth = 62;
            DGVPakan.Size = new Size(795, 528);
            DGVPakan.TabIndex = 2;
            // 
            // btnKembali
            // 
            btnKembali.BackColor = Color.CornflowerBlue;
            btnKembali.FlatAppearance.BorderSize = 0;
            btnKembali.FlatStyle = FlatStyle.Flat;
            btnKembali.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnKembali.ForeColor = Color.White;
            btnKembali.IconChar = FontAwesome.Sharp.IconChar.None;
            btnKembali.IconColor = Color.Black;
            btnKembali.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnKembali.Location = new Point(306, 540);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(175, 50);
            btnKembali.TabIndex = 3;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormDetailPakan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 600);
            Controls.Add(btnKembali);
            Controls.Add(DGVPakan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetailPakan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDetailPakan";
            ((System.ComponentModel.ISupportInitialize)DGVPakan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVPakan;
        private FontAwesome.Sharp.IconButton btnKembali;
    }
}