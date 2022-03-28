using System.Linq;
using LambdaTask;

namespace LambdaTask
{
    class LambdaTask
    {
        //public delegate bool Predicate<T>(T value);

        //public static List<T> Filter<T>(List<T> list, Predicate<T> f)
        //{
        //    List<T> result = new List<T>();

        //    foreach (T e in list)
        //    {
        //        if (f(e))
        //        {
        //            result.Add(e);
        //        }
        //    }

        //    return result;
        //}

        static void Main(string[] randomName)
        {
            Person person1 = new("Misha", 15);
            Person person2 = new("Sasha", 20);
            Person person3 = new("Lex", 17);
            Person person4 = new("Lutor", 44);
            Person person5 = new("Saitama", 25);
            Person person6 = new("Misha", 23);
            Person person7 = new("Sasha", 76);

            List<Person> people = new() { person1, person2, person3, person4, person5, person6, person7 };

            //А) получить список уникальных имен + Б) вывести список уникальных имен в формате:
            var peopleNames = people.Select(x => x.Name);

            Console.WriteLine("Имена: " + String.Join(", ", peopleNames.Distinct()));

            //В) получить список людей младше 18, посчитать для них средний возраст

            var peopleLess18 = people.Where(x => x.Age < 18).Select(x => x);
            var average = peopleLess18.Average(x => x.Age);

            Console.WriteLine($"Имена: {String.Join(", ", peopleLess18) } \tСредний возраст: {average}");

            //Г) при помощи группировки получить Map , в котором ключи имена, а значения средний возраст
            Dictionary<string, List<Person>> personsByName = people.GroupBy(x => x.Name).ToDictionary(x => x.Key, x => x.ToList());

            Console.WriteLine(String.Join(", ", personsByName));

            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста
            var peopleBetween20and45 = people.Where(x => x.Age >= 20 && x.Age <= 45 ).OrderByDescending(x => x.Age);

            Console.WriteLine(String.Join(", ", peopleBetween20and45));
        }
    }
}