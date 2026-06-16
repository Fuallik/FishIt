using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KatalogBenih : UserControl, IKatalogBenih
    {
        private readonly CKatalogBenih _controller;

        public UC_KatalogBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVKatalog);
            new AutoScaleHelper(this);
            _controller = new CKatalogBenih(this);
        }

        private void UC_KatalogBenih_Load(object sender, EventArgs e) => _controller.MuatKatalog();
        private void btnRefresh_Click(object sender, EventArgs e) => _controller.MuatKatalog();

        public void SetKatalog(DataTable data) => DGVKatalog.DataSource = data;
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}