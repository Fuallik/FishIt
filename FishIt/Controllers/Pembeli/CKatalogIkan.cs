using System;
using FishIt.Models;
using FishIt.Views.Pembeli;
using FishIt.Helpers;

namespace FishIt.Controllers.Pembeli
{
    internal class CKatalogIkan
    {
        private readonly IKatalogIkan _view;
        private readonly MKatalogIkan _model;

        public CKatalogIkan(IKatalogIkan view)
        {
            _view = view;
            _model = new MKatalogIkan();
        }

        public void MuatData()
        {
            try { _view.SetDataGrid(_model.GetKatalog()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void TambahKeKeranjang(int idIkan, string namaIkan, decimal stok, decimal kuantitas)
        {
            if (kuantitas <= 0)
            {
                _view.TampilkanPeringatan("Tentukan jumlah Kg terlebih dahulu di kotak jumlah!");
                return;
            }
            if (kuantitas > stok)
            {
                _view.TampilkanPeringatan(
                    $"Kuantitas melebihi stok! Stok {namaIkan} yang tersedia hanya {stok} Kg.");
                return;
            }

            try
            {
                _model.TambahKeKeranjang(Session.IdAkun, idIkan, kuantitas);
                _view.TampilkanSukses($"Berhasil memasukkan {kuantitas} Kg {namaIkan} ke keranjang!");
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}