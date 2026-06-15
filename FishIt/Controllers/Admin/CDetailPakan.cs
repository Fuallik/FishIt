using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDetailPakan
    {
        private readonly IDetailPakan _view;
        private readonly MDetailPakan _model;

        public CDetailPakan(IDetailPakan view)
        {
            _view = view;
            _model = new MDetailPakan();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetPakan()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}