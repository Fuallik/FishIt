using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDataKolam
    {
        private readonly IDataKolam _view;
        private readonly MDataKolam _model;

        public CDataKolam(IDataKolam view)
        {
            _view = view;
            _model = new MDataKolam();
        }

        public void MuatData()
        {
            try
            {
                _view.SetDataGrid(_model.GetKolam());
                _view.SetJumlah(_model.HitungKolam());
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError(ex.Message);
            }
        }
    }
}