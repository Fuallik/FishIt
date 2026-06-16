using System.Data;

namespace FishIt.Views.Shipper
{
    /// <summary> INTERFACE (kontrak) untuk View Riwayat Pengiriman. </summary>
    internal interface IRiwayatPengiriman
    {
        void SetDataRiwayat(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}