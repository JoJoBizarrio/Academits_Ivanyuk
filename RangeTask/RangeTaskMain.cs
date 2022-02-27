using System;

namespace RangeTask
{
    class RangeTaskMain
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(-9, 25);
            Console.WriteLine(range1.Length);

            range1 = new Range(-10, 25);

            Console.WriteLine(range1.Length);

            Console.WriteLine(range1.IsInside(100.0));
            Console.WriteLine(range1.IsInside(20.121));

            Range range2 = new Range(0, 20);    // 2-ой диап внутри 1-го диапазона
            Range range3 = new Range(-20, 30);  // 1-ый диап внутри 3-го диапазона
            Range range4 = new Range(-30, 20);  // левая граница снаружи 1-го диапазона
            Range range5 = new Range(0, 40);    // правая граница снаружи 1-го диапазона
            Range range6 = new Range(40, 50);   // не пересекаются

            Console.WriteLine();

            Console.WriteLine(range1.GetIntersection(range3));
            Console.WriteLine(range1.GetIntersection(range4));
            Console.WriteLine(range1.GetIntersection(range5));
            Console.WriteLine(range1.GetIntersection(range6));

            Console.WriteLine();

            Console.WriteLine(range1.GetSum(range2));
            Console.WriteLine(range1.GetSum(range3));
            Console.WriteLine(range1.GetSum(range4));
            Console.WriteLine(range1.GetSum(range5));
            Console.WriteLine(range1.GetSum(range6));

            Console.WriteLine();

            Console.WriteLine(range1.GetDifference(range3));
            Console.WriteLine(range1.GetDifference(range4));
            Console.WriteLine(range1.GetDifference(range5));
            Console.WriteLine(range1.GetDifference(range6));
        }
    }
}