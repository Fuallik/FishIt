namespace FishIt
{
    partial class UC_KelolaAkun
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
            panelUtama = new Panel();
            panel1 = new Panel();
            label2 = new Label();
            panelJumlahAkun = new Panel();
            lblHitungAkun = new Label();
            labelJumlahAkun = new Label();
            panelUtama.SuspendLayout();
            panelJumlahAkun.SuspendLayout();
            SuspendLayout();
            // 
            // panelUtama
            // 
            panelUtama.BackColor = Color.Gainsboro;
            panelUtama.Controls.Add(panel1);
            panelUtama.Controls.Add(label2);
            panelUtama.Controls.Add(panelJumlahAkun);
            panelUtama.Dock = DockStyle.Fill;
            panelUtama.Location = new Point(0, 0);
            panelUtama.Margin = new Padding(0);
            panelUtama.Name = "panelUtama";
            panelUtama.Padding = new Padding(20);
            panelUtama.Size = new Size(800, 600);
            panelUtama.TabIndex = 1;
            panelUtama.Paint += panelUtama_Paint;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Location = new Point(210, 80);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 180);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 20);
            label2.Name = "label2";
            label2.Size = new Size(145, 32);
            label2.TabIndex = 2;
            label2.Text = "Kelola Akun";
            // 
            // panelJumlahAkun
            // 
            panelJumlahAkun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelJumlahAkun.BackColor = Color.WhiteSmoke;
            panelJumlahAkun.Controls.Add(lblHitungAkun);
            panelJumlahAkun.Controls.Add(labelJumlahAkun);
            panelJumlahAkun.Location = new Point(20, 80);
            panelJumlahAkun.Name = "panelJumlahAkun";
            panelJumlahAkun.Size = new Size(175, 180);
            panelJumlahAkun.TabIndex = 0;
            // 
            // lblHitungAkun
            // 
            lblHitungAkun.AutoSize = true;
            lblHitungAkun.Location = new Point(40, 135);
            lblHitungAkun.Name = "lblHitungAkun";
            lblHitungAkun.Size = new Size(22, 25);
            lblHitungAkun.TabIndex = 5;
            lblHitungAkun.Text = "0";
            // 
            // labelJumlahAkun
            // 
            labelJumlahAkun.AutoSize = true;
            labelJumlahAkun.Location = new Point(40, 13);
            labelJumlahAkun.Name = "labelJumlahAkun";
            labelJumlahAkun.Size = new Size(95, 25);
            labelJumlahAkun.TabIndex = 4;
            labelJumlahAkun.Text = "Total Akun";
            // 
            // UC_KelolaAkun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(panelUtama);
            Name = "UC_KelolaAkun";
            Size = new Size(800, 600);
            Load += UC_KelolaAkun_Load;
            panelUtama.ResumeLayout(false);
            panelUtama.PerformLayout();
            panelJumlahAkun.ResumeLayout(false);
            panelJumlahAkun.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelUtama;
        private Panel panelJumlahAkun;
        private Panel panel1;
        private Label label2;
        private Label labelJumlahAkun;
        private Label lblHitungAkun;
    }
}
