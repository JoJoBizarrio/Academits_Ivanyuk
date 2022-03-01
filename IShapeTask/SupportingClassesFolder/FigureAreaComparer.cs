using IShapeTask.IShapeFolder;

namespace IShapeTask.SupportingClassesFolder
{
    public class FigureAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}