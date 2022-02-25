using System;

namespace RangeTask
{
    public class Range
    {
        private double _from { get; set; }

        private double _to { get; set; }

        // вместо ==4. Сделать метод для получения длины диапазона==, свойство:
        public double Length => _to - _from;

        // 2. Описать конструктор, при помощи которого заполняются поля
        public Range(double from, double to)
        {
            _from = from;
            _to = to;
        }

        // 5. Сделать метод isInside, который принимает вещественное число и возвращает boolean – результат проверки, принадлежит ли число диапазону: 
        public bool IsInside(double number)
        {
            return number >= _from && number <= _to;
        }

        public override string ToString()
        {
            return $"({_from}; {_to})";
        }

        // Получение интервала-пересечения двух интервалов. Если пересечения нет, выдать null. Если есть, то выдать новый диапазон с соответствующими концами
        public Range GetIntersection(Range range)
        {
            if (_to < range._from || _from > range._to)
            {
                return null;
            }

            return new Range(Math.Max(_from, range._from), Math.Min(_to, range._to));
        }

        // Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска.
        public Range[] GetUnion(Range range)
        {
            if (_to < range._from || _from > range._to)
            {
                return new Range[]{
                    new Range(_from, _to),
                    new Range(range._from, range._to),
                                  };
            }

            return new Range[] { new Range(Math.Min(_from, range._from), Math.Max(_to, range._to)) };
        }

        // Получение разности двух интервалов.
        public Range[] GetSubtract(Range range)
        {
            if (_to < range._from || _from > range._to)
            {
                return new Range[] { new Range(_from, _to) }; // что будет если использовать: return new Range[] { this }; ?
            }

            if (_from > range._from & _to < range._to)
            {
                return new Range[] { };
            }

            if (_from == range._from || _to == range._to)
            {
                return new Range[] { new Range(Math.Max(_from, range._from), Math.Min(_to, range._to)) };
            }

            return new Range[] { new Range(_from, range._from), new Range(_to, range._to) };
        }
    }
}