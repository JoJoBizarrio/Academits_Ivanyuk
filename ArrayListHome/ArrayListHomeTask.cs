namespace ArrayListHomeTask
{
    class ArrayListHomeTask
    {
        static void Main(string[] args)
        {
            // 1. Прочитать в список все строки из файла
            string path = "C:\\Users\\koniv\\source\\repos\\Academits_Ivanyuk\\ArrayListHome\\textToList.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("Ошибка: файл не найден.");
            }
            else
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    List<string> datasetByFile = new();

                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        datasetByFile.Add(currentLine);
                    }

                    Console.WriteLine(string.Join(", ", datasetByFile));
                }
            }

            //================================================================
            // 2. Есть список из целых чисел. Удалить из него все четные числа. В этой задаче новый список создавать нельзя
            List<int> integerNumbersList = new() { 15, 13, 15, 3, 2, 15, 14, 14, 13, 15, 7, 8, 9, 7, 11 };

            for (int i = 0; i < integerNumbersList.Count; ++i)
            {
                if (integerNumbersList[i] % 2 == 0)
                {
                    integerNumbersList.RemoveAt(i);
                    --i;
                }
            }

            Console.WriteLine(string.Join(", ", integerNumbersList));

            //===================================================================
            // 3. Есть список из целых чисел, в нём некоторые числа могут повторяться.
            // Надо создать новый список, в котором будут элементы первого списка в таком же порядке, но без повторений.
            List<int> list3WithoutRepeats = new();

            for (int i = 0; i < integerNumbersList.Count; ++i)
            {
                for (int j = integerNumbersList.Count - 1; j > i; --j)
                {
                    if (list3WithoutRepeats[i] == list3WithoutRepeats[j])
                    {
                        list3WithoutRepeats.RemoveAt(j);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", list3WithoutRepeats));
        }
    }
}