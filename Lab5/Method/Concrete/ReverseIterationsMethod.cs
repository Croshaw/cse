using MathAdd;

namespace Lab5;

public class ReverseIterationsMethod : IMethod
{
    public ReverseIterationsMethod(Matrix a, int errorRate)
    {
        var tempA = a.Reverse();
        var epsilon = Math.Pow(10, -errorRate);
        var y = new Vector(5, 1);

        //Fill column names
        var columns = new List<string>();
        for (var i = 0; i < tempA.Rows; i++) columns.Add("x" + (char)('₁' + i));
        columns.Add("l");
        columns.Add("|lₖ - lₖ₋₁|");
        ColumnsName = columns;

        //Fill iterations
        var iterations = new List<Iteration>();
        iterations.Add(new Iteration(y));
        iterations.Add(new Iteration(y, iterations.Last().X, tempA));
        while (true)
        {
            var last = iterations.Last();
            if (last.Abs <= epsilon)
            {
                L = last.L ?? throw new InvalidOperationException();
                X = last.X;
                break;
            }

            var cur = new Iteration(last.Y, last.X, tempA, last.L);
            iterations.Add(cur);
        }

        IterationCount = iterations.Count - 1;
        Iterations = iterations;
    }

    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }
    public double L { get; }
    public Vector X { get; }
    public int IterationCount { get; }

    public class Iteration : IIteration
    {
        public readonly double? Abs;
        public readonly double? L;
        public readonly double? M;
        public readonly Vector X;
        public readonly Vector Y;

        public Iteration(Vector y)
        {
            Y = y;
            X = Y / Y.EuclideanNorm;
        }

        public Iteration(Vector y, Vector x, Matrix a, double? lastL = null)
        {
            Y = (a * x)[0];
            X = Y / Y.EuclideanNorm;
            M = (Y * Y).Sum() / (Y * x).Sum();
            L = 1 / M.Value;
            if (lastL is not null)
                Abs = Math.Abs(L.Value - lastL.Value);
            else
                Abs = null;
        }

        public string[] ToRow(int errorRate = -1)
        {
            var result = new List<string>();
            result.AddRange(X.Select(elem => elem.ToString($"G{errorRate}")));
            result.Add(L?.ToString($"G{errorRate}") ?? "");
            result.Add(Abs?.ToString($"G{errorRate}") ?? "");
            return result.ToArray();
        }
    }
}