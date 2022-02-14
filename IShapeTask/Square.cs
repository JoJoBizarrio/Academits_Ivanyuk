using System;

namespace IShapeTask
{
    internal class Square : IShape
    {
        internal double SideSize;

        public Square(double sideSize)
        {
            SideSize = sideSize;
        }

        public double GetWidth()
        {
            return SideSize;
        }

        public double GetHeigth()
        {
            return GetWidth();
        }

        public double GetArea()
        {
            return SideSize * SideSize;
        }

        public double GetPerimeter()
        {
            return 4 * SideSize;
        }

        public override string ToString()
        {
            return $"Square. Size of side: {GetWidth}, Area: {GetArea}, Perimetr: {GetPerimeter}";
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

            Square square = (Square)obj;

            if (SideSize == square.SideSize)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + SideSize.GetHashCode();

            return hash;
        }
    }
}