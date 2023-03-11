using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class Citizens : IIdentifiable, INameable, IBirthable
    {
        public Citizens(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
    }
}
