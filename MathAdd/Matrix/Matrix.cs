using System.Collections;
using System.Text.RegularExpressions;

namespace MathAdd;

public readonly struct Matrix : ICloneable, IEnumerable<Vector>
{
    private readonly Vector[] _source;
    private readonly double[,] _source1;

    public Matrix(Vector[] source)
    {
        Rows = source.Length;
        Columns = source[0].Count;
        _source = source;
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Matrix(double[,] source)
    {
        Rows = source.GetLength(0);
        Columns = source.GetLength(1);
        _source = new Vector[Rows];
        for (var i = 0; i < Rows; i++) _source[i] = new Vector(Columns, j => source[i, j]);
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Matrix(double[][] source)
    {
        Rows = source.Length;
        Columns = source[0].Length;
        _source = new Vector[Rows];
        for (var i = 0; i < Rows; i++) _source[i] = new Vector(Columns, j => source[i][j]);
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Matrix(int rows, int columns)
    {
        _source = new Vector[rows];
        for (var i = 0; i < Rows; i++) _source[i] = new Vector(columns);
        Rows = rows;
        Columns = columns;
        EuclideanNorm = 0;
    }

    public Matrix(int rows, int columns, double initialValue)
    {
        _source = new Vector[rows];
        for (var i = 0; i < Rows; i++) _source[i] = new Vector(columns, initialValue);
        Rows = rows;
        Columns = columns;
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Matrix(int rows, int columns, Func<int, int, double> initialFunction)
    {
        _source = new Vector[rows];
        Rows = rows;
        Columns = columns;
        for (var i = 0; i < Rows; i++) _source[i] = new Vector(columns, j => initialFunction(i, j));
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public int Rows { get; }
    public int Columns { get; }
    public bool IsSquare => Rows == Columns;
    public double EuclideanNorm { get; }

    public double this[int row, int column] => _source[row][column];

    public Vector this[int id] => _source[id];

    public Vector[] ToVectors()
    {
        return (Vector[])_source.Clone();
    }

    public object Clone()
    {
        var result = new Matrix(_source.Clone() as Vector[] ?? throw new InvalidOperationException());
        return result;
    }

    public Matrix Reverse()
    {
        return Utils.Reverse(this);
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Columns != b.Columns || a.Rows != b.Rows)
            throw new InvalidOperationException("Для матриц с разным размером сложение не возможно!");
        var result = new Matrix(a.Rows, a.Columns, (i, j) => a[i, j] + b[i, j]);
        return result;
    }

    public static Matrix operator +(Matrix a, double b)
    {
        var result = new Matrix(a.Rows, a.Columns, (i, j) => a[i, j] + b);
        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Columns != b.Columns || a.Rows != b.Rows)
            throw new InvalidOperationException("Для матриц с разным размером вычетание не возможно!");
        var result = new Matrix(a.Rows, a.Columns, (i, j) => a[i, j] - b[i, j]);
        return result;
    }

    public static Matrix operator -(Matrix a, double b)
    {
        var result = new Matrix(a.Rows, a.Columns, (i, j) => a[i, j] - b);
        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows && a.Rows != b.Columns)
            throw new ArgumentException(
                "Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
        if (a.Columns == b.Rows)
            return new Matrix(a.Rows, b.Columns, (i, j) =>
            {
                double temp = 0;
                for (var k = 0; k < a.Columns; k++) temp += a[i, k] * b[k, j];
                return temp;
            });
        return new Matrix(b.Rows, a.Columns, (i, j) =>
        {
            double temp = 0;
            for (var k = 0; k < b.Columns; k++) temp += b[i, k] * a[k, j];
            return temp;
        });
    }

    public static Matrix operator *(Matrix a, double b)
    {
        var result = new Matrix(a.Rows, a.Columns, (i, j) => a[i, j] * b);
        return result;
    }

    public static implicit operator Matrix(double[,] source)
    {
        return new Matrix(source);
    }

    public static implicit operator Matrix(double[][] source)
    {
        return new Matrix(source);
    }

    public static implicit operator Matrix(string source)
    {
        var pattern = "[\\{|\\[]\\s*([\\d\\.,\\s]+?)\\s*[\\}|\\]]";
        var matches = Regex.Matches(source, pattern);
        if (matches.Count == 0)
            throw new ArgumentException("Can't parse string to Matrix");
        return matches.Select(m => m.Groups[1].Value.Split(',').Select(n => double.Parse(n.Trim())).ToArray())
            .ToArray();
    }

    public static implicit operator Matrix(Vector[] source)
    {
        return new Matrix(source);
    }

    public static implicit operator Matrix(Vector vector)
    {
        return vector.ToMatrix();
    }

    public static Matrix GetUnitMatrix(int size)
    {
        return new Matrix(size, size, (i, j) => i == j ? 1 : 0);
    }

    public IEnumerator<Vector> GetEnumerator()
    {
        foreach (var vector in _source) yield return vector;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}