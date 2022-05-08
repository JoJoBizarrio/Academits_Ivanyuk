using System.Text;

namespace RangeTask
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        // вместо {4. Сделать метод для получения длины диапазона}, свойство:
        public double Length => To - From;

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
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        // Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска.
        public Range[] GetUnion(Range range)
        {
            if (To < range.From || From > range.To)
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
        public Range[] GetDifference(Range range)
        {
            if (From >= range.To || To <= range.From) // range не пересекается с this и возвращаем целый this.
            {
                return new Range[] { new Range(From, To) };
            }

            if (From >= range.From && To <= range.To) // range покрывает диапазон this, возвращаем пустоту.
            {
                return Array.Empty<Range>();
            }

            if (From < range.To && From >= range.From && To > range.To)
            {
                return new Range[] { new Range(range.To, To) };
            }

            if (From < range.From && To > range.From && To <= range.To)
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[] { new Range(From, range.From), new Range(range.To, To) };
        }

        public override string ToString()
        {
            return $"({From}, {To})";
        }

        public static string ToString(Range[] ranges)
        {
            if (ranges.Length == 0)
            {
                return "[]";
            }

            StringBuilder stringBuilder = new("[");

            foreach (Range e in ranges)
            {
                stringBuilder.Append('(');
                stringBuilder.Append(e.From);
                stringBuilder.Append(", ");
                stringBuilder.Append(e.To);
                stringBuilder.Append(')');
                stringBuilder.Append(", ");
            }

            return stringBuilder.Replace(", ", "]", stringBuilder.Length - 2, 2).ToString();
        }
    }
}