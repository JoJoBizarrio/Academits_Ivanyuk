﻿namespace IShapeFolder
{ 
    internal class Triangle : IShape
    {
        internal double X1;
        internal double Y1;

        internal double X2;
        internal double Y2;

        internal double X3;
        internal double Y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public double GetHeigth()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3));
        }

        public double GetPerimeter()
        {
            return Math.Sqrt((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2)) + Math.Sqrt((X2 - X3) * (X2 - X3) + (Y2 - Y3) * (Y2 - Y3) + Math.Sqrt((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1)));
        }

        public override string ToString()
        {
            return $"Triangle. Coordinates: (({X1}, {Y1}), ({X2}, {Y2}), ({X3}, {Y3})), Width: {GetWidth()}, Heigth: {GetHeigth()}, Area: {GetArea()}, Perimetr: {GetPerimeter()}";
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

            if (GetWidth() == cicle.GetHeigth() && GetArea() == cicle.GetArea())
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();

            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();

            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}