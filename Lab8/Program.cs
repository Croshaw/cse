//ln(x + 2) / x

using Lab8;

Func<double, double> function = (x) => Math.Log(x+2, Math.E) / x;
Func<double, double> firstDeriativeFunc = (x) => 1 / (Math.Pow(x, 2) + 2 * x) - (Math.Log(x + 2, Math.E) / Math.Pow(x, 2));
Func<double, double> secondDeriativeFunc = (x) => (2 * Math.Log(x + 2, Math.E) / Math.Pow(x, 3)) - ((3 * x + 4) / (Math.Pow(x, 4) + 4 * Math.Pow(x, 3) + 4 * Math.Pow(x, 2)));
Func<double, double> fifthDeriativeFunc = (x) => ((2 * (137 * Math.Pow(x, 4) + 770 * Math.Pow(x, 3) + 1880 * Math.Pow(x, 2) + 2160 * x + 960)) / Math.Pow(x, 10) + 10 * Math.Pow(x, 9) + 40 * Math.Pow(x, 8) + 80 * Math.Pow(x, 7) + 80 * Math.Pow(x, 6) + 32 * Math.Pow(x, 5)) - (120 * Math.Log(x + 2, Math.E) / Math.Pow(x, 6));

//2 * (137 * Math.Pow(x, 4) + 770 * Math.Pow(x, 3) + 1880 * Math.Pow(x, 2) + 2160 * x + 960);
//Math.Pow(x, 10) + 10 * Math.Pow(x, 9) + 40 * Math.Pow(x, 8) + 80 * Math.Pow(x, 7) + 80 * Math.Pow(x, 6) + 32 * *Math.Pow(x, 5);

//120*Math.Log(x+2,Math.E) / Math.Pow(x,6)

const double a = 2; //2
const double b = 3; //3

double epsilon = 1e-6;

var integrator = new RectangleIntegrator(a, b, 10, epsilon, RectangleIntegrator.MethodType.Parabola,function, fifthDeriativeFunc);

int id = 1;
int lineWidth = 10;
char hz = '=';
// foreach (var iteration in integrator.Iterations)
// {
//     var num = id + " итерация";
//     id++;
//
//     var table = new Table()
//     {
//         ColumnHeadersVisible = true
//     };
//     table.Columns.Add("i");
//     table.Columns.Add("x");
//     table.Columns.Add("y");
//
//     for (var i = 0; i < iteration.Points.Length; i++)
//         table.Rows.Add(i, iteration.Points[i].X, iteration.Points[i].Y);
//     table.CalcWidth();
//     Console.WriteLine(new string(hz, table.Width));
//     Console.WriteLine(new string(hz, table.Width/2 - num.Length / 2) + num + new string(hz, table.Width - table.Width/2 - num.Length/2));
//     Console.WriteLine(new string(hz, table.Width));
//     Console.WriteLine($"I = {iteration.I}\tH = {iteration.H}");
//     Console.WriteLine(table.ToStr());
// }

var table1 = new Table()
{
    ColumnHeadersVisible = true
};
int k = 0;
RectangleIntegrator.IIteration? last = null;
table1.Columns.Add("k");
table1.Columns.Add("n");
table1.Columns.Add("H");
table1.Columns.Add("I");
table1.Columns.Add("|I(k) - I(k-1)|");
table1.Columns.Add("E");
foreach (var iteration in integrator.Iterations)
{
	//Math.Abs(iteration.I - last.I)
	table1.Rows.Add(k, iteration.N, iteration.H, iteration.I, last is null ? "—" : iteration.E - (iteration.E / 4), iteration.E);
    last = iteration;
    k++;
}
table1.CalcWidth();
Console.WriteLine(table1.ToStr());