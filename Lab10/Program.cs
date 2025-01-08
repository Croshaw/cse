using Lab10;
using Spectre.Console;

// var ts = new CauchyApproximation(new Range<double>(0, 0.9), 0, 0.1, "-2*u-3*t+2", "1.75-1.5*t-1.75*(e^(-2*t))");
//
// AnsiConsole.Write(ts.Table);
// AnsiConsole.Write(ts.ComparisonTable);

double[] steps = [0.1, 0.05, 0.025, 0.0125, 0.00625, 0.003125];

var hz = new CauchyReporter(new Range<double>(0, 0.9), 0, "-2*u-3*t+2", "1.75-1.5*t-1.75*(e^(-2*t))", steps);
foreach (var step in steps)
    hz.GetApproximation(step)?.ToConsole();
// hz.ToConsole();