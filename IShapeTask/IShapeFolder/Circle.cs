﻿namespace IShapeTask.IShapeFolder
{
    internal class Circle : IShape
    {
        private double _radius;

        public double Radius { set => _radius = value; }

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double GetWidth()
        {
            return 2 * _radius;
        }

        public double GetHeight()
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
            return $"Shape: Circle, Radius: {_radius:f1}, Area: {GetArea():f1}, Perimeter: {GetPerimeter():f1}";
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

            Circle circle = (Circle)obj;

            return _radius == circle._radius ? true : false;
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