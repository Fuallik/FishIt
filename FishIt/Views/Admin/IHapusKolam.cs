using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IHapusKolam
    {
        void SetKolam(DataTable data);
        void TampilkanPeringatan(string pesan);
        void TampilkanInfo(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}