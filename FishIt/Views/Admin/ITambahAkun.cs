using System.Data;

namespace FishIt.Views.Admin
{
    internal interface ITambahAkun
    {
        void SetRoles(DataTable data);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
        void TutupDialog();
    }
}