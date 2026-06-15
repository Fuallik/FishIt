namespace FishIt.Views.Admin
{
    internal interface IStokIkan
    {
        void SetRingkasan(decimal totalIkan, decimal totalBenih, decimal totalPakan);
        void TampilkanPesanError(string pesan);
    }
}