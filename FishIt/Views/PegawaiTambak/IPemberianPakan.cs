using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IPemberianPakan
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(decimal akumulasi, decimal bulan);
        void TampilkanError(string pesan);
    }
}