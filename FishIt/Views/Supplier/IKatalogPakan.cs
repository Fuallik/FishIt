using System.Data;

namespace FishIt.Views.Supplier
{
    /// <summary> INTERFACE Katalog Pakan. </summary>
    internal interface IKatalogPakan
    {
        void SetKatalog(DataTable data);
        void TampilkanPesanError(string pesan);
    }
}