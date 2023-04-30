using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FrontDeskApp.Tests
{
    public class Tests
    {
        Hotel hotel;
        private string fullName;
        private int category;

        [SetUp]
        public void Setup()
        {
            fullName = "Karlovo";
            category = 4;
            hotel = new Hotel(fullName, category);
        }

        [Test]
        public void ConstructorMakeNewHotel()
        {
            Assert.AreEqual(fullName, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
        }
        
        [Test]
        public void FullName_IfIsNullOrWhiteSpaceShouldThrowsException()
        {
            fullName = " ";

            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(fullName, category));
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(null, category));
        }

        [Test]
        public void Category_IfIsBelow1OrIsGreatterThan5ShouldThrowsException()
        {
            category = 0;

            Assert.Throws<ArgumentException>(() => hotel = new Hotel(fullName, category));
            Assert.Throws<ArgumentException>(() => hotel = new Hotel(fullName, 6));
        }

        [Test]
        public void AddRoom_IfIsBelow1OrIsGreatterThan5ShouldThrowsException()
        {
            hotel.AddRoom(new Room(2, 25));

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void BookRoom_IfAdultsIsEqualTo0ShouldThrowExcepcion()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 4, 400));
        }
        
        [Test]
        public void BookRoom_IfChildrenIsBelow0ShouldThrowExcepcion()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -2, 4, 400));
        }

        [Test]
        public void BookRoom_IfresidenceDurationIsBelow1ShouldThrowExcepcion()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, 0, 400));
        }
        
        [Test]
        public void BookRoom_ShouldBookRoom()
        {
            hotel.AddRoom(new Room(4, 25));
            hotel.BookRoom(1, 2, 3, 400);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(75, hotel.Turnover);
        }
    }
}