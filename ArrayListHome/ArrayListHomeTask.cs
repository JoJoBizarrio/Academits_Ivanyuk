namespace ArrayListHomeTask
{
    class ArrayListHomeTask
    {
        static void Main()
        {
            // 1. Прочитать в список все строки из файла
            string path = "..\\net6.0\\textToList.txt";

            try
            {
                using StreamReader reader = new StreamReader(path);

                List<string> fileStrings = new();

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    fileStrings.Add(currentLine);
                }

                Console.WriteLine(string.Join(", ", fileStrings));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("path имеет значение null.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Параметр path является пустой строкой (\"\").");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Указан недопустимый путь.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден.");
            }
            catch (IOException)
            {
                Console.WriteLine("path содержит неправильный или недопустимый синтаксис имени файла, имени каталога или метки тома.");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
            List<int> nonRepeatingIntegerNumbersList = new(integerNumbersList.Count);

            foreach (int e in nonRepeatingIntegerNumbersList)
            {
                if (!nonRepeatingIntegerNumbersList.Contains(e))
                {
                    nonRepeatingIntegerNumbersList.Add(e);
                }
            }

            Console.WriteLine(string.Join(", ", nonRepeatingIntegerNumbersList));
        }
    }
}