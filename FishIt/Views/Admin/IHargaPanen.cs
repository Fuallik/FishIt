using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IHargaPanen
    {
        void SetAntrean(DataTable data);
        void TampilkanKatalogDitemukan(decimal harga, string keterangan);  // harga dikunci
        void TampilkanKatalogBaru(string keterangan);                       // harga bisa diisi
        string AmbilInputHarga();
        void ResetForm();
        void TampilkanPeringatan(string pesan);
        void TampilkanInfo(string pesan);
        void TampilkanSukses(string pesan);
        void TampilkanError(string pesan);
    }
}