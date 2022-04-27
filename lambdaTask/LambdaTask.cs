namespace LambdaTask
{
    class LambdaTask
    {
        static void Main()
        {
            var people = new List<Person>()
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
            var peopleNames = people
                .Select(x => x.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Имена: " + string.Join(", ", peopleNames));
            Console.WriteLine();

            //В) получить список людей младше 18, посчитать для них средний возраст
            var peopleWithAgeLess18 = people
                .Where(x => x.Age < 18)
                .ToList();

            var averageAge = peopleWithAgeLess18.Average(x => x.Age);

            Console.WriteLine($"Имена: {string.Join(", ", peopleWithAgeLess18.Select(x => x.Name)) }\tСредний возраст: {averageAge}");
            Console.WriteLine();

            //Г) при помощи группировки получить Map , в котором ключи имена, а значения средний возраст
            var averageAgeByName = people
                .GroupBy(x => x.Name)
                .ToDictionary(x => x.Key, x => x
                                                .Average(x => x.Age))
                .ToList();

            Console.WriteLine(string.Join(", ", averageAgeByName));
            Console.WriteLine();

            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста
            var peopleWithAgeBetween20And45 = people
                .Where(x => x.Age >= 20 && x.Age <= 45)
                .OrderByDescending(x => x.Age)
                .Select(x => x.Name)
                .ToList();

            Console.WriteLine(string.Join(", ", peopleWithAgeBetween20And45));
        }
    }
}