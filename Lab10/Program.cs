using PrintHelper;

Func<double,double,double> function = (u,t) => (2*t*u+1)/(1-Math.Pow(t, 2));
Func<double,double,double> exactSolution = (u,t) => Math.Pow(t,2)*u+t+1;
double t0 = 0;
double T = 0.9;
double h = 0.1;

var n = (int)((T - t0) / h) + 1;
var t = new double[n];
var u = new double[n];
t[0] = t0;
u[0] = 1;
for (var i = 1; i < n; i++)
{
    u[i] = u[i - 1] + h * function(u[i - 1], t[i - 1]);
    t[i] = t[i-1] + h;
}

var table = new Table()
{
    ColumnHeadersVisible = true,
    BorderStyle = BorderStyle.Light
};
table.AddColumns("i", "t", "u", "toch");
for (var i = 0; i < n; i++)
{
   table.Rows.Add(i, t[i], u[i], exactSolution(u[i], t[i]));
}

Console.WriteLine(table);