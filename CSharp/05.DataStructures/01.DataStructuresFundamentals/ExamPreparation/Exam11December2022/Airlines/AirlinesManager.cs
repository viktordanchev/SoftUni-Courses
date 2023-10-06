using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
        private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

        public void AddAirline(Airline airline)
        {
            airlines.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            flights.Add(airline.Id, flight);
            airlines[airline.Id].Flights.Add(flight);
        }

        public bool Contains(Airline airline)
        {
            return airlines.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return airlines.Any(a => a.Value.Flights.Contains(flight));
        }

        public void DeleteAirline(Airline airline)
        {
            if (!airlines.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            airlines.Remove(airline.Id);
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return airlines.Values
                .OrderByDescending(a => a.Rating)
                .ThenByDescending(a => a.Flights.Count)
                .ThenBy(a => a.Name);
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            return airlines.Values
                .Where(a => a.Flights.Count >= 1 &&
                !a.Flights.Any(f => f.IsCompleted) &&
                a.Flights.Any(f => f.Origin == origin) &&
                a.Flights.Any(f => f.Destination == destination));
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return flights.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return flights.Values.Where(f => f.IsCompleted);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return flights.Values.OrderBy(f => f.IsCompleted)
                .ThenBy(f => f.Number);
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!airlines.ContainsKey(airline.Id) || !airlines[airline.Id].Flights.Contains(flight))
            {
                throw new ArgumentException();
            }

            flight.IsCompleted = true;
            return flight;
        }
    }
}
