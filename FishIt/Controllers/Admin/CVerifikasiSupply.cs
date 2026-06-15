using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CVerifikasiSupply
    {
        private readonly IVerifikasiSupply _view;
        private readonly MVerifikasiSupply _model;

        public CVerifikasiSupply(IVerifikasiSupply view)
        {
            _view = view;
            _model = new MVerifikasiSupply();
        }

        public void MuatPengajuan()
        {
            try { _view.SetPengajuan(_model.GetPengajuanPending()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        // Dipanggil View saat user tekan Enter di kolom ID
        public void Cari(string idText)
        {
            idText = (idText ?? "").Trim();

            if (string.IsNullOrWhiteSpace(idText))
            {
                _view.TampilkanPeringatan("ID Pengajuan tidak boleh kosong!");
                return;
            }
            if (!int.TryParse(idText, out int id))
            {
                _view.TampilkanPeringatan("ID Pengajuan harus berupa angka!");
                return;
            }

            try
            {
                var detail = _model.CariPengajuan(id);
                if (detail == null)
                {
                    _view.TampilkanInfo($"Pengajuan dengan ID '{idText}' tidak ditemukan atau sudah diproses!");
                    _view.ClearInput();
                    return;
                }
                _view.BukaDetail(detail);
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}