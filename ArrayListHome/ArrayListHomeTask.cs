namespace ArrayListHomeTask
{
    class ArrayListHomeTask
    {
        static void Main(string[] args)
        {
            // 1. Прочитать в список все строки из файла
            List<string> list1 = new();

            using (StreamReader reader = new StreamReader("C:\\Users\\koniv\\source\\repos\\Academits_Ivanyuk\\ArrayListHome\\textToList.txt"))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    list1.Add(currentLine);
                }
            }

            Console.WriteLine(String.Join(", ", list1));

            //================================================================
            // 2. Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя
            List<int> list2 = new() { 4, 3, 5, 15, 22, 12 };

            for (int i = 0; i < list2.Count; ++i)
            {
                if (list2[i] % 2 == 0)
                {
                    list2.RemoveAt(i);
                    --i;
                }
            }

            Console.WriteLine(String.Join(", ", list2));

            //===================================================================
            // 3. Есть список из целых чисел, в нём некоторые числа могут  повторяться.
            // Надо создать новый список, в котором будут элементы первого списка в таком же порядке, но без повторений.
            List<int> list3 = new() { 15, 13, 15, 3, 2, 15, 14, 14, 13, 15 };

            List<int> list3withoutRepeats = new(list3);

            for (int i = 0; i < list3withoutRepeats.Count; ++i)
            {
                for (int j = list3withoutRepeats.Count - 1; j > i; --j)
                {
                    if (list3withoutRepeats[i] == list3withoutRepeats[j])
                    {
                        list3withoutRepeats.RemoveAt(j);
                    }
                }
            }

            Console.WriteLine(String.Join(", ", list3withoutRepeats));

        }
    }
}