using System;
using System.Collections.Generic;
using System.Linq;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;

        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void AddModel(IStudent model)
        {
            models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return models.FirstOrDefault(s => s.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string firstName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
            string lastName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];

            if (models.Any(s => s.FirstName == firstName) && models.Any(s => s.LastName == lastName))
                return models.FirstOrDefault(s => s.FirstName == firstName);

            return null;
        }
    }
}
