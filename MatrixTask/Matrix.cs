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

        public Vector[] ArrayM { get; set; }

        public Matrix(int row, int column)
        {
            Row = row;
            Column = column;

            ArrayM = new Vector[row];

            for (int i = 0; i < row; i++)
            {
                ArrayM[i] = new Vector(column);
            }
        }

        public override string ToString()
        {

        }

    }
}
