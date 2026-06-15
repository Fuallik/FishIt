using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IPengiriman
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(int diproses, int dikirim, int diterima);
        void TampilkanPesanError(string pesan);
    }
}