namespace FishIt
{
    partial class FormDetailBenih
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
            DGVBenih = new DataGridView();
            btnKembali = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)DGVBenih).BeginInit();
            SuspendLayout();
            // 
            // DGVBenih
            // 
            DGVBenih.AllowUserToAddRows = false;
            DGVBenih.AllowUserToDeleteRows = false;
            DGVBenih.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBenih.Location = new Point(2, 3);
            DGVBenih.Name = "DGVBenih";
            DGVBenih.ReadOnly = true;
            DGVBenih.RowHeadersWidth = 62;
            DGVBenih.Size = new Size(795, 528);
            DGVBenih.TabIndex = 1;
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
            btnKembali.Location = new Point(295, 540);
            btnKembali.Name = "btnKembali";
            btnKembali.Size = new Size(175, 50);
            btnKembali.TabIndex = 2;
            btnKembali.Text = "Kembali";
            btnKembali.UseVisualStyleBackColor = false;
            btnKembali.Click += btnKembali_Click;
            // 
            // FormDetailBenih
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 600);
            Controls.Add(btnKembali);
            Controls.Add(DGVBenih);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetailBenih";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDetailBenih";
            Load += FormDetailBenih_Load;
            ((System.ComponentModel.ISupportInitialize)DGVBenih).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGVBenih;
        private FontAwesome.Sharp.IconButton btnKembali;
    }
}