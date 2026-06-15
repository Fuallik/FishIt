using System;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CPenebaran
    {
        private readonly IPenebaran _view;
        private readonly MPenebaran _model;

        public CPenebaran(IPenebaran view) { _view = view; _model = new MPenebaran(); }

        public void MuatData()
        {
            try
            {
                int id = Session.IdAkun;
                _view.SetDataGrid(_model.GetPenebaran(id));
                _view.SetRingkasan(_model.HitungPenebaran("AKUMULASI", id), _model.HitungPenebaran("BULAN", id));
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}