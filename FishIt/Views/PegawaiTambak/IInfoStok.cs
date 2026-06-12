using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishIt.Views.PegawaiTambak
{
    internal interface IInfoStok
    {
        void SetDataPakan(DataTable data);
        void SetDataBenih(DataTable data);
        void SetRingkasanPakan(decimal jenis, decimal total);
        void SetRingkasanBenih(decimal jenis, decimal total);
        void TampilkanPesanError(string pesan);
    }
}
