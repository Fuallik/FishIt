using System.Data;

namespace FishIt.Views.Pembeli
{
    internal interface IKatalogIkan
    {
        void SetDataGrid(DataTable data);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
    }
}