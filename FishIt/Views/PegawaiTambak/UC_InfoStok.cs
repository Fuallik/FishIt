using FishIt.Helpers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FishIt.Controllers.PegawaiTambak;
using FishIt.Views.PegawaiTambak;
using FishIt.Models;

namespace FishIt.UserControls.PegawaiTambak
{
    public partial class UC_InfoStok : UserControl, IInfoStok
    {
        private CInfoStok _controller;

        public UC_InfoStok()
        {
            InitializeComponent();
            GridHelper.AturTemaModern(DGVPakan);
            GridHelper.AturTemaModern(DGVBenih);
            new AutoScaleHelper(this);

            // Inisialisasi Controller
            _controller = new CInfoStok(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Perintahkan controller untuk memuat data
            _controller.MuatData();
        }

        // ==========================================
        // IMPLEMENTASI INTERFACE IInfoStokView
        // ==========================================

        public void SetDataPakan(DataTable data)
        {
            DGVPakan.DataSource = data;
        }

        public void SetDataBenih(DataTable data)
        {
            DGVBenih.DataSource = data;
        }

        public void SetRingkasanPakan(decimal jenis, decimal total)
        {
            labelJenisPakan.Text = $"{jenis:N0} jenis";
            labelStokPakan.Text = $"{total:N2} kg";
        }

        public void SetRingkasanBenih(decimal jenis, decimal total)
        {
            labelJenisBenih.Text = $"{jenis:N0} jenis";
            labelStokBenih.Text = $"{total:N0} ekor"; // Benih biasanya dalam satuan ekor bulat (N0)
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show($"Terjadi kesalahan: {pesan}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
