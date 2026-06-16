using System;
using FishIt.Models;
using FishIt.Views.Supplier;

namespace FishIt.Controllers.Supplier
{
    /// <summary> CONTROLLER Pengajuan Benih. </summary>
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

        /// <summary> Saat supplier memilih nama ikan: auto-isi & kunci jenis bila sudah ada. </summary>
        public void NamaDipilih(string namaIkan)
        {
            if (string.IsNullOrEmpty(namaIkan)) return;
            try
            {
                string jenis = _model.GetJenisIkanByNama(namaIkan);
                if (jenis != null) _view.KunciJenisIkan(jenis);
                else _view.BukaJenisIkan();
            }
            catch
            {
                _view.BukaJenisIkan(); // kalau gagal cek, jangan blokir supplier
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