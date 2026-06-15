using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IPengajuanPanen
    {
        void SetKolam(DataTable data);
        void SetIkan(DataTable data);
        void KosongkanIkan();
        void SetSisa(string teks);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}