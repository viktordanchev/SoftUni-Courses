using _04.BorderControl.Interfaces;

namespace _04.BorderControl
{
    public class Citizens : IIdentifiable
    {
        public Citizens(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }
}
