namespace LambdaTask
{
    internal class Person
    {
        private string _name;
        private int _age;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"({Name}; {Age})";
        }
    }
}