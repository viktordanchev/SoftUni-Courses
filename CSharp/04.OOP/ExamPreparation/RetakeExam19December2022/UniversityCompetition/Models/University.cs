using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private List<string> availableCategories = new List<string>() { "Technical", "Economical", "Humanity" };
        private string name;
        private string category;
        private int capacity;
        private List<int> requiredSubjects;

        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {
            Id = universityId;
            Name = universityName;
            Category = category;
            Capacity = capacity;
            RequiredSubjects = requiredSubjects.ToList();
            requiredSubjects = new List<int>();
        }

        public int Id { get; private set; }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                name = value;
            }
        }

        public string Category
        {
            get { return category; }
            private set
            {
                if (!availableCategories.Any(c => c == value))
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));

                category = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);

                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects
        {
            get { return requiredSubjects.AsReadOnly(); }
            private set { requiredSubjects = value.ToList(); }
        }
    }
}
