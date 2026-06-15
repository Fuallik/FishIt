using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CStokIkan
    {
        private readonly IStokIkan _view;
        private readonly MStokIkan _model;

        public CStokIkan(IStokIkan view)
        {
            _view = view;
            _model = new MStokIkan();
        }

        public void MuatData()
        {
            try
            {
                _view.SetRingkasan(_model.TotalIkan(), _model.TotalBenih(), _model.TotalPakan());
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}