using GuestLogix.Flights.API.Entities;
using GuestLogix.Flights.API.Repositories.Interfaces;
using GuestLogix.Flights.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestLogix.Flights.API.Services
{
    public class FlightsService : IFlightsService
    {
        protected readonly IAirlinesRepository airlinesRepository;
        protected readonly IAirportsRepository airportsRepository;
        protected readonly IRoutesRepository routesRepository;

        public FlightsService(IAirlinesRepository _airlinesRepository,
                              IAirportsRepository _airportsRepository,
                              IRoutesRepository _routesRepository)
        {
            airlinesRepository = _airlinesRepository;
            airportsRepository = _airportsRepository;
            routesRepository = _routesRepository;
        }

        public RoutesData BestRoute(string origin, string destination)
        {
            var data = new RoutesData();

            if (!AirportIsValid(origin))
            {
                data.Success = false;
                data.Message = "Invalid Origin";

                return data;
            }

            if (!AirportIsValid(destination))
            {
                data.Success = false;
                data.Message = "Invalid Destination";

                return data;
            }

            data = FindBestRoute(origin, destination);

            return data;
        }

        private bool AirportIsValid(string airport)
        {
            var airports = airportsRepository.GetAll();

            if (airports.Any(air => air.IATA3 == airport))
            {
                return true;
            }

            return false;
        }

        private RoutesData FindBestRoute(string origin, string destination)
        {
            var data = new RoutesData();

            var routes = routesRepository.GetAll();

            var listRoutesAvailable = new List<Trip>();

            var validOrigins = routes.Where(rt => rt.Origin == origin).ToList();

            var directFlight = validOrigins.Where(rt => rt.Destination == destination).FirstOrDefault();

            if (directFlight != null)
            {
                data.Success = true;
                data.BestRoute = directFlight.Origin + " => " + directFlight.Destination;

                return data;
            }
            else
            {
                foreach (var flight in validOrigins)
                {
                    var validTrip = new Trip();

                    validTrip.IsValid = false;

                    validTrip.Flights = new List<Route>();

                    validTrip.Flights.Add(flight);

                    if (flight.Destination != destination)
                    {
                        SearchValidConnection(flight.Origin, flight.Destination, destination, validTrip, routes);

                        if (validTrip.Flights.Count() > 20)
                            continue;

                        if (validTrip.IsValid)
                        {
                            listRoutesAvailable.Add(validTrip);
                        }
                    }
                    else
                    {
                        validTrip.IsValid = true;

                        listRoutesAvailable.Add(validTrip);

                        if (validTrip.Flights.Count() == 2)
                            break;
                    }
                }
            }

            if (listRoutesAvailable.Count > 0)
            {
                var bestRoute = listRoutesAvailable.OrderBy(item => item.Flights.Count()).FirstOrDefault();

                string completeRoute = "";

                foreach (var flight in bestRoute.Flights)
                {
                    if (completeRoute == string.Empty)
                    {
                        completeRoute += flight.Origin + " => " + flight.Destination;
                    }
                    else
                    {
                        completeRoute += " => " + flight.Destination;
                    }
                }

                data.Success = true;
                data.BestRoute = completeRoute;

                return data;
            }

            data.Success = true;
            data.BestRoute = "No Route";

            return data;
        }

        private void SearchValidConnection(string flightOrigin, string flightDestination, string tripDestination, Trip trip, ICollection<Route> listRoutes)
        {
            var routes = listRoutes.Where(rt => rt.Origin == flightDestination && rt.Origin != flightOrigin
                                                            && (trip.Flights.Count(flight => flight.Origin == rt.Origin
                                                                        && flight.Destination == rt.Destination) == 0)
                                                            && (trip.Flights.Count(flight => flight.Origin == rt.Destination) == 0));

            if (routes != null)
            {
                if (!routes.Where(rt => rt.Destination == tripDestination).Any())
                {
                    foreach (var item in routes)
                    {
                        trip.Flights.Add(item);

                        if (trip.Flights.Count() > 20)
                            return;

                        SearchValidConnection(item.Origin, item.Destination, tripDestination, trip, listRoutes);
                    }
                }
                else
                {
                    var route = routes.Where(rt => rt.Destination == tripDestination).FirstOrDefault();

                    if (route != null)
                    {
                        trip.Flights.Add(route);

                        trip.IsValid = true;
                    }             
                }
            }
        }
    }
}
