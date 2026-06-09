using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishIt
{
    public partial class FormKonfirmasiHapus : Form
    {
        public FormKonfirmasiHapus()
        {
            InitializeComponent();
        }

        private void FormKonfirmasiHapus_Load(object sender, EventArgs e)
        {

        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UsernameTarget { get; set; }

        public FormKonfirmasiHapus(string username, string nama, string alamat, string telp, string kelurahan, string kecamatan)
        {
            InitializeComponent();

            // Tangkap username rahasia untuk proses eksekusi nanti
            this.UsernameTarget = username;

            // Tampilkan data ke TextBox/Label di Form Pop-up ini
            TBNama.Text = nama;
            TBUsername.Text = username;
            TBAlamat.Text = alamat;
            TBTelpon.Text = telp;
            TBKelurahan.Text = kelurahan;
            TBKecamatan.Text = kecamatan;

            // Set semua komponen agar tidak bisa diedit oleh admin
            TBNama.ReadOnly = true;
            TBUsername.ReadOnly = true;
            TBAlamat.ReadOnly = true;
            TBTelpon.ReadOnly = true;
            TBKelurahan.ReadOnly = true;
            TBKecamatan.ReadOnly = true;
        }

        private void btnYaHapus_Click(object sender, EventArgs e)
        {
            // Sinyal bahwa admin setuju menghapus setelah melihat detail
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnHapusAkun_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnBatalHapusAkun_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}