using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorTask
{
    class VectorTaskMain
    {
        static void Main(string[] args)
        {
            Console.Write("Check 1a: ");
            Vector vector1A = new Vector(9);
            Console.WriteLine(vector1A.ToString());
            Console.WriteLine();

            // 1b after  1c

            Console.Write("Check 1c: ");
            double[] array1C = { 0.1, 9.2, 2.9 };
            Vector vector1C = new Vector(array1C);
            Console.WriteLine(vector1C.ToString());
            Console.WriteLine(vector1C.GetSize());
            Console.WriteLine();

            Console.Write("Check 1b: ");
            Vector vector1B = new Vector(vector1C);
            Console.WriteLine(vector1B.ToString());
            Console.WriteLine();

            Console.Write("Check 1d: ");
            double[] array1D = { 1.1, 9.2, 2.9 };
            Vector vector1D = new Vector(5, array1D);
            Console.WriteLine(vector1D.ToString());
            Console.WriteLine(vector1D.GetSize());



        }
    }
}