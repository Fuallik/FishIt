using System;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CPemberianPakan
    {
        private readonly IPemberianPakan _view;
        private readonly MPemberianPakan _model;

        public CPemberianPakan(IPemberianPakan view) { _view = view; _model = new MPemberianPakan(); }

        public void MuatData()
        {
            try
            {
                int id = Session.IdAkun;
                _view.SetDataGrid(_model.GetPemberianPakan(id));
                _view.SetRingkasan(_model.HitungPakan("AKUMULASI", id), _model.HitungPakan("BULAN", id));
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}