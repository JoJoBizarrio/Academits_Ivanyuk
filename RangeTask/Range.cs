using System.Text;

namespace RangeTask
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        // вместо {4. Сделать метод для получения длины диапазона}, свойство:
        public double Length => To - From;

        public Range() { }

        // 2. Описать конструктор, при помощи которого заполняются поля
        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        // 5. Сделать метод isInside, который принимает вещественное число и возвращает boolean – результат проверки, принадлежит ли число диапазону: 
        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        // Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. Если есть, то выдать новый диапазон с соответствующими концами
        public Range GetIntersection(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return new Range();
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        // Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска.
        public Range[] GetUnion(Range range)
        {
            if (To <= range.From || From >= range.To)
            {
                return new Range[]
                {
                    new Range(From, To),
                    new Range(range.From, range.To),
                };
            }

            return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        // Получение разности двух интервалов.
        public Range[] GetDifference(Range range) // пытался упростить, не получилось
        {
            if (To <= range.From || From >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From >= range.From & To <= range.To)
            {
                return Array.Empty<Range>();
            }

            if (From == range.From)
            {
                return new Range[] { new Range(range.To, To) };
            }

            if (To == range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }

            if (IsInside(range.From) && !IsInside(range.To))
            {
                return new Range[] { new Range(From, range.From) };
            }

            if (!IsInside(range.From) && IsInside(range.To))
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, range.From), new Range(range.To, To) };
        }

        public override string ToString()
        {
            if (From == 0 & To == 0)
            {
                return "[]";
            }

            return $"({From}; {To})";
        }

        public static string ToString(Range[] ranges)
        {
            StringBuilder stringBuilder = new("[");

            foreach (Range e in ranges)
            {
                stringBuilder.Append(e);
                stringBuilder.Append(", ");
            }

            if (string.IsNullOrEmpty(stringBuilder.ToString()))
            {
                return "[]";
            }

            if (stringBuilder.ToString() == "[")
            {
                return stringBuilder.Append(']').ToString();
            }

            return stringBuilder.Replace(", ", "]", stringBuilder.Length - 2, 2).ToString();
        }
    }
}