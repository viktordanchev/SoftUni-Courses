using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(' ');
            int counter = 0;
            List<User> users = new List<User>();

            while (data[0] != "End")
            {
                string name = data[0];
                string id = data[1];
                int age = int.Parse(data[2]);

                User user = new User
                {
                    Name = name,
                    Id = id,
                    Age = age
                };

                foreach (User currUser in users)
                {
                    if (currUser.Id == id)
                    {
                        currUser.Name = name;
                        currUser.Age = age;
                        counter++;
                    }
                }

                if (counter > 0)
                {
                    data = Console.ReadLine().Split(' ');
                    continue;
                }
                else
                {
                    users.Add(user);
                }

                data = Console.ReadLine().Split(' ');
            }

            List<User> orderedUsersByAge = users.OrderBy(currUser => currUser.Age).ToList();

            foreach (User user in orderedUsersByAge)
            {
                Console.WriteLine($"{user.Name} with ID: {user.Id} is {user.Age} years old.");
            }
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
}
