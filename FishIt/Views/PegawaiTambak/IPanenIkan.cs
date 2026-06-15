using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IPanenIkan
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(decimal akumulasi, decimal tahun);
        void TampilkanError(string pesan);
    }
}