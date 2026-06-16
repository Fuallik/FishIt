using System;
using System.Data;
using FishIt.Models;
using FishIt.Views.Supplier;

namespace FishIt.Controllers.Supplier
{
    /// <summary> CONTROLLER Dashboard Supplier. </summary>
    internal class CDashboardSupplier
    {
        private readonly IDashboardSupplier _view;
        private readonly MDashboardSupplier _model;

        public CDashboardSupplier(IDashboardSupplier view)
        {
            _view = view;
            _model = new MDashboardSupplier();
        }

        public void MuatRingkasan(int idAkun, string username)
        {
            try
            {
                DataTable data = _model.GetRingkasanPerStatus(idAkun);

                // Terjemahkan baris status -> tiga angka. Status tak muncul = 0.
                // 'Pending' = menunggu verifikasi (sesuai pengajuan & layar Admin).
                int menunggu = 0, disetujui = 0, ditolak = 0;
                foreach (DataRow row in data.Rows)
                {
                    string status = row["status_verifikasi"].ToString();
                    int jumlah = Convert.ToInt32(row["jumlah"]);
                    switch (status)
                    {
                        case "Pending": menunggu = jumlah; break;
                        case "Disetujui": disetujui = jumlah; break;
                        case "Ditolak": ditolak = jumlah; break;
                    }
                }

                _view.SetRingkasan(menunggu, disetujui, ditolak);
                _view.SetUsername(string.IsNullOrEmpty(username) ? "Guest" : username);
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat ringkasan: " + ex.Message);
            }
        }
    }
}