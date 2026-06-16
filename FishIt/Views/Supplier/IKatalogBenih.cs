using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Katalog Benih. </summary>
    internal interface IKatalogBenih
    {
        void SetKatalog(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}