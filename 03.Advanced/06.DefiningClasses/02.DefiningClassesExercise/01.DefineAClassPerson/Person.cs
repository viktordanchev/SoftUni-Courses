namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
           
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}