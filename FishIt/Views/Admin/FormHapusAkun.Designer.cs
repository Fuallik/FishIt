namespace FishIt
{
    partial class FormHapusAkun
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
            lblHapusAkun = new Label();
            labelNama = new Label();
            TBUsername = new TextBox();
            btnBatalHapusAkun = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // lblHapusAkun
            // 
            lblHapusAkun.AutoSize = true;
            lblHapusAkun.BackColor = Color.Transparent;
            lblHapusAkun.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHapusAkun.ImageAlign = ContentAlignment.TopCenter;
            lblHapusAkun.Location = new Point(119, 9);
            lblHapusAkun.Name = "lblHapusAkun";
            lblHapusAkun.Size = new Size(252, 54);
            lblHapusAkun.TabIndex = 2;
            lblHapusAkun.Text = "Hapus Akun";
            lblHapusAkun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelNama
            // 
            labelNama.AutoSize = true;
            labelNama.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelNama.Location = new Point(79, 94);
            labelNama.Name = "labelNama";
            labelNama.Size = new Size(124, 32);
            labelNama.TabIndex = 8;
            labelNama.Text = "Username";
            // 
            // TBUsername
            // 
            TBUsername.BorderStyle = BorderStyle.FixedSingle;
            TBUsername.Location = new Point(79, 129);
            TBUsername.Name = "TBUsername";
            TBUsername.Size = new Size(335, 31);
            TBUsername.TabIndex = 7;
            // 
            // btnBatalHapusAkun
            // 
            btnBatalHapusAkun.BackColor = Color.Green;
            btnBatalHapusAkun.FlatAppearance.BorderSize = 0;
            btnBatalHapusAkun.FlatStyle = FlatStyle.Flat;
            btnBatalHapusAkun.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBatalHapusAkun.ForeColor = Color.White;
            btnBatalHapusAkun.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btnBatalHapusAkun.IconColor = Color.White;
            btnBatalHapusAkun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBatalHapusAkun.IconSize = 35;
            btnBatalHapusAkun.Location = new Point(34, 361);
            btnBatalHapusAkun.Name = "btnBatalHapusAkun";
            btnBatalHapusAkun.Size = new Size(169, 50);
            btnBatalHapusAkun.TabIndex = 25;
            btnBatalHapusAkun.Text = "Kembali";
            btnBatalHapusAkun.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBatalHapusAkun.UseVisualStyleBackColor = false;
            btnBatalHapusAkun.Click += btnBatalHapusAkun_Click;
            // 
            // FormHapusAkun
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 430);
            Controls.Add(btnBatalHapusAkun);
            Controls.Add(labelNama);
            Controls.Add(TBUsername);
            Controls.Add(lblHapusAkun);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormHapusAkun";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormHapusAkun";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHapusAkun;
        private Label labelNama;
        private TextBox TBUsername;
        private FontAwesome.Sharp.IconButton btnBatalHapusAkun;
    }
}