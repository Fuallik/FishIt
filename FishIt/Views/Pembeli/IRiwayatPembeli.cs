using System.Data;

namespace FishIt.Views.Pembeli
{
    internal interface IRiwayatPembeli
    {
        void SetDataGrid(DataTable data);
        void TampilkanError(string pesan);
    }
}