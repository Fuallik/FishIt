using System.Data;

namespace FishIt.Views.Supplier
{
    internal interface IPengajuanBenih
    {
        void SetDaftarJenisIkan(DataTable data);
        void SetDaftarNamaIkan(DataTable data);      
        void SetRiwayat(DataTable data);
        void SetJenisIkan(string namaJenis);             
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
        void ResetForm();
    }
}