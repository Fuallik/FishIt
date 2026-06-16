namespace FishIt.Views.Admin
{
    internal interface IDetailVerifikasi
    {
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}