namespace Lab6;

public static class PrintHelper
{
    public static void Print<T>(IEnumerable<T> array, string separator = ", ", string? prefix = null, string? postfix = null, Func<T, string?>? printFunc = null)
    {
        if (printFunc is null)
            printFunc = t => t?.ToString();
        Console.WriteLine(prefix + string.Join(separator, array.Select(printFunc)) + postfix);
    }
}