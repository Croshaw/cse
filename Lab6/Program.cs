using System.Globalization;
using Lab6;

// double[] x = [1, 1.04, 1.08, 1.12, 1.16, 1.2];
// double[] y = [0, 0.039220713, 0.076961041, 0.113328685, 0.148420005, 0.182321557];
// var leftBorder = 1;
// var rightBorder = 0.833333;
// var findX = 1.05;


Console.WriteLine($"S`(a): {Settings.Sa.ToString(CultureInfo.InvariantCulture)}    |    S`(b): {Settings.Sb.ToString(CultureInfo.InvariantCulture)}    |    x*:{Settings.UnknownX.ToString(CultureInfo.InvariantCulture)}");

PrintHelper.Print(Settings.X, prefix: "X: [ ", postfix: " ]", printFunc: d => d.ToString(CultureInfo.InvariantCulture));
PrintHelper.Print(Settings.Y, prefix: "Y: [ ", postfix: " ]", printFunc: d => d.ToString(CultureInfo.InvariantCulture));
Console.WriteLine();


var size = Settings.X.Length;

var h = new double[size - 1];
var sigma = new double[size - 2];
for (var i = 0; i < h.Length; i++) h[i] = Settings.X[i + 1] - Settings.X[i];
for (var i = 0; i < sigma.Length; i++)
{
    var min = -h[i + 1] / 3;
    var max = h[i] / 3;
    if (min <= 0 && 0 <= max)
        sigma[i] = 0.0;
    else
        sigma[i] = min;
}

PrintHelper.Print(h, prefix: "H: [ ", postfix: " ]", printFunc: d => d.ToString("F3", CultureInfo.InvariantCulture));
PrintHelper.Print(sigma, prefix: "Sigma: [ ", postfix: " ]", printFunc: d => d.ToString(CultureInfo.InvariantCulture));
Console.WriteLine();



var a = new double[size - 2];
var b = new double[size - 2];
var c = new double[size - 2];
var d = new double[size - 2];
var e = new double[size - 2];
for (var i = 0; i < a.Length; i++)
{
    a[i] = -2 / h[i] + sigma[i] * (6 / (h[i] * h[i]));
    b[i] = -4 / h[i + 1] - 4 / h[i] - sigma[i] * (6 / (h[i + 1] * h[i + 1])) + sigma[i] * (6 / (h[i] * h[i]));
    c[i] = -2 / h[i + 1] - sigma[i] * 6 / (h[i + 1] * h[i + 1]);
    d[i] = -6 / h[i + 1] - sigma[i] * 12 / (h[i + 1] * h[i + 1]);
    e[i] = -6 / h[i] - sigma[i] * 12 / (h[i] * h[i]);
}

