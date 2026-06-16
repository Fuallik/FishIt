using System.Data;

namespace FishIt.Views.Supplier
{
    internal interface IRiwayatVerifikasi
    {
        void SetRiwayat(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}