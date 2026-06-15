using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IDataAkun
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(int aktif, int tidakAktif, int tambak,
                          int kasir, int supplier, int shipper, int pembeli);
        void TampilkanPesanError(string pesan);
    }
}