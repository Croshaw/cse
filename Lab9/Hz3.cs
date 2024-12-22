using PrintHelper;

namespace Lab9;

public class Hz3 : Base
{
    public double[] SecondDerivative { get; }
    
    public Hz3(double[] x, double[] y) : base(x, y)
    {
        SecondDerivative = new double[x.Length-2];
        for (var i = 1; i < x.Length - 1; i++)
            SecondDerivative[i-1] = (Y[i + 1] - 2 * y[i] + y[i - 1])/ Math.Pow(H, 2);
    }

    protected override void FillDataTable()
    {
        _dataTable = new Table()
        {
            BorderStyle = BorderStyle.Light,
            ColumnHeadersVisible = true
        };
        _dataTable.Columns.Add("i");
        _dataTable.Columns.Add("xᵢ");
        _dataTable.Columns.Add("yᵢ");
        _dataTable.Columns.Add("yᵢ''");

        for (var i = 0; i < X.Length; i++)
            _dataTable.Rows.Add(i, X[i], Y[i], i > 0 && i < X.Length - 1 ? SecondDerivative[i-1] : "");
    }
}