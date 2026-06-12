using System;
using System.Collections.Generic;
using System.Text;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CInfoStok
    {
        private readonly IInfoStok _view;
        private readonly MInfoStok _model;

        // Controller menerima View melalui Dependency Injection
        public CInfoStok(IInfoStok view)
        {
            _view = view;
            _model = new MInfoStok();
        }

        public void MuatData()
        {
            try
            {
                // Ambil data grid dari Model dan lempar ke View
                _view.SetDataPakan(_model.GetStokPakan());
                _view.SetDataBenih(_model.GetStokBenih());

                // Ambil ringkasan dari Model dan lempar ke View
                decimal jenisPakan = _model.HitungStok("PAKAN", "JENIS");
                decimal totalPakan = _model.HitungStok("PAKAN", "TOTAL");
                _view.SetRingkasanPakan(jenisPakan, totalPakan);

                decimal jenisBenih = _model.HitungStok("BENIH", "JENIS");
                decimal totalBenih = _model.HitungStok("BENIH", "TOTAL");
                _view.SetRingkasanBenih(jenisBenih, totalBenih);
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}
