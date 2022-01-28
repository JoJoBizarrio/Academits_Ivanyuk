using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    internal class Matrix
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Vector[] Array { get; set; }

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
