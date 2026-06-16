using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Pengajuan Pakan. </summary>
    internal interface IPengajuanPakan
    {
        void SetDaftarPakan(DataTable data);
        void SetRiwayat(DataTable data);
        void TampilkanPesanInfo(string pesan);
        void TampilkanPesanError(string pesan);
        void TampilkanPesanSukses(string pesan);
        void ResetForm();
    }
}