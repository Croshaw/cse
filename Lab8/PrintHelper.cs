using System.Data;
using System.Text;

namespace Lab8;

public static class PrintHelper
{
    
}

public struct Padding
{
    public int Top { get; }
    public int Left { get; }
    public int Bottom { get; }
    public int Right { get; }

    public Padding(int all)
    {
        Top = Left = Bottom = Right = all;
    }

    public Padding(int horizontal, int vertical)
    {
        Top = Bottom = vertical;
        Left = Right = horizontal;
    }
    public Padding(int top, int left, int bottom, int right)
    {
        Top = top;
        Left = left;
        Bottom = bottom;
        Right = right;
    }
}

public struct BorderStyle
{
    // ASCII стиль
    public static readonly BorderStyle Ascii = new BorderStyle(
        horizontal: '-',
        vertical: '|',
        topLeft: '+',
        topRight: '+',
        bottomLeft: '+',
        bottomRight: '+',
        cross: '+',
        leftCross: '+',
        rightCross: '+',
        topCross: '+',
        bottomCross: '+'
    );

    // Лёгкие линии (Unicode)
    public static readonly BorderStyle Light = new BorderStyle(
        horizontal: '─',
        vertical: '│',
        topLeft: '┌',
        topRight: '┐',
        bottomLeft: '└',
        bottomRight: '┘',
        cross: '┼',
        leftCross: '├',
        rightCross: '┤',
        topCross: '┬',
        bottomCross: '┴'
    );

    // Жирные линии (Unicode)
    public static readonly BorderStyle Heavy = new BorderStyle(
        horizontal: '━',
        vertical: '┃',
        topLeft: '┏',
        topRight: '┓',
        bottomLeft: '┗',
        bottomRight: '┛',
        cross: '╋',
        leftCross: '┣',
        rightCross: '┫',
        topCross: '┳',
        bottomCross: '┻'
    );

    // Двойные линии (Unicode)
    public static readonly BorderStyle Double = new BorderStyle(
        horizontal: '═',
        vertical: '║',
        topLeft: '╔',
        topRight: '╗',
        bottomLeft: '╚',
        bottomRight: '╝',
        cross: '╬',
        leftCross: '╠',
        rightCross: '╣',
        topCross: '╦',
        bottomCross: '╩'
    );

    // Смешанный стиль: двойные внешние, лёгкие внутренние
    public static readonly BorderStyle Mixed = new BorderStyle(
        horizontal: '─',
        vertical: '│',
        topLeft: '╔',
        topRight: '╗',
        bottomLeft: '╚',
        bottomRight: '╝',
        cross: '┼',
        leftCross: '├',
        rightCross: '┤',
        topCross: '┬',
        bottomCross: '┴'
    );
    public static readonly BorderStyle Minimal = new BorderStyle(
        ' ', // Horizontal
        ' ', // Vertical
        ' ', // TopLeft
        ' ', // TopRight
        ' ', // BottomLeft
        ' ', // BottomRight
        ' ', // Cross
        ' ', // LeftCross
        ' ', // RightCross
        ' ', // TopCross
        ' '  // BottomCross
    );

    public static readonly BorderStyle Dotted = new BorderStyle(
        '.', // Horizontal
        ':', // Vertical
        'o', // TopLeft
        'o', // TopRight
        'o', // BottomLeft
        'o', // BottomRight
        '*', // Cross
        'o', // LeftCross
        'o', // RightCross
        'o', // TopCross
        'o'  // BottomCross
    );

    public static readonly BorderStyle Dashed = new BorderStyle(
        '-', // Horizontal
        '|', // Vertical
        '+', // TopLeft
        '+', // TopRight
        '+', // BottomLeft
        '+', // BottomRight
        '+', // Cross
        '+', // LeftCross
        '+', // RightCross
        '+', // TopCross
        '+'  // BottomCross
    );

    public static readonly BorderStyle Curved = new BorderStyle(
        '─', // Horizontal
        '│', // Vertical
        '╭', // TopLeft
        '╮', // TopRight
        '╰', // BottomLeft
        '╯', // BottomRight
        '┼', // Cross
        '├', // LeftCross
        '┤', // RightCross
        '┬', // TopCross
        '┴'  // BottomCross
    );

