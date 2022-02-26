namespace IShapeFolder
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

        public override string ToString()
        {
            return $"Rectangle. Width: {GetWidth()}, Heigth: {GetHeigth()}, Area: {GetArea()}, Perimetr: {GetPerimeter()}";
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

            if (Width == rectangle.Width && Heigth == rectangle.Heigth)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Heigth.GetHashCode();
            
            return hash;
        }
    }
}