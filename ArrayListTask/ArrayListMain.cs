using ListTask;

namespace ListTask
{
    class ListMain
    {
        static void Main(string[] args)
        {
            List<int> listTest = new List<int>(15);
            listTest.Add(5, 1, 2, 3, 4);

            Console.WriteLine(listTest);
            Console.WriteLine(listTest.GetInformation());

            listTest.Insert(2, 2);
            Console.WriteLine(listTest.GetInformation());

            listTest.Remove(5);
            Console.WriteLine(listTest.GetInformation());

            listTest.RemoveAt(3);
            Console.WriteLine(listTest.GetInformation());

            listTest.Add(12);
            Console.WriteLine(listTest.GetInformation());

            listTest.Add(3, 4, 2, 3, 4);
            Console.WriteLine(listTest.GetInformation());

            
        }
    }
}