using Lab9;
using PrintHelper;

// double[] x = [1, 1.01, 1.02, 1.03, 1.04, 1.05, 1.06, 1.07, 1.08, 1.09, 1.10, 1.11, 1.12, 1.13, 1.14, 1.15, 1.16, 1.17, 1.18, 1.19, 1.2];
// double[] y = [0.841470985, 0.852160354, 0.862606646, 0.872795114, 0.882710803, 0.892338564, 0.901663063, 0.910668793, 0.919340088, 0.927661138, 0.935616002, 0.943188622, 0.950362847, 0.957122441, 0.963451109, 0.969332511, 0.974750287, 0.979688074, 0.984129532, 0.988058366, 0.991458348];
// Func<double, double> firstDerivativeFunc = (x) => 2*x*Math.Cos(Math.Pow(x, 2));
// Func<double, double> secondDerivativeFunc = (x) => 2*Math.Cos(Math.Pow(x, 2)) - 4*Math.Pow(x,2)*Math.Sin(Math.Pow(x,2));
// Func<double, double> thirdDerivativeFunc =
//     (x) => -12 * x * Math.Sin(Math.Pow(x, 2)) - 8 * Math.Pow(x, 3) * Math.Cos(Math.Pow(x, 2));
// Func<double, double> fourthDerivativeFunc = (x) =>
//     4 * (4 * Math.Pow(x, 4) - 3) * Math.Sin(Math.Pow(x, 2)) - 48 * Math.Pow(x, 2) * Math.Cos(Math.Pow(x, 2));

Console.OutputEncoding = System.Text.Encoding.UTF8;

double[] x = [1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2];
double[] y = [0.841, 0.810, 0.777, 0.741, 0.704, 0.665, 0.625, 0.583, 0.541, 0.498, 0.455];

Func<double, double> firstDerivativeFunc = (x) => Math.Cos(x) / x - Math.Sin(x) / Math.Pow(x,2);
Func<double, double> secondDerivativeFunc = (x) => -((Math.Pow(x,2) - 2) * Math.Sin(x) + 2*x*Math.Cos(x))/(Math.Pow(x,3));
Func<double, double> thirdDerivativeFunc = (x) => (3*(Math.Pow(x,2)-2)*Math.Sin(x)+(6*x-Math.Pow(x,3))*Math.Cos(x))/(Math.Pow(x,4));
Func<double, double> fourthDerivativeFunc = (x) => ((Math.Pow(x,4)-12*Math.Pow(x,2)+24)*Math.Sin(x)+4*(Math.Pow(x,3)-6*x)*Math.Cos(x))/(Math.Pow(x,5));

var firstDerivative = new double[x.Length];
var secondDerivative = new double[x.Length];
var thirdDerivative = new double[x.Length];
var fourthDerivative = new double[x.Length];
for (var i = 0; i < x.Length; i++)
{
    firstDerivative[i] = firstDerivativeFunc(x[i]);
    secondDerivative[i] = secondDerivativeFunc(x[i]);
    thirdDerivative[i] = thirdDerivativeFunc(x[i]);
    fourthDerivative[i] = fourthDerivativeFunc(x[i]);
}

var hz = new Hz(x, y);
var hz2 = new Hz2(x,y);
var hz3 = new Hz3(x,y);


