using System;
using FishIt.Models;
using FishIt.Views.Kasir;

namespace FishIt.Controllers.Kasir
{
    internal class CKonfirmasiPembayaran
    {
        private readonly IKonfirmasiPembayaran _view;
        private readonly MKonfirmasiPembayaran _model;

        public CKonfirmasiPembayaran(IKonfirmasiPembayaran view)
        {
            _view = view;
            _model = new MKonfirmasiPembayaran();
        }

        public void MuatAntrean()
        {
            try { _view.SetAntrean(_model.GetAntrean()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void MuatDetail(int idOrder)
        {
            try { _view.SetDetail(_model.GetItem(idOrder)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Konfirmasi(int idOrder)
        {
            try
            {
                switch (_model.Konfirmasi(idOrder))
                {
                    case HasilKonfirmasi.Sukses:
                        _view.TampilkanSukses("Pembayaran dikonfirmasi (Lunas), stok dikurangi & diteruskan ke Shipper!");
                        _view.ResetSetelahKonfirmasi();
                        MuatAntrean();
                        break;
                    case HasilKonfirmasi.SudahDikonfirmasi:
                        _view.TampilkanInfo("Order sudah dikonfirmasi sebelumnya. Coba refresh.");
                        MuatAntrean();
                        break;
                    case HasilKonfirmasi.TanpaShipper:
                        _view.TampilkanInfo("Tidak ada Shipper aktif! Pembayaran dibatalkan. Minta admin menambah Shipper dulu.");
                        break;
                }
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}