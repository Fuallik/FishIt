namespace FishIt
{
    partial class FormShipper
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
            buttonPengirimanPesanan = new Button();
            buttonRiwayatPengirimanPesanan = new Button();
            panelSB = new Panel();
            buttonLogoutAdmin = new Button();
            buttonDashboardShipper = new Button();
            panelNB = new Panel();
            panelContent = new Panel();
            panelSB.SuspendLayout();
            SuspendLayout();
            // 
            // buttonPengirimanPesanan
            // 
            buttonPengirimanPesanan.BackColor = Color.CornflowerBlue;
            buttonPengirimanPesanan.Dock = DockStyle.Top;
            buttonPengirimanPesanan.FlatAppearance.BorderSize = 0;
            buttonPengirimanPesanan.FlatStyle = FlatStyle.Flat;
            buttonPengirimanPesanan.Location = new Point(0, 50);
            buttonPengirimanPesanan.Name = "buttonPengirimanPesanan";
            buttonPengirimanPesanan.Size = new Size(200, 50);
            buttonPengirimanPesanan.TabIndex = 1;
            buttonPengirimanPesanan.Text = "Pengiriman Pesanan";
            buttonPengirimanPesanan.UseVisualStyleBackColor = false;
            buttonPengirimanPesanan.Click += buttonPengirimanPesanan_Click;
            // 
            // buttonRiwayatPengirimanPesanan
            // 
            buttonRiwayatPengirimanPesanan.BackColor = Color.CornflowerBlue;
            buttonRiwayatPengirimanPesanan.Dock = DockStyle.Top;
            buttonRiwayatPengirimanPesanan.FlatAppearance.BorderSize = 0;
            buttonRiwayatPengirimanPesanan.FlatStyle = FlatStyle.Flat;
            buttonRiwayatPengirimanPesanan.Location = new Point(0, 100);
            buttonRiwayatPengirimanPesanan.Name = "buttonRiwayatPengirimanPesanan";
            buttonRiwayatPengirimanPesanan.Size = new Size(200, 70);
            buttonRiwayatPengirimanPesanan.TabIndex = 3;
            buttonRiwayatPengirimanPesanan.Text = "Riwayat Pengiriman Pesanan";
            buttonRiwayatPengirimanPesanan.UseVisualStyleBackColor = false;
            buttonRiwayatPengirimanPesanan.Click += buttonRiwayatPengirimanPesanan_Click;
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogoutAdmin);
            panelSB.Controls.Add(buttonRiwayatPengirimanPesanan);
            panelSB.Controls.Add(buttonPengirimanPesanan);
            panelSB.Controls.Add(buttonDashboardShipper);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 50);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 606);
            panelSB.TabIndex = 8;
            // 
            // buttonLogoutAdmin
            // 
            buttonLogoutAdmin.BackColor = Color.CornflowerBlue;
            buttonLogoutAdmin.Dock = DockStyle.Bottom;
            buttonLogoutAdmin.FlatAppearance.BorderSize = 0;
            buttonLogoutAdmin.FlatStyle = FlatStyle.Flat;
            buttonLogoutAdmin.Location = new Point(0, 556);
            buttonLogoutAdmin.Name = "buttonLogoutAdmin";
            buttonLogoutAdmin.Size = new Size(200, 50);
            buttonLogoutAdmin.TabIndex = 6;
            buttonLogoutAdmin.Text = "LogOut";
            buttonLogoutAdmin.UseVisualStyleBackColor = false;
            buttonLogoutAdmin.Click += buttonLogoutAdmin_Click;
            // 
            // buttonDashboardShipper
            // 
            buttonDashboardShipper.Dock = DockStyle.Top;
            buttonDashboardShipper.FlatAppearance.BorderSize = 0;
            buttonDashboardShipper.FlatStyle = FlatStyle.Flat;
            buttonDashboardShipper.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboardShipper.ForeColor = Color.White;
            buttonDashboardShipper.Location = new Point(0, 0);
            buttonDashboardShipper.Name = "buttonDashboardShipper";
            buttonDashboardShipper.Size = new Size(200, 50);
            buttonDashboardShipper.TabIndex = 0;
            buttonDashboardShipper.Text = "Dashboard";
            buttonDashboardShipper.UseVisualStyleBackColor = true;
            buttonDashboardShipper.Click += buttonDashboard_Click;
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.CornflowerBlue;
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(0, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(980, 50);
            panelNB.TabIndex = 7;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(780, 606);
            panelContent.TabIndex = 10;
            // 
            // FormShipper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 656);
            Controls.Add(panelContent);
            Controls.Add(panelSB);
            Controls.Add(panelNB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormShipper";
            Text = "FormShipper";
            panelSB.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonLogOut;
        private Label label1;
        private Button buttonPengirimanPesanan;
        private Button buttonRiwayatPengirimanPesanan;
        private Panel panelSB;
        private Button buttonLogoutAdmin;
        private Button buttonDashboardShipper;
        private Panel panelNB;
        private Panel panelContent;
    }
}