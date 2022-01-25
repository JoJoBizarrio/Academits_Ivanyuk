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
                Range intersection = new Range(From, To);
                return intersection;
            }

            if (IsInside(range.From) & IsInside(range.To))
            {
                Range intersection = new Range(range.From, range.To);
                return intersection;
            }

            if (range.IsInside(From) & IsInside(range.To)) 
            {
                Range intersection = new Range(From, range.To);
                return intersection;
            }

            if (IsInside(range.From) & range.IsInside(To))
            {
                Range intersection = new Range(range.From, To);
                return intersection;
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