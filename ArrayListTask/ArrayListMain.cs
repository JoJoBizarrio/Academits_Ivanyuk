namespace ListTask
{
    class ListMain
    {
        static void Main(string[] args)
        {
            List<int> listTest = new List<int>(1, 2, 3, 4, 5, 6, 7, 8);
            
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

            listTest.Add(3);
            Console.WriteLine(listTest.GetInformation());

            listTest.TrimExcess();
            Console.WriteLine(listTest.GetInformation());
            listTest.TrimExcess();
            Console.WriteLine(listTest.GetInformation());

            listTest.Add(15);
            Console.WriteLine(listTest.GetInformation());

            List<string> stringList = new();
            Console.WriteLine(stringList.GetInformation());
            Console.WriteLine(stringList);
            stringList.Add("string");
            Console.WriteLine(stringList.GetInformation());
        }
    }
}