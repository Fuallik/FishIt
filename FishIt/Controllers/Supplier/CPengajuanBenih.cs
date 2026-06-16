using System;
using FishIt.Models;
using FishIt.Views.Supplier;

namespace FishIt.Controllers.Supplier
{
    internal class CPengajuanBenih
    {
        private readonly IPengajuanBenih _view;
        private readonly MPengajuanBenih _model;

        public CPengajuanBenih(IPengajuanBenih view)
        {
            _view = view;
            _model = new MPengajuanBenih();
        }

        public void MuatAwal(int idAkun)
        {
            try
            {
                _view.SetDaftarJenisIkan(_model.GetDaftarJenisIkan());
                _view.SetDaftarNamaIkan(_model.GetDaftarNamaIkan());
                _view.SetRiwayat(_model.GetRiwayat(idAkun));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat data: " + ex.Message);
            }
        }
        public void JenisDipilih(string namaJenis)
        {
            if (string.IsNullOrEmpty(namaJenis)) return;
            try
            {
                _view.SetDaftarNamaIkan(_model.GetNamaIkanByJenis(namaJenis));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal menyaring nama ikan: " + ex.Message);
            }
        }

        public void NamaDipilih(string namaIkan, string jenisDipilih)
        {
            if (string.IsNullOrEmpty(namaIkan)) return;
            try
            {
                string jenisAsli = _model.GetJenisIkanByNama(namaIkan);
                if (jenisAsli == null) return;       

                if (string.IsNullOrEmpty(jenisDipilih))
                {
                    _view.SetJenisIkan(jenisAsli);
                }
                else if (!jenisDipilih.Equals(jenisAsli, StringComparison.OrdinalIgnoreCase))
                {
                    _view.TampilkanPesanInfo(
                        $"Ikan \"{namaIkan}\" sudah terdaftar sebagai {jenisAsli}, " +
                        $"bukan {jenisDipilih}. Mohon betulkan jenis ikannya.");
                }
            }
            catch
            {
            }
        }

        public void Ajukan(int idAkun, string namaJenis, string nama, string kuantitasStr)
        {
            if (string.IsNullOrEmpty(namaJenis) || string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kuantitasStr))
            {
                _view.TampilkanPesanInfo("Jenis ikan, nama, dan kuantitas wajib diisi.");
                return;
            }
            if (!decimal.TryParse(kuantitasStr, out decimal kuantitas) || kuantitas <= 0)
            {
                _view.TampilkanPesanInfo("Kuantitas harus berupa angka lebih dari 0.");
                return;
            }

            try
            {
                string jenisAsli = _model.GetJenisIkanByNama(nama);
                if (jenisAsli != null && !jenisAsli.Equals(namaJenis, StringComparison.OrdinalIgnoreCase))
                {
                    _view.TampilkanPesanInfo(
                        $"Ikan \"{nama}\" sudah terdaftar sebagai {jenisAsli}, bukan {namaJenis}. " +
                        $"Mohon betulkan jenis ikannya sebelum mengajukan.");
                    return;
                }
            }
            catch
            {
            }

            try
            {
                _model.Ajukan(idAkun, namaJenis, nama, kuantitas);
                _view.TampilkanPesanSukses("Pengajuan benih berhasil dikirim!");
                _view.ResetForm();
                MuatAwal(idAkun);
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Pengajuan gagal, semua perubahan dibatalkan.\n\nDetail: " + ex.Message);
            }
        }
    }
}