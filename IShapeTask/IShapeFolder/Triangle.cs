using IShapeTask.SupportingClassesFolder;

namespace IShapeTask.IShapeFolder
{
    internal class Triangle : IShape
    {
        private CartesianPoint _point1;
        private CartesianPoint _point2;
        private CartesianPoint _point3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            _point1 = new CartesianPoint(x1, y1);
            _point2 = new CartesianPoint(x2, y2);
            _point3 = new CartesianPoint(x3, y3);
        }

        public Triangle(CartesianPoint point1, CartesianPoint point2, CartesianPoint point3)
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
            return + CartesianPoint.GetDistance(_point1, _point2) 
                   + CartesianPoint.GetDistance(_point2, _point3)
                   + CartesianPoint.GetDistance(_point3, _point1);
        }

        public override string ToString()
        {
            // return $"Triangle. Coordinates: ({_point1}, {_point2},  {_point3}), Width: {GetWidth()}, Height: {GetHeigth()}, Area: {GetArea()}, Perimeter: {GetPerimeter()}"; // у меня все помещается в экран.
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

            return _point1 == cicle._point1 &
                   _point2 == cicle._point2 &
                   _point3 == cicle._point3 ? true : false;
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