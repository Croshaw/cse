using MathAdd;

namespace Lab5;

public class DotProductsMethod : IMethod
{
    public DotProductsMethod(Matrix a, int errorRate)
    {
        var epsilon = Math.Pow(10, -errorRate);
        var y = new Vector(5, 1);

        //Fill column names
        var columns = new List<string>();
        for (var i = 0; i < a.Rows; i++) columns.Add("x" + (char)('₁' + i));
        columns.Add("l");
        columns.Add("|lₖ - lₖ₋₁|");
        ColumnsName = columns;

        //Fill Iterations
        var iterations = new List<Iteration>();
        iterations.Add(new Iteration(y));
        iterations.Add(new Iteration(y, iterations.Last().X, a));
        while (true)
        {
            var last = iterations.Last();
            var cur = new Iteration(last.Y, last.X, a, last.L);
            iterations.Add(cur);
            if (cur.Abs <= epsilon)
            {
                MaxL = cur.L ?? throw new InvalidOperationException();
                X = cur.X;
                break;
            }
        }

        Iterations = iterations;
    }

    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }
    public double MaxL { get; }
    public Vector X { get; }

    public class Iteration : IIteration
    {
        public readonly double? Abs;
        public readonly double? L;
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
            L = (Y * Y).Sum() / (Y * x).Sum();
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