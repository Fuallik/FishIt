using FishIt.Helpers;
using FishIt.Controllers.Admin;
using FishIt.Views.Admin;
using System;
using System.Data;
using System.Windows.Forms;

namespace FishIt
{
    public partial class UC_DataKolam : UserControl, IDataKolam
    {
        private CDataKolam _controller;

        public UC_DataKolam()
        {
            InitializeComponent();
            PanelHelper.BuatMelengkung(panelJumlahKolam, 20);
            PanelHelper.BuatMelengkung(panelStatistik, 20);
            PanelHelper.MakeButtonRounded(btnTambah, 16);
            PanelHelper.MakeButtonRounded(btnHapus, 16);
            new AutoScaleHelper(this);
            GridHelper.AturTemaModern(DGVKolam);

            _controller = new CDataKolam(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

        public void SetDataGrid(DataTable data)
        {
            DGVKolam.DataSource = data;
            GridHelper.AturTemaModern(DGVKolam);
            if (DGVKolam.Columns.Contains("ID"))
                DGVKolam.Columns["ID"].Visible = false;
        }

        public void SetJumlah(int total) => labelKolam.Text = total.ToString();

        public void TampilkanPesanError(string pesan) =>
            MessageBox.Show("Gagal memuat data: " + pesan, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (var f = new Views.Admin.FormTambahKolam())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            using (var f = new Views.Admin.FormHapusKolam())
                if (f.ShowDialog() == DialogResult.OK) _controller.MuatData();
        }
    }
}