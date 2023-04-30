using FoodShortage.Interfaces;

namespace FoodShortage
{
    public class Citizens : IIdentifiable, INameable, IBirthable, IAgeable, IBuyer
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
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
