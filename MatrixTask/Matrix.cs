using System;
using System.Text;

namespace MatrixTask
{
    internal class Matrix
    {
        internal Vector[] Vectors;

        public int Row
        {
            get { return Vectors.Length; }
        }

        public int Column
        {
            get { return Vectors[0].Dimension; }
        }

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

            Vectors = new Vector[row];

            for (int i = 0; i < row; i++)
            {
                Vectors[i] = new Vector(column);
            }
        }

        // 1b. Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            Vectors = new Vector[matrix.Row];

            matrix.Vectors.CopyTo(Vectors, 0);
        }

        // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array.Length), "Empty array");
            }

            Vectors = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                Vectors[i] = new Vector(array.GetLength(1));
            }

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    Vectors[i].Components[j] = array[i, j];
                }
            }
        }

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            Vectors = new Vector[vectorsArray.Length];

            vectorsArray.CopyTo(Vectors, 0);
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
            return Vectors[index];
        }

        public void SetRow(int index, Vector vector)
        {
            Vectors[index] = vector;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            Vector matrixColumn = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                matrixColumn.SetElement(i, Vectors[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            Matrix temp = new Matrix(Column, Row);

            for (int i = 0; i < Column; i++)
            {
                temp.Vectors[i] = GetColumn(i);
            }

            Vectors = new Vector[Column];

            for (int i = 0; i < temp.Column; i++)
            {
                Vectors[i] = new Vector(temp.Row);
            }

            Array.Copy(temp.Vectors, Vectors, Column);
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Row; i++)
            {
                Vectors[i].MultiplyByScalar(scalar);
            }
        }

        // 2f. Вычисление определителя матрицы 
        public double GetDeterminant()
        {
            double[,] matrixArray = new double[Row, Column];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    matrixArray[i, j] = Vectors[i].Components[j];
                }
            }

            return Determinant.GetDeterminant(matrixArray);
        }

        // 2g. toString определить так, чтобы результат получался в таком виде: {{ 1, 2 }, { 2, 3 }}
        public override string ToString()
        {
            StringBuilder matrixContent = new StringBuilder();
            matrixContent.Append('{');

            foreach (Vector e in Vectors)
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
                result.Components[i] = Vector.GetScalarProduct(Vectors[i], vector);
            }

            return result;
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                Vectors[i].Add(matrix.Vectors[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                Vectors[i].Subtract(matrix.Vectors[i]);
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
                    result.Vectors[i].Components[j] = Vector.GetScalarProduct(matrix1.GetRow(i), matrix2.GetColumn(j));
                }
            }

            return result;
        }
    }
}