using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CTambahKolam
    {
        private readonly ITambahKolam _view;
        private readonly MTambahKolam _model;

        public CTambahKolam(ITambahKolam view)
        {
            _view = view;
            _model = new MTambahKolam();
        }

        public void MuatJenisIkan()
        {
            try { _view.SetJenisIkan(_model.GetJenisIkan()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Simpan(DataKolamBaru d)
        {
            if (string.IsNullOrWhiteSpace(d.Nomor))
            { _view.TampilkanPeringatan("Nomor/Nama kolam wajib diisi!"); return; }

            if (!int.TryParse(d.Panjang?.Trim(), out int p) || p <= 0)
            { _view.TampilkanPeringatan("Panjang harus angka lebih dari 0!"); return; }
            if (!int.TryParse(d.Lebar?.Trim(), out int l) || l <= 0)
            { _view.TampilkanPeringatan("Lebar harus angka lebih dari 0!"); return; }
            if (!int.TryParse(d.Tinggi?.Trim(), out int t) || t <= 0)
            { _view.TampilkanPeringatan("Tinggi harus angka lebih dari 0!"); return; }
            if (!int.TryParse(d.Kapasitas?.Trim(), out int kapasitas) || kapasitas <= 0)
            { _view.TampilkanPeringatan("Kapasitas harus angka lebih dari 0!"); return; }

            if (d.IdJenis <= 0)
            { _view.TampilkanPeringatan("Pilih jenis ikan dulu!"); return; }

            string ukuran = $"{p}x{l}x{t}";     

            try
            {
                if (_model.NomorSudahAda(d.Nomor.Trim()))
                {
                    _view.TampilkanPeringatan($"Nomor/Nama kolam '{d.Nomor.Trim()}' sudah ada! Pakai yang lain.");
                    return;
                }

                _model.TambahKolam(d.Nomor.Trim(), ukuran, kapasitas, d.IdJenis);
                _view.TampilkanSukses("Kolam berhasil ditambahkan!");
                _view.TutupDialog();
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}