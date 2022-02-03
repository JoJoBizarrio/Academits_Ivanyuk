using System;
using System.Text;

namespace MatrixTask
{
    internal class Matrix
    {
        public int Row { get; }

        public int Column { get; }

        internal Vector[] MatrixArray;

        // 1a. Matrix(n, m) – матрица нулей размера n*m
        public Matrix(int row, int column)
        {
            if (row <= 0 || column <= 0)
            {
                throw new ArgumentOutOfRangeException("Row or colimn", "Sizes have to be > 0");
            }

            Row = row;
            Column = column;

            MatrixArray = new Vector[Row];

            for (int i = 0; i < row; i++)
            {
                MatrixArray[i] = new Vector(Column);
            }

        }

        // 1b. Matrix(Matrix) – конструктор копирования
        public Matrix(Matrix matrix)
        {
            Row = matrix.Row;
            Column = matrix.Column;

            MatrixArray = new Vector[Row];

            matrix.MatrixArray.CopyTo(MatrixArray, 0);

        }

        // 1c. Matrix(double[][]) – из двумерного массива(в C# double[,])
        public Matrix(double[,] array)
        {
            if (array.Length == 0)
            {
                throw new Exception("Empty array (array.Length = 0)");
            }

            Row = array.GetLength(0);
            Column = array.GetLength(1);

            MatrixArray = new Vector[Row];

            for (int i = 0; i < Row; i++)
            {
                MatrixArray[i] = new Vector(Column);
            }

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    MatrixArray[i].SetElement(j, array[i, j]);
                }
            }
              
        }

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            Row = vectorsArray.GetLength(0);
            Column = vectorsArray[0].Dimension;

            MatrixArray = new Vector[Row];

            vectorsArray.CopyTo(MatrixArray, 0);
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
            return MatrixArray[index];
        }

        public void SetRow(int index, Vector vector)
        {
            MatrixArray[index] = vector;
        }

        // 2c. Получение вектора-столбца по индексу
        public Vector GetColumn(int index)
        {
            Vector matrixColumn = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                matrixColumn.SetElement(i, MatrixArray[i].GetElement(index));
            }

            return matrixColumn;
        }

        // 2d. Транспонирование матрицы
        public void Transpose()
        {
            Matrix temp = new Matrix(Column, Row);

            for (int i = 0; i < Column; i++)
            {
                temp.MatrixArray[i] = GetColumn(i);
            }

            MatrixArray = new Vector[Column];

            for (int i = 0; i < Column; i++)
            {
                MatrixArray[i] = new Vector(Row);
            }

            Array.Copy(temp.MatrixArray, MatrixArray, Column);
        }

        // 2e.Умножение на скаляр
        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Row; i++)
            {
                MatrixArray[i].MultiplyByScalar(scalar);
            }
        }

        // 2g. toString определить так, чтобы результат получался в таком виде: {{ 1, 2 }, { 2, 3 }}
        public override string ToString()
        {
            StringBuilder matrixContent = new StringBuilder();
            matrixContent.Append("{");

            foreach (Vector e in MatrixArray)
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
                result.SetElement(i, Vector.GetScalarMultiplication(MatrixArray[i], vector));
            }

            return result;
        }

        // 2i. Сложение матриц
        public void Add(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                MatrixArray[i].Add(matrix.MatrixArray[i]);
            }
        }

        // 2j. Вычитание матриц
        public void Subtract(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                MatrixArray[i].Subtract(matrix.MatrixArray[i]);

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
                    double result1 = Vector.GetScalarMultiplication(matrix1.GetRow(i), matrix2.GetColumn(j));
                    result.MatrixArray[i].SetElement(j, result1);
                }
            }

            return result;
        }
    }
}