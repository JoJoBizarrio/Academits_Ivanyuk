using System;

namespace ListTask
{
    public class ListTaskMain
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new(1, 2, 3, 4, 5);
            Console.WriteLine(list);

            list.RemoveAt(2);
            Console.WriteLine(list);
            list.Remove(5); 
            Console.WriteLine(list);

            list.Reverse();
            Console.WriteLine(list);

            SinglyLinkedList<string> stringsList = new SinglyLinkedList<string>("1", "2");

            stringsList.SetData(0, null);
            Console.WriteLine(stringsList);
            stringsList.RemoveFirst();
            Console.WriteLine(stringsList);

        }
    }
}