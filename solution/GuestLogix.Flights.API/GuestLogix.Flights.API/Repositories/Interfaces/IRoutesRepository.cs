using GuestLogix.Flights.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Repositories.Interfaces
{
    public interface IRoutesRepository
    {
        ICollection<Route> GetAll();
    }
}
