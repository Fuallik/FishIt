using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Riwayat Verifikasi. </summary>
    internal interface IRiwayatVerifikasi
    {
        void SetRiwayat(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}