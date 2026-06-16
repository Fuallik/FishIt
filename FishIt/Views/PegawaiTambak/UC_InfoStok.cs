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
            PanelHelper.BuatMelengkung(panelPakan, 25);
            PanelHelper.BuatMelengkung(panelBenih, 25);
            PanelHelper.BuatMelengkung(panelJenisPakan, 25);
            PanelHelper.BuatMelengkung(panelStokPakan, 25);
            PanelHelper.BuatMelengkung(panelStokBenih, 25);
            PanelHelper.BuatMelengkung(panelJenisBenih, 25);
            new AutoScaleHelper(this);

            _controller = new CInfoStok(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _controller.MuatData();
        }

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
            labelStokBenih.Text = $"{total:N0} ekor";        
        }

        public void TampilkanPesanError(string pesan)
        {
            MessageBox.Show($"Terjadi kesalahan: {pesan}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
