namespace MathAdd;

public static class Utils
{
    internal static double CalcEuclideanNorm(Matrix matrix)
    {
        return Math.Sqrt(matrix.Sum(vec => vec.Sum(vec => vec * vec)));
    }

    internal static double CalcEuclideanNorm(Vector vector)
    {
        return Math.Sqrt(vector.Sum(elem => elem * elem));
    }

    public static double CalcDeterminant(Matrix matrix)
    {
        if (matrix.Rows != matrix.Columns)
            throw new ArgumentException("Определитель может быть вычислен только для квадратных матриц.");

        var n = matrix.Rows;
        var l = new double[n, n];
        var u = new double[n, n];

        // Инициализация матрицы L
        for (var i = 0; i < n; i++)
            l[i, i] = 1;

        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
        {
            double tmp = 0;
            for (var k = 0; k < Math.Min(i, j); k++)
                tmp += l[i, k] * u[k, j];

            if (i <= j)
            {
                // U-матрица
                u[i, j] = matrix[i, j] - tmp;
            }
            else
            {
                // Проверка деления на ноль
                if (Math.Abs(u[j, j]) < 1e-10)
                    throw new InvalidOperationException(
                        "Невозможно выполнить разложение: найден нулевой элемент на диагонали U.");
                // L-матрица
                l[i, j] = (matrix[i, j] - tmp) / u[j, j];
            }
        }

        // Определитель - произведение диагональных элементов U
        double determinant = 1;
        for (var i = 0; i < n; i++)
            determinant *= u[i, i];

        return determinant;
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