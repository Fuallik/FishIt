using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormTambahPenebaranBenih : Form, ITambahPenebaran
    {
        private CTambahPenebaran _controller;

        public FormTambahPenebaranBenih()
        {
            InitializeComponent();
            _controller = new CTambahPenebaran(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatKolam();
        }

        // ===== aksi UI -> controller =====
        private void CBKolam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBKolam.SelectedValue == null
                || !int.TryParse(CBKolam.SelectedValue.ToString(), out int idKolam))
            {
                KosongkanBenih();
                return;
            }
            _controller.MuatBenih(idKolam);
        }

        private void CBBenihIkan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBBenihIkan.SelectedIndex == -1 || CBBenihIkan.SelectedValue == null
                || !int.TryParse(CBBenihIkan.SelectedValue.ToString(), out int idBenih))
            {
                labelStok.Text = "";
                return;
            }
            _controller.TampilStok(idBenih);
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            var d = new DataPenebaran
            {
                Ekor = (int)NUBEkor.Value,
                IdKolam = (CBKolam.SelectedValue == null || CBKolam.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBKolam.SelectedValue),
                IdBenih = (CBBenihIkan.SelectedValue == null || CBBenihIkan.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBBenihIkan.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e) => this.Close();

        // ===== implementasi ITambahPenebaran =====
        public void SetKolam(DataTable data)
        {
            CBKolam.DataSource = data;
            CBKolam.DisplayMember = "nomor";
            CBKolam.ValueMember = "id_kolam";
            CBKolam.SelectedIndex = -1;
        }
        public void SetBenih(DataTable data)
        {
            CBBenihIkan.DataSource = data;
            CBBenihIkan.DisplayMember = "nama";
            CBBenihIkan.ValueMember = "id_benih";
            CBBenihIkan.SelectedIndex = -1;
        }
        public void KosongkanBenih() => CBBenihIkan.DataSource = null;
        public void SetStok(string teks) => labelStok.Text = teks;

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Terjadi kesalahan: " + p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}