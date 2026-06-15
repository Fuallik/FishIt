using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormTambahMonitoring : Form, ITambahMonitoring
    {
        private CTambahMonitoring _controller;

        public FormTambahMonitoring()
        {
            InitializeComponent();
            _controller = new CTambahMonitoring(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatKolam();
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            var d = new DataMonitoring
            {
                Berat = NUDBerat.Value,
                Kondisi = CBKondisi.SelectedItem?.ToString() ?? "",
                Mati = (int)NUDMati.Value,
                Catatan = TBCatatan.Text.Trim(),
                Siap = CBPanen.Checked,
                IdKolam = (CBKolam.SelectedValue == null || CBKolam.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBKolam.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e) => this.Close();

        // ===== implementasi ITambahMonitoring =====
        public void SetKolam(DataTable data)
        {
            CBKolam.DataSource = data;
            CBKolam.DisplayMember = "nomor";
            CBKolam.ValueMember = "id_kolam";
            CBKolam.SelectedIndex = -1;
        }
        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal menyimpan: " + p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}