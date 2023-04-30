using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);

                fullName = value; 
            }
        }

        public int Category
        {
            get { return category; }
            private set 
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);

                category = value; 
            }
        }

        public double Turnover
        {
            get { return Math.Round(Bookings.All().Sum(h => h.ResidenceDuration * h.Room.PricePerNight)); }
        }

        public IRepository<IRoom> Rooms
        {
            get { return rooms; }
            private set { rooms = value; }
        }

        public IRepository<IBooking> Bookings
        {
            get { return bookings; }
            private set { bookings = value; }
        }
    }
}
