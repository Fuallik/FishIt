using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Pengajuan Benih. </summary>
    internal interface IPengajuanBenih
    {
        void SetDaftarJenisIkan(DataTable data);
        void SetDaftarNamaIkan(DataTable data);
        void SetRiwayat(DataTable data);
        void KunciJenisIkan(string namaJenis);  // auto-isi + kunci saat ikan sudah ada
        void BukaJenisIkan();                    // buka lagi untuk nama baru
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
        void ResetForm();
    }
}