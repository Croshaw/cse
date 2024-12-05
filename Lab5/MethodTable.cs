using Lab5;
using Terminal.Gui;

public class MethodTable : ITableSource
{
    private readonly string[][] _rows;

    public MethodTable(IMethod method)
    {
        var temp = method.ColumnsName.ToList();
        temp.Insert(0, "");
        ColumnNames = temp.ToArray();
        Columns = ColumnNames.Length;
        _rows = new string[method.Iterations.Count][];
        Rows = _rows.Length;
        for (var i = 0; i < method.Iterations.Count; i++)
        {
            temp = new List<string>();
            temp.Add(i.ToString());
            temp.AddRange(method.Iterations[i].ToRow(9));
            _rows[i] = temp.ToArray();
        }
    }

    public string[] ColumnNames { get; }
    public int Columns { get; }

    public object this[int row, int col] => _rows[row][col];

    public int Rows { get; }
}