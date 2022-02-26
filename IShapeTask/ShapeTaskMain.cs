namespace IShapeFolder
{
    internal class ShapeTaskMain
    {
        public static double GetMaxArea(IShape[] shapesArray)
        {
            Array.Sort(shapesArray, new ComparerAreas());

            return shapesArray[shapesArray.Length - 1].GetArea();
        }

        static void Main(string[] args)
        {
            IShape[] shapesArray = new IShape[8];

            shapesArray[0] = new Rectangle(5, 13);
            shapesArray[1] = new Rectangle(22, 8);

            shapesArray[2] = new Cicle(21);
            shapesArray[3] = new Cicle(11);

            shapesArray[4] = new Square(21);
            shapesArray[5] = new Square(11);

            shapesArray[6] = new Triangle(0, 0, 21, 0, 0, 11);
            shapesArray[7] = new Triangle(-13, 5, 2, 15, 1, 1);

            Console.WriteLine("MaxArea: " + GetMaxArea(shapesArray));
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetArea());
            }

            Console.WriteLine();

            Array.Sort(shapesArray, new ComparerPerimeters());

            Console.WriteLine("Second perimeters: " + shapesArray[6].GetPerimeter());
            Console.WriteLine();

            foreach (IShape e in shapesArray)
            {
                Console.WriteLine(e.GetPerimeter());
            }
        }
    }
}