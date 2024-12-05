using MathAdd;

namespace Lab5;

public interface IMethod
{
    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }
    double L { get; }
    Vector X { get; }
    int IterationCount { get; }
}