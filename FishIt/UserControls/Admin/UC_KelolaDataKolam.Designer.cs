namespace FishIt
{
    partial class UC_KelolaDataKolam
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
            labelKelolaDataAkun = new Label();
            SuspendLayout();
            // 
            // labelKelolaDataAkun
            // 
            labelKelolaDataAkun.AutoSize = true;
            labelKelolaDataAkun.Location = new Point(264, 125);
            labelKelolaDataAkun.Name = "labelKelolaDataAkun";
            labelKelolaDataAkun.Size = new Size(215, 25);
            labelKelolaDataAkun.TabIndex = 0;
            labelKelolaDataAkun.Text = "INI KELOLA DATA KOLAM";
            labelKelolaDataAkun.Click += label1_Click;
            // 
            // UC_KelolaDataKolam
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelKelolaDataAkun);
            Name = "UC_KelolaDataKolam";
            Size = new Size(800, 600);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelKelolaDataAkun;
    }
}
