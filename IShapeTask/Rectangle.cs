using System;

namespace IShapeTask
{
    internal class Rectangle : IShape
    {
        internal double Width;

        internal double Heigth;

        public Rectangle(double width, double heigth)
        {
            Width = width;
            Heigth = heigth;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeigth()
        {
            return Heigth;
        }

        public double GetArea()
        {
            return Width * Heigth;
        }

        public double GetPerimeter()
        {
            return 2 * Width + 2 * Heigth;
        }
    }
}
