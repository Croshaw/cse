using System.Globalization;

namespace Lab6.GUI.Controls;

public readonly struct PointD
{
    public double X { get; }
    public double Y { get; }

    public PointD()
    {
        X = Y = 0;
    }

    public PointD(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public static class Utils
{
    public static void OnlyDoubleNumbers(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            e.Handled = true;

        if (sender is TextBox textBox && e.KeyChar is '.' or ',' && (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            e.Handled = true;
    }
}

public class PointControl : FlowLayoutPanel
{
    private TextBox XTB;
    private TextBox YTB;
    public PointD Point
    {
        get => new PointD(double.Parse(XTB.Text, CultureInfo.InvariantCulture), double.Parse(YTB.Text, CultureInfo.InvariantCulture));
        set
        {
            XTB.Text = value.X.ToString(CultureInfo.InvariantCulture);
            YTB.Text = value.Y.ToString(CultureInfo.InvariantCulture);
        }
    }
    public bool ReadOnlyX { get => XTB.ReadOnly; set => XTB.ReadOnly = value; }
    public bool ReadOnlyY { get => YTB.ReadOnly; set => YTB.ReadOnly = value; }

    public PointControl()
    {
        XTB = new TextBox()
        {
            AutoSize = true,
            Width = 60,
            TextAlign = HorizontalAlignment.Center
        };
        YTB = new TextBox()
        {
            AutoSize = true,
            Width = 60,
            TextAlign = HorizontalAlignment.Center
        };
        XTB.KeyPress += Utils.OnlyDoubleNumbers;
        YTB.KeyPress += Utils.OnlyDoubleNumbers;
        Point = new PointD();
        
        Controls.Add(XTB);
        Controls.Add(YTB);
    }
    
}