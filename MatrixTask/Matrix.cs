using System;

namespace MatrixTask
{
    internal class Matrix
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Vector[] Array { get; set; }

        // 1a
        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;

            Array = new Vector[row];

            for (int i = 0; i < row; i++)
            {
                Array[i] = new Vector(column);
            }
        }

        // 1b
        public Matrix(Matrix matrix)
        {
            Row = matrix.GetRowsCount();
            Column = matrix.GetColumnsCount();

            Array = new Vector[matrix.GetRowsCount()];

            for (int i = 0; i < Row; i++)
            {
                Array[i] = matrix.GetColumnElements(i);
            }
        }

        // 1d
        public Matrix(Vector[] vectorArray)
        {
            Row = vectorArray.GetLength(0);
            Column = vectorArray.GetLength(1);

            Array = new Vector[Row];

            for (int i = 0; i < Row; i++)
            {
                Array[i] = vectorArray[i];
            }
        }
        // 1с
         /*
        public Matrix(double[,] array)
        {
            Row = array.GetLength(0);
            Column = array.GetLength(1);

            Array = new Vector[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Array[i].GetElementChange(array[i, j], j+1);
                }
            }
        }
        */
        // 2a
        public int GetSize()
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
        
        // 2b
        public Vector GetRowElements(int rowIndex)
        {
            return Array[rowIndex];
        }

        public Vector GetRowElementsChange(Vector insertableVector, int rowIndex)
        {
            return Array[rowIndex] = insertableVector;
        }

        // 2c 
        public Vector GetColumnElements(int columnIndex)
        {
            Vector vectorColumn = new Vector(Row);

            for (int i = 0; i < Row; i++)
            {
                vectorColumn.GetElementChange(Array[i].GetElement(columnIndex), i);
            }

            return vectorColumn;
        }

        // 2d 
        public void GetTranspose()
        {
            
        }

        // 2g
        public override string ToString()
        {
            string information = "{ ";

            foreach (Vector e in Array)
            {
                information += e.ToString() + ", ";
            }

            return information.Remove(information.Length - 2) + " }";
        }
    }
}