using System;
using Npgsql;
using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Helpers;

namespace FishIt.Controllers.PegawaiTambak
{
    internal class CTambahMonitoring
    {
        private readonly ITambahMonitoring _view;
        private readonly MTambahMonitoring _model;

        public CTambahMonitoring(ITambahMonitoring view) { _view = view; _model = new MTambahMonitoring(); }

        public void MuatKolam()
        {
            try { _view.SetKolam(_model.GetKolam()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Simpan(DataMonitoring d)
        {
            if (d.IdKolam <= 0) { _view.TampilkanPeringatan("Pilih kolam dulu!"); return; }
            if (string.IsNullOrEmpty(d.Kondisi)) { _view.TampilkanPeringatan("Pilih kondisi kolam!"); return; }
            if (d.Berat <= 0) { _view.TampilkanPeringatan("Berat rata-rata harus lebih dari 0!"); return; }

            d.IdAkun = Session.IdAkun;
            try
            {
                _model.Simpan(d);
                _view.TampilkanSukses("Data monitoring berhasil disimpan!");
                _view.TutupDialog();
            }
            catch (PostgresException pg) { _view.TampilkanPeringatan(pg.MessageText); }          
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}