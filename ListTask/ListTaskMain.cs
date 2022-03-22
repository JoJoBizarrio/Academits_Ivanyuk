using System;

namespace ListTask
{
    public class ListTaskMain
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>(3, 2, 3, 7, 11);
            Console.WriteLine(list);

            SinglyLinkedList<int> copyList = list.Copy();

            Console.WriteLine(list);

            list.InsertValue(3, 5);
            Console.WriteLine(list);

            list.InsertValueInBegin(1102);
            Console.WriteLine(list);
            Console.WriteLine(copyList);

            Console.WriteLine(list.Head);

            list.Revert();
            Console.WriteLine(list);
            Console.WriteLine(list.Head);
        }
    }
}

