using OxyPlot;
using OxyPlot.Series;

namespace Lab7
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			if (Settings.X.Length != Settings.Y.Length)
				throw new Exception();

			//double avg = Settings.X.Average();
			//double sigma = Settings.Y.Sum(x => Math.Pow(x - avg, 2));
			//MessageBox.Show(sigma.ToString());

			var plotModel = new PlotModel();

			var scatterSeries = new ScatterSeries
			{
				MarkerType = MarkerType.Circle,
				MarkerSize = 5,
				MarkerFill = OxyColors.Red // Цвет маркера
			};

			for (int i = 0; i < Settings.X.Length; i++)
				scatterSeries.Points.Add(new ScatterPoint(Settings.X[i], Settings.Y[i]));
			plotModel.Series.Add(scatterSeries);
			plotView1.Model = plotModel;

			int k = 0;
			double sumKvX = 0;
			double sumX = 0;
			double sumY = 0;
			double sumXY = 0;
			for(int i = 0; i < Settings.X.Length;i++)
			{
				sumKvX += Math.Pow(Settings.X[i], 2);
				sumX += Settings.X[i];
				sumY += Settings.Y[i];
				sumXY += Settings.X[i] * Settings.Y[i];
			}

		}
	}
}
