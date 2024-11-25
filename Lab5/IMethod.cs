namespace Lab5;

public interface IMethod
{
    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }
}