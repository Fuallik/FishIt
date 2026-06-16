using FishIt.Helpers;
using FishIt.Controllers.Supplier;
using FishIt.Views.Supplier;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_PengajuanPakan : UserControl, IPengajuanPakan
    {
        private readonly CPengajuanPakan _controller;

        public UC_PengajuanPakan()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPengajuan);
            new AutoScaleHelper(this);
            _controller = new CPengajuanPakan(this);
        }

        private void UC_PengajuanPakan_Load(object sender, EventArgs e) =>
            _controller.MuatAwal(Session.IdAkun);

        private void btnAjukan_Click(object sender, EventArgs e) =>
            _controller.Ajukan(Session.IdAkun, cmbPakan.Text.Trim(), txtKuantitas.Text.Trim());

        public void SetDaftarPakan(DataTable data)
        {
            cmbPakan.Items.Clear();
            foreach (DataRow row in data.Rows)
                cmbPakan.Items.Add(row[0].ToString());
        }

        public void SetRiwayat(DataTable data)
        {
            DGVPengajuan.DataSource = data;
            if (DGVPengajuan.Columns.Contains("ID"))
                DGVPengajuan.Columns["ID"].Visible = false;
        }

        public void ResetForm() => txtKuantitas.Clear();

        public void TampilkanPesanInfo(string pesan) =>
            MessageBox.Show(pesan, "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show(pesan, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void TampilkanPesanSukses(string pesan) =>
            MessageBox.Show(pesan, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}