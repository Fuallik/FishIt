using System.Data;
using FishIt.Models;

namespace FishIt.Views.Admin
{
    internal interface IVerifikasiSupply
    {
        void SetPengajuan(DataTable data);
        void BukaDetail(DetailPengajuan data);
        void ClearInput();
        void TampilkanPeringatan(string pesan);
        void TampilkanInfo(string pesan);
        void TampilkanError(string pesan);
    }
}