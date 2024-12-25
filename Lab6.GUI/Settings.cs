namespace Lab6.GUI;

public enum SigmaSettings
{
	Zero,
	Min,
	Max,
	Random
}

public class Settings
{
	public double[] X { get; }
	public double[] Y { get; }

	public double Sa { get; }
	public double Sb { get; }
	public double UnknownX { get; }
	public SigmaSettings SigmaSettings { get; }

	public Settings(double[] x, double[] y, double sa, double sb, double unknownX, SigmaSettings sigmaSettings)
	{
		if (x.Length != y.Length)
			throw new ArgumentException();
		X = x;
		Y = y;
		Sa = sa;
		Sb = sb;
		UnknownX = unknownX;
		SigmaSettings = sigmaSettings;
	}
}

public readonly struct Range<T> where T : IComparable
{
	private readonly T _from;
	private readonly T _to;

	public Range(T from, T to)
	{
		_from = from.CompareTo(to) == -1 ? from : to;
		_to = to.CompareTo(from) >= 0 ? to : from;
	}
	public bool InRange(T value)
	{
		return _from.CompareTo(value) <= 0 && _to.CompareTo(value) == 1;
	}
}

public class Spline
{
	private readonly Range<double> _range;
	private readonly Func<double, double> _function;

	public Spline(Range<double> range, Func<double, double> function)
	{
		_range = range;
		_function = function ?? throw new ArgumentNullException(nameof(function));
	}
	public bool InRange(double value)
	{
		return _range.InRange(value);
	}
	public double Calculate(double value)
	{
		return _function.Invoke(value);
	}
}
public class Hz
{
	public Settings Settings { get; }
	public int N { get; }
	public Range<double>[] Ranges { get; }
	public double[] H { get; }
	public double[] Sigma { get; }
	public double[] A { get; }
	public double[] B { get; }
	public double[] C { get; }
	public double[] D { get; }
	public double[] E { get; }
	public double[] Alpha { get; }
	public double[] Betta { get; }
	public double[] M { get; }
	private Spline[] _splines;

	public Hz(Settings settings)
	{
		Settings = settings;
		N = Settings.X.Length;
		Ranges = new Range<double>[N - 1];
		H = new double[N - 1];
		Sigma = new double[N - 2];
		A = new double[N - 2];
		B = new double[N - 2];
		C = new double[N - 2];
		D = new double[N - 2];
		E = new double[N - 2];
		Alpha = new double[N - 1];
		Betta = new double[N - 1];
		M = new double[N];
		_splines = new Spline[Ranges.Length];
		PrepareRange();
		Prepare();
		Progonka();
		GenerateSplaines();
	}
	private void PrepareRange()
	{
		for (int i = 0; i < Ranges.Length; i++)
		{
			Ranges[i] = new Range<double>(Settings.X[i], Settings.X[i + 1]);
			H[i] = Settings.X[i + 1] - Settings.X[i];
		}
	}
	private void Prepare()
	{
		for(int i = 0; i < Sigma.Length; i++)
		{
			var min = -H[i + 1] / 3;
			var max = H[i] / 3;

			switch (Settings.SigmaSettings)
			{
				case SigmaSettings.Min:
					Sigma[i] = min;
					break;
				case SigmaSettings.Max:
					Sigma[i] = max;
					break;
				case SigmaSettings.Random:
					Sigma[i] = Random.Shared.NextDouble();
					break;
			}
			A[i] = -2 / H[i] + Sigma[i] * (6 / (H[i] * H[i]));
			B[i] = -4 / H[i + 1] - 4 / H[i] - Sigma[i] * (6 / (H[i + 1] * H[i + 1])) + Sigma[i] * (6 / (H[i] * H[i]));
			C[i] = -2 / H[i + 1] - Sigma[i] * 6 / (H[i + 1] * H[i + 1]);
			D[i] = -6 / H[i + 1] - Sigma[i] * 12 / (H[i + 1] * H[i + 1]);
			E[i] = -6 / H[i] - Sigma[i] * 12 / (H[i] * H[i]);

		}
	}
	private void Progonka()
	{
		Betta[0] = Settings.Sa;
		for (var i = 1; i < N - 1; i++)
		{
			Alpha[i] = -C[i - 1] / (A[i - 1] * Alpha[i - 1] + B[i - 1]);
			Betta[i] = (D[i - 1] * ((Settings.Y[i + 1] - Settings.Y[i]) / H[i]) + E[i - 1] * ((Settings.Y[i] - Settings.Y[i - 1]) / H[i - 1]) -
					   A[i - 1] * Betta[i - 1]) / (A[i - 1] * Alpha[i - 1] + B[i - 1]);
		}
		M[^1] = Settings.Sb;
		for (var i = N - 2; i >= 0; i--) M[i] = Alpha[i] * M[i + 1] + Betta[i];
	}
	private void GenerateSplaines()
	{
		for (int i = 0; i < _splines.Length; i++)
		{
			_splines[i] = new Spline(Ranges[i], (x) =>
			{
				var tau = (x - Settings.X[i]) /H[i];
				return Settings.Y[i] * (1 - 3 * Math.Pow(tau, 2) + 2 * Math.Pow(tau, 3)) +
							 Settings.Y[i + 1] * (3 * Math.Pow(tau, 2) - 2 * Math.Pow(tau, 3)) +
							 M[i] * H[i] * (tau - 2 * Math.Pow(tau, 2) + Math.Pow(tau, 3)) +
							 M[i + 1] * H[i] * (Math.Pow(tau, 3) - Math.Pow(tau, 2));
			}
			);
		}
	}
	public double Find(double x)
	{
		return _splines.FirstOrDefault(spline => spline.InRange(x))?.Calculate(x) ?? throw new Exception();
	}
}

public class Newton
{
	public double[] X { get; }
	public double[] Y { get; }
	public double[] DivDif { get; }
	public Newton(double[] x, double[] y)
	{
		X = x;
		Y = y;
		DivDif = new double[X.Length];
		Array.Copy(Y, DivDif, X.Length);
		DividedDifferences();
	}
	void DividedDifferences()
	{
		int n = X.Length;
		for (int i = 1; i < n; i++)
		{
			for(int j = n-1; j>=i;j--)
			{
				DivDif[j] = (DivDif[j] - DivDif[j - 1]) / (X[j] - X[j - i]);
			}
		}
	}
	public double Calculate(double x)
	{
		double result = DivDif[0];
		double term = 1;

		for (int i = 1; i < X.Length; i++)
		{
			term *= (x - X[i - 1]);
			result += DivDif[i] * term;
			//term = DivDif[i];

			//for (int j = 0; j < i; j++)
			//{
			//	term *= (x - X[j]);
			//}
			//result += term;
		}

		return result;

	}
}