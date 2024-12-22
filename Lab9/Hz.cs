using PrintHelper;

namespace Lab9;

public class Hz : Base
{
    public double[] DerivativeForward { get; }
    public double[] DerivativeBackward { get; }
    
    public Hz(double[] x, double[] y) : base(x, y)
    {
        DerivativeForward = new double[X.Length-1];
        DerivativeBackward = new double[X.Length-1];
        for (var i = 0; i < X.Length-1; i++)
        {
            DerivativeForward[i] = (Y[i + 1] - Y[i])/H;
            DerivativeBackward[i] = (Y[i + 1] - Y[i])/H;
        }
    }

    protected override void FillDataTable()
    {
        _dataTable = new Table()
        {
            BorderStyle = BorderStyle.Light,
            ColumnHeadersVisible = true
        };
        _dataTable.Columns.Add("i");
        _dataTable.Columns.Add("x");
        _dataTable.Columns.Add("yᵢ");
        _dataTable.Columns.Add("yᵢ'f");
        _dataTable.Columns.Add("yᵢ'b");

        for (var i = 0; i < X.Length; i++)
            _dataTable.Rows.Add(i, X[i], Y[i], i == X.Length - 1 ? "" : DerivativeForward[i], i == 0 ? "" : DerivativeBackward[i-1]);
    }
}