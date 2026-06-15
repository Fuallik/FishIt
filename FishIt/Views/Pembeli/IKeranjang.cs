using System.Data;

namespace FishIt.Views.Pembeli
{
    internal interface IKeranjang
    {
        void SetDataGrid(DataTable data);
        void TampilkanPeringatan(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanGagalCheckout(string pesan);
        void TampilkanError(string pesan);
        void BukaRiwayat();   // navigasi ke halaman riwayat (UI murni)
    }
}