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
            return $"Size of side: {GetWidth}, Area: {GetArea}, Perimetr: {GetPerimeter}";
        }
    }
}