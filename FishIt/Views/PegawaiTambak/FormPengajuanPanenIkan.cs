using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormPengajuanPanenIkan : Form, IPengajuanPanen
    {
        private CPengajuanPanen _controller;

        public FormPengajuanPanenIkan()
        {
            InitializeComponent();
            _controller = new CPengajuanPanen(this);
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
                KosongkanIkan();
                labelIkan.Text = "0";
                return;
            }
            _controller.MuatIkan(idKolam);
            labelIkan.Text = "0";
        }

        private void CBIkan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBIkan.SelectedIndex == -1 || CBKolam.SelectedValue == null
                || !int.TryParse(CBKolam.SelectedValue.ToString(), out int idKolam))
            {
                labelIkan.Text = "0";
                return;
            }
            _controller.TampilSisa(idKolam);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            var d = new DataPanen
            {
                Kg = NUDBerat.Value,
                Ekor = (int)NUBEkor.Value,
                Kualitas = CBKualitas.SelectedItem?.ToString() ?? "",
                IdKolam = (CBKolam.SelectedValue == null || CBKolam.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBKolam.SelectedValue),
                IdIkan = (CBIkan.SelectedValue == null || CBIkan.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBIkan.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ===== implementasi IPengajuanPanen =====
        public void SetKolam(DataTable data)
        {
            CBKolam.DataSource = data;
            CBKolam.DisplayMember = "nomor";
            CBKolam.ValueMember = "id_kolam";
            CBKolam.SelectedIndex = -1;
        }
        public void SetIkan(DataTable data)
        {
            CBIkan.DataSource = null;
            CBIkan.DataSource = data;
            CBIkan.DisplayMember = "label";
            CBIkan.ValueMember = "id_ikan";
            CBIkan.SelectedIndex = -1;
        }
        public void KosongkanIkan() => CBIkan.DataSource = null;
        public void SetSisa(string teks) => labelIkan.Text = teks;

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Terjadi kesalahan: " + p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}