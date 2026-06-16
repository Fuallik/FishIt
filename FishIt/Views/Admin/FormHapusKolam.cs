using FishIt.Controllers.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt.Views.Admin
{
    public partial class FormHapusKolam : Form, IHapusKolam
    {
        private CHapusKolam _controller;

        public FormHapusKolam()
        {
            InitializeComponent();
            _controller = new CHapusKolam(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatKolam();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CBIdKolam.SelectedIndex == -1 || CBIdKolam.SelectedValue == null)
            {
                TampilkanPeringatan("Pilih kolam yang mau dihapus dulu!");
                return;
            }

            int idKolam = Convert.ToInt32(CBIdKolam.SelectedValue);
            string nomorKolam = CBIdKolam.Text;

            var konfirmasi = MessageBox.Show(
                $"Tandai kolam '{nomorKolam}' sebagai Tidak Terpakai?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (konfirmasi != DialogResult.Yes) return;

            _controller.Hapus(idKolam, nomorKolam);
        }

        private void btnBatal_Click(object sender, EventArgs e) => this.Close();

        public void SetKolam(DataTable data)
        {
            CBIdKolam.DataSource = data;
            CBIdKolam.DisplayMember = "nomor";
            CBIdKolam.ValueMember = "id_kolam";
            CBIdKolam.SelectedIndex = -1;
            CBIdKolam.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void TampilkanPeringatan(string p) =>
            MessageBox.Show(p, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanInfo(string p) =>
            MessageBox.Show(p, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanSukses(string p) =>
            MessageBox.Show(p, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public void TampilkanError(string p) =>
            MessageBox.Show("Gagal menghapus kolam: " + p, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TutupDialog() { this.DialogResult = DialogResult.OK; this.Close(); }
    }
}