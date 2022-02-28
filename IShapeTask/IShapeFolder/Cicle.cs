namespace IShapeTask
{
    internal class Cicle : IShape
    {
        private double _radius;

        public double Radius { set => _radius = value; }

        public Cicle(double radius)
        {
            _radius = radius;
        }

        public double GetWidth()
        {
            return 2 * _radius;
        }

        public double GetHeigth()
        {
            return GetWidth();
        }

        public double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }

        public override string ToString()
        {
            return $"Cicle. Radius: {_radius:f1}, Area: {GetArea():f1}, Perimetr: {GetPerimeter():f1}";
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

            return _radius == cicle._radius ? true : false;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            int prime = 31;

            hash = prime * hash + _radius.GetHashCode();

            return hash;
        }
    }
}