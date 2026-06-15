using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CKelolaAkun
    {
        private readonly IKelolaAkun _view;
        private readonly MKelolaAkun _model;

        public CKelolaAkun(IKelolaAkun view)
        {
            _view = view;
            _model = new MKelolaAkun();
        }

        public void MuatData()
        {
            try
            {
                _view.SetDataRiwayat(_model.GetRiwayat());
                _view.SetRingkasan(_model.HitungAktif(), _model.HitungTidakAktif());
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}