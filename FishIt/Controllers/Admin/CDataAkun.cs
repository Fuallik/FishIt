using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDataAkun
    {
        private readonly IDataAkun _view;
        private readonly MDataAkun _model;

        public CDataAkun(IDataAkun view)
        {
            _view = view;
            _model = new MDataAkun();
        }

        public void MuatData()
        {
            try
            {
                _view.SetDataGrid(_model.GetDataAkun());
                _view.SetRingkasan(
                    _model.HitungAktif(),
                    _model.HitungTidakAktif(),
                    _model.HitungRole(3),  // tambak
                    _model.HitungRole(2),  // kasir
                    _model.HitungRole(5),  // supplier
                    _model.HitungRole(4),  // shipper
                    _model.HitungRole(6)); // pembeli
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}