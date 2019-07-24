using GuestLogix.Flights.API.Entities;
using GuestLogix.Flights.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Repositories
{
    public class AirlinesRepository : IAirlinesRepository
    {
        protected readonly IFlightsContext flightsContext;
        public AirlinesRepository(IFlightsContext _flightsContext)
        {
            flightsContext = _flightsContext;
        }

        public ICollection<Airline> GetAll()
        {
            return flightsContext.Airlines;
        }
    }
}
