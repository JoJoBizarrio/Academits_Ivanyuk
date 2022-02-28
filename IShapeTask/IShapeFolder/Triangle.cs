namespace IShapeTask
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

        public double GetHeigth()
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
            // return $"Triangle. Coordinates: ({_point1}, {_point2},  {_point3}), Width: {GetWidth()}, Heigth: {GetHeigth()}, Area: {GetArea()}, Perimetr: {GetPerimeter()}"; // у меня все вмещается в экран, даже с комментарием.
            return $"Triangle. Coordinates: ({_point1}, {_point2},  {_point3}), " +
                   $"Width: {GetWidth():f1}, Heigth: {GetHeigth():f1}, " +
                   $"Area: {GetArea():f1}, Perimetr: {GetPerimeter():f1}";
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

        /*
        private double _x1;
        private double _y1;

        private double _x2;
        private double _y2;

        private double _x3;
        private double _y3;

        public double X1 { get => _x1; set => _x1 = value; }
        public double Y1 { get => _y1; set => _y1 = value; }

        public double X2 { get => _x2; set => _x2 = value; }
        public double Y2 { get => _y2; set => _y2 = value; }

        public double X3 { get => _x3; set => _x3 = value; }
        public double Y3 { get => _y3; set => _y3 = value; }
        

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            _x1 = x1;
            _y1 = y1;

            _x2 = x2;
            _y2 = y2;

            _x3 = x3;
            _y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(_x1, _x2), _x3) - Math.Min(Math.Min(_x1, _x2), _x3);
        }

        public double GetHeigth()
        {
            return Math.Max(Math.Max(_y1, _y2), _y3) - Math.Min(Math.Min(_y1, _y2), _y3);
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((_x1 - _x3) * (_y2 - _y3) - (_x2 - _x3) * (_y1 - _y3));
        }

        public double GetPerimeter()
        {
            return Math.Sqrt((_x1 - _x2) * (_x1 - _x2) + (_y1 - _y2) * (_y1 - _y2)) + Math.Sqrt((_x2 - _x3) * (_x2 - _x3) + (_y2 - _y3) * (_y2 - _y3) + Math.Sqrt((_x3 - _x1) * (_x3 - _x1) + (_y3 - _y1) * (_y3 - _y1)));
        }

        public double GetSideLength(double x1, double x2, )

        public override string ToString()
        {
            return $"Triangle. Coordinates: (({_x1}, {_y1}), ({_x2}, {_y2}), ({_x3}, {_y3})), Width: {GetWidth()}, Heigth: {GetHeigth()}, Area: {GetArea()}, Perimetr: {GetPerimeter()}";
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

            return _x1 == cicle._x1 & _x2 == cicle._x2 & _x3 == cicle._x3 & _y1 == cicle._y1 & _y2 == cicle._y2 & _y3 == cicle._y3 ? true : false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + _x1.GetHashCode();
            hash = prime * hash + _y1.GetHashCode();

            hash = prime * hash + _x2.GetHashCode();
            hash = prime * hash + _y2.GetHashCode();

            hash = prime * hash + _x3.GetHashCode();
            hash = prime * hash + _y3.GetHashCode();

            return hash;
        }
        */
    }
}