using System;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CPanenIkan
    {
        private readonly IPanenIkan _view;
        private readonly MPanenIkan _model;

        public CPanenIkan(IPanenIkan view) { _view = view; _model = new MPanenIkan(); }

        public void MuatData()
        {
            try
            {
                int id = Session.IdAkun;
                _view.SetDataGrid(_model.GetPanen(id));
                _view.SetRingkasan(_model.HitungPanen("AKUMULASI", id), _model.HitungPanen("TAHUN", id));
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}