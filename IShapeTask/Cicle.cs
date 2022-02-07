using System;

namespace IShapeTask
{
    internal class Cicle : IShape
    {
        internal double Radius;

        public Cicle(double radius)
        {
            Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeigth()
        {
            return GetWidth();
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
