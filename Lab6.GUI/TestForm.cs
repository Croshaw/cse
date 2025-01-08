using Lab6.GUI.Controls;
using MathNet.Symbolics;

namespace Lab6.GUI;

public partial class TestForm : Form
{
    public TestForm()
    {
        InitializeComponent();
        ToNUD.Maximum = 10000;
        SetupColumns();
        FromNUD.Value = 20;
        ToNUD.Value = 80;
        StepNUD.Value = 10;
        PointTB.Text = "2.022";
        XStepTB.Text = "0.5";
        FromNUD.ValueChanged += (s, e) =>
        {
            ToNUD.Minimum = FromNUD.Value;
        };
        ToNUD.ValueChanged += (s, e) =>
        {
            FromNUD.Maximum = ToNUD.Value;
        };
        PointTB.KeyPress += Utils.OnlyDoubleNumbers;
        XStepTB.KeyPress += Utils.OnlyDoubleNumbers;
        RunBTN.Click += (s, e) =>
        {
            try
            {
                var exactFunc = SymbolicExpression.Parse(FunctionTB.Text).Compile("x");
                var from = (int)FromNUD.Value;
                var to = (int)ToNUD.Value;
                var step = (int)StepNUD.Value;
                if (from >= to)
                {
                    MessageBox.Show(@"Заполните правильно диапазоны");
                    return;
                }
                if (step >= to)
                {
                    MessageBox.Show(@"Заполните правильно шаг");
                    return;
                }
                if (!double.TryParse(PointTB.Text.Replace(".", ","), out var point))
                {
                    MessageBox.Show(@"Не корректно введена точка");
                    return;
                }
                if (!double.TryParse(XStepTB.Text.Replace(".", ","), out var xstep))
                {
                    MessageBox.Show(@"Не корректно введен шаг для Х");
                    return;
                }

                var exactValue = exactFunc.Invoke(point);
                ConvergenceDGV.Rows.Clear();
                ErrorDGV.Rows.Clear();
                for (var i = from;i <= to; i += step)
                {
                    var x = GenerateX(i, xstep);
                    var points = x.Select(x => new PointD(x, exactFunc.Invoke(x))).ToArray();
                    var interpolation = new NewtonInterpolation(points);
                    var result = interpolation.Calculate(point);
                    ErrorDGV.Rows.Add(i, result, Math.Abs(result - exactValue));
                    if(i == from)
                        ConvergenceDGV.Rows.Add(i, result);
                    else
                    {
                        var last = (double)ConvergenceDGV.Rows[ConvergenceDGV.RowCount - 1].Cells[1].Value;
                        ConvergenceDGV.Rows.Add(i, result, Math.Abs(last-result));
                    }
                    MessageBox.Show(interpolation.ToString());
                }
                ExactValueTB.Text = exactFunc.Invoke(point).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Что-то пошло не так", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        };
    }

    private static double[] GenerateX(int count, double step)
    {
        var x = new double[count];
        for (var i = 0; i < count; i++)
        {
            x[i] = i * step;
        }

        return x;
    }

    private void SetupColumns()
    {
        ConvergenceDGV.Columns.Add(null, "Кол-во точек i");
        ConvergenceDGV.Columns.Add(null, "Pi(x)");
        ConvergenceDGV.Columns.Add(null, "\u2206|Pi(x)-P(i-1)(x)|");
        ErrorDGV.Columns.Add(null, "Кол-во точек i");
        ErrorDGV.Columns.Add(null, "Pi(x)");
        ErrorDGV.Columns.Add(null, "|Pi(x)-f(x)|");
    }
}