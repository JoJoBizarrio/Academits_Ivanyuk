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

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
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
    }
}