namespace MathAdd;

internal static class Utils
{
    internal static double CalcEuclideanNorm(Matrix matrix)
    {
        return Math.Sqrt(matrix.Sum(vec => vec.Sum(vec => vec * vec)));
    }

    internal static double CalcEuclideanNorm(Vector vector)
    {
        return Math.Sqrt(vector.Sum(elem => elem * elem));
    }

    internal static Matrix Reverse(Matrix mat)
    {
        if (!mat.IsSquare)
            throw new ArgumentException("Matrix must be square");
        var size = mat.Rows;
        var vectors = mat.ToVectors();
        var singles = new Vector[size];
        for (var i = 0; i < size; i++)
            singles[i] = new Vector(size, j => j == i ? 1 : 0);
        for (var i = 0; i < size; i++)
        {
            var del = vectors[i][i];
            vectors[i] = vectors[i] / del;
            singles[i] = singles[i] / del;
            for (var j = i + 1; j < size; j++)
            {
                del = vectors[j][i];
                vectors[j] -= vectors[i] * del;
                singles[j] -= singles[i] * del;
            }
        }

        var inverse = new Vector[size];
        for (var i = size - 1; i >= 0; i--)
        {
            var temp = new Vector(size, 0);
            for (var j = i + 1; j < size; j++) temp += inverse[j] * vectors[i][j];
            inverse[i] = singles[i] - temp;
        }

        return inverse;
    }
}