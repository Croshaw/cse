using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Legends;

namespace Lab6.GUI
{
	public partial class VariantForm : Form
	{
		public static readonly double[] X = [1, 1.1, 1.17, 1.23, 1.3, 1.35, 1.41, 1.5, 1.56, 1.6, 1.64, 1.7, 1.75, 1.8, 1.89, 1.93, 2];
		public static readonly double[] Y = [1.718, 1.904, 2.052, 2.191, 2.369, 2.507, 2.686, 2.982, 3.199, 3.353, 3.515, 3.774, 4.005, 4.250, 4.729, 4.960, 5.389];
		public static readonly double[] X1 = [0.21,0.22,0.23,0.24,0.25, 0.26, 0.27, 0.28, 0.29, 0.3];
		public static readonly double[] Y1 = [1.045087, 1.04959, 1.054324, 1.059291, 1.064494, 1.069937, 1.075623, 1.081555, 1.087738, 1.094174];
		public static readonly double[] NeedX = [0.215, 0.234, 0.257, 0.286, 0.293];
		public VariantForm()
		{
			InitializeComponent();
			var plotModel = new PlotModel();
			var legend = new Legend()
			{
				LegendPosition = LegendPosition.TopRight,
				LegendPlacement = LegendPlacement.Outside
			};
			plotModel.Legends.Add(legend);

			plotModel.Series.Add(GenerateScatterSeries(X1, Y1, "f(x)"));
			var newton = new Newton(X1, Y1);
			plotModel.Series.Add(GenerateLineSeries(NeedX, newton.Calculate, "Newton"));
			string result = String.Join(" | ", NeedX.Select(x => newton.Calculate(x).ToString()));
			MessageBox.Show(result);
			plotView1.Model = plotModel;
		}

		private static ScatterSeries GenerateScatterSeries(double[] x, double[] y, string? title = null)
		{
			var scatterSeries = new ScatterSeries
			{
				MarkerType = MarkerType.Circle,
				MarkerSize = 5,
				Title = title
			};

			for (var i = 0; i < x.Length; i++)
				scatterSeries.Points.Add(new ScatterPoint(x[i], y[i]));

			return scatterSeries;
		}
		private static LineSeries GenerateLineSeries(double firstX, double lastX, double count, Func<double, double> y, string? title = null)
		{
			var lineSeries = new LineSeries()
			{
				Title = title,
			};
			double step = (lastX - firstX) / count;
			for(; firstX<=lastX; firstX+=step)
				lineSeries.Points.Add(new DataPoint(firstX, y.Invoke(firstX)));
			return lineSeries;
		}
		private static LineSeries GenerateLineSeries(double[] x, Func<double, double> y, string? title = null)
		{
			var lineSeries = new LineSeries()
			{
				Title = title,
			};
			foreach (var t in x)
				lineSeries.Points.Add(new DataPoint(t, y.Invoke(t)));
			return lineSeries;
		}
	}
}
