using System.Data;

namespace FishIt.Views.Shipper
{
    internal interface IPengirimanPesanan
    {
        void SetDataPengiriman(DataTable data);
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
    }
}