using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDetailBenih
    {
        private readonly IDetailBenih _view;
        private readonly MDetailBenih _model;

        public CDetailBenih(IDetailBenih view)
        {
            _view = view;
            _model = new MDetailBenih();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetBenih()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}