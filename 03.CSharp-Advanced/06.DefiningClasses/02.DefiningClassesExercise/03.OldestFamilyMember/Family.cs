using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        public Family() 
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public string GetOldestMember()
        {
            int age = int.MinValue;
            string oldest = string.Empty;

            foreach (Person person in People)
            {
                if (person.Age > age)
                {
                    oldest = person.Name + " " + person.Age;
                    age = person.Age;
                }
            }

            return oldest;
        }
    }
}