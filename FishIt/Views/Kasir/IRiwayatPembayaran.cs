using System.Data;

namespace FishIt.Views.Kasir
{
    internal interface IRiwayatPembayaran
    {
        void SetDataGrid(DataTable data);
        void SetDetail(DataTable data);
        void TampilkanError(string pesan);
    }
}