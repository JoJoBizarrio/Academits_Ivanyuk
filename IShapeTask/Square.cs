using System;

namespace IShapeTask
{
    internal class Square : IShape
    {
        internal double _sideSize;

        public Square(double sideSize)
        {
            _sideSize = sideSize;
        }

        public double GetWidth()
        {
            return _sideSize;
        }

        public double GetHeight()
        {
            return GetWidth();
        }

        public double GetArea()
        {
            return _sideSize * _sideSize;
        }

        public double GetPerimeter()
        {
            return 4 * _sideSize;
        }
    }
}