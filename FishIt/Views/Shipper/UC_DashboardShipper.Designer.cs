namespace FishIt.UserControls.Shipper
{
    partial class UC_DashboardShipper
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelDiproses = new Panel();
            lblAngkaDiproses = new Label();
            lblLabelDiproses = new Label();
            panelDikirim = new Panel();
            lblAngkaDikirim = new Label();
            lblLabelDikirim = new Label();
            panelSelesai = new Panel();
            lblAngkaSelesai = new Label();
            lblLabelSelesai = new Label();
            lblUsername = new Label();
            lblSelamatDatang = new Label();
            panelDiproses.SuspendLayout();
            panelDikirim.SuspendLayout();
            panelSelesai.SuspendLayout();
            SuspendLayout();
            // 
            // panelDiproses
            // 
            panelDiproses.BackColor = Color.FromArgb(241, 196, 15);
            panelDiproses.Controls.Add(lblAngkaDiproses);
            panelDiproses.Controls.Add(lblLabelDiproses);
            panelDiproses.Location = new Point(22, 90);
            panelDiproses.Margin = new Padding(2);
            panelDiproses.Name = "panelDiproses";
            panelDiproses.Size = new Size(230, 130);
            panelDiproses.TabIndex = 1;
            // 
            // lblAngkaDiproses
            // 
            lblAngkaDiproses.AutoSize = true;
            lblAngkaDiproses.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAngkaDiproses.ForeColor = Color.White;
            lblAngkaDiproses.Location = new Point(20, 20);
            lblAngkaDiproses.Margin = new Padding(2, 0, 2, 0);
            lblAngkaDiproses.Name = "lblAngkaDiproses";
            lblAngkaDiproses.Size = new Size(64, 74);
            lblAngkaDiproses.TabIndex = 0;
            lblAngkaDiproses.Text = "0";
            // 
            // lblLabelDiproses
            // 
            lblLabelDiproses.AutoSize = true;
            lblLabelDiproses.Font = new Font("Segoe UI", 11F);
            lblLabelDiproses.ForeColor = Color.White;
            lblLabelDiproses.Location = new Point(15, 90);
            lblLabelDiproses.Margin = new Padding(2, 0, 2, 0);
            lblLabelDiproses.Name = "lblLabelDiproses";
            lblLabelDiproses.Size = new Size(193, 30);
            lblLabelDiproses.TabIndex = 1;
            lblLabelDiproses.Text = "Menunggu Dikirim";
            // 
            // panelDikirim
            // 
            panelDikirim.BackColor = Color.FromArgb(41, 128, 185);
            panelDikirim.Controls.Add(lblAngkaDikirim);
            panelDikirim.Controls.Add(lblLabelDikirim);
            panelDikirim.Location = new Point(285, 90);
            panelDikirim.Margin = new Padding(2);
            panelDikirim.Name = "panelDikirim";
            panelDikirim.Size = new Size(230, 130);
            panelDikirim.TabIndex = 2;
            // 
            // lblAngkaDikirim
            // 
            lblAngkaDikirim.AutoSize = true;
            lblAngkaDikirim.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAngkaDikirim.ForeColor = Color.White;
            lblAngkaDikirim.Location = new Point(20, 20);
            lblAngkaDikirim.Margin = new Padding(2, 0, 2, 0);
            lblAngkaDikirim.Name = "lblAngkaDikirim";
            lblAngkaDikirim.Size = new Size(64, 74);
            lblAngkaDikirim.TabIndex = 0;
            lblAngkaDikirim.Text = "0";
            // 
            // lblLabelDikirim
            // 
            lblLabelDikirim.AutoSize = true;
            lblLabelDikirim.Font = new Font("Segoe UI", 11F);
            lblLabelDikirim.ForeColor = Color.White;
            lblLabelDikirim.Location = new Point(20, 90);
            lblLabelDikirim.Margin = new Padding(2, 0, 2, 0);
            lblLabelDikirim.Name = "lblLabelDikirim";
            lblLabelDikirim.Size = new Size(160, 30);
            lblLabelDikirim.TabIndex = 1;
            lblLabelDikirim.Text = "Sedang Dikirim";
            // 
            // panelSelesai
            // 
            panelSelesai.BackColor = Color.FromArgb(39, 174, 96);
            panelSelesai.Controls.Add(lblAngkaSelesai);
            panelSelesai.Controls.Add(lblLabelSelesai);
            panelSelesai.Location = new Point(548, 90);
            panelSelesai.Margin = new Padding(2);
            panelSelesai.Name = "panelSelesai";
            panelSelesai.Size = new Size(230, 130);
            panelSelesai.TabIndex = 3;
            // 
            // lblAngkaSelesai
            // 
            lblAngkaSelesai.AutoSize = true;
            lblAngkaSelesai.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblAngkaSelesai.ForeColor = Color.White;
            lblAngkaSelesai.Location = new Point(20, 20);
            lblAngkaSelesai.Margin = new Padding(2, 0, 2, 0);
            lblAngkaSelesai.Name = "lblAngkaSelesai";
            lblAngkaSelesai.Size = new Size(64, 74);
            lblAngkaSelesai.TabIndex = 0;
            lblAngkaSelesai.Text = "0";
            // 
            // lblLabelSelesai
            // 
            lblLabelSelesai.AutoSize = true;
            lblLabelSelesai.Font = new Font("Segoe UI", 11F);
            lblLabelSelesai.ForeColor = Color.White;
            lblLabelSelesai.Location = new Point(20, 90);
            lblLabelSelesai.Margin = new Padding(2, 0, 2, 0);
            lblLabelSelesai.Name = "lblLabelSelesai";
            lblLabelSelesai.Size = new Size(153, 30);
            lblLabelSelesai.TabIndex = 1;
            lblLabelSelesai.Text = "Selesai Dikirim";
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.MidnightBlue;
            lblUsername.Location = new Point(274, 25);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(504, 48);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // lblSelamatDatang
            // 
            lblSelamatDatang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelamatDatang.ForeColor = Color.MidnightBlue;
            lblSelamatDatang.Location = new Point(22, 25);
            lblSelamatDatang.Name = "lblSelamatDatang";
            lblSelamatDatang.Size = new Size(261, 48);
            lblSelamatDatang.TabIndex = 5;
            lblSelamatDatang.Text = "Selamat Datang, ";
            // 
            // UC_DashboardShipper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(lblSelamatDatang);
            Controls.Add(lblUsername);
            Controls.Add(panelSelesai);
            Controls.Add(panelDikirim);
            Controls.Add(panelDiproses);
            Margin = new Padding(2);
            Name = "UC_DashboardShipper";
            Size = new Size(800, 600);
            Load += UC_DashboardShipper_Load;
            panelDiproses.ResumeLayout(false);
            panelDiproses.PerformLayout();
            panelDikirim.ResumeLayout(false);
            panelDikirim.PerformLayout();
            panelSelesai.ResumeLayout(false);
            panelSelesai.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelDiproses;
        private Label lblAngkaDiproses;
        private Label lblLabelDiproses;
        private Panel panelDikirim;
        private Label lblAngkaDikirim;
        private Label lblLabelDikirim;
        private Panel panelSelesai;
        private Label lblAngkaSelesai;
        private Label lblLabelSelesai;
        private Label lblUsername;
        private Label lblSelamatDatang;
    }
}