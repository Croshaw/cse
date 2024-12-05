using System.Collections.ObjectModel;
using Lab5;
using MathAdd;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;
Matrix mat = new[,]
{
    { 1d, 2, 3, 4, 5 },
    { 2, -3, 0, -4, 5 },
    { 3, 0, 11, -3, 5 },
    { 4, -4, -3, -3, 3 },
    { 5, 5, 5, 3, 1 }
};
var errorRate = 6;
bool isMin = false;
if (args.Length != 0)
    for (var i = 0; i < args.Length; i += 2)
    {
        var command = args[i];
        switch (command)
        {
            case "-m" or "--min":
                isMin = true;
                i--;
                break;
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

var reverseMat = mat.Reverse();

var power = new PowerMethod(mat, errorRate, false);
var dot = new DotProductsMethod(mat, errorRate, false);
var rayleigh = new PartialRayleighMethod(mat, errorRate, false);

var reversePower = new PowerMethod(reverseMat, errorRate, true);
var reverseDot = new DotProductsMethod(reverseMat, errorRate, true);
var reverseRayleigh = new PartialRayleighMethod(reverseMat, errorRate, true);

var dic = new Dictionary<string, (IMethod, IMethod)>
{
    { "Power", (power, reversePower) },
    { "Dot", (dot, reverseDot) },
    { "Rayleigh", (rayleigh, reverseRayleigh) },
};
// var reverse = new ReverseIterationsMethod(mat, errorRate);

var colorScheme = new ColorScheme(Attribute.Default, new Attribute(ColorName.Black, ColorName.White), Attribute.Default,
    Attribute.Default, Attribute.Default);


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

void SetupTabs(TabView tabView, Dictionary<string, (IMethod, IMethod)> methods)
{
    foreach (var tab in tabView.Tabs.ToArray())
        tabView.RemoveTab(tab);
    
    foreach (var tuple in methods)
        tabView.AddTab(GetTab(isMin ? tuple.Value.Item2 : tuple.Value.Item1, tuple.Key), false);
}

var tabView = new TabView
{
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

var comboBox = new ComboBox
{
    Width = Dim.Fill(),
    Height = Dim.Percent(10)
};

void Setup()
{
    SetupTabs(tabView, dic);
    comboBox.OnSelectedChanged();
}

var radio = new CheckBox()
{
    Text = "Is Min",
    CheckedState = isMin ? CheckState.Checked : CheckState.UnChecked
};
radio.CheckedStateChanging += (sender, args) =>
{
    isMin = args.NewValue == CheckState.Checked;
    Setup();
};

// tabView.AddTab(GetTab(power, "Power"), true);
// tabView.AddTab(GetTab(dot, "Dot"), false);
// tabView.AddTab(GetTab(rayleigh, "Rayleigh"), false);
// tabView.AddTab(GetTab(reverse, "Reverse"), false);

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
    ReadOnly = true,
    ColorScheme = colorScheme
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
    ReadOnly = true,
    ColorScheme = colorScheme
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


comboBox.SetSource(new ObservableCollection<string>(dic.Keys.ToArray()));
comboBox.SelectedItemChanged += (sender, args) =>
{
    if (args.Item >= 0)
    {
        var tuple = dic[args.Value.ToString()!];
        var method = isMin ? tuple.Item2 : tuple.Item1;
        var temp = Matrix.GetUnitMatrix(mat.Rows) * method.L;
        textInLeftSide.Text =
            $"ErrorRate: {errorRate}\nl: {method.L}\n|A-l*E|: {Utils.CalcDeterminant(mat - temp)}\n\nIterations Count: {method.IterationCount}";
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
//
// ComboBox cb = new ComboBox()
// {
//     Source = new ListWrapper<string>(["3","4","5","6","7","8","9"]),
//     Width = Dim.Fill(30),
//     Height = Dim.Absolute(10),
//     SelectedItem = 0
// };
// cb.SelectedItemChanged += (sender, args) =>
// {
//     errorRate = int.Parse(args.Value.ToString()!);
//     dic.Clear();
//     dic["Power"] = (new PowerMethod(mat, errorRate, false), new PowerMethod(mat, errorRate, true));
//     dic["Dot"] = (new DotProductsMethod(mat, errorRate, false), new DotProductsMethod(mat, errorRate, true));
//     dic["Rayleigh"] = (new PartialRayleighMethod(mat, errorRate, false), new PartialRayleighMethod(mat, errorRate, true));
//     Setup();
// };
Application.Init();
Application.QuitKey = Key.C.WithCtrl;

var w = new Window
{
    Title = "Lab5",
    Width = Dim.Fill(),
    Height = Dim.Fill(),
    ColorScheme = colorScheme
};
w.Add(totalTabView);
w.Add(radio);
radio.X = Pos.Absolute(20);
radio.Y = Pos.Absolute(1);

// radio.Y = Pos.;

Application.Run(w);
Application.Shutdown();