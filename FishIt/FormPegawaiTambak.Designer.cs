namespace FishIt
{
    partial class FormPegawaiTambak
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
            label1 = new Label();
            panelSB = new Panel();
            buttonMonitoring = new Button();
            buttonLogout = new Button();
            buttonPemberianPakan = new Button();
            buttonPenebaran = new Button();
            buttonPanenIkan = new Button();
            buttonDashboard = new Button();
            panelPegawaiTambak = new Panel();
            panelContent = new Panel();
            panelSB.SuspendLayout();
            panelPegawaiTambak.SuspendLayout();
            SuspendLayout();
            // 
            // panelNB
            // 
            panelNB.BackColor = Color.CornflowerBlue;
            panelNB.Dock = DockStyle.Top;
            panelNB.Location = new Point(0, 0);
            panelNB.Name = "panelNB";
            panelNB.Size = new Size(980, 50);
            panelNB.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 240);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 8;
            label1.Text = "INI PEMBELI";
            // 
            // panelSB
            // 
            panelSB.BackColor = Color.CornflowerBlue;
            panelSB.Controls.Add(buttonMonitoring);
            panelSB.Controls.Add(buttonLogout);
            panelSB.Controls.Add(buttonPemberianPakan);
            panelSB.Controls.Add(buttonPenebaran);
            panelSB.Controls.Add(buttonPanenIkan);
            panelSB.Controls.Add(buttonDashboard);
            panelSB.Dock = DockStyle.Left;
            panelSB.Location = new Point(0, 0);
            panelSB.Name = "panelSB";
            panelSB.Size = new Size(200, 606);
            panelSB.TabIndex = 0;
            // 
            // buttonMonitoring
            // 
            buttonMonitoring.Dock = DockStyle.Top;
            buttonMonitoring.FlatAppearance.BorderSize = 0;
            buttonMonitoring.FlatStyle = FlatStyle.Flat;
            buttonMonitoring.Location = new Point(0, 200);
            buttonMonitoring.Name = "buttonMonitoring";
            buttonMonitoring.Size = new Size(200, 50);
            buttonMonitoring.TabIndex = 5;
            buttonMonitoring.Text = "Monitoring";
            buttonMonitoring.UseVisualStyleBackColor = true;
            buttonMonitoring.Click += buttonMonitoring_Click;
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
            // buttonPemberianPakan
            // 
            buttonPemberianPakan.Dock = DockStyle.Top;
            buttonPemberianPakan.FlatAppearance.BorderSize = 0;
            buttonPemberianPakan.FlatStyle = FlatStyle.Flat;
            buttonPemberianPakan.Location = new Point(0, 150);
            buttonPemberianPakan.Name = "buttonPemberianPakan";
            buttonPemberianPakan.Size = new Size(200, 50);
            buttonPemberianPakan.TabIndex = 3;
            buttonPemberianPakan.Text = "Pemberian Pakan";
            buttonPemberianPakan.UseVisualStyleBackColor = true;
            buttonPemberianPakan.Click += buttonPemberianPakan_Click;
            // 
            // buttonPenebaran
            // 
            buttonPenebaran.Dock = DockStyle.Top;
            buttonPenebaran.FlatAppearance.BorderSize = 0;
            buttonPenebaran.FlatStyle = FlatStyle.Flat;
            buttonPenebaran.Location = new Point(0, 100);
            buttonPenebaran.Name = "buttonPenebaran";
            buttonPenebaran.Size = new Size(200, 50);
            buttonPenebaran.TabIndex = 2;
            buttonPenebaran.Text = "Penebaran Benih Ikan";
            buttonPenebaran.UseVisualStyleBackColor = true;
            buttonPenebaran.Click += buttonPenebaran_Click;
            // 
            // buttonPanenIkan
            // 
            buttonPanenIkan.Dock = DockStyle.Top;
            buttonPanenIkan.FlatAppearance.BorderSize = 0;
            buttonPanenIkan.FlatStyle = FlatStyle.Flat;
            buttonPanenIkan.Location = new Point(0, 50);
            buttonPanenIkan.Name = "buttonPanenIkan";
            buttonPanenIkan.Size = new Size(200, 50);
            buttonPanenIkan.TabIndex = 1;
            buttonPanenIkan.Text = "Panen Ikan";
            buttonPanenIkan.UseVisualStyleBackColor = true;
            buttonPanenIkan.Click += buttonPanenIkan_Click;
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
            buttonDashboard.Click += buttonDashboard_Click;
            // 
            // panelPegawaiTambak
            // 
            panelPegawaiTambak.BackColor = Color.White;
            panelPegawaiTambak.Controls.Add(panelContent);
            panelPegawaiTambak.Controls.Add(panelSB);
            panelPegawaiTambak.Dock = DockStyle.Fill;
            panelPegawaiTambak.Location = new Point(0, 50);
            panelPegawaiTambak.Name = "panelPegawaiTambak";
            panelPegawaiTambak.Size = new Size(980, 606);
            panelPegawaiTambak.TabIndex = 10;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(780, 606);
            panelContent.TabIndex = 5;
            // 
            // FormPegawaiTambak
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 656);
            Controls.Add(panelPegawaiTambak);
            Controls.Add(panelNB);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormPegawaiTambak";
            Text = "FormPTambak";
            panelSB.ResumeLayout(false);
            panelPegawaiTambak.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelNB;
        private Label label1;
        private Panel panelSB;
        private Button buttonMonitoring;
        private Button buttonLogout;
        private Button buttonPemberianPakan;
        private Button buttonPenebaran;
        private Button buttonPanenIkan;
        private Button buttonDashboard;
        private Panel panelPegawaiTambak;
        private Panel panelContent;
    }
}