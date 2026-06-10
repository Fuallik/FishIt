using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class AutoScaleHelper
{
    private Control _container;
    private Size _originalContainerSize;
    private Dictionary<Control, Rectangle> _controlBounds = new Dictionary<Control, Rectangle>();
    private Dictionary<Control, float> _originalFonts = new Dictionary<Control, float>();

    public AutoScaleHelper(Control container)
    {
        _container = container;
        _originalContainerSize = container.Size;

        SaveBounds(_container);
        SaveFonts(_container);

        _container.Resize += Container_Resize;
    }

    private void Container_Resize(object sender, EventArgs e)
    {
        if (_originalContainerSize.Width == 0 || _originalContainerSize.Height == 0) return;

        float xRatio = (float)_container.Width / _originalContainerSize.Width;
        float yRatio = (float)_container.Height / _originalContainerSize.Height;
        float scale = Math.Min(xRatio, yRatio);

        ResizeControls(_container, xRatio, yRatio);
        ResizeFonts(_container, scale);
    }

    private void SaveBounds(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            _controlBounds[control] = control.Bounds;
            if (control.HasChildren) SaveBounds(control);
        }
    }

    private void SaveFonts(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            _originalFonts[control] = control.Font.Size;
            if (control.HasChildren) SaveFonts(control);
        }
    }

    private void ResizeControls(Control parent, float xRatio, float yRatio)
    {
        foreach (Control control in parent.Controls)
        {
            if (_controlBounds.ContainsKey(control))
            {
                Rectangle r = _controlBounds[control];
                control.SetBounds(
                    (int)(r.X * xRatio),
                    (int)(r.Y * yRatio),
                    (int)(r.Width * xRatio),
                    (int)(r.Height * yRatio)
                );
            }
            if (control.HasChildren) ResizeControls(control, xRatio, yRatio);
        }
    }

    private void ResizeFonts(Control parent, float scale)
    {
        foreach (Control control in parent.Controls)
        {
            if (_originalFonts.ContainsKey(control))
            {
                float newSize = _originalFonts[control] * scale;
                if (newSize < 1.0f) newSize = 1.0f;

                control.Font = new Font(
                    control.Font.FontFamily,
                    newSize,
                    control.Font.Style
                );
            }
            if (control.HasChildren) ResizeFonts(control, scale);
        }
    }
}