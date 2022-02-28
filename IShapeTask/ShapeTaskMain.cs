namespace IShapeTask
{
    internal class ShapeTaskMain
    {
        public static IShape GetMaxArea(IShape[] shapesArray)
        {
            if (shapesArray.Length == 0)
            {
                throw new ArgumentException($" Empty array {nameof(shapesArray.Length)} = {shapesArray.Length} ");
            }

            Array.Sort(shapesArray, new FigureAreaComparer());

            return shapesArray[shapesArray.Length ^ 1].GetArea();
        }

        static void Main(string[] args)
        {
            IShape[] shapesArray = new IShape[]
            {
                new Rectangle(5, 13), new Rectangle(22, 8),
                new Cicle(21), new Cicle(11),
                new Square(21), new Square(11),
                new Triangle(0, 0, 21, 0, 0, 11), new Triangle(-13, 5, 2, 15, 1, 1)
            };

            Console.WriteLine("MaxArea: " + GetMaxArea(shapesArray));
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetArea());
            }

            Console.WriteLine();

            Array.Sort(shapesArray, new FigurePerimeterComparer());

            Console.WriteLine("Second perimeters: " + shapesArray[6].GetPerimeter());
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetPerimeter());
            }

            IShape shape = new IShape[];

            Console.WriteLine( GetMaxArea(shape));
        }
    }
}