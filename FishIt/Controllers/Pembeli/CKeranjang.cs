using System;
using FishIt.Models;
using FishIt.Views.Pembeli;
using FishIt.Helpers;

namespace FishIt.Controllers.Pembeli
{
    internal class CKeranjang
    {
        private readonly IKeranjang _view;
        private readonly MKeranjang _model;

        public CKeranjang(IKeranjang view)
        {
            _view = view;
            _model = new MKeranjang();
        }

        public void MuatData()
        {
            if (Session.IdAkun <= 0)
            {
                _view.TampilkanPeringatan("Sesi pengguna tidak valid. Silakan login kembali.");
                return;
            }
            try { _view.SetDataGrid(_model.GetKeranjang(Session.IdAkun)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Checkout(int idMetode)
        {
            if (idMetode <= 0)
            {
                _view.TampilkanPeringatan("Silakan pilih metode pembayaran terlebih dahulu!");
                return;
            }

            try
            {
                var hasil = _model.Checkout(Session.IdAkun, idMetode);
                if (hasil.Sukses)
                {
                    _view.TampilkanSukses(hasil.Pesan);
                    _view.BukaRiwayat();
                }
                else
                {
                    // pesan gagal datang langsung dari logic PostgreSQL (mis. keranjang kosong)
                    _view.TampilkanGagalCheckout(hasil.Pesan);
                }
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void HapusItem(int idKeranjang)
        {
            try
            {
                _model.HapusItem(idKeranjang);
                _view.TampilkanSukses("Item berhasil dihapus dari keranjang.");
                MuatData();   // refresh grid
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}