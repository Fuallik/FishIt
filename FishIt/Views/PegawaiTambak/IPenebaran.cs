using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IPenebaran
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(long akumulasi, long bulan);
        void TampilkanError(string pesan);
    }
}