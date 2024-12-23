using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;

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

public class ExponentialFunctionFitter : IFunctionFitter
{
	private Func<double, double> _function;
	public double[] X { get; }
	public double[] Y { get; }
	public double Deviation { get; }
	public double A { get; }
	public double B { get; }

	public ExponentialFunctionFitter(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y.Select(v => Math.Log(v)).ToArray();
		(B, var k) = FunctionFitterUtils.FindLinearCoefficients(X, Y);
		A = Math.Exp(k);
		_function = x => A*Math.Pow(Math.E, B*x);
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

public class SquareFunctionFitter : IFunctionFitter 
{
	private Func<double, double> _function;
	public double[] X { get; }
	public double[] Y { get; }
	public double Deviation { get; }
	public double A { get; }
	public double B { get; }
	public double C { get; }

	public SquareFunctionFitter(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y;
		(A, B, C) = FunctionFitterUtils.FindCoefficients(x, y);
		_function = x => A * Math.Pow(x, 2) + B*x + C;
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
	public SquareFunctionFitter SquareFunctionFitter { get; }
	public ExponentialFunctionFitter ExponentialFunctionFitter { get; }
	public IFunctionFitter BestFunctionFitter { get; }
	public FunctionSelector(double[] x, double[] y)
	{
		if(x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y;
		LinearFunctionFitter = new LinearFunctionFitter(x,y);
		PowerFunctionFitter = new PowerFunctionFitter(x,y);
		SquareFunctionFitter = new SquareFunctionFitter(x, y);
		ExponentialFunctionFitter = new ExponentialFunctionFitter(x, y);
		BestFunctionFitter = LinearFunctionFitter.Deviation < PowerFunctionFitter.Deviation
			? (LinearFunctionFitter.Deviation < SquareFunctionFitter.Deviation
				? LinearFunctionFitter
				: SquareFunctionFitter)
			: PowerFunctionFitter.Deviation < SquareFunctionFitter.Deviation ? PowerFunctionFitter : SquareFunctionFitter;
		if(BestFunctionFitter.Deviation > ExponentialFunctionFitter.Deviation)
			BestFunctionFitter = ExponentialFunctionFitter;
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

	public static (double a, double b, double c) FindCoefficients(double[] x, double[] y)
	{
		double sumX4 = 0;
		double sumX3 = 0;
		double sumX2 = 0;
		double sumX = 0;
		double sumX2Y = 0;
		double sumXY = 0;
		double sumY = 0;
		for (var i = 0; i < x.Length; i++)
		{
			sumX4 += Math.Pow(x[i], 4);
			sumX3 += Math.Pow(x[i], 3);
			sumX2 += Math.Pow(x[i], 2);
			sumX += x[i];
			sumX2Y += Math.Pow(x[i], 2) * y[i];
			sumXY += x[i] * y[i];
			sumY += y[i];
		}
		var matrix = Matrix<double>.Build.DenseOfArray(new[,]
		{
			{ sumX4, sumX3, sumX2 },
			{ sumX3, sumX2, sumX },
			{ sumX2, sumX, x.Length }
		});
		var vector = Vector<double>.Build.Dense([sumX2Y, sumXY, sumY]);
		var solution = matrix.Solve(vector);
		ArgumentNullException.ThrowIfNull(solution);
		return (solution[0], solution[1], solution[2]);
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
	public static readonly double[] X = [2, 2.4, 2.8, 3.2, 3.6, 4, 4.4, 4.8, 5.2, 5.6, 6];
	public static readonly double[] Y = [5.389, 8.623, 13.645, 21.333, 32.998, 50.598, 77.051, 116.71, 176.072, 264.826, 397.429];
}
