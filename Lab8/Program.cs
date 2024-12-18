//ln(x + 2) / x

using Lab8;

Func<double, double> function = (x) => Math.Log(x+2, Math.E) / x;
const double a = 2; //2
const double b = 3; //3

double epsilon = 1e-3;

var integrator = new RectangleIntegrator(0, 1, 10, epsilon, RectangleIntegrator.MethodType.Parabola,(x) => x*Math.Pow(Math.E, x));

int id = 1;
int lineWidth = 10;
char hz = '=';
foreach (var iteration in integrator.Iterations)
{
    var num = id + " итерация";
    id++;

    var table = new Table()
    {
        ColumnHeadersVisible = true
    };
    table.Columns.Add("i");
    table.Columns.Add("x");
    table.Columns.Add("y");

    for (var i = 0; i < iteration.Points.Length; i++)
        table.Rows.Add(i, iteration.Points[i].X, iteration.Points[i].Y);
    table.CalcWidth();
    Console.WriteLine(new string(hz, table.Width));
    Console.WriteLine(new string(hz, table.Width/2 - num.Length / 2) + num + new string(hz, table.Width - table.Width/2 - num.Length/2));
    Console.WriteLine(new string(hz, table.Width));
    Console.WriteLine($"I = {iteration.I}\tH = {iteration.H}");
    Console.WriteLine(table.ToStr());
}

