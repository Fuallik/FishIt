using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IMonitoring
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(int hariIni, int satuBulan);
        void TampilkanPesanError(string pesan);
    }
}