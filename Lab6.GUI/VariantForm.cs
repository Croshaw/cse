using Lab6.GUI.Controls;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.Legends;

namespace Lab6.GUI
{
	public partial class VariantForm : Form
	{
		public VariantForm()
		{
			Func<double, double> test = (x) => Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + x - 1;
			InitializeComponent();
			AddPointBTN.Click += (_, _) => AddPoint();
			RemovePointBTN.Click += (_, _) => RemovePoint();
			AddUnknownXBTN.Click += (_, _) => AddUnknownX();
			RemoveUnknownXBTN.Click += (_, _) => RemoveUnknownX();
			RunButton.Click += (_, _) =>
			{
				var newton = new NewtonInterpolation(GetPoints());
				var points = GetUnknownX().Select(x => new PointD(x, newton.Calculate(x))).ToArray();
				plotView1.Model.Series.Clear();
				plotView1.Model.Series.Add(GenerateLineSeries(points, "Ньютон"));
				plotView1.Model.InvalidatePlot(true);
				var i = 0;
				foreach (Control control in UnknownXPanel.Controls)
				{
					if (control is not PointControl pointControl) continue;
					pointControl.Point = points[i];
					i++;
				}

				MessageBox.Show(string.Join(" ; ", Settings.UnknownX.Select(x => test(x).ToString())));;
			};
			for (var i = 0; i < Settings.X.Length; i++)
				AddPoint(new PointD(Settings.X[i], Settings.Y[i]));
			foreach (var x in Settings.UnknownX)
				AddUnknownX(x);
			var plotModel = new PlotModel();
			var legend = new Legend()
			{
				LegendPosition = LegendPosition.TopRight,
				LegendPlacement = LegendPlacement.Outside
			};
			plotModel.Legends.Add(legend);
			plotView1.Model = plotModel;
		}

		private void AddPoint(PointD? point = null)
		{
			var pointControl = new PointControl()
			{
				Dock = DockStyle.Left,
				AutoSize = true,
				FlowDirection = FlowDirection.TopDown
			};
			if (point.HasValue)
				pointControl.Point = point.Value;
			PointsPanel.Controls.Add(pointControl);
		}

		private void RemovePoint()
		{
			if(PointsPanel.Controls.Count > 0)
				PointsPanel.Controls.RemoveAt(PointsPanel.Controls.Count-1);
		}

		private void AddUnknownX(double? x = null)
		{
			var point = new PointControl()
			{
				Dock = DockStyle.Left,
				AutoSize = true,
				FlowDirection = FlowDirection.TopDown,
				ReadOnlyY = true
			};
			if (x is not null)
				point.Point = new PointD(x.Value, 0);
			point.KeyPress += Utils.OnlyDoubleNumbers;
			UnknownXPanel.Controls.Add(point);
		}
		
		private void RemoveUnknownX()
		{
			if(UnknownXPanel.Controls.Count > 0)
				UnknownXPanel.Controls.RemoveAt(UnknownXPanel.Controls.Count-1);
		}
		
		private PointD[] GetPoints()
		{
			List<PointD> points = [];
			foreach (Control control in PointsPanel.Controls)
			{
				if(control is PointControl point)
					points.Add(point.Point);
			}
			return points.ToArray();
		}
		
		private double[] GetUnknownX()
		{
			List<double> xes = [];
			foreach (Control control in UnknownXPanel.Controls)
			{
				if(control is PointControl pointControl)
					xes.Add(pointControl.Point.X);
			}
			return xes.ToArray();
		}
		
		private static LineSeries GenerateLineSeries(PointD[] points, string? title = null)
		{
			var lineSeries = new LineSeries()
			{
				Title = title,
			};
			foreach (var point in points)
				lineSeries.Points.Add(new DataPoint(point.X, point.Y));
			return lineSeries;
		}
		
		// private static ScatterSeries GenerateScatterSeries(double[] x, double[] y, string? title = null)
		// {
		// 	var scatterSeries = new ScatterSeries
		// 	{
		// 		MarkerType = MarkerType.Circle,
		// 		MarkerSize = 5,
		// 		Title = title
		// 	};
		//
		// 	for (var i = 0; i < x.Length; i++)
		// 		scatterSeries.Points.Add(new ScatterPoint(x[i], y[i]));
		//
		// 	return scatterSeries;
		// }
		// private static LineSeries GenerateLineSeries(double firstX, double lastX, double count, Func<double, double> y, string? title = null)
		// {
		// 	var lineSeries = new LineSeries()
		// 	{
		// 		Title = title,
		// 	};
		// 	double step = (lastX - firstX) / count;
		// 	for(; firstX<=lastX; firstX+=step)
		// 		lineSeries.Points.Add(new DataPoint(firstX, y.Invoke(firstX)));
		// 	return lineSeries;
		// }
		// private static LineSeries GenerateLineSeries(double[] x, Func<double, double> y, string? title = null)
		// {
		// 	var lineSeries = new LineSeries()
		// 	{
		// 		Title = title,
		// 	};
		// 	foreach (var t in x)
		// 		lineSeries.Points.Add(new DataPoint(t, y.Invoke(t)));
		// 	return lineSeries;
		// }
	}
}
