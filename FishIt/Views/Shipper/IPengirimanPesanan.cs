using System.Data;

namespace FishIt.Views.Shipper
{
    /// <summary>
    /// INTERFACE (kontrak) untuk View Pengiriman Pesanan.
    /// Controller berbicara ke View hanya lewat method di sini.
    /// </summary>
    internal interface IPengirimanPesanan
    {
        void SetDataPengiriman(DataTable data);
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
    }
}