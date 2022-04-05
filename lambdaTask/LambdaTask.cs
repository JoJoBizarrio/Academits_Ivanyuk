namespace LambdaTask
{
    class LambdaTask
    {
        static void Main()
        {
            List<Person> people = new()
            {
                new("Misha", 15),
                new("Sasha", 20),
                new("Lex", 17),
                new("Lutor", 44),
                new("Saitama", 25),
                new("Misha", 23),
                new("Sasha", 76)
            };

            //А) получить список уникальных имен + Б) вывести список уникальных имен в формате:
            var namesFilter = people
                .Select(x => x.Name)
                .Distinct();

            var peopleNames = namesFilter.ToList();

            Console.WriteLine("Имена: " + string.Join(", ", peopleNames));
            Console.WriteLine();

            //В) получить список людей младше 18, посчитать для них средний возраст
            var peopleWithAgeLess18Filter = people
                .Where(x => x.Age < 18);

            var peopleWithAgeLess18 = peopleWithAgeLess18Filter.ToList();
            var average = peopleWithAgeLess18.Average(x => x.Age);

            Console.WriteLine($"Имена: {string.Join(", ", peopleWithAgeLess18.Select(x => x.Name)) }\tСредний возраст: {average}");
            Console.WriteLine();

            //Г) при помощи группировки получить Map , в котором ключи имена, а значения средний возраст
            var personsByNameFilter = people
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x
                                                .ToList()
                                                .Average(x => x.Age))
                .ToList();

            var personsByName = personsByNameFilter;

            Console.WriteLine(string.Join(", ", personsByName));
            Console.WriteLine();

            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста
            var peopleWithAgeBetween20And45Filter = people
                .Where(x => x.Age >= 20 && x.Age <= 45)
                .OrderByDescending(x => x.Age)
                .Select(x => x.Name);

            Console.WriteLine(string.Join(", ", peopleWithAgeBetween20And45Filter));
        }
    }
}