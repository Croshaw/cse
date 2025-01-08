using System.Globalization;
using MathNet.Symbolics;
using Spectre.Console;

namespace Lab10;

public static class MathUtils
{
    public static int Factorial(int n)
    {
        if (n is 1 or 2)
            return n;
        return Factorial(n - 1) * n;
    }
}

public readonly struct Range<T> where T : IComparable
{
    public T From { get; }
    public T To { get; }

    public Range(T first, T second)
    {
        From = first.CompareTo(second) == -1 ? first : second;
        To = second.CompareTo(first) >= 0 ? second : first;
    }
    public bool InRange(T value)
    {
        return From.CompareTo(value) <= 0 && To.CompareTo(value) == 1;
    }
}

public class CauchyReporter
{
    private Table[] tables;
    private Dictionary<double, CauchyApproximation> _approximations = [];
    private double[] _steps;
    public CauchyReporter(Range<double> range, double u0, string function, string exactFunction, params double[] steps)
    {
        foreach (var step in steps)
            _approximations[step] = new CauchyApproximation(range, u0, step, function, exactFunction);
        tables = new Table[steps.Length - 1];
        _steps = steps;
        var tmp = steps.OrderDescending().ToArray();
        for (var i = 0; i < tmp.Length - 1; i++)
        {
            tables[i] = new Table();
            FillTable(tables[i], tmp[i], tmp[i+1]);
        }
    }

    private void FillTable(Table table, double fromStep, double toStep)
    {
        table.Border(TableBorder.Rounded);
        table.AddColumns("i", "t", "Эйлер", "Предиктор-корректор", "Рунге-Кутта III", "Рунге-Кутта IV");
        var fromApproximation = _approximations[fromStep];
        var toApproximation = _approximations[toStep];
        var maxEuler = double.MinValue;
        var maxPredictorCorrector = double.MinValue;
        var maxRungeKuttaThird = double.MinValue;
        var maxRungeKuttaFourth = double.MinValue;
        for (var i = 0; i < fromApproximation.T.Length; i++)
        {
            var euler = hz(fromApproximation.Euler, toApproximation.Euler, i);
            var predictorCorrector = hz(fromApproximation.PredictorCorrector, toApproximation.PredictorCorrector, i);
            var rungeKuttaThird = hz(fromApproximation.RungeKuttaThird, toApproximation.RungeKuttaThird, i);
            var rungeKuttaFourth = hz(fromApproximation.RungeKuttaFourth, toApproximation.RungeKuttaFourth, i);
            table.AddRow(i.ToString(CultureInfo.InvariantCulture), fromApproximation.T[i].ToString(CultureInfo.InvariantCulture), euler.ToString(CultureInfo.InvariantCulture),
                predictorCorrector.ToString(CultureInfo.InvariantCulture),
                rungeKuttaThird.ToString(CultureInfo.InvariantCulture),
                rungeKuttaFourth.ToString(CultureInfo.InvariantCulture));
            maxEuler = Math.Max(euler, maxEuler);
            maxPredictorCorrector = Math.Max(predictorCorrector, maxPredictorCorrector);
            maxRungeKuttaThird = Math.Max(rungeKuttaThird, maxRungeKuttaThird);
            maxRungeKuttaFourth = Math.Max(rungeKuttaFourth, maxRungeKuttaFourth);
        }

        table.AddRow("", "", "", "", "", "");
        table.AddRow("", "max", maxEuler.ToString(CultureInfo.InvariantCulture), maxPredictorCorrector.ToString(CultureInfo.InvariantCulture), maxRungeKuttaThird.ToString(CultureInfo.InvariantCulture), maxRungeKuttaFourth.ToString(CultureInfo.InvariantCulture));
    }

    double hz(CauchyApproximationMethod firMethod, CauchyApproximationMethod secMethod, int id)
    {
        var t = firMethod.T[id];
        var secInd = -1;
        for(var i = 0; i < secMethod.T.Length; i++)
            if (Math.Abs(secMethod.T[i] - t) < Math.Pow(10, -1))
            {
                secInd = i;
                break;
            }

        return Math.Abs(secMethod[secInd] - firMethod[id]);
    }
    public CauchyApproximation? GetApproximation(double step)
    {
        return _approximations.GetValueOrDefault(step);
    }

    public void ToConsole()
    {
        for (var i = 0; i < tables.Length; i++)
        {
            Console.WriteLine($"т={_steps[i]}");
            AnsiConsole.Write(tables[i]);
        }
    }
    
}

