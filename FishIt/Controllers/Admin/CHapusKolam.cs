using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CHapusKolam
    {
        private readonly IHapusKolam _view;
        private readonly MHapusKolam _model;

        public CHapusKolam(IHapusKolam view)
        {
            _view = view;
            _model = new MHapusKolam();
        }

        public void MuatKolam()
        {
            try { _view.SetKolam(_model.GetKolamKosong()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        // Konfirmasi Yes/No sudah dilakukan di View (murni UI). Di sini tinggal eksekusi.
        public void Hapus(int idKolam, string nomorKolam)
        {
            try
            {
                int baris = _model.HapusKolam(idKolam);
                if (baris > 0)
                {
                    _view.TampilkanSukses($"Kolam '{nomorKolam}' ditandai Tidak Terpakai.");
                    _view.TutupDialog();
                }
                else
                {
                    _view.TampilkanInfo("Kolam tidak bisa dihapus (mungkin sudah terisi). Coba refresh.");
                }
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}