using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface ITambahPemberianPakan
    {
        void SetKolam(DataTable data);
        void SetPakan(DataTable data);     // sekaligus aktifkan dropdown pakan
        void MatikanPakan();               // kosongkan + nonaktifkan
        void SetStok(string teks);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}