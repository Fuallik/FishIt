namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE (kontrak) untuk View Dashboard Supplier. </summary>
    internal interface IDashboardSupplier
    {
        void SetRingkasan(int menunggu, int disetujui, int ditolak);
        void SetUsername(string username);
        void TampilkanPesanError(string pesan);
    }
}