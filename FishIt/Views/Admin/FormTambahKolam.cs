using FishIt.Controllers.Admin;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.Views.Admin
{
    public partial class FormTambahKolam : Form, ITambahKolam
    {
        private CTambahKolam _controller;

        public FormTambahKolam()
        {
            InitializeComponent();
            _controller = new CTambahKolam(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatJenisIkan();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var d = new DataKolamBaru
            {
                Nomor = TBNama.Text,
                Panjang = TBPanjang.Text,
                Lebar = TBLebar.Text,
                Tinggi = TBTinggi.Text,
                Kapasitas = TBKapasitas.Text,
                IdJenis = (CBJenisIkan.SelectedValue == null || CBJenisIkan.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBJenisIkan.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatal_Click(object sender, EventArgs e) => this.Close();

        public void SetJenisIkan(DataTable data)
        {
            CBJenisIkan.DataSource = data;
            CBJenisIkan.DisplayMember = "nama_jenis_ikan";
            CBJenisIkan.ValueMember = "id_jenis_ikan";
            CBJenisIkan.SelectedIndex = -1;
            CBJenisIkan.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal menyimpan kolam: " + p, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}