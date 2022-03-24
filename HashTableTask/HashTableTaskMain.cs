namespace HashTableTask
{
    class HashTableTaskMain
    {
        static void Main(string[] args)
        {
            HashTable<int> ht = new HashTable<int>(100);

            ht.Add(5);
            ht.Add(16);
            ht.Add(124);
            ht.Add(24);

            Console.WriteLine(ht);

            int[] array1 = new int[10];

            ht.CopyTo(array1, 3);

            Console.WriteLine(String.Join(",", array1));
            Console.WriteLine();

            foreach (int e in ht)
            {
                Console.Write($"{e}; ");
            }
        } 
    }
}