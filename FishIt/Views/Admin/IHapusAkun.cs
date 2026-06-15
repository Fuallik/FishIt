using FishIt.Models;

namespace FishIt.Views.Admin
{
    internal interface IHapusAkun
    {
        void BukaKonfirmasi(DetailAkunHapus data);
        void ClearInput();
        void TampilkanPeringatan(string pesan);
        void TampilkanInfo(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}