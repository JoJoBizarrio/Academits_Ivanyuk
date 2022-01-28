using System;

namespace MatrixTask
{
    class MatrixTuskMain
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 2);
            Vector insert = new Vector(2);
            insert.GetElementChange(1, 0);
            insert.GetElementChange(3, 1);
            Console.WriteLine(matrix1.ToString());

            matrix1.GetRowElementsChange(insert, 0);
            matrix1.GetRowElementsChange(insert, 1);
            matrix1.GetRowElementsChange(insert, 2);

            Console.WriteLine(matrix1.ToString());

            double[,] array = { { 5.5, 3.1, 0 }, { 9.4, 1.1, 0.5 } };
            
            matrix1.GetTranspose();
            Console.WriteLine(matrix1.ToString());
            
            /*
            Console.WriteLine(matrix1.GetSize());
            Console.WriteLine(matrix1.GetRowsCount());
            Console.WriteLine(matrix1.GetColumnsCount());
            */
        }
    }
}