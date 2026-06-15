using FishIt.Helpers;
using FishIt.Controllers.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.Views.Admin
{
    public partial class UC_HargaPanen : UserControl, IHargaPanen
    {
        private CHargaPanen _controller;

        public UC_HargaPanen()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVPanen);

            _controller = new CHargaPanen(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatAntrean();
        }

        // ===== aksi UI -> controller =====
        private void DGVPanen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = DGVPanen.Rows[e.RowIndex];

            _controller.PilihPanen(
                Convert.ToInt32(row.Cells["ID"].Value),
                row.Cells["Ikan"].Value.ToString(),
                Convert.ToInt32(row.Cells["ID Jenis"].Value),
                Convert.ToInt32(row.Cells["ID Kualitas"].Value),
                Convert.ToDecimal(row.Cells["Jumlah (kg)"].Value),
                row.Cells["Kualitas"].Value.ToString());
        }

        private void btnSimpan_Click(object sender, EventArgs e) => _controller.Simpan();

        // ===== implementasi IHargaPanen (cuma UI) =====
        public void SetAntrean(DataTable data)
        {
            DGVPanen.DataSource = data;
            GridHelper.AturTemaModern(DGVPanen);
            foreach (var k in new[] { "ID", "ID Jenis", "ID Kualitas" })
                if (DGVPanen.Columns.Contains(k)) DGVPanen.Columns[k].Visible = false;
        }

        public void TampilkanKatalogDitemukan(decimal harga, string keterangan)
        {
            TBHarga.Text = harga.ToString("0.##");
            TBHarga.Enabled = false;
            labelIkanTerpilih.Text = keterangan;
        }

        public void TampilkanKatalogBaru(string keterangan)
        {
            TBHarga.Text = "";
            TBHarga.Enabled = true;
            labelIkanTerpilih.Text = keterangan;
        }

        public string AmbilInputHarga() => TBHarga.Text;

        public void ResetForm()
        {
            TBHarga.Text = "";
            TBHarga.Enabled = true;
            labelIkanTerpilih.Text = "";
        }

        public void TampilkanPeringatan(string pesan) =>
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanInfo(string pesan) =>
            MessageBox.Show(pesan, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal: " + pesan, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}