using PrintHelper;

namespace Lab9;

public abstract class Base
{
    public double[] X { get; }
    public double[] Y { get; }
    public double H { get; }
    protected Table? _dataTable;

    protected Base(double[] x, double[] y)
    {
        if(x.Length != y.Length || x.Length < 2)
        {
            var exception = new ArgumentException
            {
                HelpLink = null,
                HResult = 0,
                Source = null
            };
            throw exception;
        }

        X = x;
        Y = y;
        H = X[1] - X[0];
    }

    protected abstract void FillDataTable();

    public override string ToString()
    {
        if(_dataTable is null)
            FillDataTable();
        return _dataTable!.ToString();
    }
}