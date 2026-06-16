namespace FishIt.Views.Shipper
{
    /// <summary> INTERFACE (kontrak) untuk View Dashboard Shipper. </summary>
    internal interface IDashboardShipper
    {
        void SetRingkasan(int diproses, int dikirim, int diterima);
        void SetUsername(string username);
        void TampilkanPesanError(string pesan);
    }
}