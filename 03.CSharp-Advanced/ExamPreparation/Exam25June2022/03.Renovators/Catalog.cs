using System.Collections.Generic;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get; set; }
        public int Count { get { return Renovators.Count; } }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            foreach (var renovator in Renovators)
            {
                if (renovator.Name == name)
                {
                    Renovators.Remove(renovator);
                    return true;
                }
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int removedRenovators = 0;

            for (int i = 0; i < Count; i++)
            {
                if (Renovators[i].Type == type)
                {
                    Renovators.RemoveAt(i--);
                    removedRenovators++;
                }
            }

            return removedRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            foreach (var renovator in Renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    return renovator;
                }
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> list = new List<Renovator>();

            foreach (var renovator in Renovators)
            {
                if (renovator.Days >= days)
                {
                    list.Add(renovator);
                }
            }

            return list;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in Renovators)
            {
                if (!renovator.Hired)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}