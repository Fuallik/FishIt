using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CMonitoring
    {
        private readonly IMonitoring _view;
        private readonly MMonitoring _model;

        public CMonitoring(IMonitoring view)
        {
            _view = view;
            _model = new MMonitoring();
        }

        public void MuatData()
        {
            try
            {
                _view.SetDataGrid(_model.GetMonitoring());
                _view.SetRingkasan(
                    _model.HitungMonitoring("HARI_INI"),
                    _model.HitungMonitoring("BULAN"));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}