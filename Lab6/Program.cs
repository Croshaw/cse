// double[] x = [1, 1.04, 1.08, 1.12, 1.16, 1.2];
// double[] y = [0, 0.039220713, 0.076961041, 0.113328685, 0.148420005, 0.182321557];
// var leftBorder = 1;
// var rightBorder = 0.833333;
// var findX = 1.05;

double[] x = [1, 1.1, 1.17, 1.23, 1.3, 1.35, 1.41, 1.5, 1.56, 1.6, 1.64, 1.7, 1.75, 1.8, 1.89, 1.93, 2];
double[] y =
[
    1.718, 1.904, 2.052, 2.191, 2.369, 2.507, 2.686, 2.982, 3.199, 3.353, 3.515, 3.774, 4.005, 4.250, 4.729, 4.960,
    5.389
];
var leftBorder = 1.718282;
var rightBorder = 6.389056;
var findX = 1.47;


var size = x.Length;

var h = new double[size - 1];
var omega = new double[size - 2];
for (var i = 0; i < h.Length; i++) h[i] = x[i + 1] - x[i];
for (var i = 0; i < omega.Length; i++)
{
    var min = -h[i + 1] / 3;
    var max = h[i] / 3;
    if (min <= 0 && 0 <= max)
        omega[i] = 0;
    else
        omega[i] = max + min + min;
}

var a = new double[size - 2];
var b = new double[size - 2];
var c = new double[size - 2];
var d = new double[size - 2];
var e = new double[size - 2];
for (var i = 0; i < a.Length; i++)
{
    a[i] = -2 / h[i] + omega[i] * (6 / (h[i] * h[i]));
    b[i] = -4 / h[i + 1] - 4 / h[i] - omega[i] * (6 / (h[i + 1] * h[i + 1])) + omega[i] * (6 / (h[i] * h[i]));
    c[i] = -2 / h[i + 1] - omega[i] * 6 / (h[i + 1] * h[i + 1]);
    d[i] = -6 / h[i + 1] - omega[i] * 12 / (h[i + 1] * h[i + 1]);
    e[i] = -6 / h[i] - omega[i] * 12 / (h[i] * h[i]);
}

var alpha = new double[size - 1];
var beta = new double[size - 1];
beta[0] = leftBorder;
for (var i = 1; i < size - 1; i++)
{
    alpha[i] = -c[i - 1] / (a[i - 1] * alpha[i - 1] + b[i - 1]);
    beta[i] = (d[i - 1] * ((y[i + 1] - y[i]) / h[i]) + e[i - 1] * ((y[i] - y[i - 1]) / h[i - 1]) -
               a[i - 1] * beta[i - 1]) / (a[i - 1] * alpha[i - 1] + b[i - 1]);
}

var newX = new double[size];
newX[size - 1] = rightBorder;
for (var i = size - 2; i >= 0; i--) newX[i] = alpha[i] * newX[i + 1] + beta[i];
var firstInd = -1;
var secondInd = -1;
for (var i = 0; i < size; i++)
    if (x[i] >= findX)
    {
        firstInd = i - 1;
        secondInd = i;
        break;
    }

var t = (findX - x[firstInd]) / h[firstInd];
var result = y[firstInd] * (1 - 3 * Math.Pow(t, 2) + 2 * Math.Pow(t, 3)) +
             y[secondInd] * (3 * Math.Pow(t, 2) - 2 * Math.Pow(t, 3)) +
             newX[firstInd] * h[firstInd] * (t - 2 * Math.Pow(t, 2) + Math.Pow(t, 3)) +
             newX[secondInd] * h[secondInd] * (Math.Pow(t, 3) - Math.Pow(t, 2));

Console.WriteLine(result);