namespace IShapeFolder
{
    public class ComparerAreas : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetArea() == shape2.GetArea())
            {
                return 0;
            }

            if (shape1.GetArea() < shape2.GetArea())
            {
                return -1;
            }

            return 1;
        }
    }

    public class ComparerPerimeters : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() == shape2.GetPerimeter())
            {
                return 0;
            }

            if (shape1.GetPerimeter() < shape2.GetPerimeter())
            {
                return -1;
            }

            return 1;
        }
    }
}