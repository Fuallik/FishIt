namespace FishIt
{
    partial class FormPembeli
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
            label1 = new Label();
            panelNB = new Panel();
            panel1 = new Panel();
            buttonLogout = new Button();
            buttonRiwayat = new Button();
            buttonKeranjang = new Button();
            buttonKatalog = new Button();
            buttonDashboard = new Button();
            panelContent = new Panel();
            panel1.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 240);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 0;
            label1.Text = "INI PEMBELI";
            label1.Click += label1_Click;
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.CornflowerBlue;
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(0, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(980, 50);
            panelNB.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.CornflowerBlue;
            panel1.Controls.Add(buttonLogout);
            panel1.Controls.Add(buttonRiwayat);
            panel1.Controls.Add(buttonKeranjang);
            panel1.Controls.Add(buttonKatalog);
            panel1.Controls.Add(buttonDashboard);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 606);
            panel1.TabIndex = 0;
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
            // buttonRiwayat
            // 
            buttonRiwayat.Dock = DockStyle.Top;
            buttonRiwayat.FlatAppearance.BorderSize = 0;
            buttonRiwayat.FlatStyle = FlatStyle.Flat;
            buttonRiwayat.Location = new Point(0, 150);
            buttonRiwayat.Name = "buttonRiwayat";
            buttonRiwayat.Size = new Size(200, 50);
            buttonRiwayat.TabIndex = 3;
            buttonRiwayat.Text = "Riwayat";
            buttonRiwayat.UseVisualStyleBackColor = true;
            // 
            // buttonKeranjang
            // 
            buttonKeranjang.Dock = DockStyle.Top;
            buttonKeranjang.FlatAppearance.BorderSize = 0;
            buttonKeranjang.FlatStyle = FlatStyle.Flat;
            buttonKeranjang.Location = new Point(0, 100);
            buttonKeranjang.Name = "buttonKeranjang";
            buttonKeranjang.Size = new Size(200, 50);
            buttonKeranjang.TabIndex = 2;
            buttonKeranjang.Text = "Keranjang";
            buttonKeranjang.UseVisualStyleBackColor = true;
            // 
            // buttonKatalog
            // 
            buttonKatalog.Dock = DockStyle.Top;
            buttonKatalog.FlatAppearance.BorderSize = 0;
            buttonKatalog.FlatStyle = FlatStyle.Flat;
            buttonKatalog.Location = new Point(0, 50);
            buttonKatalog.Name = "buttonKatalog";
            buttonKatalog.Size = new Size(200, 50);
            buttonKatalog.TabIndex = 1;
            buttonKatalog.Text = "Katalog Ikan";
            buttonKatalog.UseVisualStyleBackColor = true;
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
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(panel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(980, 606);
            panelContent.TabIndex = 7;
            panelContent.Paint += panelContent_Paint;
            // 
            // FormPembeli
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 656);
            Controls.Add(panelContent);
            Controls.Add(panelNB);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPembeli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormPembeli";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panelNB;
        private Panel panel1;
        private Button buttonDashboard;
        private Panel panelContent;
        private Button buttonKatalog;
        private Button buttonLogout;
        private Button buttonRiwayat;
        private Button buttonKeranjang;
    }
}