namespace FishIt.Views.Shipper
{
    internal interface IDashboardShipper
    {
        void SetRingkasan(int diproses, int dikirim, int diterima);
        void SetUsername(string username);
        void TampilkanPesanError(string pesan);
    }
}