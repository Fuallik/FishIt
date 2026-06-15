using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CPengiriman
    {
        private readonly IPengiriman _view;
        private readonly MPengiriman _model;

        public CPengiriman(IPengiriman view)
        {
            _view = view;
            _model = new MPengiriman();
        }

        public void MuatData()
        {
            try
            {
                _view.SetDataGrid(_model.GetPengiriman());
                _view.SetRingkasan(
                    _model.HitungStatus("Diproses"),
                    _model.HitungStatus("Dikirim"),
                    _model.HitungStatus("Diterima"));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}