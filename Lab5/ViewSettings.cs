namespace Lab5;

public static class ViewSettings
{
    public static Func<int, string[]> PowerColumns = size =>
    {
        var columns = new string[size + 1 + size];
        for (var i = 1; i <= size; i++)
            columns[i - 1] = "l" + i;
        columns[size] = "abs";
        for (var i = 1; i <= size; i++)
            columns[size + i] = "x" + i;
        return columns;
    };

    public static Func<PowerMethod.Iteration, string[]> PowerIterationView = iter =>
    {
        var size = iter.X.Count;
        var row = new string[size + 1 + size];
        for (var i = 0; i < size; i++)
            row[i] = iter.L?[i].ToString("F6") ?? "";
        row[size] = iter.Abs?.ToString("F6") ?? "";
        for (var i = 0; i < size; i++)
            row[size + i + 1] = iter.X[i].ToString("F6");
        return row;
    };
}