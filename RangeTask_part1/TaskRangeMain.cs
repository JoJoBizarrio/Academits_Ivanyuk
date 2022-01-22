using System;

namespace Range
{
    class TaskRangeMain
    {
        static void Main(string[] args)
        {
            Range range = new Range(-53.21, 21.98);
            Console.WriteLine(range.GetLength());

            range.From = 0.11;
            Console.WriteLine(range.GetLength());

            Console.WriteLine(range.IsInside(100.0));
            Console.WriteLine(range.IsInside(20.121));
        }
    }
}