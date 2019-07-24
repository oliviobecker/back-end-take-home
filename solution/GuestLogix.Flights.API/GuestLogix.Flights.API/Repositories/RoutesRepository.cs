using GuestLogix.Flights.API.Entities;
using GuestLogix.Flights.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Repositories
{
    public class RoutesRepository : IRoutesRepository
    {
        protected readonly IFlightsContext flightsContext;

        public RoutesRepository(IFlightsContext _flightsContext)
        {
            flightsContext = _flightsContext;
        }

        public ICollection<Route> GetAll()
        {
            return flightsContext.Routes;
        }
    }
}