PrintHelper.Print(a, prefix: "A: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
PrintHelper.Print(b, prefix: "B: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
PrintHelper.Print(c, prefix: "C: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
PrintHelper.Print(d, prefix: "D: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
PrintHelper.Print(e, prefix: "E: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
Console.WriteLine();

var alpha = new double[size - 1];
var betta = new double[size - 1];
betta[0] = Settings.Sa;
for (var i = 1; i < size - 1; i++)
{
    alpha[i] = -c[i - 1] / (a[i - 1] * alpha[i - 1] + b[i - 1]);
    betta[i] = (d[i - 1] * ((Settings.Y[i + 1] - Settings.Y[i]) / h[i]) + e[i - 1] * ((Settings.Y[i] - Settings.Y[i - 1]) / h[i - 1]) -
               a[i - 1] * betta[i - 1]) / (a[i - 1] * alpha[i - 1] + b[i - 1]);
}

PrintHelper.Print(alpha, prefix: "Alpha: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
PrintHelper.Print(betta, prefix: "Betta: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
Console.WriteLine();


var m = new double[size];
m[size - 1] = Settings.Sb;
for (var i = size - 2; i >= 0; i--) m[i] = alpha[i] * m[i + 1] + betta[i];

PrintHelper.Print(m, prefix: "M: [ ", postfix: " ]", printFunc: d => d.ToString("F5", CultureInfo.InvariantCulture));
Console.WriteLine();
List<(Func<double, bool>, Func<double, double>)> functions = [];
for (int i = 0; i < m.Length-1; i++)
{
    functions.Add(((x) => x >= Settings.X[i] && x < Settings.X[i + 1], (x) =>
    {
		var t = (x - Settings.X[i]) / h[i];
		return Settings.Y[i] * (1 - 3 * Math.Pow(t, 2) + 2 * Math.Pow(t, 3)) +
					 Settings.Y[i+1] * (3 * Math.Pow(t, 2) - 2 * Math.Pow(t, 3)) +
					 m[i] * h[i] * (t - 2 * Math.Pow(t, 2) + Math.Pow(t, 3)) +
					 m[i+1] * h[i] * (Math.Pow(t, 3) - Math.Pow(t, 2));
    }));

    string ex = $"S{i} = ";
    if(Settings.Y[i] != 0) ex += $"{Settings.Y[i]}(1 - 3t^2 + 2t^3) + ";
    if (Settings.Y[i + 1] != 0) ex += $"{Settings.Y[i + 1]}(3t^2 - 2t^3) + ";
    
    if(h[i] == 0)
        continue;
    bool hi = Math.Abs(h[i] - 1) > 0.000006;
    if (m[i] != 0)
    {
        if (Math.Abs(m[i] - 1) > 0.000006)
            ex += $"{m[i].ToString("F5", CultureInfo.InvariantCulture)}" + (hi ? " * " : "");
        if(hi)
            ex += $"{h[i].ToString("F2", CultureInfo.InvariantCulture)}";
        ex += "(t - 2t^2 + t^3) + ";
    }
    if (m[i+1] != 0)
    {
        if (Math.Abs(m[i+1] - 1) > 0.000006)
            ex += $"{m[i+1].ToString("F5", CultureInfo.InvariantCulture)}" + (hi ? " * " : "");
        if(hi)
            ex += $"{h[i].ToString("F2", CultureInfo.InvariantCulture)}";
        ex += "(t^3 - t^2)";
    }
    Console.Write(ex);
    Console.WriteLine($"   X: [{Settings.X[i].ToString(CultureInfo.InvariantCulture)}; {Settings.X[i+1].ToString(CultureInfo.InvariantCulture)}]");
}

Console.WriteLine();

bool first = true;
while (true)
{
    double unknownX = 0;
    if (first)
    {
        first = false;
        unknownX = Settings.UnknownX;
    }
    else
    {
        var command = Console.ReadLine();
        bool shouldEnd = false;
        switch (command)
        {
            case "exit":
            case "close":
            case "quit":
            case "end":
                shouldEnd = true;
                break;
        }

        if (shouldEnd)
            break;
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.Write("\r" + new string(' ', Console.BufferWidth) + "\r");
        if (Double.TryParse(command, NumberStyles.Any, CultureInfo.InvariantCulture, out double x) && x >= Settings.X[0] && x <= Settings.X[^1])
        {
            unknownX = x;
        }
        else
            continue;
    }
    var firstInd = -1;
    var secondInd = -1;
    for (var i = 1; i < size; i++)
        if (Settings.X[i] >= unknownX)
        {
            firstInd = i - 1;
            secondInd = i;
            break;
        }
    var result = functions.First(pair => pair.Item1.Invoke(unknownX)).Item2.Invoke(unknownX);
    var t = (unknownX - Settings.X[firstInd]) / h[firstInd];
    //var result = Settings.Y[firstInd] * (1 - 3 * Math.Pow(t, 2) + 2 * Math.Pow(t, 3)) +
    //             Settings.Y[secondInd] * (3 * Math.Pow(t, 2) - 2 * Math.Pow(t, 3)) +
    //             m[firstInd] * h[firstInd] * (t - 2 * Math.Pow(t, 2) + Math.Pow(t, 3)) +
    //             m[secondInd] * h[firstInd] * (Math.Pow(t, 3) - Math.Pow(t, 2));
    Console.WriteLine($"t = {t.ToString(CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Sc({unknownX.ToString(CultureInfo.InvariantCulture)}) = {result.ToString(CultureInfo.InvariantCulture)}");

}