    public static readonly BorderStyle Rounded = new BorderStyle(
        '─', // Horizontal
        '│', // Vertical
        '╭', // TopLeft
        '╮', // TopRight
        '╰', // BottomLeft
        '╯', // BottomRight
        '○', // Cross
        '├', // LeftCross
        '┤', // RightCross
        '┬', // TopCross
        '┴'  // BottomCross
    );

    public static readonly BorderStyle DoubleDashed = new BorderStyle(
        '=', // Horizontal
        '║', // Vertical
        '╓', // TopLeft
        '╖', // TopRight
        '╙', // BottomLeft
        '╜', // BottomRight
        '╫', // Cross
        '╟', // LeftCross
        '╢', // RightCross
        '╥', // TopCross
        '╨'  // BottomCross
    );

    public static readonly BorderStyle BoldDashed = new BorderStyle(
        '━', // Horizontal
        '┃', // Vertical
        '┏', // TopLeft
        '┓', // TopRight
        '┗', // BottomLeft
        '┛', // BottomRight
        '╋', // Cross
        '┣', // LeftCross
        '┫', // RightCross
        '┳', // TopCross
        '┻'  // BottomCross
    );

    public static readonly BorderStyle ThickCurved = new BorderStyle(
        '═', // Horizontal
        '║', // Vertical
        '╔', // TopLeft
        '╗', // TopRight
        '╚', // BottomLeft
        '╝', // BottomRight
        '╬', // Cross
        '╠', // LeftCross
        '╣', // RightCross
        '╦', // TopCross
        '╩'  // BottomCross
    );

    public static readonly BorderStyle Shaded = new BorderStyle(
        '░', // Horizontal
        '▒', // Vertical
        '▓', // TopLeft
        '▓', // TopRight
        '▓', // BottomLeft
        '▓', // BottomRight
        '█', // Cross
        '▓', // LeftCross
        '▓', // RightCross
        '▓', // TopCross
        '▓'  // BottomCross
    );

    public static readonly BorderStyle Decorative = new BorderStyle(
        '~', // Horizontal
        '!', // Vertical
        '@', // TopLeft
        '#', // TopRight
        '$', // BottomLeft
        '%', // BottomRight
        '^', // Cross
        '&', // LeftCross
        '*', // RightCross
        '(', // TopCross
        ')'  // BottomCross
    );
    public char Horizontal { get; }
    public char Vertical { get; }
    public char TopLeft { get; }
    public char TopRight { get; }
    public char BottomLeft { get; }
    public char BottomRight { get; }
    public char Cross { get; }
    public char LeftCross { get; }
    public char RightCross { get; }
    public char TopCross { get; }
    public char BottomCross { get; }

    public BorderStyle(char horizontal, char vertical, char topLeft, char topRight, char bottomLeft, char bottomRight, char cross, char leftCross, char rightCross, char topCross, char bottomCross)
    {
        Horizontal = horizontal;
        Vertical = vertical;
        TopLeft = topLeft;
        TopRight = topRight;
        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
        Cross = cross;
        LeftCross = leftCross;
        RightCross = rightCross;
        TopCross = topCross;
        BottomCross = bottomCross;
    }
}

public class CellSettings
{
    public Padding Padding { get; init; }
}


public class Table : DataTable
{
    // public DataTable Source { get; set; }
    public CellSettings CellSettings { get; set; }
    public BorderStyle BorderStyle { get; set; }
    public bool ColumnHeadersVisible { get; set; }
    public int Width { get; private set; }

    private int[] widths;

    public Table()
    {
        CellSettings = new CellSettings()
        {
            Padding = new Padding(0),
        };
        BorderStyle = BorderStyle.Light;
        Width = 0;
    }

