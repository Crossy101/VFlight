using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFlight_Network.Data;
using VFlightNetwork.Data.Models.Aircraft;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Data.Models.World;

namespace VFlight_Network.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Airline>>> SearchAircrafts(string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest();

            
            List<AircraftType> matchedAircraftType = await _context.AircraftTypes.Where(act => act.Name.Contains(term)).ToListAsync();
            List<Aircraft> matchedAircraft = await _context.Aircrafts.Where(ac => matchedAircraftType.All(act => act.Id == ac.AircraftTypeId)).ToListAsync();
            List<Airline> matchedAirlines = await _context.Airlines.Where(al => matchedAircraft.All(ac => ac.AirlineId == al.Id)).ToListAsync();
            

            return matchedAirlines;
        }
        */

        //TODO: Create a upper case format before the search so we don't have to recursively keep chaning the term ToUpper()
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<AircraftType>>> SearchAircraftTypes(string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest();

            List<AircraftType> matchedAircraftType = await _context.AircraftTypes.Where(act => act.Name.ToUpper().Contains(term.ToUpper())).ToListAsync();

            return matchedAircraftType;
        }

        //TODO: Create a upper case format before the search so we don't have to recursively keep chaning the term ToUpper()
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Airline>>> SearchAirlines(string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest();

            List<Airline> foundAirlines = await _context.Airlines.Where(al => al.Name.ToUpper().Contains(term.ToUpper()) || al.ICAO.ToUpper().Contains(term.ToUpper())).ToListAsync();

            return foundAirlines;
        }

        //TODO: Create a upper case format before the search so we don't have to recursively keep chaning the term ToUpper()
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Airport>>> SearchAirports(string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest();

            List<Airport> foundAirports = await _context.Airports.Where(ap => ap.ICAO.ToUpper().Contains(term.ToUpper()) || ap.Name.ToUpper().Contains(term.ToUpper())).ToListAsync();

            return foundAirports;
        }

        //TODO: Create a upper case format before the search so we don't have to recursively keep chaning the term ToUpper()
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Country>>> SearchCountries(string term)
        {
            if (string.IsNullOrEmpty(term))
                return BadRequest();

            List<Country> foundCountries = await _context.Countries.Where(co => co.Name.ToUpper().Contains(term.ToUpper()) || co.CountryISO.ToUpper().Contains(term.ToUpper())).ToListAsync();

            return foundCountries;
        }
    }
}