namespace IShapeTask.Shape
{
    internal class Triangle : IShape
    {
        private Point _point1;
        private Point _point2;
        private Point _point3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            _point1 = new Point(x1, y1);
            _point2 = new Point(x2, y2);
            _point3 = new Point(x3, y3);
        }

        public Triangle(Point point1, Point point2, Point point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(_point1.X, _point2.X), _point3.X) - Math.Min(Math.Min(_point1.X, _point2.X), _point3.X);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(_point1.Y, _point2.Y), _point3.Y) - Math.Min(Math.Min(_point1.Y, _point2.Y), _point3.Y);
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((_point1.X - _point3.X) * (_point2.Y - _point3.Y) - (_point2.X - _point3.X) * (_point1.Y - _point3.Y));
        }

        public double GetPerimeter()
        {
            return Point.GetDistance(_point1, _point2) +
                   Point.GetDistance(_point2, _point3) +
                   Point.GetDistance(_point3, _point1);
        }

        public override string ToString()
        {
            return $"Shape: Triangle, Coordinates: ({_point1}, {_point2},  {_point3}), " +
                   $"Width: {GetWidth():f1}, Height: {GetHeight():f1}, " +
                   $"Area: {GetArea():f1}, Perimeter: {GetPerimeter():f1}";
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

            Triangle cicle = (Triangle)obj;

            return _point1.Equals(cicle._point1) &
                   _point2.Equals(cicle._point2) &
                   _point3.Equals(cicle._point3);
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + _point1.GetHashCode();
            hash = prime * hash + _point2.GetHashCode();
            hash = prime * hash + _point3.GetHashCode();

            return hash;
        }
    }
}