using FishIt.Helpers;
using FishIt.Controllers.Pembeli;
using FishIt.Views.Pembeli;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KatalogIkanPembeli : UserControl, IKatalogIkan
    {
        private CKatalogIkan _controller;

        public UC_KatalogIkanPembeli()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            _controller = new CKatalogIkan(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }
        private void dgvStokIkan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVKatalogIkan.Columns[e.ColumnIndex].Name == "colTambah" && e.RowIndex >= 0)
            {
                var row = DGVKatalogIkan.Rows[e.RowIndex];
                _controller.TambahKeKeranjang(
                    Convert.ToInt32(row.Cells["id_ikan"].Value),
                    row.Cells["nama_ikan"].Value.ToString(),
                    Convert.ToDecimal(row.Cells["stok_ikan"].Value),
                    numericJumlah.Value);
            }
        }
        public void SetDataGrid(DataTable data)
        {
            DGVKatalogIkan.DataSource = data;
            DGVKatalogIkan.Columns["id_ikan"].HeaderText = "ID Ikan";
            DGVKatalogIkan.Columns["nama_ikan"].HeaderText = "Nama Ikan";
            DGVKatalogIkan.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
            DGVKatalogIkan.Columns["kualitas_ikan"].HeaderText = "Kualitas Ikan";
            DGVKatalogIkan.Columns["harga_per_kg"].HeaderText = "Harga per KG";
            DGVKatalogIkan.Columns["stok_ikan"].HeaderText = "Stok Ikan";
            GridHelper.AturTemaModern(DGVKatalogIkan);
        }

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal masuk keranjang: " + p, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}