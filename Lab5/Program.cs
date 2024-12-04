using System.Collections.ObjectModel;
using Lab5;
using MathAdd;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

Tab GetTab(IMethod method, string name)
{
    var table = new TableView(new MethodTable(method))
    {
        Width = Dim.Fill(),
        Height = Dim.Fill(),
        FullRowSelect = true,
        X = Pos.Center(),
        Style = { AlwaysShowHeaders = true, ShowHorizontalBottomline = true }
    };
    return new Tab
    {
        DisplayText = name,
        View = table
    };
}

Matrix mat = new[,]
{
    { 1d, 2, 3, 4, 5 },
    { 2, -3, 0, -4, 5 },
    { 3, 0, 11, -3, 5 },
    { 4, -4, -3, -3, 3 },
    { 5, 5, 5, 3, 1 }
};
var errorRate = 6;

if (args.Length != 0)
    for (var i = 0; i < args.Length; i += 2)
    {
        var command = args[i];
        switch (command)
        {
            case "-e" or "--example":
                mat = new[,]
                {
                    { 3.48, 0.044, 0.54, 0.73, 1 },
                    { 0.044, 2.43, 0.98, 0.6, 0.65 },
                    { 0.54, 0.98, 2, 0.4, 0.44 },
                    { 0.73, 0.6, 0.4, 3.43, 0.44 },
                    { 1, 0.65, 0.44, 0.44, 2.48 }
                };
                i--;
                break;
            case "-c" or "--custom":
                mat = args[i + 1];
                break;
            case "-r" or "--error":
                errorRate = int.Parse(args[i + 1]);
                break;
            default:
                throw new ArgumentException($"Invalid command '{command}'");
        }
    }


var power = new PowerMethod(mat, errorRate);
var dot = new DotProductsMethod(mat, errorRate);
var rayleigh = new PartialRayleighMethod(mat, errorRate);
var reverse = new ReverseIterationsMethod(mat, errorRate);

Application.Init();

var w = new Window
{
    Title = "Lab5",
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    ColorScheme = new ColorScheme(Attribute.Default, new Attribute(ColorName.Black, ColorName.White), Attribute.Default,
        Attribute.Default, Attribute.Default)
};

var dic = new Dictionary<string, IMethod>
{
    { "Power", power },
    { "Dot", dot },
    { "Rayleigh", rayleigh },
    { "Reverse", reverse }
};

Application.QuitKey = Key.C.WithCtrl;

var tabView = new TabView
{
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

tabView.AddTab(GetTab(power, "Power"), true);
tabView.AddTab(GetTab(dot, "Dot"), false);
tabView.AddTab(GetTab(rayleigh, "Rayleigh"), false);
tabView.AddTab(GetTab(reverse, "Reverse"), false);


var vectorView = new ListView
{
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    Y = Pos.Percent(10)
};
var textInRightSide = new TextView
{
    Width = Dim.Fill(),
    Height = Dim.Percent(10),
    Text = "Vector X:",
    ReadOnly = true
};
var rightSideView = new FrameView
{
    Width = Dim.Percent(50),
    Height = Dim.Fill(),
    X = Pos.Percent(50),
    Y = Pos.Percent(10)
};
rightSideView.Add(textInRightSide, vectorView);


var textInLeftSide = new TextView
{
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    TextAlignment = Alignment.Center,
    ReadOnly = true
};
var leftSideView = new FrameView
{
    Width = Dim.Percent(50),
    Height = Dim.Fill(),
    Y = Pos.Percent(10)
};
leftSideView.Add(textInLeftSide);

var frameView = new FrameView
{
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

var comboBox = new ComboBox
{
    Width = Dim.Fill(),
    Height = Dim.Percent(10)
};
comboBox.SetSource(["Power", "Dot", "Rayleigh", "Reverse"]);
comboBox.SelectedItemChanged += (sender, args) =>
{
    if (args.Item >= 0)
    {
        var method = dic[args.Value.ToString()!];
        var temp = Matrix.GetUnitMatrix(mat.Rows) * method.MaxL;
        textInLeftSide.Text =
            $"ErrorRate: {errorRate}\nmax l: {method.MaxL}\n|A-l*E|: {Utils.CalcDeterminant(mat - temp)}\n\nIterations Count: {method.Iterations.Count}";
        vectorView.SetSource(new ObservableCollection<double>(method.X.ToArray()));
    }
};
comboBox.SelectedItem = 0;
frameView.Add(comboBox);
frameView.Add(leftSideView);
frameView.Add(rightSideView);


var totalTabView = new TabView
{
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

totalTabView.AddTab(new Tab { DisplayText = "Single", View = frameView }, true);
totalTabView.AddTab(new Tab { DisplayText = "Total", View = tabView }, false);

w.Add(totalTabView);
Application.Run(w);
Application.Shutdown();