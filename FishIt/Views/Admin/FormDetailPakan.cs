using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormDetailPakan : Form, IDetailPakan
    {
        private CDetailPakan _controller;

        public FormDetailPakan()
        {
            InitializeComponent();
            _controller = new CDetailPakan(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVPakan.DataSource = data;
            DGVPakan.Columns["id_pakan"].HeaderText = "ID Pakan";
            DGVPakan.Columns["nama"].HeaderText = "Nama Pakan";
            DGVPakan.Columns["jumlah_stok"].HeaderText = "Jumlah Stok";
            GridHelper.AturTemaModern(DGVPakan);
        }

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat tabel pakan: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnKembali_Click(object sender, EventArgs e) => this.Close();
    }
}