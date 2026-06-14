namespace FishIt.UserControls.PegawaiTambak
{
    partial class UC_DashboardPegawaiTambak
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
            lblUsername = new Label();
            lblSelamatDatang = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.MidnightBlue;
            lblUsername.Location = new Point(271, 22);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(498, 48);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // lblSelamatDatang
            // 
            lblSelamatDatang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelamatDatang.ForeColor = Color.MidnightBlue;
            lblSelamatDatang.Location = new Point(24, 22);
            lblSelamatDatang.Name = "lblSelamatDatang";
            lblSelamatDatang.Size = new Size(261, 48);
            lblSelamatDatang.TabIndex = 2;
            lblSelamatDatang.Text = "Selamat Datang, ";
            // 
            // UC_DashboardPegawaiTambak
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(lblUsername);
            Controls.Add(lblSelamatDatang);
            Name = "UC_DashboardPegawaiTambak";
            Size = new Size(800, 600);
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsername;
        private Label lblSelamatDatang;
    }
}
