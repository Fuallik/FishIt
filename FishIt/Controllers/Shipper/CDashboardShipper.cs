using System;
using System.Data;
using FishIt.Models;
using FishIt.Views.Shipper;

namespace FishIt.Controllers.Shipper
{
    internal class CDashboardShipper
    {
        private readonly IDashboardShipper _view;
        private readonly MDashboardShipper _model;

        public CDashboardShipper(IDashboardShipper view)
        {
            _view = view;
            _model = new MDashboardShipper();
        }

        public void MuatRingkasan(int idShipper, string username)
        {
            try
            {
                DataTable data = _model.GetRingkasanPerStatus(idShipper);

                int diproses = 0, dikirim = 0, diterima = 0;
                foreach (DataRow row in data.Rows)
                {
                    string status = row["status_pengiriman"].ToString();
                    int jumlah = Convert.ToInt32(row["jumlah"]);
                    switch (status)
                    {
                        case "Diproses": diproses = jumlah; break;
                        case "Dikirim": dikirim = jumlah; break;
                        case "Diterima": diterima = jumlah; break;
                    }
                }

                _view.SetRingkasan(diproses, dikirim, diterima);
                _view.SetUsername(string.IsNullOrEmpty(username) ? "Guest" : username);
            }
            catch (Exception ex)
            {
                _view.TampilkanPesanError("Gagal memuat ringkasan: " + ex.Message);
            }
        }
    }
}