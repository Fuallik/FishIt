using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormDetailIkan : Form, IDetailIkan
    {
        private CDetailIkan _controller;

        public FormDetailIkan()
        {
            InitializeComponent();
            _controller = new CDetailIkan(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVIkan.DataSource = data;
            DGVIkan.Columns["nama_ikan"].HeaderText = "Nama Ikan";
            DGVIkan.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
            DGVIkan.Columns["kualitas_ikan"].HeaderText = "Kualitas Ikan";
            DGVIkan.Columns["harga_per_kg"].HeaderText = "Harga per KG";
            DGVIkan.Columns["stok_ikan"].HeaderText = "Stok Ikan";
            GridHelper.AturTemaModern(DGVIkan);
        }

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat tabel ikan: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnKembali_Click(object sender, EventArgs e) => this.Close();
    }
}