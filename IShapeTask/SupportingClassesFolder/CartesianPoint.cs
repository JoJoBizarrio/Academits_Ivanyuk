namespace IShapeTask
{
    internal class CartesianPoint
    {
        private double _x;
        private double _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public CartesianPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return $"({_x}, {_y})";
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

            CartesianPoint cartesianPoint = (CartesianPoint)obj;

            return _x == cartesianPoint._x & _y == cartesianPoint._y ? true : false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 11021996;

            hash = prime * hash + _x.GetHashCode();
            hash = prime * hash + _y.GetHashCode();

            return hash;
        }

        // чем отличаются две нижние функции? кроме того что статик он для всех объектов класса
        public double GetDistance(CartesianPoint point)
        {
            return Math.Sqrt(Math.Pow((_x - point._x), 2) * Math.Pow((_y - point._y), 2)); // эта функция изменит координаты точки this ?
        }

        public static double GetDistance(CartesianPoint point1, CartesianPoint point2)
        {
            return Math.Sqrt(Math.Pow((point2._x - point1._x), 2) * Math.Pow((point2._y - point1._y), 2));
        }
    }
}