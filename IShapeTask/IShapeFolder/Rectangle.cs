namespace IShapeTask.IShapeFolder
{
    internal class Rectangle : IShape
    {
        private double _width;

        private double _heigth;

        public double Width { set => _width = value; }
        public double Height { set => _heigth = value; }

        public Rectangle(double width, double heigth)
        {
            _width = width;
            _heigth = heigth;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight()
        {
            return _heigth;
        }

        public double GetArea()
        {
            return _width * _heigth;
        }

        public double GetPerimeter()
        {
            return 2 * (_width + _heigth);
        }

        public override string ToString()
        {
            return $"Shape: Rectangle, Width: {_width:f1}, Height: {_heigth:f1}, Area: {GetArea():f1}, Perimeter: {GetPerimeter():f1}";
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

            Rectangle rectangle = (Rectangle)obj;

            return _width == rectangle._width && _heigth == rectangle._heigth ? true : false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + _width.GetHashCode();
            hash = prime * hash + _heigth.GetHashCode();

            return hash;
        }
    }
}