using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface ITambahMonitoring
    {
        void SetKolam(DataTable data);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}