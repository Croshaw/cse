using MathAdd;

namespace Lab5;

public class PowerMethod : IMethod
{
    public PowerMethod(Matrix a, int errorRate)
    {
        var epsilon = Math.Pow(10, -errorRate);
        var y = new Vector(5, 1);

        //Fill column names
        var columns = new List<string>();
        for (var i = 0; i < a.Rows; i++) columns.Add("l" + (char)('₁' + i));
        columns.Add("|lₖ - lₖ₋₁|");
        for (var i = 0; i < a.Rows; i++) columns.Add("x" + (char)('₁' + i));
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
                SpectralRadius = cur.L.Sum() / cur.L.Value.Count;
                break;
            }
        }

        Iterations = iterations;
    }

    public double SpectralRadius { get; }

    public IReadOnlyList<string> ColumnsName { get; }
    public IReadOnlyList<IIteration> Iterations { get; }

    public class Iteration : IIteration
    {
        public readonly double? Abs;
        public readonly Vector? L;
        public readonly Vector X;
        public readonly Vector Y;

        public Iteration(Vector y)
        {
            Y = y;
            X = Y / Y.EuclideanNorm;
        }

        public Iteration(Vector y, Vector prevX, Matrix a, Vector? prevL = null)
        {
            Y = (a * prevX)[0];
            X = Y / Y.EuclideanNorm;
            L = Y / prevX;
            if (prevL.HasValue)
            {
                double temp = -1;
                Abs = -1;
                for (var i = 0; i < prevL.Value.Count; i++)
                {
                    temp = Math.Abs(L.Value[i] - prevL.Value[i]);
                    if (temp > Abs)
                        Abs = temp;
                }
            }
        }

        public string[] ToRow(int errorRate = -1)
        {
            var result = new List<string>();
            result.AddRange(L?.Select(elem => elem.ToString($"G{errorRate}")) ??
                            Enumerable.Repeat<string>("", X.Count));
            result.Add(Abs?.ToString($"G{errorRate}") ?? "");
            result.AddRange(X.Select(elem => elem.ToString($"G{errorRate}")));
            return result.ToArray();
        }
    }
}