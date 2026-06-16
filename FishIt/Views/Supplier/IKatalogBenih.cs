using System.Data;

namespace FishIt.Views.Supplier
{
    internal interface IKatalogBenih
    {
        void SetKatalog(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}