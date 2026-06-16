using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Pengajuan Benih. </summary>
    internal interface IPengajuanBenih
    {
        void SetDaftarJenisIkan(DataTable data);
        void SetDaftarNamaIkan(DataTable data);   // isi/refresh dropdown nama
        void SetRiwayat(DataTable data);
        void SetJenisIkan(string namaJenis);      // set pilihan jenis (saat auto-isi dari nama)
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
        void ResetForm();
    }
}