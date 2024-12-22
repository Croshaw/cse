using PrintHelper;

namespace Lab9;

public class Hz2 : Base
{
    public double[] Derivative { get; }

    public Hz2(double[] x, double[] y) : base(x, y)
    {
        Derivative = new double[x.Length];
        var n = x.Length-1;
        Derivative[0] = (-3 * Y[0] + 4 * Y[1] - Y[2]) / (2 * H);
        Derivative[n] = (Y[n - 2] - 4 * Y[n - 1] + 3 * Y[n]) / (2 * H);
        for (var i = 1; i < X.Length - 1; i++)
            Derivative[i] = (Y[i + 1] - Y[i - 1])/ (2 * H);
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
        _dataTable.Columns.Add("yᵢ'");

        for (var i = 0; i < X.Length; i++)
            _dataTable.Rows.Add(i, X[i], Y[i], Derivative[i]);
    }
}