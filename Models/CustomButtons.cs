 using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomButton : Button
{
    private int borderRadius = 20;
    private Color borderColor = Color.Red;
    private Color backgroundColor = Color.Red;

    public int BorderRadius
    {
        get { return borderRadius; }
        set { borderRadius = value; this.Invalidate(); }
    }

    public Color BorderColor
    {
        get { return borderColor; }
        set { borderColor = value; this.Invalidate(); }
    }

    public Color BackgroundColor
    {
        get { return backgroundColor; }
        set { backgroundColor = value; this.Invalidate(); }
    }

    public CustomButton()
    {
        this.FlatStyle = FlatStyle.Flat;
        this.FlatAppearance.BorderSize = 0;
        this.BackColor = backgroundColor;
        this.ForeColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Create path for rounded rectangle
        GraphicsPath path = new GraphicsPath();
        path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
        path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
        path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
        path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90);
        path.CloseAllFigures();

        // Fill button background
        using (SolidBrush brush = new SolidBrush(backgroundColor))
        {
            pevent.Graphics.FillPath(brush, path);
        }

        // Draw button text
        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
