using FishIt.Models;
using FishIt.Views.Pembeli;
using FishIt.Views.Supplier;
using System;

namespace FishIt.Controllers.Supplier
{
    internal class CKatalogPakan
    {
        private readonly IKatalogPakan _view;
        private readonly MKatalogPakan _model;

        public CKatalogPakan(IKatalogPakan view)
        {
            _view = view;
            _model = new MKatalogPakan();
        }

        public void MuatKatalog()
        {
            try { _view.SetKatalog(_model.GetKatalog()); }
            catch (Exception ex) { _view.TampilkanPesanError("Gagal memuat katalog pakan: " + ex.Message); }
        }
    }
}