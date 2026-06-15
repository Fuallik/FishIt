using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IDetailPakan
    {
        void SetDataGrid(DataTable data);
        void TampilkanError(string pesan);
    }
}