// var table = new Table()
// {
//     BorderStyle = BorderStyle.Light,
//     ColumnHeadersVisible = true
// };
// table.Columns.Add("i");
// table.Columns.Add("x[i]");
// table.Columns.Add("y[i]'");
// table.Columns.Add("Δy[i]'f");
// table.Columns.Add("Δy[i]'b");
// table.Columns.Add("Δy[i]'s");
//
// double maxDeltaYF = -1;
// double maxDeltaYB = -1;
// double maxDeltaYS = -1;
//
// for (var i = 0; i < x.Length; i++)
// {
//     var deltaYF = i < x.Length - 1 ? Math.Abs(hz.DerivativeForward[i] - firstDerivative[i]) : -1;
//     var deltaYB = i > 0 ? Math.Abs(hz.DerivativeBackward[i-1] - firstDerivative[i]) : -1;
//     var deltaYS = Math.Abs(hz2.Derivative[i] - firstDerivative[i]);
//     
//     maxDeltaYF = Math.Max(maxDeltaYF, deltaYF);
//     maxDeltaYB = Math.Max(maxDeltaYB, deltaYB);
//     maxDeltaYS = Math.Max(maxDeltaYS, deltaYS);
//     
//     var yf = i < x.Length - 1 ? deltaYF.ToString(CultureInfo.InvariantCulture) : "";
//     var yb = i > 0 ? deltaYB.ToString(CultureInfo.InvariantCulture) : "";
//     table.Rows.Add(i, x[i], firstDerivative[i], yf, yb, deltaYS.ToString(CultureInfo.InvariantCulture));
// }
//
// table.Rows.Add("", "", "maxΔy[i]'", maxDeltaYF.ToString(CultureInfo.InvariantCulture), maxDeltaYB.ToString(CultureInfo.InvariantCulture), maxDeltaYS.ToString(CultureInfo.InvariantCulture));
// Console.WriteLine(table);
//
//
// var secTable = new Table()
// {
//     BorderStyle = BorderStyle.Light,
//     ColumnHeadersVisible = true
// };
// secTable.Columns.Add("i");
// secTable.Columns.Add("x[i]");
// secTable.Columns.Add("y[i]''");
// secTable.Columns.Add("Δy[i]''");
//
// double maxDeltaSecY = -1;
// for (var i = 0; i < x.Length; i++)
// {
//     var deltaY = i > 0 && i < x.Length - 1 ? Math.Abs(hz3.SecondDerivative[i-1] - secondDerivative[i]) : -1;
//     
//     maxDeltaSecY = Math.Max(maxDeltaSecY, deltaY);
//     
//     secTable.Rows.Add(i, x[i], secondDerivative[i], deltaY >= 0 ? deltaY.ToString(CultureInfo.InvariantCulture) : "");
// }
// secTable.Rows.Add("", "", "maxΔy[i]'", maxDeltaSecY.ToString(CultureInfo.InvariantCulture));
// Console.WriteLine(secTable);


var table = new Table()
{
    ColumnHeadersVisible = true,
    BorderStyle = BorderStyle.Light
};
table.AddColumns("i", "x[i]", "y[i]", "y[i]'");

Console.WriteLine("Направленная разность вперёд");
for (var i = 0; i < x.Length; i++)
    table.Rows.Add(i, x[i], y[i], i < x.Length-1 ?hz.DerivativeForward[i] : "");
Console.WriteLine(table);
table.Rows.Clear();

#region теоретическую погрешность направленная разность «вперед»

double maxE = double.MinValue;
double maxDifDer = double.MinValue;
var secondTable = new Table()
{
    BorderStyle = BorderStyle.Light,
    ColumnHeadersVisible = true
};
secondTable.AddColumns("i", "X", "E", "|y'-y'*|");

for (var i = 0; i < x.Length; i++)
{
    double e = Math.Abs(secondDerivative[i] / 2 * Math.Abs(hz.H));
    double difDer = i < x.Length-1 ? Math.Abs(firstDerivative[i] - hz.DerivativeForward[i]) : -1;
    if (i < x.Length - 1)
    {
        maxE = Math.Max(maxE, e);
        maxDifDer = Math.Max(maxDifDer, difDer);
        secondTable.Rows.Add(i, x[i], e, difDer);
    }
    else
        secondTable.Rows.Add(i, x[i], "","");
}
secondTable.Rows.Add("", "", "|E|<="+maxE,"Δy'="+maxDifDer);
Console.WriteLine(secondTable);
secondTable.Rows.Clear();
#endregion


