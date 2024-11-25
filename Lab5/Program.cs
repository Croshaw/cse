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

if (args.Length != 0)
{
    var command = args[0];
    switch (command)
    {
        case "-e":
            mat = new[,]
            {
                { 3.48, 0.044, 0.54, 0.73, 1 },
                { 0.044, 2.43, 0.98, 0.6, 0.65 },
                { 0.54, 0.98, 2, 0.4, 0.44 },
                { 0.73, 0.6, 0.4, 3.43, 0.44 },
                { 1, 0.65, 0.44, 0.44, 2.48 }
            };
            break;
        case "-p":
            mat = args.Length > 2 ? string.Join(" ", args.Skip(1)) : args[1];
            break;
        default:
            throw new ArgumentException($"Invalid command '{command}'");
    }
}


var errorRate = 6;

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

w.Add(tabView);
Application.Run(w);
Application.Shutdown();