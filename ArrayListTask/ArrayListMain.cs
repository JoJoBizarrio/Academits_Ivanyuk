using System;

namespace ListTask
{
    class ListMain
    {
        static void Main(string[] args)
        {
            List<int> listTest = new List<int>(100);
            listTest.Add(5, 1, 2, 3, 4);
            Console.WriteLine(String.Join(", ", listTest));

            Console.WriteLine(listTest);
        }
    }
}