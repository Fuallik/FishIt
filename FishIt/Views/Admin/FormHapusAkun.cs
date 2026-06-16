using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using FishIt.Models;
using System;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormHapusAkun : Form, IHapusAkun
    {
        private CHapusAkun _controller;

        public FormHapusAkun()
        {
            InitializeComponent();
            TBUsername.MaxLength = 50;
            TBUsername.PlaceholderText = "Ketik username di sini...";
            TBUsername.KeyDown += TBUsername_KeyDown;

            _controller = new CHapusAkun(this);
        }
        private void TBUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _controller.Cari(TBUsername.Text);
            }
        }

        private void btnBatalHapusAkun_Click(object sender, EventArgs e) => this.Close();
        public void BukaKonfirmasi(DetailAkunHapus d)
        {
            using (var popUp = new FormKonfirmasiHapus(
                TBUsername.Text.Trim(), d.Nama, d.Alamat, d.Telp, d.Kelurahan, d.Kecamatan))
            {
                if (popUp.ShowDialog() == DialogResult.Yes)
                    _controller.Hapus();
            }
        }

        public void ClearInput()
        {
            TBUsername.Clear();
            TBUsername.Focus();
        }

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanInfo(string p) =>
            MessageBox.Show(p, "Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal memproses:\n" + p, "Error Database",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}