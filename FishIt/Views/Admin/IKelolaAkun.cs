using System.Data;

namespace FishIt.Views.Admin
{
    internal interface IKelolaAkun
    {
        void SetDataRiwayat(DataTable data);
        void SetRingkasan(int aktif, int tidakAktif);
        void TampilkanPesanError(string pesan);
    }
}