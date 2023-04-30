using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms = new List<IRoom>();

        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }

        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(r => r.Equals(criteria));
        }
    }
}
