using System;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CMonitoringIkan
    {
        private readonly IMonitoringIkan _view;
        private readonly MMonitoringIkan _model;

        public CMonitoringIkan(IMonitoringIkan view) { _view = view; _model = new MMonitoringIkan(); }

        public void MuatData()
        {
            try
            {
                int id = Session.IdAkun;
                _view.SetDataGrid(_model.GetMonitoring(id));
                _view.SetRingkasan(_model.HitungMonitoring("BULAN", id), _model.HitungMonitoring("HARI_INI", id));
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}