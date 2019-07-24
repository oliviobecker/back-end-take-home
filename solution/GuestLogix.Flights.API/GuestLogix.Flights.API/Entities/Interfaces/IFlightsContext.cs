using System.Collections.Generic;

namespace GuestLogix.Flights.API.Entities
{
    public interface IFlightsContext
    {
        ICollection<Airline> Airlines { get; set; }
        ICollection<Airport> Airports { get; set; }
        ICollection<Route> Routes { get; set; }
    }
}