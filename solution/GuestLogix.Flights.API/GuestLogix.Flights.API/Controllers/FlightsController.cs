using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestLogix.Flights.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuestLogix.Flights.API.Controllers
{
    [Route("Flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        protected readonly IFlightsService flightsService;

        public FlightsController(IFlightsService _flightsService)
        {
            flightsService = _flightsService;
        }

        [HttpGet("BestRoute/{origin}/{destination}", Name = "BestRoute")]
        public IActionResult BestRoute([FromRoute]string origin, [FromRoute]string destination)
        {
            var result = flightsService.BestRoute(origin, destination);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.BestRoute);
        }
    }
}
