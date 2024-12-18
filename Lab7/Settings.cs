namespace Lab7;

public interface IFunctionFitter
{
	public double[] X { get; }
	public double[] Y { get; }
	public double Deviation { get; }
	double Calculate(double x);
}

public class LinearFunctionFitter : IFunctionFitter
{
	private Func<double, double> _function;
	public double[] X { get; }
	public double[] Y { get; }
	public double K { get; }
	public double B { get; }
	public double Deviation { get; }

	public LinearFunctionFitter(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y;
		(K, B) = FunctionFitterUtils.FindLinearCoefficients(X, Y);
		_function = x => K * x + B;
		Deviation = FunctionFitterUtils.CalcDeviation(x, y, _function);
	}
	public double Calculate(double x)
	{
		return _function.Invoke(x);
	}
}

public class PowerFunctionFitter : IFunctionFitter
{
	private Func<double, double> _function;

	public double[] X { get; }
	public double[] Y { get; }
	public double M { get; }
	public double B { get; }
	public double C { get; }
	public double Deviation { get; }

	public PowerFunctionFitter(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x.Select(x=> Math.Log(x)).ToArray();
		Y = y.Select(y=> Math.Log(y)).ToArray();
		(M, B) = FunctionFitterUtils.FindLinearCoefficients(X, Y);
		C = Math.Pow(Math.E, B);
		_function = x => C*Math.Pow(x, M);
		Deviation = FunctionFitterUtils.CalcDeviation(x, y, _function);
	}

	public double Calculate(double x)
	{
		return _function.Invoke(x);
	}
}

public class FunctionSelector
{
	public double[] X { get; }
	public double[] Y { get; }
	public LinearFunctionFitter LinearFunctionFitter { get; }
	public PowerFunctionFitter PowerFunctionFitter { get; }
	public IFunctionFitter BestFunctionFitter { get; }
	public FunctionSelector(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y;
		LinearFunctionFitter = new LinearFunctionFitter(x,y);
		PowerFunctionFitter = new PowerFunctionFitter(x,y);
		BestFunctionFitter = LinearFunctionFitter.Deviation < PowerFunctionFitter.Deviation
			? LinearFunctionFitter
			: PowerFunctionFitter;
	}
}

public static class FunctionFitterUtils
{
	public static double CalcDeviation(double[] x, double[] y, Func<double, double> function)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		return x.Select((t, i) => Math.Pow(y[i] - function(t), 2)).Sum();
	}
	public static (double k, double b) FindLinearCoefficients(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		var n = x.Length;
		double sumKvX = 0;
		double sumX = 0;
		double sumY = 0;
		double sumXY = 0;
		for(int i = 0; i < n;i++)
		{
			sumKvX += Math.Pow(x[i], 2);
			sumX += x[i];
			sumY += y[i];
			sumXY += x[i] * y[i];
		}

		var k = (n*sumXY - sumX * sumY) / (n*sumKvX-Math.Pow(sumX, 2));
		var b = (sumY - sumX * k) / n;
		return (k, b);
	}
}

public static class Settings
{
	// public static readonly double[] X = [1.1, 1.7, 2.4, 3, 3.7, 4.5, 5.1, 5.8];
	// public static readonly double[] Y = [0.3, 0.6, 1.1, 1.7, 2.3, 3, 3.8, 4.6];
	public readonly static double[] X = [2, 2.4, 2.8, 3.2, 3.6, 4, 4.4, 4.8, 5.2, 5.6, 6];
	public readonly static double[] Y = [5.389, 8.623, 13.645, 21.333, 32.998, 50.598, 77.051, 116.71, 176.072, 264.826, 397.429];
}
