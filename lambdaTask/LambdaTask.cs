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


            //А) получить список уникальных имен
            //List<Person> unicumName = new List<Person>();
            //Predicate<Person> f = delegate (Person x)
            //{
            //    for (int i = 0; i < people.Count; ++i)
            //    {
            //        try
            //        {
            //            if (x.Name == unicumName[i].Name)
            //            {
            //                return false;
            //            }
            //        }
            //        catch
            //        {
            //            continue;
            //        }
            //    }

            //    return true;
            //};
            //unicumName = Filter(people, f);
            //Console.WriteLine(String.Join(", ", unicumName));

            Person person1 = new("Misha", 15);
            Person person2 = new("Sasha", 20);
            Person person3 = new("Lex", 17);
            Person person4 = new("Lutor", 49);
            Person person5 = new("Saitama", 25);
            Person person6 = new("Misha", 23);
            Person person7 = new("Sasha", 76);

            List<Person> people = new() { person1, person2, person3, person4, person5, person6, person7 };

            var peopleNames = people.Select(x => x.Name);

            Console.WriteLine(String.Join(", ", peopleNames.Distinct()));

            //•
            //Б) вывести список уникальных имен в формате:
            //Имена: Иван, Сергей, Петр.
            //•
            //В) получить список людей младше 18, посчитать для них средний
            //возраст
            //•
            //Г) при помощи группировки получить Map , в котором ключи
            //имена, а значения средний возраст
            //•
            //Д) получить людей, возраст которых от 20 до 45, вывести в консоль
            //их имена в порядке убывания возраста
        }
    }
}