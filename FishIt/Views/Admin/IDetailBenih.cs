using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IDetailBenih
    {
        void SetDataGrid(DataTable data);
        void TampilkanError(string pesan);
    }
}