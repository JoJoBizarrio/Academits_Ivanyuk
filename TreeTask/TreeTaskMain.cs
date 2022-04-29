namespace TreeTask
{
    class TreeTaskMain
    {
        static void Main(string[] args)
        {
            Tree<int> treeTest = new(8);
            treeTest.Add(3);
            treeTest.Add(10);
            treeTest.Add(6);
            treeTest.Add(4);
            treeTest.Add(7);
            treeTest.Add(14);
            treeTest.Add(13);
            treeTest.Add(1);

            Action<int> write = (x) =>
            {
                Console.Write(x);
                Console.Write(", ");
            };

            treeTest.BypassInDeep(write);
            Console.WriteLine();

            treeTest.BypassInWidth(write);


           
        }
    }
}