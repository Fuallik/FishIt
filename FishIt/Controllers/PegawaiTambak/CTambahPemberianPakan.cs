using System;
using Npgsql;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CTambahPemberianPakan
    {
        private readonly ITambahPemberianPakan _view;
        private readonly MTambahPemberianPakan _model;

        public CTambahPemberianPakan(ITambahPemberianPakan view)
        { _view = view; _model = new MTambahPemberianPakan(); }

        public void MuatKolam()
        {
            try { _view.SetKolam(_model.GetKolam()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void MuatPakan()
        {
            try { _view.SetPakan(_model.GetPakan()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void TampilStok(int idPakan)
        {
            try { _view.SetStok($" {_model.GetStokPakan(idPakan):N2} kg"); }
            catch { _view.SetStok("Gagal ambil stok"); }
        }

        public void Simpan(DataPemberianPakan d)
        {
            if (d.IdKolam <= 0 || d.IdPakan <= 0) { _view.TampilkanPeringatan("Pilih kolam dan pakan dulu!"); return; }
            if (d.Jumlah <= 0) { _view.TampilkanPeringatan("Jumlah pakan harus lebih dari 0!"); return; }

            d.IdAkun = Session.IdAkun;
            try
            {
                _model.Simpan(d);
                _view.TampilkanSukses("Pemberian pakan dicatat & stok diperbarui!");
                _view.TutupDialog();
            }
            catch (PostgresException pg) { _view.TampilkanPeringatan(pg.MessageText); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}