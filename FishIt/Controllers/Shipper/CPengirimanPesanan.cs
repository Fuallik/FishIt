using System;
using FishIt.Models;
using FishIt.Views.Shipper;

namespace FishIt.Controllers.Shipper
{
    internal class CPengirimanPesanan
    {
        private readonly IPengirimanPesanan _view;
        private readonly MPengirimanPesanan _model;

        public CPengirimanPesanan(IPengirimanPesanan view)
        {
            _view = view;
            _model = new MPengirimanPesanan();
        }

        public void MuatData(int idShipper)
        {
            try
            {
                _view.SetDataPengiriman(_model.GetPengirimanAktif(idShipper));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat data pengiriman: " + ex.Message);
            }
        }

        public void MulaiKirim(int idPengiriman, int idShipper)
        {
            try
            {
                int baris = _model.MulaiKirim(idPengiriman, idShipper);
                if (baris > 0)
                {
                    _view.TampilkanPesanSukses("Pesanan ditandai sedang dikirim.");
                    MuatData(idShipper);
                }
                else
                {
                    _view.TampilkanPesanInfo("Tidak ada perubahan. Mungkin status sudah berubah, coba Refresh.");
                }
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memperbarui status: " + ex.Message);
            }
        }

        public void TandaiDiterima(int idPengiriman, int idShipper)
        {
            try
            {
                int baris = _model.TandaiDiterima(idPengiriman, idShipper);
                if (baris > 0)
                {
                    _view.TampilkanPesanSukses("Pesanan ditandai sudah diterima pembeli.");
                    MuatData(idShipper);
                }
                else
                {
                    _view.TampilkanPesanInfo("Tidak ada perubahan. Mungkin status sudah berubah, coba Refresh.");
                }
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memperbarui status: " + ex.Message);
            }
        }
    }
}