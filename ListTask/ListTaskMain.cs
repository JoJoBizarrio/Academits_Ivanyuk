using System;

namespace ListTask
{
    public class ListTaskMain
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new(1, 2, 3, 4, 5);
            Console.WriteLine(list);

            SinglyLinkedList<int> copyList = list.Copy();

            Console.WriteLine(list);
            Console.WriteLine(list.Count);
            Console.WriteLine(copyList);
            Console.WriteLine(copyList.Count);


            list.Insert(4, 6);
            Console.WriteLine(list);

            list.InsertFirst(17);
            Console.WriteLine(list);
            Console.WriteLine(copyList);

            list.RemoveFirst();
            Console.WriteLine(list);
            Console.WriteLine(copyList);

            Console.WriteLine(list.GetFirst());

            list.Revert();
            Console.WriteLine(list);
            Console.WriteLine(list.GetFirst());

            list.RemoveItem(2);
            Console.WriteLine(list);
            list.RemoveItem(2); // RemoveItem имеет перегрузку, но в данном случае дженерики T data и T index совпали ??? Это вроде привело к блокировки перегрузки по T data... 
            Console.WriteLine(list);

            SinglyLinkedList<int> singlyLinkedList = new();
            Console.WriteLine(singlyLinkedList);
            Console.WriteLine(singlyLinkedList.Count);
        }
    }
}

