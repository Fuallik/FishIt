using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class PanelHelper
{
    // Fungsi utama untuk mendaftarkan event
    public static void BuatMelengkung(Panel panel, int radius)
    {
        if (panel.Width <= 0 || panel.Height <= 0) return;

        // Mendaftarkan fungsi static ke event resize
        panel.Resize += (sender, e) => AturRegionMelengkung(panel, radius);

        AturRegionMelengkung(panel, radius);
    }

    // KUNCINYA: Di sini harus ditambahkan kata 'static' sebelum void
    private static void AturRegionMelengkung(Panel panel, int radius)
    {
        if (panel.Width <= 0 || panel.Height <= 0) return;

        Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
        using (GraphicsPath path = new GraphicsPath())
        {
            float diameter = radius * 2;

            path.StartFigure();
            // Atas Kiri
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            // Atas Kanan
            path.AddArc(rect.Width - diameter + rect.X, rect.Y, diameter, diameter, 270, 90);
            // Bawah Kanan
            path.AddArc(rect.Width - diameter + rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 0, 90);
            // Bawah Kiri
            path.AddArc(rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
    }
}