public class CauchyApproximation
{
    public Table Table { get; }
    public Table ComparisonTable { get; }
    public double[] T { get; }
    public EulerMethod Euler { get; }
    public PredictorCorrectorMethod PredictorCorrector { get; }
    public RungeKuttaMethod RungeKuttaThird { get; }
    public RungeKuttaMethod RungeKuttaFourth { get; }
    private double _h;
    public CauchyApproximation(Range<double> range, double u0, double h, string function, string exactFunction)
    {
        _h = h;
        Table = new Table();
        ComparisonTable = new Table();
        List<double> listT = [];
        for(var t = range.From ; t <= range.To; t+=h)
            listT.Add(t);
        T = listT.ToArray();
        
        var u = new double[T.Length];
        u[0] = u0;
        
        
        var tVar = SymbolicExpression.Variable("t");
        var uVar = SymbolicExpression.Variable("u");
        var exact = SymbolicExpression.Parse(exactFunction);
        var exactFunc = exact.Compile("t");
        var expression = SymbolicExpression.Parse(function).Compile("t","u");
        if(expression is null || exactFunc is null)
            throw new Exception();
        List<SymbolicExpression> derivatives = [exact.Differentiate(tVar)];
        for (var i = 0; i < 3; i++)
            derivatives.Add(derivatives.Last().Differentiate(tVar));
        Euler = new EulerMethod(T, u, h,expression, derivatives[2].Compile("t"), exactFunc);
        PredictorCorrector = new PredictorCorrectorMethod(T, u, h,expression, derivatives[3].Compile("t"), exactFunc);
        RungeKuttaThird = new RungeKuttaMethod(T,u, h, RungeKuttaMethod.RungeKuttaType.Third, expression, exactFunc);
        RungeKuttaFourth = new RungeKuttaMethod(T,u, h, RungeKuttaMethod.RungeKuttaType.Fourth, expression, exactFunc);

        SetupTable(exactFunc);
        SetupComparisonTable();
    }

    private void SetupTable(Func<double, double> exact)
    {
        Table.Border(TableBorder.Rounded);
        Table.AddColumns("i", "t", "Эйлер", "Предиктор-корректор", "Рунге-Кутта III ", "Рунге-Кутта IV","Точное решение");
        for (var i = 0; i < T.Length; i++)
            Table.AddRow(i.ToString(CultureInfo.InvariantCulture), T[i].ToString(CultureInfo.InvariantCulture), Euler[i].ToString(CultureInfo.InvariantCulture), PredictorCorrector[i].ToString(CultureInfo.InvariantCulture)
                ,RungeKuttaThird[i].ToString(CultureInfo.InvariantCulture), RungeKuttaFourth[i].ToString(CultureInfo.InvariantCulture), exact.Invoke(T[i]).ToString(CultureInfo.InvariantCulture));
    }

    private void SetupComparisonTable()
    {
        ComparisonTable.Border(TableBorder.Rounded);
        ComparisonTable.AddColumns("i", "t", "Эйлер", "Предиктор-корректор", "Рунге-Кутта III ", "Рунге-Кутта IV");
        for (var i = 0; i < T.Length; i++)
            ComparisonTable.AddRow(i.ToString(CultureInfo.InvariantCulture), T[i].ToString(CultureInfo.InvariantCulture), Euler.ErrorRates[i].ToString(CultureInfo.InvariantCulture), PredictorCorrector.ErrorRates[i].ToString(CultureInfo.InvariantCulture)
            ,RungeKuttaThird.ErrorRates[i].ToString(CultureInfo.InvariantCulture), RungeKuttaFourth.ErrorRates[i].ToString(CultureInfo.InvariantCulture));
        ComparisonTable.AddRow("", "", "", "", "", "");
        ComparisonTable.AddRow("", "max", Euler.MaxErrorRate.ToString(CultureInfo.InvariantCulture) + "<=" + Euler.ErrorRate.Value.ToString(CultureInfo.InvariantCulture), PredictorCorrector.MaxErrorRate.ToString(CultureInfo.InvariantCulture) + "<=" + PredictorCorrector.ErrorRate.Value.ToString(CultureInfo.InvariantCulture)
        ,RungeKuttaThird.MaxErrorRate.ToString(CultureInfo.InvariantCulture), RungeKuttaFourth.MaxErrorRate.ToString(CultureInfo.InvariantCulture));
    }

    public void ToConsole()
    {
        Console.WriteLine($"h = {_h}");
        AnsiConsole.Write(Table);
        AnsiConsole.Write(ComparisonTable);
    }
}

