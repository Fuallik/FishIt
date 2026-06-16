using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormTambahAkun : Form, ITambahAkun
    {
        private CTambahAkun _controller;

        public FormTambahAkun()
        {
            InitializeComponent();
            TBUsername.PlaceholderText = "Username";
            TBPassword.PlaceholderText = "Password";
            TBKonfirmasi.PlaceholderText = "Konfirmasi Password";
            TBNama.PlaceholderText = "Nama Lengkap";
            TBTelpon.PlaceholderText = "No. Telpon";
            TBAlamat.PlaceholderText = "Alamat";
            TBKelurahan.PlaceholderText = "Kelurahan";
            TBKecamatan.PlaceholderText = "Kecamatan";
            CBJabatan.Text = "Pilih Jabatan";

            _controller = new CTambahAkun(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblTambahAkun.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatRole();
        }

        private void btnSaveTambahAkun_Click(object sender, EventArgs e)
        {
            var d = new DataAkunBaru
            {
                Username = TBUsername.Text.Trim(),
                Password = TBPassword.Text,
                Konfirmasi = TBKonfirmasi.Text,
                Nama = TBNama.Text.Trim(),
                Alamat = TBAlamat.Text.Trim(),
                Telpon = TBTelpon.Text.Trim(),
                Kelurahan = TBKelurahan.Text.Trim(),
                Kecamatan = TBKecamatan.Text.Trim(),
                IdRole = (CBJabatan.SelectedValue == null || CBJabatan.SelectedIndex == -1)
                         ? 0 : Convert.ToInt32(CBJabatan.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatalTambahAkun_Click(object sender, EventArgs e) => this.Close();

        public void SetRoles(DataTable data)
        {
            CBJabatan.DataSource = data;
            CBJabatan.DisplayMember = "nama_role";
            CBJabatan.ValueMember = "id_role";
            CBJabatan.SelectedIndex = -1;
        }
        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal menyimpan data akun:\n" + p, "Error Database",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}