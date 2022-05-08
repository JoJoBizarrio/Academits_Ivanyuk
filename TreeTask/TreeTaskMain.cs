using TreeTask.Comparers;

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

            treeTest.BypassByDeep(write);
            Console.WriteLine();

            treeTest.BypassByWidth(write);
            Console.WriteLine();

            DataComparer<string> comparer = new DataComparer<string>();

            Tree<string> treeTest2 = new("abc");

            treeTest2.Add("a");
            treeTest2.Add("a");
            treeTest2.Add("bc");
            treeTest2.Add("acd");
            treeTest2.Add("ab");
            treeTest2.Add("aadad");
            treeTest2.Add("apo");
            treeTest2.Add(null);
            treeTest2.Add(null);

            Action<string> write2 = (x) =>
            {
                if (x == null)
                {
                    Console.Write("null, ");
                }
                else
                {
                    Console.Write(x);
                    Console.Write(", ");
                }
            };

            treeTest2.BypassByDeep(write2);
            Console.WriteLine();

            treeTest2.BypassByWidth(write2);

            Tree<string> tree = new Tree<string>("abs");
            tree = new Tree<string>(comparer);
            tree.BypassByDeep(write2);
        }
    }
}