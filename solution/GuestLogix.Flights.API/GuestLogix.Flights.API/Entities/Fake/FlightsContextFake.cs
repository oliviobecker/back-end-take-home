using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Entities
{
    public class FlightsContextFake : IFlightsContext
    {
        public FlightsContextFake()
        {
            Airlines = System.IO.File.ReadAllLines(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/test/Airlines.csv"))
                    .Skip(1)
                    .Select(x => x.Split(','))
                    .Select(x => new Airline
                    {
                        Name = x[0],                       
                        TwoDigitCode = x[1],
                        ThreeDigitCode = x[2],
                        Country = x[3],
                    }).ToList();

            Airports = System.IO.File.ReadAllLines(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/test/Airports.csv"))
                   .Skip(1)
                   .Select(x => x.Split(','))
                   .Select(x => new Airport
                   {
                       Name = x[0],
                       City = x[1],
                       Country = x[2],
                       IATA3 = x[3],
                       Latitute = x[4],
                       Longitude = x[5]
                   }).ToList();

            Routes = System.IO.File.ReadAllLines(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/test/routes.csv"))
                   .Skip(1)
                   .Select(x => x.Split(','))
                   .Select(x => new Route
                   {
                       AirlineId = x[0],
                       Origin = x[1],
                       Destination = x[2]
                   }).ToList();
        }

        public ICollection<Airline> Airlines { get; set; }
        public ICollection<Airport> Airports { get; set; }
        public ICollection<Route> Routes { get; set; }
    }
}
