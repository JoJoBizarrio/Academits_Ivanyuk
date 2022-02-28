namespace IShapeTask
{
    internal class ShapeTaskMain
    {
        public static IShape GetMaxArea(IShape[] shapesArray)
        {
            if (shapesArray.Length == 0)
            {
                throw new ArgumentException($"Empty array: {nameof(shapesArray.Length)} = {shapesArray.Length}");
            }

            Array.Sort(shapesArray, new FigureAreaComparer());

            return shapesArray[^1];
        }

        static void Main(string[] args)
        {
            IShape[] shapesArray = new IShape[]
            {
                new Rectangle(5, 13), new Rectangle(22, 8),
                new Circle(21), new Circle(11),
                new Square(21), new Square(11),
                new Triangle(0, 0, 21, 0, 0, 11), new Triangle(-13, 5, 2, 15, 1, 1)
            };

            Console.WriteLine("Figure with MaxArea: " + GetMaxArea(shapesArray));
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetArea());
            }

            Console.WriteLine();

            Array.Sort(shapesArray, new FigurePerimeterComparer());

            Console.WriteLine("Figure with second perimeter: " + shapesArray[^2]);
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetPerimeter());
            }

        }
    }
}