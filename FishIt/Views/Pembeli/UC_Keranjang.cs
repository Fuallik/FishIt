using FishIt.Helpers;
using FishIt.Controllers.Pembeli;
using FishIt.Views.Pembeli;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_Keranjang : UserControl, IKeranjang
    {
        private CKeranjang _controller;

        public UC_Keranjang()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            _controller = new CKeranjang(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CBMetodePembayaran.Items.Clear();
            CBMetodePembayaran.Items.Add("Cash");
            CBMetodePembayaran.Items.Add("QRIS");
            CBMetodePembayaran.DropDownStyle = ComboBoxStyle.DropDownList;
            CBMetodePembayaran.SelectedIndex = 0;

            _controller.MuatData();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int idMetode = CBMetodePembayaran.SelectedIndex == -1 ? 0
                : (CBMetodePembayaran.SelectedItem.ToString() == "QRIS" ? 2 : 1);

            _controller.Checkout(idMetode);
        }

        private void DGVKeranjang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = DGVKeranjang.Rows[e.RowIndex];
            int idKeranjang = Convert.ToInt32(row.Cells["id_keranjang"].Value);
            string namaIkan = row.Cells["nama_ikan"].Value.ToString();

            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menghapus '{namaIkan}' dari keranjang?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
                _controller.HapusItem(idKeranjang);
        }

        public void SetDataGrid(DataTable data)
        {
            DGVKeranjang.DataSource = data;
            DGVKeranjang.Columns["id_keranjang"].Visible = false;
            DGVKeranjang.Columns["nama_ikan"].HeaderText = "Nama Ikan";
            DGVKeranjang.Columns["kuantitas"].HeaderText = "Kuantitas";
            DGVKeranjang.Columns["harga_per_kg"].HeaderText = "Harga Per Kg";
            DGVKeranjang.Columns["subtotal"].HeaderText = "Subtotal";
            GridHelper.AturTemaModern(DGVKeranjang);
        }

        public void BukaRiwayat()
        {
            try
            {
                Form formInduk = this.FindForm();
                Panel pnl = (Panel)formInduk.Controls.Find("panelKontenPembeli", true)[0];
                PanelHelper.ShowUserControl(pnl, new UC_RIwayatPembeli());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membuka halaman riwayat secara otomatis: " + ex.Message,
                    "Error Tampilan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanGagalCheckout(string p) =>
            MessageBox.Show(p, "Gagal Checkout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanError(string p) =>
            MessageBox.Show("Koneksi Database Gagal: " + p, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}