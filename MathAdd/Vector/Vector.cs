using System.Collections;

namespace MathAdd;

public readonly struct Vector : ICloneable, IEnumerable<double>
{
    private readonly double[] _source;

    public Vector(double[] source)
    {
        _source = source;
        Count = source.Length;
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Vector(int count)
    {
        _source = new double[count];
        Count = count;
        EuclideanNorm = 0;
    }

    public Vector(int count, double initialValue)
    {
        _source = new double[count];
        Count = count;
        for (var i = 0; i < count; i++)
            _source[i] = initialValue;
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public Vector(int count, Func<int, double> initialFunction)
    {
        _source = new double[count];
        Count = count;
        for (var i = 0; i < count; i++)
            _source[i] = initialFunction(i);
        EuclideanNorm = Utils.CalcEuclideanNorm(this);
    }

    public int Count { get; }

    public double EuclideanNorm { get; }

    public double this[int id] => _source[id];

    public Matrix ToMatrix()
    {
        var thys = this;
        return new Matrix(1, Count, (i, j) => thys[j]);
    }

    public object Clone()
    {
        var result = new Vector(_source.Clone() as double[] ?? throw new InvalidOperationException());
        return result;
    }

    public static Vector GetUnitVector(int size)
    {
        return new Vector(size, i => 1);
    }

    public static Vector operator +(Vector a, Vector b)
    {
        if (a.Count != b.Count)
            throw new InvalidOperationException("Vector sizes do not match.");
        var result = new Vector(a.Count, i => a[i] + b[i]);
        return result;
    }

    public static Vector operator +(Vector a, double b)
    {
        var result = new Vector(a.Count, i => a[i] + b);
        return result;
    }

    public static Vector operator -(Vector a, Vector b)
    {
        if (a.Count != b.Count)
            throw new InvalidOperationException("Vector sizes do not match.");
        var result = new Vector(a.Count, i => a[i] - b[i]);
        return result;
    }

    public static Vector operator -(Vector a, double b)
    {
        var result = new Vector(a.Count, i => a[i] - b);
        return result;
    }

    public static Vector operator *(Vector a, Vector b)
    {
        if (a.Count != b.Count)
            throw new InvalidOperationException("Vector sizes do not match.");

        var result = new Vector(a.Count, i => a[i] * b[i]);
        return result;
    }

    public static Vector operator *(Vector a, double b)
    {
        var result = new Vector(a.Count, i => a[i] * b);
        return result;
    }

    public static Vector operator /(Vector a, Vector b)
    {
        if (a.Count != b.Count)
            throw new InvalidOperationException("Vector sizes do not match.");

        var result = new Vector(a.Count, i => a[i] / b[i]);
        return result;
    }

    public static Vector operator /(Vector a, double b)
    {
        var result = new Vector(a.Count, i => a[i] / b);
        return result;
    }
    public static Vector operator /(double a, Vector b)
    {
        var result = new Vector(b.Count, i => a/b[i]);
        return result;
    }


    public static implicit operator Vector(double[] source)
    {
        return new Vector(source);
    }

    public IEnumerator<double> GetEnumerator()
    {
        foreach (var value in _source) yield return value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}