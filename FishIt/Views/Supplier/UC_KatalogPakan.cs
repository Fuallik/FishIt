using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KatalogPakan : UserControl, IKatalogPakan
    {
        private readonly CKatalogPakan _controller;

        public UC_KatalogPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVKatalog);
            new AutoScaleHelper(this);
            _controller = new CKatalogPakan(this);
        }

        private void UC_KatalogPakan_Load(object sender, EventArgs e) => _controller.MuatKatalog();
        private void btnRefresh_Click(object sender, EventArgs e) => _controller.MuatKatalog();

        // ---- IMPLEMENTASI INTERFACE ----
        public void SetKatalog(DataTable data) => DGVKatalog.DataSource = data;
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}