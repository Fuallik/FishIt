using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IDataKolam
    {
        void SetDataGrid(DataTable data);
        void SetJumlah(int total);
        void TampilkanPesanError(string pesan);
    }
}