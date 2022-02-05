using System;
using System.Text;

namespace MatrixTask
{
    internal class Matrix
    {
        public int Row
        {
            get { return _vectors.Length; }
        }

        public int Column
        {
            get { return _vectors[0].Dimension; }
        }

        private Vector[] _vectors;

        // 1a. Matrix(n, m) – матрица нулей размера n*m
        public Matrix(int row, int column)
        {
            if (row <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Count of rows have to be > 0");
            }

            if (column <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(column), "Count of columns have to be > 0");
            }

            _vectors = new Vector[row];

            for (int i = 0; i < row; i++)
            {
                _vectors[i] = new Vector(column);
            }
        }

        // 1b. Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            _vectors = new Vector[matrix.Row];

            matrix._vectors.CopyTo(_vectors, 0);
        }

        // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array.Length), "Empty array");
            }

            _vectors = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                _vectors[i] = new Vector(array.GetLength(1));
            }

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    _vectors[i]._components[j] = array[i, j];
                }
            }
        }

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            _vectors = new Vector[Row];

            vectorsArray.CopyTo(_vectors, 0);
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
            return _vectors[index];
        }

        public void SetRow(int index, Vector vector)
        {
            _vectors[index] = vector;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            Vector matrixColumn = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                matrixColumn.SetElement(i, _vectors[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            Matrix temp = new Matrix(Column, Row);

            for (int i = 0; i < Column; i++)
            {
                temp._vectors[i] = GetColumn(i);
            }

            _vectors = new Vector[Column];

            for (int i = 0; i < Column; i++)
            {
                _vectors[i] = new Vector(Row);
            }

            Array.Copy(temp._vectors, _vectors, Column);
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Row; i++)
            {
                _vectors[i].MultiplyByScalar(scalar);
            }
        }

        // 2g. toString определить так, чтобы результат получался в таком виде: {{ 1, 2 }, { 2, 3 }}
        public override string ToString()
        {
            StringBuilder matrixContent = new StringBuilder();
            matrixContent.Append("{");

            foreach (Vector e in _vectors)
            {
                matrixContent.Append(e + ", ");
            }

            return matrixContent.Remove(matrixContent.Length - 2, 2).Append("}").ToString();
        }

        // 2h. умножение матрицы на вектор
        public Vector MultiplyByVector(Vector vector)
        {
            Vector result = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                result.SetElement(i, Vector.GetScalarProduct(_vectors[i], vector));
            }

            return result;
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                _vectors[i].Add(matrix._vectors[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                _vectors[i].Subtract(matrix._vectors[i]);

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
        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Column != matrix2.Row)
            {
                throw new Exception("Empty");
            }

            Matrix result = new Matrix(matrix1.Row, matrix2.Column);

            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Column; i++)
                {
                    double result1 = Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j));
                    result._vectors[i].SetElement(j, result1);
                }
            }

            return result;
        }
    }
}