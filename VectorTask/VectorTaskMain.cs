using System;

namespace VectorTask
{
    class VectorTaskMain
    {
        static void Main(string[] args)
        {
            // Блок 1, 2 и 3.
            Console.Write("Check 1a, 2, 3: ");
            Vector vector1A = new Vector(9);
            Console.WriteLine(vector1A.ToString());
            Console.WriteLine("Dimension: " + vector1A.GetSize());
            Console.WriteLine();

            // 1b after 1c

            Console.Write("Check 1c, 2, 3: ");
            double[] array1C = { 0.1, 9.2, 2.9 };
            Vector vector1C = new Vector(array1C);
            Console.WriteLine(vector1C.ToString());
            Console.WriteLine("Dimension: " + vector1C.GetSize());
            Console.WriteLine();

            Console.Write("Check 1b, 2, 3: ");
            Vector vector1B = new Vector(vector1C);
            Console.WriteLine(vector1B.ToString());
            Console.WriteLine("Dimension: " + vector1B.GetSize());
            Console.WriteLine();

            Console.Write("Check 1d, 2, 3: ");
            double[] array1D = { 1.1, 4.2, 8.9 };
            Vector vector1D = new Vector(5, array1D);
            Console.WriteLine(vector1D.ToString());
            Console.WriteLine("Dimension: " + vector1D.GetSize());
            Console.WriteLine();
            Console.WriteLine();

            // Блок 4
            Console.WriteLine("Check 4a: ");
            vector1A.GetElementChange(5, 2);

            Console.Write("vector1C: " + vector1C.ToString() + " add vector1B: " + vector1B.ToString() + " result: ");
            vector1C.Add(vector1B);
            Console.WriteLine(vector1C.ToString());

            Console.Write("vector1B: " + vector1B.ToString() + " add vector1A: " + vector1A.ToString() + " result: ");
            vector1B.Add(vector1A);
            Console.WriteLine(vector1B.ToString());
            Console.WriteLine();

            Console.WriteLine("Check 4с: ");
            Console.Write(vector1C.ToString() + " * 5 = ");
            vector1C.GetScalarMultiplication(5);
            Console.WriteLine(vector1C.ToString());
            Console.WriteLine();

            Console.WriteLine("Check 4d: ");
            Console.Write("Разворот вектора: " + vector1C.ToString() + " => ");
            vector1C.Revert();
            Console.WriteLine(vector1C.ToString());
            Console.WriteLine();

            Console.Write("Check 4e: ");
            Vector vector4E = new Vector(3);
            vector4E.GetElementChange(2, 0);
            vector4E.GetElementChange(4, 1);
            vector4E.GetElementChange(-4, 2);
            Console.WriteLine($"{vector4E.Length():f1}");
            Console.WriteLine();

            Console.WriteLine("Check 4f: " + vector4E.GetElement(2));
            vector4E.GetElementChange(2.4, 2);
            Console.WriteLine("Check 4f: " + vector4E.GetElement(2));
            Console.WriteLine();

            Console.WriteLine("Check 4g: ");
            Vector vector4G = new Vector(vector4E);
            Console.WriteLine("Равны ли вектора: " + vector4G.ToString() + " и " + vector4E.ToString() + " = " + vector4E.Equals(vector4G));
            vector4G.GetElementChange(-1, 1);
            Console.WriteLine("Равны ли вектора: " + vector4G.ToString() + " и " + vector4E.ToString() + " = " + vector4E.Equals(vector4G));
            Console.WriteLine();

            /// Блок 5
            Console.WriteLine("Check 5a: ");
            Vector vectorsSum = Vector.GetSum(vector4E, vector4G);
            Console.WriteLine(vector4E.ToString() + " + " + vector4G.ToString() + " = " + vectorsSum.ToString());
            Console.WriteLine();

            Console.WriteLine("Check 5b: ");
            Vector vectorsSubtract = Vector.GetDifference(vector4E, vector1B);
            Console.WriteLine(vector4E.ToString() + " - " + vector4G.ToString() + " = " + vectorsSubtract.ToString());
            Console.WriteLine();

            Console.WriteLine("Check 5c: ");
            double vectorsMultiply = Vector.GetScalarMultiplication(vector4E, vector4G);
            Console.WriteLine(vector4E.ToString() + " * " + vector4G.ToString() + " = " + vectorsMultiply);
            Console.WriteLine();
        }
    }
}