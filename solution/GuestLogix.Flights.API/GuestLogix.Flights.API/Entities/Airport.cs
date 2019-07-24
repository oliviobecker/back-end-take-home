using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Entities
{
    public class Airport
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IATA3 { get; set; }
        public string Latitute { get; set; }
        public string Longitude { get; set; }
    }
}
