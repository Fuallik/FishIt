using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormDetailBenih : Form, IDetailBenih
    {
        private CDetailBenih _controller;

        public FormDetailBenih()
        {
            InitializeComponent();
            _controller = new CDetailBenih(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVBenih.DataSource = data;
            DGVBenih.Columns["id_benih"].HeaderText = "ID Benih";
            DGVBenih.Columns["nama"].HeaderText = "Nama Benih";
            DGVBenih.Columns["nama_jenis_ikan"].HeaderText = "Jenis Ikan";
            DGVBenih.Columns["jumlah_stok"].HeaderText = "Jumlah Stok";
            GridHelper.AturTemaModern(DGVBenih);
        }

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memuat tabel benih: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnKembali_Click(object sender, EventArgs e) => this.Close();
    }
}