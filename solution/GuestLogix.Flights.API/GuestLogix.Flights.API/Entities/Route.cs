using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Entities
{
    public class Route
    {
        public string AirlineId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
}
