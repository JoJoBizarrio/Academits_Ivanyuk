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

            Console.WriteLine(treeTest.BypassInWidth());
            Console.WriteLine(treeTest.BypassInDeep());
            treeTest.BypassInRecursiveDeep();

            Console.WriteLine();
            treeTest.HasData(7);
            Console.WriteLine(treeTest.BypassInWidth());

            treeTest.Add(15);
            treeTest.Add(17);
            Console.WriteLine(treeTest.BypassInWidth());
            Console.WriteLine(treeTest.BypassInDeep());

            treeTest.Remove(14);
            Console.WriteLine(treeTest.BypassInWidth());
            Console.WriteLine(treeTest.BypassInDeep());

            treeTest.Remove(8);
            Console.WriteLine(treeTest.BypassInWidth());
            Console.WriteLine(treeTest.BypassInDeep());
        }
    }
}