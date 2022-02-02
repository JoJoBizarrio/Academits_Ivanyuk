using System;


namespace MatrixTask
{
    internal class Matrix
    {
        public int Row { get; }

        public int Column { get; }

        private Vector[] MatrixArray;

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

        /*
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

            double[,] oneDimensionArray = new double[0, array.Length];
            array.CopyTo(oneDimensionArray, 0);

            for (int i = 0; i < Row; i++)
            {
                MatrixArray[i] = new Vector(Column);
                Array.ConstrainedCopy(array, i * Row, MatrixArray, i * Row, Row);
            }
        }
        */

        // 1d. Matrix(Vector[]) – из массива векторов-строк 
        public Matrix(Vector[] vectorsArray)
        {
            Row = vectorsArray.GetLength(0);
            Column = vectorsArray[0].Dimension;

            MatrixArray = new Vector[Row];

            vectorsArray.CopyTo(MatrixArray, 0);
        }

        // 2a. Получение размеров матрицы
        public int GetElementsCount()
        {
            return Row * Column;
        }

        public int GetRowsCount()
        {
            return Row;
        }

        public int GetColumnsCount()
        {
            return Column;
        }

        // 2b. Получение и задание вектора-строки по индексу	
        public Vector GetRow(int index)
        {
            return MatrixArray[index];
        }

        public void SetRow(Vector vector, int index)
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
            Matrix temp = new Matrix(MatrixArray);

            Array.Resize(ref MatrixArray[0], Row);

            for (int i = 1; i < Row; i++)
            {
                MatrixArray[i] = temp.GetColumn(i);
            }
        }

        // 2g
        public override string ToString()
        {
            string information = "{ ";

            foreach (Vector e in MatrixArray)
            {
                information += e.ToString() + ", ";
            }

            return information.Remove(information.Length - 2) + " }";
        }

    }
}