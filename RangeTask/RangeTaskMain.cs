using System;

namespace RangeTask
{
    class RangeTaskMain
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

            Range intersectionRange1WithRange2 = range1.GetIntersection(range2);
            Range intersectionRange1WithRange3 = range1.GetIntersection(range3);
            Range intersectionRange1WithRange4 = range1.GetIntersection(range4);
            Range intersectionRange1WithRange5 = range1.GetIntersection(range5);
            Range intersectionRange1WithRange6 = range1.GetIntersection(range6);

            intersectionRange1WithRange2.WriteLineRange();
            intersectionRange1WithRange3.WriteLineRange();
            intersectionRange1WithRange4.WriteLineRange();
            intersectionRange1WithRange5.WriteLineRange();

            Range Range1mergeWithRange2 = range1.MergeWith(range2);
            Range Range1mergeWithRange3 = range1.MergeWith(range3);
            Range Range1mergeWithRange4 = range1.MergeWith(range4);
            Range Range1mergeWithRange5 = range1.MergeWith(range5);
            Range Range1mergeWithRange6 = range1.MergeWith(range6);

            Console.WriteLine();

            Range1mergeWithRange2.WriteLineRange();
            Range1mergeWithRange3.WriteLineRange();
            Range1mergeWithRange4.WriteLineRange();
            Range1mergeWithRange5.WriteLineRange();

            Console.WriteLine();

            range1.Substract(range3).WriteLineRange();
            range1.Substract(range4).WriteLineRange();
            range1.Substract(range5).WriteLineRange();
            range1.Substract(range6).WriteLineRange();
        }
    }
}