using System;

namespace ListTask
{
    public class ListTaskMain
    {
        public static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new(1, 2, 3, 4, 5);
            Console.WriteLine(list);

            list.RemoveItem(2);
            Console.WriteLine(list);
            list.RemoveItem(2); // RemoveItem имеет перегрузку, но в данном случае дженерики T data и T index совпали ??? Это вроде привело к блокировки перегрузки по T data... 
            Console.WriteLine(list);
        }
    }
}

