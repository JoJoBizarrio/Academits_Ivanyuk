using System.Text;
using VectorTask;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] _rows;

        public int RowsCount => _rows.Length;

        public int ColumnsCount => _rows[0].Dimension;

        public int ElementsCount => RowsCount * ColumnsCount;

        // 1a. Matrix(n, m) – матрица нулей размера n*m
        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Count of rows must be > 0 ({nameof(rowsCount)} = {rowsCount}).", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Count of columns must be > 0 ({nameof(columnsCount)} = {columnsCount}).", nameof(columnsCount));
            }

            _rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                _rows[i] = new Vector(columnsCount);
            }
        }

        // 1b. Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            _rows = new Vector[matrix.RowsCount];

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                _rows[i] = new Vector(matrix._rows[i]);
            }
        }

        // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException($"Empty array ({nameof(array.Length)} = {array.Length}).", nameof(array));
            }

            _rows = new Vector[array.GetLength(0)];

            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i] = new Vector(array.GetLength(1));

                for (int j = 0; j < ColumnsCount; j++)
                {
                    _rows[i].SetElement(j, array[i, j]);
                }
            }
        }

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray.Length == 0)
            {
                throw new ArgumentException($"Empty vector ({nameof(vectorsArray.Length)} = {vectorsArray.Length}).", nameof(vectorsArray));
            }

            _rows = new Vector[vectorsArray.Length];

            int maxLength = vectorsArray[0].Dimension;

            for (int i = 1; i < vectorsArray.Length; i++)
            {
                if (vectorsArray[i].Dimension > maxLength)
                {
                    maxLength = vectorsArray[i].Dimension;
                }
            }

            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i] = new Vector(maxLength);

                for(int j = 0; j < vectorsArray[i].Dimension; j++)
                {
                    _rows[i].SetElement(j, vectorsArray[i].GetElement(j));
                }
            }
        }

        // 2b. Получение и задание вектора-строки по индексу	
        public Vector GetRow(int index)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentException($"Argument ({nameof(index)} = {index}) out of range: [0; {RowsCount - 1}].", nameof(index));
            }

            return new Vector(_rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= RowsCount)
            {
                throw new ArgumentException($"Argument ({nameof(index)} = {index}) out of range: [0; {RowsCount - 1}].", nameof(index));
            }

            _rows[index] = vector;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= ColumnsCount)
            {
                throw new ArgumentException($"Argument ({nameof(index)} = {index}) out of range: [0; {ColumnsCount - 1}].", nameof(index));
            }

            Vector matrixColumn = new(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                matrixColumn.SetElement(i, _rows[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            Vector[] temp = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                temp[i] = GetColumn(i);
            }

            _rows = temp;
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i].MultiplyByScalar(scalar);
            }
        }

        // вспомогательное для детерминанта
        public double[,] ConvertToArray()
        {
            double[,] array = new double[RowsCount, ColumnsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    array[i, j] = _rows[i].GetElement(j);
                }
            }

            return array;
        }

        // 2f. Вычисление определителя матрицы 
        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException($"Matrix isn't square. {nameof(RowsCount)} = {RowsCount} isn't equal to {nameof(ColumnsCount)} = {ColumnsCount}");
            }

            double[,] matrixArray = ConvertToArray();

            const double epsilon = 1.0e-10;
            int swapsCount = 0;

            for (int i = 0; i < RowsCount - 1; ++i)
            {
                if (Math.Abs(matrixArray[i, i]) <= epsilon)
                {
                    for (int j = i + 1; j < RowsCount; ++j)
                    {
                        if (Math.Abs(matrixArray[j, i]) > epsilon)
                        {
                            for (int k = 0; k < ColumnsCount; ++k)
                            {
                                (matrixArray[i, k], matrixArray[j, k]) = (matrixArray[j, k], matrixArray[i, k]);
                            }

                            ++swapsCount;
                            break;
                        }
                    }
                }

                for (int j = i + 1; j < RowsCount; ++j)
                {
                    if (Math.Abs(matrixArray[j, i]) <= epsilon)
                    {
                        continue;
                    }

                    double multiplicationFactor = matrixArray[j, i] / matrixArray[i, i];

                    for (int k = 0; k < RowsCount; ++k)
                    {
                        matrixArray[j, k] -= matrixArray[i, k] * multiplicationFactor;
                    }
                }
            }

            double determinant = matrixArray[0, 0];

            for (int i = 1; i < RowsCount; ++i)
            {
                determinant *= matrixArray[i, i];
            }

            return Math.Pow(-1, swapsCount) * determinant;
        }

        // 2g. toString определить так, чтобы результат получался в таком виде: {{ 1, 2 }, { 2, 3 }}
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('{');

            foreach (Vector e in _rows)
            {
                stringBuilder.Append($"{e}, ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
        }

        // 2h. умножение матрицы на вектор
        public Vector MultiplyByVector(Vector vector)
        {
            if (ColumnsCount != vector.Dimension)
            {
                throw new ArgumentException($"Count of columns (value: {ColumnsCount}) must equal to dimension of vector (value: {vector.Dimension})");
            }

            Vector result = new(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                result.SetElement(i, Vector.GetScalarProduct(_rows[i], vector));
            }

            return result;
        }

        public static void СompareMatrixsSizes(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException($"It isn't equal column's number of the {nameof(matrix1)} (value: {matrix1.ColumnsCount}) and the {nameof(matrix2)} ((value: {matrix2.ColumnsCount})).");
            }

            if (matrix1.RowsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"It isn't equal row's number of the {nameof(matrix1)} (value: {matrix1.RowsCount}) and the {nameof(matrix2)} ((value: {matrix2.RowsCount})).");
            }
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            СompareMatrixsSizes(this, matrix);

            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i].Add(matrix._rows[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            СompareMatrixsSizes(this, matrix);

            for (int i = 0; i < RowsCount; i++)
            {
                _rows[i].Subtract(matrix._rows[i]);
            }
        }

        // 3a. Статик сложение
        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            СompareMatrixsSizes(matrix1, matrix2);

            Matrix result = new(matrix1);
            result.Add(matrix2);

            return result;
        }

        // 3b. Статик вычитание
        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            СompareMatrixsSizes(matrix1, matrix2);

            Matrix result = new(matrix1);
            result.Subtract(matrix2);

            return result;
        }

        // 3c. статик умножение
        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"Column's count = {matrix1.ColumnsCount} of {nameof(matrix1)} must equal to row's count = {matrix2.RowsCount} of matrix2.");
            }

            Matrix result = new(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < result.RowsCount; i++)
            {
                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    result._rows[i].SetElement(j, Vector.GetScalarProduct(matrix1._rows[i], matrix2.GetColumn(j)));
                }
            }

            return result;
        }
    }
}