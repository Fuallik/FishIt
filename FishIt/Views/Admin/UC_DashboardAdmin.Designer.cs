namespace FishIt
{
    partial class UC_DashboardAdmin
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
            lblSelamatDatang = new Label();
            lblUsername = new Label();
            SuspendLayout();
            // 
            // lblSelamatDatang
            // 
            lblSelamatDatang.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSelamatDatang.ForeColor = Color.MidnightBlue;
            lblSelamatDatang.Location = new Point(18, 21);
            lblSelamatDatang.Name = "lblSelamatDatang";
            lblSelamatDatang.Size = new Size(261, 48);
            lblSelamatDatang.TabIndex = 0;
            lblSelamatDatang.Text = "Selamat Datang, ";
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.MidnightBlue;
            lblUsername.Location = new Point(265, 21);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(498, 48);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // UC_DashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            Controls.Add(lblUsername);
            Controls.Add(lblSelamatDatang);
            Name = "UC_DashboardAdmin";
            Size = new Size(800, 600);
            Load += UC_DashboardAdmin_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label lblSelamatDatang;
        private Label lblUsername;
    }
}
