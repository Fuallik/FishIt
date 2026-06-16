using FishIt.Helpers;
using FishIt.Controllers.Kasir;
using FishIt.Views.Kasir;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_KonfirmasiPembayaran : UserControl, IKonfirmasiPembayaran
    {
        private int idOrderTerpilih = 0;
        private CKonfirmasiPembayaran _controller;

        public UC_KonfirmasiPembayaran()
        {
            InitializeComponent();
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVAntrean);
            PanelHelper.BuatMelengkung(panel6, 20);

            _controller = new CKonfirmasiPembayaran(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatAntrean();
        }

        private void DGVAntrean_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idOrderTerpilih = Convert.ToInt32(DGVAntrean.Rows[e.RowIndex].Cells["ID"].Value);
            labelTotal.Text = DGVAntrean.Rows[e.RowIndex].Cells["Total"].Value.ToString();
            _controller.MuatDetail(idOrderTerpilih);
        }

        private void buttonKonfirmasi_Click(object sender, EventArgs e)
        {
            if (idOrderTerpilih == 0)
            {
                MessageBox.Show("Pilih order di antrean dulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var konfirmasi = MessageBox.Show($"Konfirmasi pembayaran untuk order #{idOrderTerpilih}?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi != DialogResult.Yes) return;

            _controller.Konfirmasi(idOrderTerpilih);
        }
        public void SetAntrean(DataTable data)
        {
            DGVAntrean.DataSource = data;
            GridHelper.AturTemaModern(DGVAntrean);
            if (DGVAntrean.Columns.Contains("ID"))
                DGVAntrean.Columns["ID"].Visible = false;
        }

        public void SetDetail(DataTable data)
        {
            DGVDetail.DataSource = data;
            GridHelper.AturTemaModern(DGVDetail);
        }

        public void ResetSetelahKonfirmasi()
        {
            idOrderTerpilih = 0;
            labelTotal.Text = "0";
            DGVDetail.DataSource = null;
        }

        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanInfo(string p) =>
            MessageBox.Show(p, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal konfirmasi: " + p, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}