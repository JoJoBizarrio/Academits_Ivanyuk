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
        /*
        public Matrix(Matrix matrix)
        {
            for (int i = 0; i < Row; i++)
            {
                Array[i] = matrix.
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