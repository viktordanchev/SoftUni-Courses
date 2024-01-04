using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private Dictionary<string, Passenger> passengers = new Dictionary<string, Passenger>();
        private Dictionary<string, Bus> buses = new Dictionary<string, Bus>();

        public void RegisterPassenger(Passenger passenger)
        {
            passengers.Add(passenger.Id, passenger);
        }

        public void AddBus(Bus bus)
        {
            bus.Passengers = new List<Passenger>();
            buses.Add(bus.Id, bus);
        }

        public bool Contains(Passenger passenger)
        {
            return passengers.ContainsKey(passenger.Id);
        }

        public bool Contains(Bus bus)
        {
            return buses.ContainsKey(bus.Id);
        }

        public IEnumerable<Bus> GetBuses()
        {
            return buses.Values;
        }

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!passengers.ContainsKey(passenger.Id) || !buses.ContainsKey(bus.Id))
            {
                throw new ArgumentException();
            }

            buses[bus.Id].Passengers.Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
            if (!Contains(passenger) || !Contains(bus) || !bus.Passengers.Contains(passenger))
            {
                throw new ArgumentException();
            }

            buses[bus.Id].Passengers.Remove(passenger);
        }

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus)
        {
            return buses[bus.Id].Passengers;
        }

        public IEnumerable<Bus> GetBusesOrderedByOccupancy()
        {
            return buses.Values
                .OrderBy(b => b.Passengers.Count);
        }

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity)
        {
            return buses.Values
                .Where(b => b.Capacity >= capacity);
        }
    }
}