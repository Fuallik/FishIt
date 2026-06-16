using System;
using FishIt.Models;
using FishIt.Views.Shipper;

namespace FishIt.Controllers.Shipper
{
    internal class CRiwayatPengiriman
    {
        private readonly IRiwayatPengiriman _view;
        private readonly MRiwayatPengiriman _model;

        public CRiwayatPengiriman(IRiwayatPengiriman view)
        {
            _view = view;
            _model = new MRiwayatPengiriman();
        }

        public void MuatRiwayat(int idShipper)
        {
            try
            {
                _view.SetDataRiwayat(_model.GetRiwayat(idShipper));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat riwayat: " + ex.Message);
            }
        }
    }
}