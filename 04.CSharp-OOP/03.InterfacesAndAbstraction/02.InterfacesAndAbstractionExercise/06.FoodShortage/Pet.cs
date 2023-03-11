using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations
{
    public class Pet : INameable, IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public string Birthdate { get; }
    }
}
