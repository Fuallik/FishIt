using FishIt.Models;
using FishIt.Views.PegawaiTambak;
using FishIt.Views.Supplier;
using System;

namespace FishIt.Controllers.Supplier
{
    internal class CPengajuanPakan
    {
        private readonly IPengajuanPakan _view;
        private readonly MPengajuanPakan _model;

        public CPengajuanPakan(IPengajuanPakan view)
        {
            _view = view;
            _model = new MPengajuanPakan();
        }

        public void MuatAwal(int idAkun)
        {
            try
            {
                _view.SetDaftarPakan(_model.GetDaftarPakan());
                _view.SetRiwayat(_model.GetRiwayat(idAkun));
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat data: " + ex.Message);
            }
        }

        public void Ajukan(int idAkun, string namaPakan, string kuantitasStr)
        {
            if (string.IsNullOrEmpty(namaPakan) || string.IsNullOrEmpty(kuantitasStr))
            {
                _view.TampilkanPesanInfo("Nama pakan dan kuantitas wajib diisi.");
                return;
            }
            if (!decimal.TryParse(kuantitasStr, out decimal kuantitas) || kuantitas <= 0)
            {
                _view.TampilkanPesanInfo("Kuantitas harus berupa angka lebih dari 0.");
                return;
            }

            try
            {
                _model.Ajukan(idAkun, namaPakan, kuantitas);
                _view.TampilkanPesanSukses("Pengajuan pakan berhasil dikirim!");
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