using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IDetailIkan
    {
        void SetDataGrid(DataTable data);
        void TampilkanError(string pesan);
    }
}