using System;
using FishIt.Models;
using FishIt.Views.Kasir;

namespace FishIt.Controllers.Kasir
{
    internal class CRiwayatPembayaran
    {
        private readonly IRiwayatPembayaran _view;
        private readonly MRiwayatPembayaran _model;

        public CRiwayatPembayaran(IRiwayatPembayaran view)
        {
            _view = view;
            _model = new MRiwayatPembayaran();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetRiwayat()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void MuatDetail(int idOrder)
        {
            try { _view.SetDetail(_model.GetDetail(idOrder)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}