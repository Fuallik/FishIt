using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDetailIkan
    {
        private readonly IDetailIkan _view;
        private readonly MDetailIkan _model;

        public CDetailIkan(IDetailIkan view)
        {
            _view = view;
            _model = new MDetailIkan();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetIkan()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}