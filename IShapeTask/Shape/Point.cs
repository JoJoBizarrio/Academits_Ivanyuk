namespace IShapeTask.Shape
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // чем отличаются две нижние функции? кроме того что статик он для всех объектов класса
        public double GetDistance(Point point)
        {
            return Math.Sqrt(Math.Pow(X - point.X, 2) * Math.Pow(Y - point.Y, 2)); // эта функция изменит координаты точки this ?
        }

        public static double GetDistance(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow((point2.X - point1.X), 2) * Math.Pow((point2.Y - point1.Y), 2));
        }

        public override string ToString()
        {
            return $"({X:f1}, {Y:f1})";
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

            return X == cartesianPoint.X && Y == cartesianPoint.Y;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 11;

            hash = prime * hash + X.GetHashCode();
            hash = prime * hash + Y.GetHashCode();

            return hash;
        }
    }
}