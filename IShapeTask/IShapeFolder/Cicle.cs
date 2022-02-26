namespace IShapeFolder
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

        public override string ToString()
        {
            return $"Cicle. Radius: {GetWidth()}, Area: {GetArea()}, Perimetr: {GetPerimeter()}";
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

            Cicle cicle = (Cicle)obj;

            if (Radius == cicle.GetHeigth() && GetArea() == cicle.GetArea())
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + Radius.GetHashCode();

            return hash;
        }
    }
}