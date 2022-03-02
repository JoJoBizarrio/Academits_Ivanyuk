namespace IShapeTask.IShapeFolder
{
    internal class Square : IShape
    {
        private double _sideLength;

        public double SideLength { set => _sideLength = value; }

        public Square(double sideSize)
        {
            _sideLength = sideSize;
        }

        public double GetWidth()
        {
            return _sideLength;
        }

        public double GetHeight()
        {
            return GetWidth();
        }

        public double GetArea()
        {
            return _sideLength * _sideLength;
        }

        public double GetPerimeter()
        {
            return 4 * _sideLength;
        }

        public override string ToString()
        {
            return $"Shape: Square. Length of side: {_sideLength:f1}, Area: {GetArea():f1}, Perimeter: {GetPerimeter():f1}";
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

            return _sideLength == square._sideLength ? true : false; 
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + _sideLength.GetHashCode();

            return hash;
        }
    }
}