public interface IErrorRate
{
    public double[] ErrorRates { get; }
    public double MaxErrorRate { get; }
    public double? ErrorRate { get; }

    protected void CalculateErrorRates(Func<double, double> exact);
}

public interface ICauchyApproximationMethod
{
    public double[] T { get; }
    public double[] U { get; }
}

public abstract class CauchyApproximationMethod : ICauchyApproximationMethod, IErrorRate
{
    public double[] T { get; }
    public double[] U { get; }
    public double[] ErrorRates { get; }
    public double MaxErrorRate => ErrorRates.Max();
    public double? ErrorRate { get; protected init; }
    public void CalculateErrorRates(Func<double, double> exact)
    {
        for(var i = 0; i < U.Length; i++)
            ErrorRates[i] = Math.Abs(U[i] - exact(T[i]));
    }

    public double this[int id] => U[id];
    protected CauchyApproximationMethod(double[] t, double[] u)
    {
        if(t.Length != u.Length)
            throw new ArgumentException("T and U are not the same length");
        T = t;
        U = new double[u.Length];
        ErrorRates = new double[u.Length];
        Array.Copy(u, U, u.Length);
    }
}

public class EulerMethod : CauchyApproximationMethod
{
    public EulerMethod(double[] t, double[] u, double h, Func<double, double, double> function, Func<double,double>? derivative, Func<double, double> exact) : base(t, u)
    {
        var n = t.Length;
        for (var i = 1; i < n; i++)
            U[i] = U[i - 1] + h * function(t[i - 1], U[i - 1]);
        if(derivative is not null)
            ErrorRate = Math.Pow(h, 2) / MathUtils.Factorial(3) * derivative(t[^1]);
        CalculateErrorRates(exact);
    }
    
}

public class PredictorCorrectorMethod : CauchyApproximationMethod
{
    public PredictorCorrectorMethod(double[] t, double[] u, double h, Func<double, double, double> function, Func<double,double>? derivative, Func<double, double> exact) : base(t, u)
    {
        var n = t.Length;
        for (var i = 1; i < n; i++)
        {
            var tempU = U[i - 1] + 0.5*h*function(t[i - 1], U[i - 1]);
            var tempT = t[i-1] + 0.5 * h;
            U[i] = U[i-1] + h*function(tempT, tempU);
        }
        if(derivative is not null)
            ErrorRate = Math.Pow(h, 2) / MathUtils.Factorial(3) * derivative(t[^1]);
        CalculateErrorRates(exact);
    }
}

public class RungeKuttaMethod : CauchyApproximationMethod
{
    public enum RungeKuttaType
    {
        Third,
        Fourth
    }
    public RungeKuttaMethod(double[] t, double[] u, double h, RungeKuttaType type, Func<double, double, double> function, Func<double, double> exact) : base(t, u)
    {
        var rankFunction = Generate(function, h, type);
        var n = t.Length;
        for (var i = 1; i < n; i++)
            U[i] = rankFunction(t[i - 1], U[i - 1]);
        ErrorRate = double.NaN;
        CalculateErrorRates(exact);
    }

    private static Func<double, double, double> Generate(Func<double, double, double> function, double h, RungeKuttaType type)
    {
        return type switch
        {
            RungeKuttaType.Third => (t, u) =>
            {
                var k1 = function(t, u);
                // var k2 = function(t + h / 2, u + h / 2 * k1);
                // var k3 = function(t + h, u - h * k1 + 2 * h * k2);
                // return t / 6 * (k1 + 4 * k2 + k3);
                var k2 = function(t + h / 3, u + h / 3 * k1);
                var k3 = function(t + 2*h / 3, u + 2 * h / 3 * k2);
                return u + h / 4 * (k1 + 3 * k3);
            },
            RungeKuttaType.Fourth => (t, u) =>
            {
                var k1 = function(t, u);
                // var k2 = function(t + h / 2, u + h / 2 * k1);
                // var k3 = function(t + h / 2, u + h / 2 * k2);
                // var k4 = function(t + h, u + h * k3);
                // return u+ t / 6 * (k1 + 2 * k2 + 2 * k3 + k4);
                var k2 = function(t+h/4, u + h/4 * k1);
                var k3 = function(t + h / 2, u + h / 2 * k2);
                var k4 = function(t + h, u + h * k1 - 2 * h * k2 + 2 * t * k3);
                return u + h / 6 * (k1 + 4 * k3 + k4);
            },
            _ => throw new NotImplementedException()
        };
    }
}