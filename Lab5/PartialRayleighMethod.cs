using MathAdd;

namespace Lab5;

public class PartialRayleighMethod : IMethod
{
    public PartialRayleighMethod(Matrix a, int errorRate)
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
        iterations.Add(new Iteration(y, a));
        while (true)
        {
            var last = iterations.Last();
            var cur = new Iteration(last.Y, a, last.L);
            iterations.Add(cur);
            if (cur.Abs <= epsilon) break;
        }

        Iterations = iterations;
    }

    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }

    public class Iteration : IIteration
    {
        public readonly double? Abs;
        public readonly double L;
        public readonly Vector X;
        public readonly Vector Y;

        public Iteration(Vector y, Matrix a, double? lastL = null)
        {
            X = y / y.EuclideanNorm;
            Y = (a * X)[0];
            L = (Y * X).Sum() / (X * X).Sum();
            if (lastL is not null)
                Abs = Math.Abs(L - lastL.Value);
            else
                Abs = null;
        }

        public string[] ToRow(int errorRate = -1)
        {
            var result = new List<string>();
            result.AddRange(X.Select(elem => elem.ToString($"G{errorRate}")));
            result.Add(L.ToString($"G{errorRate}"));
            result.Add(Abs?.ToString($"G{errorRate}") ?? "");
            return result.ToArray();
        }
    }
}