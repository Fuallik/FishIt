using System;
using FishIt.Models;
using FishIt.Views.Pembeli;
using FishIt.Helpers;

namespace FishIt.Controllers.Pembeli
{
    internal class CRiwayatPembeli
    {
        private readonly IRiwayatPembeli _view;
        private readonly MRiwayatPembeli _model;

        public CRiwayatPembeli(IRiwayatPembeli view)
        {
            _view = view;
            _model = new MRiwayatPembeli();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetRiwayat(Session.IdAkun)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}