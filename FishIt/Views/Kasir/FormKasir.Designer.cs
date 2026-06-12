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
            panelContent = new Panel();
            panelSB = new Panel();
            buttonLogout = new FontAwesome.Sharp.IconButton();
            buttonRiwayatPembayaran = new FontAwesome.Sharp.IconButton();
            buttonKonfirmasiPembayaran = new FontAwesome.Sharp.IconButton();
            buttonDashboard = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panelTB = new Panel();
            panelSB.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 50);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(780, 606);
            panelContent.TabIndex = 10;
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonLogout);
            panelSB.Controls.Add(buttonRiwayatPembayaran);
            panelSB.Controls.Add(buttonKonfirmasiPembayaran);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Controls.Add(label1);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 50);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 606);
            panelSB.TabIndex = 9;
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.Transparent;
            buttonLogout.BackgroundImageLayout = ImageLayout.Zoom;
            buttonLogout.Dock = DockStyle.Bottom;
            buttonLogout.FlatAppearance.BorderSize = 0;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.IconChar = FontAwesome.Sharp.IconChar.LongArrowLeft;
            buttonLogout.IconColor = Color.White;
            buttonLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonLogout.IconSize = 30;
            buttonLogout.ImageAlign = ContentAlignment.MiddleLeft;
            buttonLogout.Location = new Point(0, 556);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Padding = new Padding(15, 0, 0, 0);
            buttonLogout.Size = new Size(200, 50);
            buttonLogout.TabIndex = 11;
            buttonLogout.Text = "Logout";
            buttonLogout.TextAlign = ContentAlignment.MiddleLeft;
            buttonLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // buttonRiwayatPembayaran
            // 
            buttonRiwayatPembayaran.BackColor = Color.Transparent;
            buttonRiwayatPembayaran.Dock = DockStyle.Top;
            buttonRiwayatPembayaran.FlatAppearance.BorderSize = 0;
            buttonRiwayatPembayaran.FlatStyle = FlatStyle.Flat;
            buttonRiwayatPembayaran.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonRiwayatPembayaran.ForeColor = Color.White;
            buttonRiwayatPembayaran.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            buttonRiwayatPembayaran.IconColor = Color.White;
            buttonRiwayatPembayaran.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonRiwayatPembayaran.IconSize = 30;
            buttonRiwayatPembayaran.ImageAlign = ContentAlignment.MiddleLeft;
            buttonRiwayatPembayaran.Location = new Point(0, 150);
            buttonRiwayatPembayaran.Name = "buttonRiwayatPembayaran";
            buttonRiwayatPembayaran.Padding = new Padding(15, 0, 0, 0);
            buttonRiwayatPembayaran.Size = new Size(200, 50);
            buttonRiwayatPembayaran.TabIndex = 10;
            buttonRiwayatPembayaran.Text = "Riwayat Pembayaran";
            buttonRiwayatPembayaran.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRiwayatPembayaran.UseVisualStyleBackColor = false;
            buttonRiwayatPembayaran.Click += buttonRiwayatPembayaran_Click;
            // 
            // buttonKonfirmasiPembayaran
            // 
            buttonKonfirmasiPembayaran.BackColor = Color.Transparent;
            buttonKonfirmasiPembayaran.Dock = DockStyle.Top;
            buttonKonfirmasiPembayaran.FlatAppearance.BorderSize = 0;
            buttonKonfirmasiPembayaran.FlatStyle = FlatStyle.Flat;
            buttonKonfirmasiPembayaran.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKonfirmasiPembayaran.ForeColor = Color.White;
            buttonKonfirmasiPembayaran.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            buttonKonfirmasiPembayaran.IconColor = Color.White;
            buttonKonfirmasiPembayaran.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonKonfirmasiPembayaran.IconSize = 30;
            buttonKonfirmasiPembayaran.ImageAlign = ContentAlignment.MiddleLeft;
            buttonKonfirmasiPembayaran.Location = new Point(0, 100);
            buttonKonfirmasiPembayaran.Name = "buttonKonfirmasiPembayaran";
            buttonKonfirmasiPembayaran.Padding = new Padding(15, 0, 0, 0);
            buttonKonfirmasiPembayaran.Size = new Size(200, 50);
            buttonKonfirmasiPembayaran.TabIndex = 8;
            buttonKonfirmasiPembayaran.Text = "Konfirmasi Pembayaran";
            buttonKonfirmasiPembayaran.TextAlign = ContentAlignment.MiddleLeft;
            buttonKonfirmasiPembayaran.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonKonfirmasiPembayaran.UseVisualStyleBackColor = false;
            buttonKonfirmasiPembayaran.Click += buttonKonfirmasiPembayaran_Click;
            // 
            // buttonDashboard
            // 
            buttonDashboard.BackColor = Color.Transparent;
            buttonDashboard.Dock = DockStyle.Top;
            buttonDashboard.FlatAppearance.BorderSize = 0;
            buttonDashboard.FlatStyle = FlatStyle.Flat;
            buttonDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDashboard.ForeColor = Color.White;
            buttonDashboard.IconChar = FontAwesome.Sharp.IconChar.Bars;
            buttonDashboard.IconColor = Color.White;
            buttonDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            buttonDashboard.IconSize = 30;
            buttonDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.Location = new Point(0, 50);
            buttonDashboard.Name = "buttonDashboard";
            buttonDashboard.Padding = new Padding(15, 0, 0, 0);
            buttonDashboard.Size = new Size(200, 50);
            buttonDashboard.TabIndex = 7;
            buttonDashboard.Text = " Dashboard";
            buttonDashboard.TextAlign = ContentAlignment.MiddleLeft;
            buttonDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDashboard.UseVisualStyleBackColor = false;
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(200, 50);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTB
            // 
            panelTB.BackColor = Color.Black;
            panelTB.Dock = DockStyle.Top;
            panelTB.Location = new Point(0, 0);
            panelTB.Name = "panelTB";
            panelTB.Size = new Size(980, 50);
            panelTB.TabIndex = 8;
            // 
            // FormKasir
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 656);
            Controls.Add(panelContent);
            Controls.Add(panelSB);
            Controls.Add(panelTB);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKasir";
            Text = "FormKasir";
            WindowState = FormWindowState.Maximized;
            panelSB.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel panelSB;
        private FontAwesome.Sharp.IconButton buttonLogout;
        private FontAwesome.Sharp.IconButton buttonKonfirmasiPembayaran;
        private FontAwesome.Sharp.IconButton buttonRiwayatPembayaran;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private Label label1;
        private Panel panelTB;
    }
}