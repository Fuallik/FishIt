using System.Data;

namespace FishIt.Views.Kasir
{
    internal interface IKonfirmasiPembayaran
    {
        void SetAntrean(DataTable data);
        void SetDetail(DataTable data);
        void ResetSetelahKonfirmasi();
        void TampilkanSukses(string pesan);
        void TampilkanInfo(string pesan);
        void TampilkanError(string pesan);
    }
}