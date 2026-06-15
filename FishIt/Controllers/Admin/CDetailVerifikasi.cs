using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CDetailVerifikasi
    {
        private readonly IDetailVerifikasi _view;
        private readonly MDetailVerifikasi _model;

        public CDetailVerifikasi(IDetailVerifikasi view)
        {
            _view = view;
            _model = new MDetailVerifikasi();
        }

        public void Setujui(int id) =>
            Proses(id, "Disetujui", "Pengajuan supply BERHASIL DISETUJUI dan stok master bertambah otomatis!");

        public void Tolak(int id) =>
            Proses(id, "Ditolak", "Pengajuan supply telah ditolak.");

        // Satu jalur untuk ACC & Tolak, beda status + pesan
        private void Proses(int id, string status, string pesanSukses)
        {
            try
            {
                _model.UbahStatus(id, status);
                _view.TampilkanSukses(pesanSukses);
                _view.TutupDialog();
            }
            catch (Exception ex)
            {
                _view.TampilkanError(ex.Message);
            }
        }
    }
}