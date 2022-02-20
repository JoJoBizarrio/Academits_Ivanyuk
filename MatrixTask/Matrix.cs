using System.Text;
using Vector = VectorTask.Vector;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] _matrixRows;

        public int RowsCount => _matrixRows.Length;

        public int ColumnsCount => _matrixRows[0].Dimension;

        public int ElementsCount => RowsCount * ColumnsCount;

        // 1a. Matrix(n, m) – матрица нулей размера n*m
        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rowsCount), rowsCount, "Count of rows have to be > 0");
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(columnsCount), columnsCount, "Count of columns have to be > 0");
            }

            _matrixRows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                _matrixRows[i] = new Vector(columnsCount);
            }
        }

        // 1b. Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            _matrixRows = new Vector[matrix.RowsCount];

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                _matrixRows[i] = new Vector(matrix._matrixRows[i]);
            }
        }

        // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array.Length), "Empty array");
            }

            _matrixRows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                _matrixRows[i] = new Vector(array.GetLength(1));
            }

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    _matrixRows[i].SetElement(j, array[i, j]);
                }
            }
        }

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            if (vectorsArray.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vectorsArray.Length), vectorsArray.Length, "Vector[] has length = 0");
            }

            _matrixRows = new Vector[vectorsArray.Length];

            int[] vectorsLengths = new int[vectorsArray.Length];

            for (int i = 0; i < vectorsArray.Length; i++)
            {
                vectorsLengths[i] = (int)vectorsArray[i].Dimension;
            }

            int maxLength = vectorsLengths.Max();

            for (int i = 0; i < RowsCount; i++)
            {
                _matrixRows[i] = new Vector(maxLength);
                _matrixRows[i] = new Vector(vectorsArray[i]);
            }
        }

        // 2b. Получение и задание вектора-строки по индексу	
        public Vector GetRow(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to more or euqal to 0.");
            }

            if (index >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to less count of rows.");
            }

            Vector vector = new Vector(_matrixRows[index]);

            return vector;
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to more or euqal to 0.");
            }

            if (index >= RowsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to less count of rows.");
            }

            Vector temp = new Vector(vector);
            _matrixRows[index] = temp;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to more or euqal to 0.");
            }

            if (index >= ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "Index have to less count of columns.");
            }

            Vector matrixColumn = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                matrixColumn.SetElement(i, _matrixRows[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            int temmR = RowsCount;

            for (int i = 0; i < ColumnsCount; i++)
            {
                Vector temp = new Vector(GetColumn(i));

                Array.Resize(ref _matrixRows[i], RowsCount);
            }
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                _matrixRows[i].MultiplyByScalar(scalar);
            }
        }

        // 2f. Вычисление определителя матрицы 
        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new Exception("Array isn't square matrix.");
            }

            double[,] matrixArray = new double[RowsCount, ColumnsCount];

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    matrixArray[i, j] = _matrixRows[i].GetElement(j);
                }
            }

            int swapsCount = 0;
            const double epsilon = 1.0e-10;

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
                                double temp = matrixArray[i, k];
                                matrixArray[i, k] = matrixArray[j, k];
                                matrixArray[j, k] = temp;
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
            StringBuilder matrixContent = new StringBuilder();
            matrixContent.Append('{');

            foreach (Vector e in _matrixRows)
            {
                matrixContent.Append($"{e:f1}, ");
            }

            return matrixContent.Remove(matrixContent.Length - 2, 2).Append('}').ToString();
        }

        // 2h. умножение матрицы на вектор
        public Vector MultiplyByVector(Vector vector)
        {
            Vector result = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                result.SetElement(i, Vector.GetScalarProduct(_matrixRows[i], vector));
            }

            return result;
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                _matrixRows[i].Add(matrix._matrixRows[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < RowsCount; i++)
            {
                _matrixRows[i].Subtract(matrix._matrixRows[i]);
            }
        }

        // 3a. Статик сложение
        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        // 3b. Статик вычитание
        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        // 3c. статик умножение
        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new Exception("Column's count of matrix1 have to equal to row's count of matrix2");
            }

            Matrix result = new Matrix(matrix1.RowsCount, matrix2.ColumnsCount);

            for (int i = 0; i < result.RowsCount; i++)
            {
                for (int j = 0; j < result.ColumnsCount; j++)
                {
                    result._matrixRows[i].SetElement(j, Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j)));
                }
            }

            return result;
        }
    }
}