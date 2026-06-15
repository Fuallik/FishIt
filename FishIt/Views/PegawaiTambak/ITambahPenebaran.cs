using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface ITambahPenebaran
    {
        void SetKolam(DataTable data);
        void SetBenih(DataTable data);
        void KosongkanBenih();
        void SetStok(string teks);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}