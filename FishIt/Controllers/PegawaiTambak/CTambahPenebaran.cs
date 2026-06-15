using System;
using Npgsql;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CTambahPenebaran
    {
        private readonly ITambahPenebaran _view;
        private readonly MTambahPenebaran _model;

        public CTambahPenebaran(ITambahPenebaran view) { _view = view; _model = new MTambahPenebaran(); }

        public void MuatKolam()
        {
            try { _view.SetKolam(_model.GetKolam()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void MuatBenih(int idKolam)
        {
            try { _view.SetBenih(_model.GetBenihByKolam(idKolam)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void TampilStok(int idBenih)
        {
            try { _view.SetStok(_model.GetStokBenih(idBenih) + " ekor"); }
            catch { _view.SetStok("Gagal ambil stok"); }
        }

        public void Simpan(DataPenebaran d)
        {
            if (d.IdKolam <= 0 || d.IdBenih <= 0) { _view.TampilkanPeringatan("Pilih kolam dan benih dulu!"); return; }
            if (d.Ekor <= 0) { _view.TampilkanPeringatan("Jumlah ekor harus lebih dari 0!"); return; }

            d.IdAkun = Session.IdAkun;
            try
            {
                _model.Simpan(d);
                _view.TampilkanSukses("Penebaran benih dicatat & stok otomatis diperbarui!");
                _view.TutupDialog();
            }
            catch (PostgresException pg) { _view.TampilkanPeringatan(pg.MessageText); }  // kapasitas penuh / stok benih kurang
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}