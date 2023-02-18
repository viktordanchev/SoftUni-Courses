using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private string name;
        private int capacity;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public List<Child> Registry { get; set; }
        public int ChildrenCount { get { return Registry.Count; } }
        public string Name { get { return name; } set { name = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }

        public bool AddChild(Child child)
        {
            if (ChildrenCount + 1 <= Capacity)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }
        public bool RemoveChild(string childFullName)
        {
            foreach (var child in Registry)
            {
                string currFullName = child.FirstName + " " +child.LastName;

                if (currFullName == childFullName)
                {
                    Registry.Remove(child);
                    return true;
                }
            }

            return false;
        }
        public Child GetChild(string childFullName)
        {
            foreach (var child in Registry)
            {
                string currFullName = child.FirstName + " " + child.LastName;

                if (currFullName == childFullName)
                {
                    return child;
                }
            }

            return null;
        }
        public string RegistryReport()
        {
            Registry = Registry.OrderByDescending(a => a.Age).ThenBy(l => l.LastName).ThenBy(f => f.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}