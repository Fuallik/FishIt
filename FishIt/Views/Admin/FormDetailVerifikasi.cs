using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormDetailVerifikasi : Form, IDetailVerifikasi
    {
        private readonly int idPengajuanTerpilih;
        private CDetailVerifikasi _controller;

        public FormDetailVerifikasi(int idPengajuan, int idBenih, int idPakan, string namaBarang,
            int kuantitas, string tipe, string tanggalKirim, string statusVerifikasi,
            string tanggalVerifikasi, string namaSupplier)
        {
            InitializeComponent();
            idPengajuanTerpilih = idPengajuan;

            // isi tampilan (UI murni)
            TBIdPengajuan.Text = idPengajuan.ToString();
            TBSupplier.Text = namaSupplier;
            TBNamaIkan.Text = namaBarang;
            TBKuantitas.Text = kuantitas.ToString();
            TBTipe.Text = tipe;
            TBTglKirim.Text = tanggalKirim;
            TBStatus.Text = statusVerifikasi;
            TBTglVerifikasi.Text = tanggalVerifikasi;

            _controller = new CDetailVerifikasi(this);
        }

        // ===== aksi UI -> controller (konfirmasi tetap di View karena murni UI) =====
        private void btnACC_Click(object sender, EventArgs e)
        {
            var konfirmasi = MessageBox.Show(
                $"ACC pasokan '{TBNamaIkan.Text}' sebanyak {TBKuantitas.Text}?",
                "Konfirmasi ACC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
                _controller.Setujui(idPengajuanTerpilih);
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menolak pengajuan ID {idPengajuanTerpilih}?",
                "Konfirmasi Tolak", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (konfirmasi == DialogResult.Yes)
                _controller.Tolak(idPengajuanTerpilih);
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ===== implementasi IDetailVerifikasi =====
        public void TampilkanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void TampilkanError(string pesan) =>
            MessageBox.Show("Gagal memproses: " + pesan, "Error Database",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void TutupDialog()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}