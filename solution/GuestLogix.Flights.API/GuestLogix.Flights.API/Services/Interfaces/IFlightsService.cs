using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Services.Interfaces
{
    public interface IFlightsService
    {
        RoutesData BestRoute(string origin, string destination);
    }
}
