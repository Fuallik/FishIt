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

        // Penanda supaya event tidak saling memicu saat kita mengubah nilai dari kode.
        private bool _sedangMengisiDariKode = false;

        public UC_PengajuanBenih()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
            new AutoScaleHelper(this);
            _controller = new CPengajuanBenih(this);
        }

        private void UC_PengajuanBenih_Load(object sender, EventArgs e) =>
            _controller.MuatAwal(Session.IdAkun);

        // Saat supplier memilih JENIS ikan -> saring dropdown nama sesuai jenis.
        private void cmbJenisIkan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sedangMengisiDariKode) return;
            _controller.JenisDipilih(cmbJenisIkan.Text.Trim());
        }

        // Saat supplier memilih NAMA ikan -> cek jenisnya (auto-isi / peringatan).
        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_sedangMengisiDariKode) return;
            _controller.NamaDipilih(cmbNama.Text.Trim(), cmbJenisIkan.Text.Trim());
        }

        // Saat supplier MENGETIK nama lalu pindah fokus (Leave), cek juga.
        // SelectedIndexChanged tidak terpicu saat mengetik, jadi Leave menutup celah itu.
        private void cmbNama_Leave(object sender, EventArgs e)
        {
            if (_sedangMengisiDariKode) return;
            _controller.NamaDipilih(cmbNama.Text.Trim(), cmbJenisIkan.Text.Trim());
        }

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
            // Pakai penanda supaya pengisian ini tidak memicu event nama.
            _sedangMengisiDariKode = true;
            string namaSekarang = cmbNama.Text;
            cmbNama.Items.Clear();
            foreach (DataRow row in data.Rows)
                cmbNama.Items.Add(row[0].ToString());
            cmbNama.Text = namaSekarang; // pertahankan teks yang sedang diketik
            _sedangMengisiDariKode = false;
        }

        public void SetRiwayat(DataTable data)
        {
            DGVPengajuan.DataSource = data;
            if (DGVPengajuan.Columns.Contains("ID"))
                DGVPengajuan.Columns["ID"].Visible = false;
        }

        public void SetJenisIkan(string namaJenis)
        {
            // Isi jenis dari kode (mis. auto-isi dari nama ikan yang sudah ada),
            // tanpa memicu ulang penyaringan nama.
            _sedangMengisiDariKode = true;
            cmbJenisIkan.SelectedItem = namaJenis;
            _sedangMengisiDariKode = false;
        }

        public void ResetForm()
        {
            _sedangMengisiDariKode = true;
            txtKuantitas.Clear();
            cmbJenisIkan.SelectedIndex = -1;
            cmbNama.SelectedIndex = -1;
            cmbNama.Text = "";
            _sedangMengisiDariKode = false;
        }

        public void TampilkanPesanInfo(string pesan) =>
            MessageBox.Show(pesan, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TampilkanPesanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}