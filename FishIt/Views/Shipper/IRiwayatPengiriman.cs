using System.Data;

namespace FishIt.Views.Shipper
{
    internal interface IRiwayatPengiriman
    {
        void SetDataRiwayat(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}