using System;
using FishIt.Models;
using FishIt.Views.Supplier;

namespace FishIt.Controllers.Supplier
{
    internal class CRiwayatVerifikasi
    {
        private readonly IRiwayatVerifikasi _view;
        private readonly MRiwayatVerifikasi _model;

        public CRiwayatVerifikasi(IRiwayatVerifikasi view)
        {
            _view = view;
            _model = new MRiwayatVerifikasi();
        }

        public void MuatRiwayat(int idAkun)
        {
            try { _view.SetRiwayat(_model.GetRiwayat(idAkun)); }
            catch (Exception ex) { _view.TampilkanPesanError("Gagal memuat riwayat verifikasi: " + ex.Message); }
        }
    }
}