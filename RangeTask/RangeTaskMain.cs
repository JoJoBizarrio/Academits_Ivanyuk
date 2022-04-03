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
            Range range7 = new Range(-10, 40);
            Range range8 = new Range(-10, 10);
            Range range9 = new Range(-20, -10);

            Console.WriteLine();
            Console.WriteLine("Check intersection:");
            Console.WriteLine($"{range1} and {range3}: " + range1.GetIntersection(range3));
            Console.WriteLine($"{range1} and {range4}: " + range1.GetIntersection(range4));
            Console.WriteLine($"{range1} and {range5}: " + range1.GetIntersection(range5));
            Console.WriteLine($"{range1} and {range6}: " + range1.GetIntersection(range6));
            Console.WriteLine($"{range1} and {range7}: " + range1.GetIntersection(range7));
            Console.WriteLine($"{range1} and {range8}: " + range1.GetIntersection(range8));
            Console.WriteLine($"{range1} and {range9}: " + range1.GetIntersection(range9));

            Console.WriteLine();
            Console.WriteLine("Check sum:");
            Console.WriteLine($"{range1} and {range2}: " + Range.ToString(range1.GetUnion(range2)));
            Console.WriteLine($"{range1} and {range3}: " + Range.ToString(range1.GetUnion(range3)));
            Console.WriteLine($"{range1} and {range4}: " + Range.ToString(range1.GetUnion(range4)));
            Console.WriteLine($"{range1} and {range5}: " + Range.ToString(range1.GetUnion(range5)));
            Console.WriteLine($"{range1} and {range6}: " + Range.ToString(range1.GetUnion(range6)));

            Console.WriteLine();
            Console.WriteLine("Check difference:");
            Console.WriteLine($"{range1} and {range2}: " + Range.ToString(range1.GetDifference(range2)));
            Console.WriteLine($"{range1} and {range3}: " + Range.ToString(range1.GetDifference(range3)));
            Console.WriteLine($"{range1} and {range4}: " + Range.ToString(range1.GetDifference(range4)));
            Console.WriteLine($"{range1} and {range5}: " + Range.ToString(range1.GetDifference(range5)));
            Console.WriteLine($"{range1} and {range6}: " + Range.ToString(range1.GetDifference(range6)));
            Console.WriteLine($"{range1} and {range7}: " + Range.ToString(range1.GetDifference(range7)));
            Console.WriteLine($"{range1} and {range8}: " + Range.ToString(range1.GetDifference(range8)));
        }
    }
}