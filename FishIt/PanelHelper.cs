using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class PanelHelper
{
    public static void BuatMelengkung(Panel panel, int radius)
    {
        if (panel.Width <= 0 || panel.Height <= 0) return;

        panel.Resize += (sender, e) => AturRegionMelengkung(panel, radius);

        AturRegionMelengkung(panel, radius);
    }

    private static void AturRegionMelengkung(Panel panel, int radius)
    {
        if (panel.Width <= 0 || panel.Height <= 0) return;

        Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
        using (GraphicsPath path = new GraphicsPath())
        {
            float diameter = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Width - diameter + rect.X, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Width - diameter + rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Height - diameter + rect.Y, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
    }
    public static void MakeButtonRounded(Button btn, int radius)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;

        btn.Paint += (sender, e) =>
        {
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.StartFigure();
                gp.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                gp.AddArc(new Rectangle(rect.Width - radius - 1, 0, radius, radius), 270, 90);
                gp.AddArc(new Rectangle(rect.Width - radius - 1, rect.Height - radius - 1, radius, radius), 0, 90);
                gp.AddArc(new Rectangle(0, rect.Height - radius - 1, radius, radius), 90, 90);
                gp.CloseFigure();

                btn.Region = new Region(gp);
            }
        };
    }
    public static void ShowUserControl(Panel pnl, UserControl uc)
    {
        // Bersihkan UserControl lama yang ada di panel konten
        pnl.Controls.Clear();

        // Atur agar ukurannya otomatis penuh mengikuti panel
        uc.Dock = DockStyle.Fill;

        // Masukkan UserControl baru ke dalam panel, lalu tampilkan
        pnl.Controls.Add(uc);
        uc.BringToFront();
    }
}