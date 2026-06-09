using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FishIt
{
    public static class GridHelper
    {
        public static void AturTemaModern(DataGridView dgv)
        {
            // 1. Pengaturan Dasar & Kebersihan Tabel
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(235, 237, 240); // Garis pembatas tipis abu-abu muda
            dgv.RowHeadersVisible = false; // Menghilangkan kolom kosong paling kiri
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Klik baris langsung memblok satu baris penuh
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false; // Mencegah user mengacak-acak tinggi baris
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Hanya garis horizontal, vertikal dihilangkan

            // 2. Desain Header Kolom (Bagian Atas)
            dgv.EnableHeadersVisualStyles = false; // Wajib di-false agar custom warna berfungsi
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.FromArgb(41, 128, 185); // Warna utama (Misal: Biru Royal)
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 40; // Membuat header lebih tinggi dan lega

            // 3. Desain Baris Data (Rows)
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
            rowStyle.BackColor = Color.White;
            rowStyle.ForeColor = Color.FromArgb(45, 52, 54); // Warna teks abu-abu gelap (lebih lembut dari hitam pekat)
            rowStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            rowStyle.SelectionBackColor = Color.FromArgb(225, 242, 250); // Warna saat baris diklik (Biru sangat muda)
            rowStyle.SelectionForeColor = Color.FromArgb(41, 128, 185); // Warna teks saat diklik
            dgv.RowsDefaultCellStyle = rowStyle;

            // 4. Efek Zebra (Baris Selang-Seling) untuk Mempermudah Membaca Data
            DataGridViewCellStyle altRowStyle = new DataGridViewCellStyle();
            altRowStyle.BackColor = Color.FromArgb(248, 249, 250); // Abu-abu super muda untuk baris genap
            dgv.AlternatingRowsDefaultCellStyle = altRowStyle;

            // 5. Atur Tinggi Baris Data
            dgv.RowTemplate.Height = 35;

            // 6. Pengaturan Ukuran Kolom Otomatis
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolom otomatis melar memenuhi layar
        }
    }
}
