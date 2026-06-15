using System;
using System.Linq;
using FishIt.Models;
using FishIt.Views.Admin;

namespace FishIt.Controllers.Admin
{
    internal class CTambahAkun
    {
        private readonly ITambahAkun _view;
        private readonly MTambahAkun _model;

        public CTambahAkun(ITambahAkun view)
        {
            _view = view;
            _model = new MTambahAkun();
        }

        public void MuatRole()
        {
            try { _view.SetRoles(_model.GetRoles()); }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }

        public void Simpan(DataAkunBaru d)
        {
            // ===== validasi (business rules ada di Controller) =====
            if (string.IsNullOrWhiteSpace(d.Username) || string.IsNullOrWhiteSpace(d.Nama) ||
                string.IsNullOrWhiteSpace(d.Password) || string.IsNullOrWhiteSpace(d.Konfirmasi) ||
                string.IsNullOrWhiteSpace(d.Alamat) || string.IsNullOrWhiteSpace(d.Telpon) ||
                string.IsNullOrWhiteSpace(d.Kelurahan) || string.IsNullOrWhiteSpace(d.Kecamatan))
            { _view.TampilkanPeringatan("Semua data teks wajib diisi!"); return; }

            if (!d.Username.All(char.IsLetterOrDigit))
            { _view.TampilkanPeringatan("Username hanya boleh huruf dan angka (tanpa simbol/spasi)!"); return; }

            if (d.Password.Length < 8)
            { _view.TampilkanPeringatan("Password minimal 8 karakter!"); return; }

            if (d.Password.Contains(" "))
            { _view.TampilkanPeringatan("Password tidak boleh mengandung spasi!"); return; }

            if (d.Password != d.Konfirmasi)
            { _view.TampilkanPeringatan("Password dan Konfirmasi tidak cocok!"); return; }

            if (!d.Telpon.All(char.IsDigit))
            { _view.TampilkanPeringatan("Nomor telepon hanya boleh angka!"); return; }

            if (d.IdRole <= 0)
            { _view.TampilkanPeringatan("Silakan pilih Jabatan dulu!"); return; }

            // ===== eksekusi =====
            try
            {
                _model.TambahAkun(d);
                _view.TampilkanSukses(
                    $"Akun baru berhasil ditambahkan!\n" +
                    $"Wilayah Kelurahan {d.Kelurahan} - Kecamatan {d.Kecamatan} tervalidasi sistem.");
                _view.TutupDialog();
            }
            catch (Exception ex) { _view.TampilkanError(ex.Message); }
        }
    }
}