Console.WriteLine("Направленная разность назад");
for (var i = 0; i < x.Length; i++)
    table.Rows.Add(i, x[i], y[i], i > 0 ?hz.DerivativeBackward[i-1] : "");
Console.WriteLine(table);
table.Rows.Clear();

#region теоретическую погрешность направленная разность «назад»

maxE = -1;
maxDifDer = -1;
for (var i = 0; i < x.Length; i++)
{
    double e = Math.Abs(secondDerivative[i] / 2 * Math.Abs(hz.H));
    double difDer = i > 0 ?Math.Abs(firstDerivative[i] - hz.DerivativeBackward[i-1]) : -1;
    if (i > 0)
    {
        maxE = Math.Max(maxE, e);
        maxDifDer = Math.Max(maxDifDer, difDer);
        secondTable.Rows.Add(i, x[i], e, difDer);
    }
    else
        secondTable.Rows.Add(i, x[i], "","");
}
secondTable.Rows.Add("", "", "|E|<="+maxE,"Δy'="+maxDifDer);

Console.WriteLine(secondTable);
secondTable.Rows.Clear();
#endregion

Console.WriteLine("Второй порядок точности");
for (var i = 0; i < x.Length; i++)
    table.Rows.Add(i, x[i], y[i], hz2.Derivative[i] );
Console.WriteLine(table);
table.Rows.Clear();

#region с теоретической оценкой погрешности для вычисления первой производной со вторым порядком точности

maxE = -1;
maxDifDer = -1;
double fe = 0;
double le = 0;
for (var i = 0; i < hz2.Derivative.Length; i++)
{
    double e = Math.Abs(thirdDerivative[i] / (i == 0 || i == hz2.Derivative.Length-1 ? 3 : 6) * Math.Pow(hz2.H,2));
    double difDer = Math.Abs(firstDerivative[i] - hz2.Derivative[i]);
    if (i == 0)
    {
        fe = e;
    } else if (i == hz2.Derivative.Length - 1)
    {
        le = e;
    }
    else
    {
        maxE = Math.Max(maxE, e);
        maxDifDer = Math.Max(maxDifDer, difDer);
    }
    secondTable.Rows.Add(i, x[i], e, difDer);
}
secondTable.Rows.Add("", "", "|E|<="+fe,"Δy'="+ (firstDerivative[0] - hz2.Derivative[0]));
secondTable.Rows.Add("", "", "|E|<="+maxE,"Δy'="+maxDifDer);
secondTable.Rows.Add("", "", "|E|<="+le,"Δy'="+
                                        (firstDerivative[^1] -
                                         hz2.Derivative[^1]));

Console.WriteLine(secondTable);
secondTable.Rows.Clear();

#endregion

Console.WriteLine("Вторая производная");
for (var i = 0; i < x.Length; i++)
    table.Rows.Add(i, x[i], y[i], i > 0 && i < x.Length-1 ? hz3.SecondDerivative[i-1] : "");
Console.WriteLine(table);
table.Rows.Clear();

#region теоретической оценкой погрешности для второй производной

maxE = -1;
maxDifDer = -1;
for (var i = 0; i < x.Length; i++)
{
    double e = i == 0 || i == x.Length-1 ? -1 : Math.Abs(fourthDerivative[i] / 12 * Math.Abs(hz.H));
    double difDer = i == 0 || i == x.Length-1 ? -1 :Math.Abs(secondDerivative[i] - hz3.SecondDerivative[i-1]);
    if(i == 0 || i == x.Length-1)
        secondTable.Rows.Add(i, x[i], "","");
    else
    {
        maxE = Math.Max(maxE, e);
        maxDifDer = Math.Max(maxDifDer, difDer);
        secondTable.Rows.Add(i, x[i], e, difDer);
    }
}
secondTable.Rows.Add("", "", "|E|<="+maxE,"Δy'="+maxDifDer);

Console.WriteLine(secondTable);
secondTable.Rows.Clear();
#endregion