namespace FishIt
{
    partial class UC_KatalogBenih
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
            lblJudul = new Label();
            DGVKatalog = new DataGridView();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVKatalog).BeginInit();
            SuspendLayout();
            // 
            // lblJudul
            // 
            lblJudul.AutoSize = true;
            lblJudul.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblJudul.Location = new Point(23, 20);
            lblJudul.Name = "lblJudul";
            lblJudul.Size = new Size(220, 37);
            lblJudul.TabIndex = 0;
            lblJudul.Text = "Katalog Benih";
            // 
            // DGVKatalog
            // 
            DGVKatalog.AllowUserToAddRows = false;
            DGVKatalog.AllowUserToDeleteRows = false;
            DGVKatalog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVKatalog.Location = new Point(23, 80);
            DGVKatalog.Name = "DGVKatalog";
            DGVKatalog.ReadOnly = true;
            DGVKatalog.Size = new Size(754, 400);
            DGVKatalog.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(127, 140, 141);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(657, 495);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // UC_KatalogBenih
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(DGVKatalog);
            Controls.Add(lblJudul);
            Name = "UC_KatalogBenih";
            Size = new Size(800, 600);
            Load += UC_KatalogBenih_Load;
            ((System.ComponentModel.ISupportInitialize)DGVKatalog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblJudul;
        private DataGridView DGVKatalog;
        private Button btnRefresh;
    }
}