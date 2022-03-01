using IShapeTask.IShapeFolder;

namespace IShapeTask.SupportingClassesFolder
{
    public class FigurePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}