using System;
using Npgsql;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CPengajuanPanen
    {
        private readonly IPengajuanPanen _view;
        private readonly MPengajuanPanen _model;

        public CPengajuanPanen(IPengajuanPanen view) { _view = view; _model = new MPengajuanPanen(); }

        public void MuatKolam()
        {
            try { _view.SetKolam(_model.GetKolam()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void MuatIkan(int idKolam)
        {
            try { _view.SetIkan(_model.GetIkanByKolam(idKolam)); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void TampilSisa(int idKolam)
        {
            try { _view.SetSisa(_model.GetSisaKolam(idKolam).ToString()); }
            catch { _view.SetSisa("0"); }
        }

        public void Simpan(DataPanen d)
        {
            if (d.IdKolam <= 0 || d.IdIkan <= 0 || string.IsNullOrEmpty(d.Kualitas))
            { _view.TampilkanPeringatan("Lengkapi kolam, ikan, dan kualitas dulu!"); return; }
            if (d.Kg <= 0 || d.Ekor <= 0)
            { _view.TampilkanPeringatan("Jumlah kg dan ekor harus lebih dari 0!"); return; }

            d.IdAkun = Session.IdAkun;
            try
            {
                _model.Simpan(d);
                _view.TampilkanSukses("Panen dicatat, kolam diperbarui & stok ikan bertambah!");
                _view.TutupDialog();
            }
            catch (PostgresException pg) { _view.TampilkanPeringatan(pg.MessageText); }  // trigger: ekor > sisa
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}