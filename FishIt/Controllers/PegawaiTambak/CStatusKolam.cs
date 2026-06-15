using System;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CStatusKolam
    {
        private readonly IStatusKolam _view;
        private readonly MStatusKolam _model;

        public CStatusKolam(IStatusKolam view) { _view = view; _model = new MStatusKolam(); }

        public void MuatData()
        {
            try
            {
                _view.SetDataGrid(_model.GetStatusKolam());
                _view.SetRingkasan(
                    _model.HitungKolam("Terisi"),
                    _model.HitungKolam("Kosong"),
                    _model.HitungKolam("Tidak Terpakai"));
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}