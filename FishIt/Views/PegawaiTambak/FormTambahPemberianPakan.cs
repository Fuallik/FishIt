using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using FishIt.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormTambahPemberianPakan : Form, ITambahPemberianPakan
    {
        private CTambahPemberianPakan _controller;

        public FormTambahPemberianPakan()
        {
            InitializeComponent();
            _controller = new CTambahPemberianPakan(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CBPakan.DataSource = null;
            CBPakan.Enabled = false;       // pakan nonaktif sampai kolam dipilih
            _controller.MuatKolam();
        }

        // ===== aksi UI -> controller =====
        private void CBKolam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBKolam.SelectedIndex == -1 || CBKolam.SelectedValue == null
                || !int.TryParse(CBKolam.SelectedValue.ToString(), out _))
            {
                MatikanPakan();
                labelStokPakan.Text = "";
                return;
            }
            _controller.MuatPakan();
        }

        private void CBPakan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPakan.SelectedIndex == -1 || CBPakan.SelectedValue == null
                || !int.TryParse(CBPakan.SelectedValue.ToString(), out int idPakan))
            {
                labelStokPakan.Text = "";
                return;
            }
            _controller.TampilStok(idPakan);
        }

        private void btnSaveTambahMonitoring_Click(object sender, EventArgs e)
        {
            var d = new DataPemberianPakan
            {
                Jumlah = NUBJumlahPakan.Value,
                IdKolam = (CBKolam.SelectedValue == null || CBKolam.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBKolam.SelectedValue),
                IdPakan = (CBPakan.SelectedValue == null || CBPakan.SelectedIndex == -1)
                          ? 0 : Convert.ToInt32(CBPakan.SelectedValue)
            };
            _controller.Simpan(d);
        }

        private void btnBatalTambahMonitoring_Click(object sender, EventArgs e) => this.Close();

        // ===== implementasi ITambahPemberianPakan =====
        public void SetKolam(DataTable data)
        {
            CBKolam.DataSource = data;
            CBKolam.DisplayMember = "nomor";
            CBKolam.ValueMember = "id_kolam";
            CBKolam.SelectedIndex = -1;
        }
        public void SetPakan(DataTable data)
        {
            CBPakan.DataSource = null;
            CBPakan.DataSource = data;
            CBPakan.DisplayMember = "nama";
            CBPakan.ValueMember = "id_pakan";
            CBPakan.SelectedIndex = -1;
            CBPakan.Enabled = true;
        }
        public void MatikanPakan()
        {
            CBPakan.DataSource = null;
            CBPakan.Enabled = false;
        }
        public void SetStok(string teks) => labelStokPakan.Text = teks;

        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Terjadi kesalahan: " + p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}