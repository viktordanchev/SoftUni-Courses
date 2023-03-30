using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels = new HotelRepository();
        private List<string> allowedRooms = new List<string>() { "Apartment", "DoubleBed", "Studio" };

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);

            hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            int neededBedCapacity = adults + children;

            List<IHotel> orderedHotels = hotels.All()
                .OrderBy(h => h.FullName)
                .Where(h => h.Rooms.All().Where(r => r.PricePerNight > 0).Any(r => r.BedCapacity > 0))
                .ToList();

            if (!orderedHotels.Any(h => h.Category == category))
                return string.Format(OutputMessages.CategoryInvalid, category);

            if (!orderedHotels.Any(h => h.Rooms.All().Any(r => r.BedCapacity >= neededBedCapacity)))
                return string.Format(OutputMessages.RoomNotAppropriate);

            IHotel hotel = null;
            IRoom room = null;

            int roomCapacity = int.MaxValue;

            foreach (var currHotel in orderedHotels)
            {
                foreach (var currRoom in currHotel.Rooms.All())
                {
                    if (currRoom.BedCapacity >= neededBedCapacity && roomCapacity > currRoom.BedCapacity)
                    {
                        roomCapacity = currRoom.BedCapacity;
                        hotel = currHotel;
                        room = currRoom;
                    }
                }
            }

            hotel.Bookings.AddNew(new Booking(room, duration, adults, children, hotel.Bookings.All().Count + 1));
            return string.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Count, hotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel == null)
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine("--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
                sb.AppendLine("none");

            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (!allowedRooms.Any(r => r == roomTypeName))
                throw new ArgumentException("Incorrect room type!");

            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
                return string.Format(OutputMessages.RoomTypeNotCreated);

            IRoom room = hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName);

            if (room.PricePerNight != 0)
                throw new InvalidOperationException("Price is already set!");

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName ==  hotelName);

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);

            if (!allowedRooms.Any(r => r == roomTypeName))
                throw new ArgumentException("Incorrect room type!");

            IRoom room = null;

            switch (roomTypeName)
            {
                case "Apartment":
                    room = new Apartment();
                    break;
                case "DoubleBed":
                    room = new DoubleBed();
                    break;
                case "Studio":
                    room = new Studio();
                    break;
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
