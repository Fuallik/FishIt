namespace FishIt.Views.Supplier
{
    internal interface IDashboardSupplier
    {
        void SetRingkasan(int menunggu, int disetujui, int ditolak);
        void SetUsername(string username);
        void TampilkanPesanError(string pesan);
    }
}