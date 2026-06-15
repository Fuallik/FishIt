namespace FishIt
{
    partial class FormDetailIkan
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
            DGVIkan = new DataGridView();
            btnKembali = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVIkan).BeginInit();
            SuspendLayout();
            // 
            // DGVIkan
            // 
            DGVIkan.AllowUserToAddRows = false;
            DGVIkan.AllowUserToDeleteRows = false;
            DGVIkan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVIkan.Location = new Point(2, 2);
            DGVIkan.Name = "DGVIkan";
            DGVIkan.ReadOnly = true;
            DGVIkan.RowHeadersWidth = 62;
            DGVIkan.Size = new Size(795, 528);
            DGVIkan.TabIndex = 0;
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
            btnKembali.Location = new Point(302, 538);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(175, 50);
            btnKembali.TabIndex = 1;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormDetailIkan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 600);
            Controls.Add(btnKembali);
            Controls.Add(DGVIkan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetailIkan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDetailIkan";
            ((System.ComponentModel.ISupportInitialize)DGVIkan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVIkan;
        private FontAwesome.Sharp.IconButton btnKembali;
    }
}