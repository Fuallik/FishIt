using System;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CHapusAkun
    {
        private readonly IHapusAkun _view;
        private readonly MHapusAkun _model;
        private string _username = "";   // username yang sedang diproses

        public CHapusAkun(IHapusAkun view)
        {
            _view = view;
            _model = new MHapusAkun();
        }

        public void Cari(string username)
        {
            username = (username ?? "").Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                _view.TampilkanPeringatan("Username tidak boleh kosong!");
                return;
            }

            try
            {
                var d = _model.CariAkun(username);
                if (d == null)
                {
                    _view.TampilkanInfo($"Akun '{username}' tidak ditemukan atau sudah tidak aktif!");
                    _view.ClearInput();
                    return;
                }
                _username = username;
                _view.BukaKonfirmasi(d);
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        // Dipanggil View kalau user klik "Ya" di popup konfirmasi
        public void Hapus()
        {
            try
            {
                _model.HapusAkun(_username);
                _view.TampilkanSukses($"Akun '{_username}' berhasil dinonaktifkan dari sistem!");
                _view.TutupDialog();
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}