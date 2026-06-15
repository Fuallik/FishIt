using System.Data;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IStatusKolam
    {
        void SetDataGrid(DataTable data);
        void SetRingkasan(int terisi, int kosong, int tidakTerpakai);
        void TampilkanError(string pesan);
    }
}