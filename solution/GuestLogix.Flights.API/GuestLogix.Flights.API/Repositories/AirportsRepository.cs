using GuestLogix.Flights.API.Entities;
using GuestLogix.Flights.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Repositories
{
    public class AirportsRepository : IAirportsRepository
    {
        protected readonly IFlightsContext flightsContext;
        public AirportsRepository(IFlightsContext _flightsContext)
        {
            flightsContext = _flightsContext;
        }

        public ICollection<Airport> GetAll()
        {
            return flightsContext.Airports;
        }
    }
}
