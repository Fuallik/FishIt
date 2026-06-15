using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_VerifikasiSupply : UserControl, IVerifikasiSupply
    {
        private CVerifikasiSupply _controller;

        public UC_VerifikasiSupply()
        {
            InitializeComponent();
            TBIDPengajuan.MaxLength = 50;
            TBIDPengajuan.PlaceholderText = "Ketik ID Pengajuan di sini...";
            TBIDPengajuan.KeyDown += TBIDPengajuan_KeyDown;

            new AutoScaleHelper(this);
            PanelHelper.BuatMelengkung(panelMonitoring, 25);

            _controller = new CVerifikasiSupply(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatPengajuan();
        }

        // ===== aksi UI -> controller =====
        private void TBIDPengajuan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _controller.Cari(TBIDPengajuan.Text);
            }
        }

        // ===== implementasi IVerifikasiSupply =====
        public void SetPengajuan(DataTable data)
        {
            DGVPengajuan.DataSource = data;
            GridHelper.AturTemaModern(DGVPengajuan);
        }

        public void BukaDetail(DetailPengajuan d)
        {
            using (var popUp = new FormDetailVerifikasi(
                d.IdPengajuan, d.IdBenih, d.IdPakan, d.NamaBarang, d.Kuantitas,
                d.Tipe, d.TanggalKirim, d.StatusVerifikasi, d.TanggalVerifikasi, d.NamaSupplier))
            {
                popUp.StartPosition = FormStartPosition.CenterParent;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    ClearInput();
                    _controller.MuatPengajuan();   // refresh grid setelah ACC/tolak
                }
            }
        }

        public void ClearInput()
        {
            TBIDPengajuan.Clear();
            TBIDPengajuan.Focus();
        }

        public void TampilkanPeringatan(string pesan) =>
            MessageBox.Show(pesan, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanInfo(string pesan) =>
            MessageBox.Show(pesan, "Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal: " + pesan, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}