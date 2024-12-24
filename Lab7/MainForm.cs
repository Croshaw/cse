using MathNet.Numerics;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace Lab7
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			var plotModel = new PlotModel();
			var legend = new Legend()
			{	
				LegendPosition = LegendPosition.TopRight,
				LegendPlacement = LegendPlacement.Outside
			};
			plotModel.Legends.Add(legend);

			var functionSelector = new FunctionSelector(Settings.X, Settings.Y);
			plotModel.Series.Add(GenerateScatterSeries(Settings.X, Settings.Y, "f(x)"));
			// plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.LinearFunctionFitter.Calculate, "Линейная"));
			plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.PowerFunctionFitter.Calculate, "Степенная"));
			plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.SquareFunctionFitter.Calculate, "Квадратичная"));
			plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.ExponentialFunctionFitter.Calculate, "Экспоненциальная"));
			plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.CubicFunctionFitter.Calculate, "Кубическая"));
			//plotModel.Series.Add(GenerateLineSeries(Settings.X, functionSelector.LogFunctionFitter.Calculate, "Логарифмическая"));

			plotView1.Model = plotModel;
			
			tabPage1.Controls.Add(GenerateDataGridView(Settings.X, Settings.Y));
			
			tabPage2.Controls.Add(Hz(functionSelector.LinearFunctionFitter));
			tabPage2.Controls.Add(GenerateDataGridView(functionSelector.LinearFunctionFitter.X, functionSelector.LinearFunctionFitter.Y));
			
			tabPage3.Controls.Add(Hz(functionSelector.PowerFunctionFitter));
			tabPage3.Controls.Add(GenerateDataGridView(functionSelector.PowerFunctionFitter.X, functionSelector.PowerFunctionFitter.Y));
			
			tabPage4.Controls.Add(Hz(functionSelector.SquareFunctionFitter));
			tabPage4.Controls.Add(GenerateDataGridView(functionSelector.SquareFunctionFitter.X, functionSelector.SquareFunctionFitter.Y));
			
			tabPage5.Controls.Add(Hz(functionSelector.ExponentialFunctionFitter));
			tabPage5.Controls.Add(GenerateDataGridView(functionSelector.ExponentialFunctionFitter.X, functionSelector.ExponentialFunctionFitter.Y));

			tabPage6.Controls.Add(Hz(functionSelector.CubicFunctionFitter));
			tabPage6.Controls.Add(GenerateDataGridView(functionSelector.CubicFunctionFitter.X, functionSelector.CubicFunctionFitter.Y));
		}

		private static ScatterSeries GenerateScatterSeries(double[] x, double[] y, string? title = null)
		{
			var scatterSeries = new ScatterSeries
			{
				MarkerType = MarkerType.Circle,
				MarkerSize = 5,
				Title = title
			};
			
			for (var i = 0; i < Settings.X.Length; i++)
				scatterSeries.Points.Add(new ScatterPoint(x[i], y[i]));
			
			return scatterSeries;
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

		private static DataGridView GenerateDataGridView(double[] x, double[] y)
		{
			var dgv = new DataGridView()
			{
				BorderStyle = BorderStyle.None,
				BackColor = Color.White,
				Dock = DockStyle.Top,
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToOrderColumns = false,
				AllowUserToResizeColumns = false,
				AllowUserToResizeRows = false,
				ReadOnly = true,
				ColumnHeadersVisible = false,
				RowHeadersVisible = false,
				AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
			};
			for (var i = 0; i <= x.Length; i++)
				dgv.Columns.Add(null, "");
			dgv.Rows.Add(x.Select(x => x.ToString()).Prepend("x").ToArray());
			dgv.Rows.Add(y.Select(y => y.ToString()).Prepend("f(x)").ToArray());
			return dgv;
		}
		private static Panel Hz(LinearFunctionFitter fitter) {
			var panel = new Panel()
			{
				Dock = DockStyle.Fill
			};
			var label = new Label()
			{
				Text = $"k = {fitter.K}\nb = {fitter.B}\nσ = {fitter.Deviation}",
				Dock = DockStyle.Fill,
				// ReadOnly = true,
				// WordWrap = true,
				AutoSize = false
			};
			panel.Controls.Add(label);
			return panel;
		}
		private static Panel Hz(PowerFunctionFitter fitter) {
			var panel = new Panel()
			{
				Dock = DockStyle.Fill
			};
			var label = new Label()
			{
				Text = $"m = {fitter.M}\nb = {fitter.B}\nc = {fitter.C}\nσ = {fitter.Deviation}",
				Dock = DockStyle.Fill,
				// ReadOnly = true,
				// WordWrap = true,
				AutoSize = false
			};
			panel.Controls.Add(label);
			return panel;
		}
		private static Panel Hz(SquareFunctionFitter fitter) {
			var panel = new Panel()
			{
				Dock = DockStyle.Fill
			};
			var label = new Label()
			{
				Text = $"a = {fitter.A}\nb = {fitter.B}\nc = {fitter.C}\nσ = {fitter.Deviation}",
				Dock = DockStyle.Fill,
				// ReadOnly = true,
				// WordWrap = true,
				AutoSize = false
			};
			panel.Controls.Add(label);
			return panel;
		}
		private static Panel Hz(ExponentialFunctionFitter fitter) {
			var panel = new Panel()
			{
				Dock = DockStyle.Fill
			};
			var label = new Label()
			{
				Text = $"a = {fitter.A}\nb = {fitter.B}\nσ = {fitter.Deviation}",
				Dock = DockStyle.Fill,
				// ReadOnly = true,
				// WordWrap = true,
				AutoSize = false
			};
			panel.Controls.Add(label);
			return panel;
		}
		private static Panel Hz(CubicFunctionFitter fitter)
		{
			var panel = new Panel()
			{
				Dock = DockStyle.Fill
			};
			var label = new Label()
			{
				Text = $"a = {fitter.A}\nb = {fitter.B}\nc = {fitter.C}\nd = {fitter.D}\nσ = {fitter.Deviation}",
				Dock = DockStyle.Fill,
				// ReadOnly = true,
				// WordWrap = true,
				AutoSize = false
			};
			panel.Controls.Add(label);
			return panel;
		}
	}
}
