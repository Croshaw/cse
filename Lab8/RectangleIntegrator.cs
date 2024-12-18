namespace Lab8;

public struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class RectangleIntegrator
{
    public enum MethodType
    {
        Left,
        Right,
        Middle,
        Trapezium,
        Parabola
    }
    public IReadOnlyCollection<IIteration> Iterations { get; }
    public MethodType Method { get; }

    private static IIteration CreateIteration(MethodType method, int n, double a, double b, Func<double, double> function)
    {
        return method switch
        {
            MethodType.Left => new LeftIteration(n, a, b, function),
            MethodType.Right => new RightIteration(n, a, b, function),
            MethodType.Middle => new MiddleIteration(n, a, b, function),
            MethodType.Trapezium => new TrapeziumIteration(n, a, b, function),
            MethodType.Parabola => new ParabolaIteration(n, a, b, function),
            _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
        };
    }
    public RectangleIntegrator(double a, double b, int n, double epsilon, MethodType method, Func<double, double> function)
    {
        Method = method;
        if (method == MethodType.Parabola && n % 2 != 0)
            n *= 2;
        var iterations = new List<IIteration>();
        int hz = n;
        iterations.Add(CreateIteration(method, hz, a, b, function));
        while (true)
        {
            hz *= 2;
            var lastIteration = iterations.Last();
            var curIteration = CreateIteration(method, hz, a, b, function);
            iterations.Add(curIteration);
            if (Math.Abs(curIteration.I - lastIteration.I) <= epsilon)
                break;
        }
        Iterations = iterations;
    }

    public interface IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }
    }
    public class LeftIteration : IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }
        public LeftIteration(int n, double a, double b, Func<double, double> function)
        {
            H = (b - a) / n;
            Points = new Point[n];
            for (var i = 0; i < n; i++)
            {
                var x = a+i * H;
                var y = function(x);
                Points[i] = new Point(x, y);
            }
            I = H * Points.Sum(p => p.Y);
        }
    }
    public class RightIteration : IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }

        public RightIteration(int n, double a, double b, Func<double, double> function)
        {
            H = (b - a) / n;
            Points = new Point[n];
            for (var i = 1; i <= n; i++)
            {
                var x = a+i * H;
                var y = function(x);
                Points[i-1] = new Point(x, y);
            }
            I = H * Points.Sum(p => p.Y);
        }
    }
    public class MiddleIteration : IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }

        public MiddleIteration(int n, double a, double b, Func<double, double> function)
        {
            H = (b - a) / n;
            Points = new Point[n];
            for (var i = 0; i < n; i++)
            {
                var x = a+i * H + (H/2);
                var y = function(x);
                Points[i] = new Point(x, y);
            }
            I = H * Points.Sum(p => p.Y);
        }
    }
    public class TrapeziumIteration : IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }
        public TrapeziumIteration(int n, double a, double b, Func<double, double> function)
        {
            H = (b - a) / n;
            Points = new Point[n+1];
            for (var i = 0; i <= n; i++)
            {
                var x = a+i * H;
                var y = function(x);
                Points[i] = new Point(x, y);
            }
            I = H/2 *(Points.First().Y + Points.Last().Y + 2 * Points.Skip(1).SkipLast(1).Sum(p => p.Y));
        }
    }
    public class ParabolaIteration : IIteration
    {
        public double H { get; }
        public double I { get; }
        public Point[] Points { get; }
        public ParabolaIteration(int n, double a, double b, Func<double, double> function)
        {
            // n *= 2;
            H = (b - a) / n;
            Points = new Point[n+1];
            for (var i = 0; i <= n; i++)
            {
                var x = a+i * H;
                var y = function(x);
                Points[i] = new Point(x, y);
            }
            var sumOdd = Points.Skip(1).SkipLast(1).Where((p, i) => i % 2 == 0).Sum(p => p.Y);
            var sumEven = Points.Skip(2).SkipLast(1).Where((p, i) => i % 2 == 0).Sum(p => p.Y);
            I = H/3 *(Points.First().Y + Points.Last().Y + 4 * sumOdd + 2 *sumEven);
        }
    }
}