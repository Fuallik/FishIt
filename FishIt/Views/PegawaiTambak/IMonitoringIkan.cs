using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IMonitoringIkan
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(int totalBulan, int totalHari);
        void TampilkanError(string pesan);
    }
}