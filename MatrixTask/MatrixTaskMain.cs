using System;

namespace MatrixTask
{
    class MatrixTuskMain
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 2);
            Vector insert = new Vector(3);
            insert.GetElementChange(1, 0);
            insert.GetElementChange(3, 1);
            Console.WriteLine(matrix1.ToString());

            matrix1.GetRowElementsChange(insert, 0);
            matrix1.GetRowElementsChange(insert, 1);
            matrix1.GetRowElementsChange(insert, 2);

            Console.WriteLine(matrix1.ToString());
        }
    }
}