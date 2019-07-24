using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Entities
{
    public class Trip
    {
        public List<Route> Flights { get; set; }

        public bool IsValid { get; set; }
    }
}
