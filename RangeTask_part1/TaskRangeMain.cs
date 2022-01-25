using System;

namespace Range
{
    class TaskRangeMain
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(-9, 25);
            Console.WriteLine(range1.GetLength());

            range1.From = -10;
            Console.WriteLine(range1.GetLength());

            Console.WriteLine(range1.IsInside(100.0));
            Console.WriteLine(range1.IsInside(20.121));

            Range range2 = new Range(0, 20);    // 2-ой диап внутри 1-го диапазона
            Range range3 = new Range(-20, 30);  // 1-ый диап внутри 2-го диапазона
            Range range4 = new Range(-30, 20);  // левая граница снаружи 1-го диапазона
            Range range5 = new Range(0, 40);    // правая граница снаружи 1-го диапазона
            Range range6 = new Range(40, 50);   // не пересекаются

            range1.WriteLineRange();
            Console.WriteLine();

            Range intersectionWithRange2 = range1.GetIntersection(range2);
            Range intersectionWithRange3 = range1.GetIntersection(range3);
            Range intersectionWithRange4 = range1.GetIntersection(range4);
            Range intersectionWithRange5 = range1.GetIntersection(range5);
            Range intersectionWithRange6 = range1.GetIntersection(range6);

            intersectionWithRange2.WriteLineRange();
            intersectionWithRange3.WriteLineRange();
            intersectionWithRange4.WriteLineRange();
            intersectionWithRange5.WriteLineRange();


        }
    }
}