    public void CalcWidth()
    {
        widths = new int[Columns.Count];
        for (var i = 0; i < widths.Length; i++)
        {
            widths[i] = (from DataRow sourceRow in Rows select sourceRow[i].ToString() into row select row?.Length ?? 0).Prepend(-1).Max();
            // if(widths[i]%2 != 0)
            //     widths[i]++;
        }
        Width = widths.Sum() + Columns.Count * (CellSettings.Padding.Left + CellSettings.Padding.Right) + Columns.Count + 1;
    }
    public string ToStr()
    {
        var sb = new StringBuilder();
        if (ColumnHeadersVisible)
        {
            sb.AppendLine(GenerateLine(widths, 0));
            sb.Append(GenerateVerticalOffset(widths, CellSettings.Padding.Top));
            for (int j = 0; j < Columns.Count; j++)
            {
                var cell = Columns[j].ColumnName?? "";
                sb.Append(BorderStyle.Vertical);
                sb.Append(new string(' ', CellSettings.Padding.Left));
                if (cell.Length < widths[j])
                {
                    int div = widths[j] - cell.Length;
                    var ins = new string(' ', div / 2);
                    cell = cell.Insert(0, ins);
                    cell += ins;
                    if (div % 2 != 0)
                        cell = cell.Insert(0, " ");
                }
                sb.Append(cell);
                sb.Append(new string(' ', CellSettings.Padding.Right));
            }
            sb.Append(BorderStyle.Vertical+"\n");
            
            sb.Append(GenerateVerticalOffset(widths, CellSettings.Padding.Bottom));
        }
        for (var i = 0; i < Rows.Count; i++)
        {
            var row = Rows[i];
            sb.AppendLine(GenerateLine(widths, ColumnHeadersVisible ? i + 1 : i));
            sb.Append(GenerateVerticalOffset(widths, CellSettings.Padding.Top));
           
            for (int j = 0; j < Columns.Count; j++)
            {
                var cell = row[j].ToString()?? "";
                sb.Append(BorderStyle.Vertical);
                sb.Append(new string(' ', CellSettings.Padding.Left));
                if (cell.Length < widths[j])
                {
                    int div = widths[j] - cell.Length;
                    var ins = new string(' ', div / 2);
                    cell = cell.Insert(0, ins);
                    cell += ins;
                    if (div % 2 != 0)
                        cell = cell.Insert(0, " ");
                }
                sb.Append(cell);
                sb.Append(new string(' ', CellSettings.Padding.Right));
            }
            sb.Append(BorderStyle.Vertical+"\n");
            
            sb.Append(GenerateVerticalOffset(widths, CellSettings.Padding.Bottom));
        }
        sb.AppendLine(GenerateLine(widths, (ColumnHeadersVisible ? Rows.Count + 1 : Rows.Count)));
        return sb.ToString();
    }

    private string GenerateVerticalOffset(int[] widths, int count)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < Columns.Count; j++)
            {
                sb.Append(BorderStyle.Vertical);
                sb.Append(new string(' ', widths[j] + CellSettings.Padding.Left + CellSettings.Padding.Right));
            }
            sb.Append(BorderStyle.Vertical+"\n");
        }
        return sb.ToString();
    }

    private string GenerateLine(int[] widths, int row)
    {
        var sb = new StringBuilder();
        for (var j = 0; j < Columns.Count; j++)
        {
            if (j == 0)
            {
                if (row == 0)
                {
                    sb.Append(BorderStyle.TopLeft);
                }
                else if(row == (ColumnHeadersVisible ? Rows.Count + 1 : Rows.Count))
                {
                    sb.Append(BorderStyle.BottomLeft);
                }
                else
                {
                    sb.Append(BorderStyle.LeftCross);
                }
            }
            else
            {
                if (row == 0)
                {
                    sb.Append(BorderStyle.TopCross);
                }
                else if(row == (ColumnHeadersVisible ? Rows.Count + 1 : Rows.Count))
                {
                    sb.Append(BorderStyle.BottomCross);
                }
                else
                {
                    sb.Append(BorderStyle.Cross);
                }
            }
            sb.Append(new string(BorderStyle.Horizontal, widths[j] + CellSettings.Padding.Left + CellSettings.Padding.Right));
        }

        sb.Append(row == (ColumnHeadersVisible ? Rows.Count + 1 : Rows.Count) ? BorderStyle.BottomRight : row == 0 ? BorderStyle.TopRight : BorderStyle.RightCross);
        return sb.ToString();
    }
}