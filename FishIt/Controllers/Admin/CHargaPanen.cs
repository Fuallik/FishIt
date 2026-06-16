using System;
using System.Globalization;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CHargaPanen
    {
        private readonly IHargaPanen _view;
        private readonly MHargaPanen _model;

        private int _idPanen = 0;
        private string _nama = "";
        private int _idJenis = 0;
        private int _idKualitas = 0;
        private decimal _jumlahKg = 0;
        private HasilKatalog _katalog;

        public CHargaPanen(IHargaPanen view)
        {
            _view = view;
            _model = new MHargaPanen();
        }

        public void MuatAntrean()
        {
            try { _view.SetAntrean(_model.GetAntrean()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void PilihPanen(int idPanen, string nama, int idJenis, int idKualitas,
                               decimal jumlahKg, string kualitasChar)
        {
            try
            {
                _idPanen = idPanen; _nama = nama; _idJenis = idJenis;
                _idKualitas = idKualitas; _jumlahKg = jumlahKg;

                _katalog = _model.CariKatalog(nama, idJenis, idKualitas);

                if (_katalog.Ditemukan)
                    _view.TampilkanKatalogDitemukan(_katalog.Harga,
                        $"{nama} (Kualitas {kualitasChar}) — sudah di katalog, hanya tambah stok");
                else
                    _view.TampilkanKatalogBaru(
                        $"{nama} (Kualitas {kualitasChar}) — BARU, isi harga dulu");
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Simpan()
        {
            if (_idPanen == 0)
            {
                _view.TampilkanPeringatan("Pilih panen di antrean dulu!");
                return;
            }

            decimal harga = 0;
            bool entriBaru = _katalog == null || !_katalog.Ditemukan;
            if (entriBaru)
            {
                if (!decimal.TryParse(_view.AmbilInputHarga().Trim(), NumberStyles.Any,
                        CultureInfo.InvariantCulture, out harga) || harga <= 0)
                {
                    _view.TampilkanPeringatan("Isi harga per kg dengan angka lebih dari 0!");
                    return;
                }
            }

            try
            {
                bool berhasil = _model.ProsesHarga(_idPanen, _katalog, harga,
                                                   _nama, _idJenis, _idKualitas, _jumlahKg);
                if (!berhasil)
                {
                    _view.TampilkanInfo("Panen ini sudah diproses sebelumnya. Coba refresh.");
                    MuatAntrean();
                    return;
                }

                _view.TampilkanSukses("Stok masuk ke katalog sesuai kualitasnya!");
                _idPanen = 0; _katalog = null;
                _view.ResetForm();
                MuatAntrean();
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}