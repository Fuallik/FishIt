using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_PengajuanBenih : UserControl, IPengajuanBenih
    {
        private readonly CPengajuanBenih _controller;

        public UC_PengajuanBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
            new AutoScaleHelper(this);
            _controller = new CPengajuanBenih(this);
        }

        private void UC_PengajuanBenih_Load(object sender, EventArgs e) =>
            _controller.MuatAwal(Session.IdAkun);

        // Saat supplier memilih nama ikan -> controller cek & auto-isi jenis air.
        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e) =>
            _controller.NamaDipilih(cmbNama.Text.Trim());

        private void btnAjukan_Click(object sender, EventArgs e) =>
            _controller.Ajukan(Session.IdAkun, cmbJenisIkan.Text.Trim(),
                                cmbNama.Text.Trim(), txtKuantitas.Text.Trim());

        // ---- IMPLEMENTASI INTERFACE ----

        public void SetDaftarJenisIkan(DataTable data)
        {
            cmbJenisIkan.Items.Clear();
            foreach (DataRow row in data.Rows)
                cmbJenisIkan.Items.Add(row[0].ToString());
        }

        public void SetDaftarNamaIkan(DataTable data)
        {
            cmbNama.Items.Clear();
            foreach (DataRow row in data.Rows)
                cmbNama.Items.Add(row[0].ToString());
        }

        public void SetRiwayat(DataTable data)
        {
            DGVPengajuan.DataSource = data;
            if (DGVPengajuan.Columns.Contains("ID"))
                DGVPengajuan.Columns["ID"].Visible = false;
        }

        public void KunciJenisIkan(string namaJenis)
        {
            cmbJenisIkan.SelectedItem = namaJenis;
            cmbJenisIkan.Enabled = false;
        }

        public void BukaJenisIkan() => cmbJenisIkan.Enabled = true;

        public void ResetForm()
        {
            txtKuantitas.Clear();
            cmbJenisIkan.Enabled = true;
            cmbNama.SelectedIndex = -1;
        }

        public void TampilkanPesanInfo(string pesan) =>
            MessageBox.Show(pesan, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TampilkanPesanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}