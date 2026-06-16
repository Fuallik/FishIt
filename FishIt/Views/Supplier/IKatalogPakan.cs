using System.Data;

namespace FishIt.Views.Supplier
{
    internal interface IKatalogPakan
    {
        void SetKatalog(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}