using System.Text;
using Vector = VectorTask.Vector;

namespace MatrixTask
{
    internal class Matrix
    {
        private Vector[] _matrixRows;

        public int Row => _matrixRows.Length;

        public int Column => _matrixRows[0].Dimension;

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
            _matrixRows = new Vector[matrix.Row];

            for (int i = 0; i < matrix.Row; i++)
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

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
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
                vectorsLengths[i] = (int)vectorsArray[i].GetLength();
            }

            int maxLength = vectorsLengths.Max();

            for (int i = 0; i < Row; i++)
            {
                _matrixRows[i] = new Vector(maxLength);
                _matrixRows[i] = new Vector(vectorsArray[i]);
            }
        }

        // 2a. Получение размеров матрицы
        public int GetElements()
        {
            return Row * Column;
        }

        public int GetRows()
        {
            return Row;
        }

        public int GetColumns()
        {
            return Column;
        }

        // 2b. Получение и задание вектора-строки по индексу	
        public Vector GetRow(int index)
        {
            return _matrixRows[index];
        }

        public void SetRow(int index, Vector vector)
        {
            _matrixRows[index] = vector;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            Vector matrixColumn = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                matrixColumn.SetElement(i, _matrixRows[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            Matrix temp = new Matrix(Column, Row);

            for (int i = 0; i < Column; i++)
            {
                temp._matrixRows[i] = GetColumn(i);
            }

            _matrixRows = new Vector[Column];

            for (int i = 0; i < temp.Column; i++)
            {
                _matrixRows[i] = new Vector(temp.Row);
            }

            Array.Copy(temp._matrixRows, _matrixRows, Column);
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Row; i++)
            {
                _matrixRows[i].MultiplyByScalar(scalar);
            }
        }

        // 2f. Вычисление определителя матрицы 
        public double GetDeterminant()
        {
            if (Row != Column)
            {
                throw new Exception("Array isn't square matrix.");
            }

            double[,] matrixArray = new double[Row, Column];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    matrixArray[i, j] = _matrixRows[i].GetElement(j);
                }
            }

            int swapsCount = 0;
            const double epsilon = 1.0e-10;

            for (int i = 0; i < Row - 1; ++i)
            {
                if (Math.Abs(matrixArray[i, i]) <= epsilon)
                {
                    for (int j = i + 1; j < Row; ++j)
                    {
                        if (Math.Abs(matrixArray[j, i]) > epsilon)
                        {
                            for (int k = 0; k < Column; ++k)
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

                for (int j = i + 1; j < Row; ++j)
                {
                    if (Math.Abs(matrixArray[j, i]) <= epsilon)
                    {
                        continue;
                    }

                    double multiplicationFactor = matrixArray[j, i] / matrixArray[i, i];

                    for (int k = 0; k < Row; ++k)
                    {
                        matrixArray[j, k] -= matrixArray[i, k] * multiplicationFactor;
                    }
                }
            }

            double determinant = matrixArray[0, 0];

            for (int i = 1; i < Row; ++i)
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
                matrixContent.Append(e + ", ");
            }

            return matrixContent.Remove(matrixContent.Length - 2, 2).Append('}').ToString();
        }

        // 2h. умножение матрицы на вектор
        public Vector MultiplyByVector(Vector vector)
        {
            Vector result = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                result.SetElement(i, Vector.GetScalarProduct(_matrixRows[i], vector));
            }

            return result;
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                _matrixRows[i].Add(matrix._matrixRows[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
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
            if (matrix1.Column != matrix2.Row)
            {
                throw new Exception("Empty");
            }

            Matrix result = new Matrix(matrix1.Row, matrix2.Column);

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Column; j++)
                {
                    result._matrixRows[i].SetElement(j, Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j)));
                }
            }

            return result;
        }
    }
}