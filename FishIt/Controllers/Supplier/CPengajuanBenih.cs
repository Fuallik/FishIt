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
                _view.SetDaftarNamaIkan(_model.GetDaftarNamaIkan()); // awal: semua ikan
                _view.SetRiwayat(_model.GetRiwayat(idAkun));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat data: " + ex.Message);
            }
        }

        /// <summary>
        /// Saat supplier memilih JENIS ikan: saring dropdown nama supaya hanya
        /// menampilkan ikan dengan jenis tersebut.
        /// </summary>
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

        /// <summary>
        /// Saat supplier memilih/mengetik NAMA ikan. Tiga kemungkinan:
        /// - ikan belum ada (nama baru): jenis ikut yang dipilih supplier, tidak diapa-apakan.
        /// - ikan sudah ada & belum pilih jenis: jenis diisi otomatis.
        /// - ikan sudah ada & jenis dipilih TAPI beda: beri peringatan supaya dibetulkan.
        /// </summary>
        public void NamaDipilih(string namaIkan, string jenisDipilih)
        {
            if (string.IsNullOrEmpty(namaIkan)) return;
            try
            {
                string jenisAsli = _model.GetJenisIkanByNama(namaIkan);
                if (jenisAsli == null) return; // nama baru, biarkan jenis pilihan supplier

                if (string.IsNullOrEmpty(jenisDipilih))
                {
                    // belum pilih jenis -> isikan otomatis sesuai data ikan
                    _view.SetJenisIkan(jenisAsli);
                }
                else if (!jenisDipilih.Equals(jenisAsli, StringComparison.OrdinalIgnoreCase))
                {
                    // sudah pilih jenis tapi beda dari data ikan -> peringatkan
                    _view.TampilkanPesanInfo(
                        $"Ikan \"{namaIkan}\" sudah terdaftar sebagai {jenisAsli}, " +
                        $"bukan {jenisDipilih}. Mohon betulkan jenis ikannya.");
                }
            }
            catch
            {
                // kalau gagal cek, jangan blokir supplier
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

            // Validasi konsistensi jenis: kalau ikan sudah ada dengan jenis berbeda
            // dari yang dipilih, TOLAK pengajuan (jangan diam-diam pakai jenis lama).
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
                // kalau gagal cek, lanjut saja — trigger database tetap jadi pengaman terakhir.
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