using GuestLogix.Flights.API.Entities;
using GuestLogix.Flights.API.Repositories;
using GuestLogix.Flights.API.Services;
using GuestLogix.Flights.API.Services.Interfaces;
using System;
using Xunit;

namespace GuestLogix.Flights.API.Tests
{
    public class FlightsTests
    {
        protected IFlightsService flightService;

        public FlightsTests()
        {
            var context = new FlightsContextFake();
            var airlinesRepository = new AirlinesRepository(context);
            var airportsRepository = new AirportsRepository(context);
            var routesRepository = new RoutesRepository(context);
            flightService = new FlightsService(airlinesRepository, airportsRepository, routesRepository);
        }

        [Fact]
        public void FindBestRoute_ProvidedInvalidOrigin_ShouldReturnInvalid()
        {
            var origin = "XXX";
            var destination = "ORD";

            var result = flightService.BestRoute(origin, destination);

            Assert.Equal("Invalid Origin", result.Message);
        }

        [Fact]
        public void FindBestRoute_ProvidedInvalidDestination_ShouldReturnInvalid()
        {
            var origin = "ORD";
            var destination = "XXX";

            var result = flightService.BestRoute(origin, destination);

            Assert.Equal("Invalid Destination", result.Message);
        }

        [Fact]
        public void FindBestRoute_ProvidedInvalidRoute_ShouldReturnNoRoute()
        {
            var origin = "YYZ";
            var destination = "ORD";

            var result = flightService.BestRoute(origin, destination);

            Assert.Equal("No Route", result.BestRoute);
        }

        [Fact]
        public void FindBestRoute_ProvidadedYYZTOJFK_ShouldReturn_YYZ_JFK()
        {
            var origin = "YYZ";
            var destination = "JFK";

            var result = flightService.BestRoute(origin, destination);

            Assert.Equal("YYZ => JFK", result.BestRoute);
        }

        [Fact]
        public void FindBestRoute_ProvidadedYYZTOYVR_ShouldReturn_YYZ_JFK_LAX_YVR()
        {
            var origin = "YYZ";
            var destination = "YVR";

            var result = flightService.BestRoute(origin, destination);

            Assert.Equal("YYZ => JFK => LAX => YVR", result.BestRoute);
        }
    }
}
