using System;
using FishIt.Models;
using FishIt.Views.Supplier;

namespace FishIt.Controllers.Supplier
{
    /// <summary> CONTROLLER Katalog Benih. </summary>
    internal class CKatalogBenih
    {
        private readonly IKatalogBenih _view;
        private readonly MKatalogBenih _model;

        public CKatalogBenih(IKatalogBenih view)
        {
            _view = view;
            _model = new MKatalogBenih();
        }

        public void MuatKatalog()
        {
            try { _view.SetKatalog(_model.GetKatalog()); }
            catch (Exception ex) { _view.TampilkanPesanError("Gagal memuat katalog benih: " + ex.Message); }
        }
    }
}