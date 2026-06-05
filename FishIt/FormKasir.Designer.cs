namespace FishIt
{
    partial class FormKasir
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
            panelNB = new Panel();
            panel1 = new Panel();
            buttonLogout = new Button();
            panelContent = new Panel();
            buttonDashboard = new Button();
            buttonPesanan = new Button();
            buttonBuktiTransaksi = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.CornflowerBlue;
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(0, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(980, 50);
            panelNB.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(buttonBuktiTransaksi);
            panel1.Controls.Add(buttonPesanan);
            panel1.Controls.Add(buttonDashboard);
            panel1.Controls.Add(buttonLogout);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 606);
            panel1.TabIndex = 7;
            // 
            // buttonLogout
            // 
            buttonLogout.Dock = DockStyle.Bottom;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Location = new Point(0, 556);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(200, 50);
            buttonLogout.TabIndex = 4;
            buttonLogout.Text = "LogOut";
            buttonLogout.UseVisualStyleBackColor = true;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(780, 606);
            panelContent.TabIndex = 8;
            // 
            // buttonDashboard
            // 
            buttonDashboard.Dock = DockStyle.Top;
            buttonDashboard.FlatAppearance.BorderSize = 0;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.Location = new Point(0, 0);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Size = new Size(200, 50);
            buttonDashboard.TabIndex = 0;
            buttonDashboard.Text = "Dashboard";
            buttonDashboard.UseVisualStyleBackColor = true;
            // 
            // buttonPesanan
            // 
            buttonPesanan.Dock = DockStyle.Top;
            buttonPesanan.FlatAppearance.BorderSize = 0;
            buttonPesanan.FlatStyle = FlatStyle.Flat;
            buttonPesanan.Location = new Point(0, 50);
            buttonPesanan.Name = "buttonPesanan";
            buttonPesanan.Size = new Size(200, 50);
            buttonPesanan.TabIndex = 5;
            buttonPesanan.Text = "Pesanan";
            buttonPesanan.UseVisualStyleBackColor = true;
            // 
            // buttonBuktiTransaksi
            // 
            buttonBuktiTransaksi.Dock = DockStyle.Top;
            buttonBuktiTransaksi.FlatAppearance.BorderSize = 0;
            buttonBuktiTransaksi.FlatStyle = FlatStyle.Flat;
            buttonBuktiTransaksi.Location = new Point(0, 100);
            buttonBuktiTransaksi.Name = "buttonBuktiTransaksi";
            buttonBuktiTransaksi.Size = new Size(200, 50);
            buttonBuktiTransaksi.TabIndex = 6;
            buttonBuktiTransaksi.Text = "Bukti Transaksi";
            buttonBuktiTransaksi.UseVisualStyleBackColor = true;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 656);
            Controls.Add(panelContent);
            Controls.Add(panel1);
            Controls.Add(panelNB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKasir";
            Text = "FormKasir";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelNB;
        private Panel panel1;
        private Button buttonLogout;
        private Panel panelContent;
        private Button buttonBuktiTransaksi;
        private Button buttonPesanan;
        private Button buttonDashboard;
    }
}