namespace IShapeTask.Shape
{
    internal class Point
    {
        private double _x;
        private double _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        // чем отличаются две нижние функции? кроме того что статик он для всех объектов класса
        public double GetDistance(Point point)
        {
            return Math.Sqrt(Math.Pow(_x - point._x, 2) * Math.Pow(_y - point._y, 2)); // эта функция изменит координаты точки this ?
        }

        public static double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow((point2._x - point1._x), 2) * Math.Pow((point2._y - point1._y), 2));
        }

        public override string ToString()
        {
            return $"({_x:f1}, {_y:f1})";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Point cartesianPoint = (Point)obj;

            return _x == cartesianPoint._x && _y == cartesianPoint._y;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 11;

            hash = prime * hash + _x.GetHashCode();
            hash = prime * hash + _y.GetHashCode();

            return hash;
        }
    }
}