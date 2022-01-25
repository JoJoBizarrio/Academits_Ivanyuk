using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Range
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public Range(Range range1, Range range2)
        {
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)  // Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null.
                                                   // Если есть, то выдать новый диапазон с соответствующими концами
        {
            if (range.IsInside(From) & range.IsInside(To))
            {
                return new Range(From, To);
            }

            if (IsInside(range.From) & IsInside(range.To))
            {
                return new Range(range.From, range.To);
            }

            if (range.IsInside(From) & IsInside(range.To))
            {
                return new Range(From, range.To);
            }

            if (IsInside(range.From) & range.IsInside(To))
            {
                return new Range(range.From, To);
            }

            return null;
        }
        public void WriteRange()
        {
            Console.Write("( " + From + " ; " + To + " )");
        }

        public void WriteLineRange()
        {
            Console.WriteLine("( " + From + " ; " + To + " )");
        }

        public Range MergeWith(Range range) // Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска

        {
            if (range.IsInside(From) & range.IsInside(To))
            {
                return new Range(range.From, range.To);
            }

            if (IsInside(range.From) & IsInside(range.To))
            {
                return new Range(From, To);
            }

            if (range.IsInside(From) & IsInside(range.To))
            {
                return new Range(range.From, To);
            }

            if (IsInside(range.From) & range.IsInside(To))
            {
                return new Range(From, range.To);
            }

            Range range1 = new Range(range.From, range.To);
            Range range2 = new Range(From, To);

            return new Range(range1, range2);
        }

        public Range Substract(Range range)  // Получение разности двух интервалов.
        {
            if (IsInside(range.From) & IsInside(range.To))
            {
                Range range1 = new Range(From, range.From);
                Range range2 = new Range(range.To, To);

                return new Range(range1, range2);
            }

            if (range.IsInside(From) & range.IsInside(To))
            {
                return new Range(0, 0);
            }

            if (IsInside(range.From) & !IsInside(range.To))
            {
                return new Range(From, range.From);
            }

            if (!IsInside(range.From) & IsInside(range.To))
            {
                return new Range(range.To, To);
            }

            if (!IsInside(range.From) & !IsInside(range.To))
            {
                return new Range(From, To);
            }

            return null;
        }
    }
}