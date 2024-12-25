using System.Text;
using Lab6.GUI.Controls;

namespace Lab6.GUI;

public class NewtonInterpolation
{
    private string? _formula;
    public PointD[] Points { get; }
    public double[] DivDif { get; }
    public NewtonInterpolation(double[] x, double[] y)
    {
        if(x.Length != y.Length)
            throw new ArgumentException();
        Points = x.Select((x, i) => new PointD(x, y[i])).ToArray();
        DivDif = Points.Select(p => p.Y).ToArray();
        DividedDifferences();
    }
    public NewtonInterpolation(PointD[] points)
    {
        Points = points;
        DivDif = Points.Select(p => p.Y).ToArray();
        DividedDifferences();
    }
    private void DividedDifferences()
    {
        var n = Points.Length;
        for (var i = 1; i < n; i++)
        {
            for(var j = n-1; j>=i;j--)
            {
                DivDif[j] = (DivDif[j] - DivDif[j - 1]) / (Points[j].X - Points[j - i].X);
            }
        }
    }
    public double Calculate(double x)
    {
        var result = DivDif[0];
        double term = 1;

        for (var i = 1; i < Points.Length; i++)
        {
            term *= (x - Points[i - 1].X);
            result += DivDif[i] * term;
        }

        return result;
    }
    public override string ToString()
    {
        if(_formula is not null)
            return _formula;
        var sb = new StringBuilder();
        var temp = "";
        sb.Append(Points[0].Y);
        for (var i = 1; i < Points.Length; i++)
        {
            temp += $"(x - {Points[i-1].X})";
            sb.Append($" + {DivDif[i]} * {temp}");
            if (i != Points.Length - 1)
                temp += " * ";
        }
        _formula = sb.ToString();
        return _formula;
    }
}