using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VFlightNetwork.Data.Models.Airports.ViewModels;
using VFlight_Network.Data;
using Microsoft.AspNetCore.Authorization;
using VFlightNetwork.Data.Models.Notification;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Data.Models.World;
using VFlightNetwork.Data.Enums.Notification;

namespace VFlight_Network.Controllers
{
    public class AirportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airports
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AirportIndexModel viewModel = new AirportIndexModel
            {
                SearchAirport = new AirportRequestModel(),
                Airports = new List<AirportResponseModel>()
            };
            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Search(AirportRequestModel airportRequestModel)
        {
            AirportIndexModel viewModel = new AirportIndexModel
            {
                SearchAirport = new AirportRequestModel(),
                Airports = new List<AirportResponseModel>(),
                Notification = new AlertNotification()
            };

            if (string.IsNullOrEmpty(airportRequestModel.Name) && string.IsNullOrEmpty(airportRequestModel.Country))
            {
                viewModel.Notification.SetNotification(NotificationType.Error, "You must have atleast a Name/ICAO or Country to Search for Airports!");
                return View("Index", viewModel);
            }

            List<Airport> airportsFound = new List<Airport>();
            Country foundCountry = new Country();
            if(!string.IsNullOrEmpty(airportRequestModel.Country))
            {
                foundCountry = _context.Countries.FirstOrDefault(co => co.Name == airportRequestModel.Country);

                airportsFound = string.IsNullOrEmpty(airportRequestModel.Name)
                                                                                ? await _context.Airports.Where(ap => ap.CountryId == foundCountry.Id).ToListAsync()
                                                                                : await _context.Airports.Where(ap => ap.CountryId == foundCountry.Id && ap.Name == airportRequestModel.Name).ToListAsync();                                                                                                          
            }
            else
            {
                airportsFound = string.IsNullOrEmpty(airportRequestModel.Name) 
                                                                                ? await _context.Airports.ToListAsync() 
                                                                                : await _context.Airports.Where(ap => ap.Name.ToUpper() == airportRequestModel.Name.ToUpper() || ap.ICAO.ToUpper() == airportRequestModel.Name.ToUpper()).ToListAsync();
            }

            List<AirportResponseModel> AllAirports = new List<AirportResponseModel>();
            foreach (var airport in airportsFound)
            {
                if (string.IsNullOrEmpty(foundCountry.Name))
                    foundCountry = _context.Countries.FirstOrDefault(co => airport.CountryId == co.Id);

                AirportResponseModel newAirportResponse = new AirportResponseModel
                {
                    Name = airport.Name,
                    ICAO = airport.ICAO,
                    IATA = airport.IATA,
                    Country = foundCountry
                };
                AllAirports.Add(newAirportResponse);
            }

            viewModel.Airports = AllAirports;
            return View("Index", viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            AirportCreateModel viewModel = new AirportCreateModel();
            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(AirportCreateModel airportCreateModel)
        {
            if(ModelState.IsValid)
            {
                var foundCountry = _context.Countries.FirstOrDefault(co => co.Name == airportCreateModel.Country);

                if (foundCountry != null)
                {
                    Airport newAirport = new Airport
                    {
                        Name = airportCreateModel.Name,
                        ICAO = airportCreateModel.ICAO,
                        IATA = airportCreateModel.IATA,
                        Latitude = airportCreateModel.Latitude,
                        Longitude = airportCreateModel.Longitude,
                        CountryId = foundCountry.Id
                    };
                    _context.Airports.Add(newAirport);
                    await _context.SaveChangesAsync();

                    airportCreateModel.Notification = new AlertNotification(NotificationType.Success, $"Successfully added {newAirport.Name}");
                    return View(airportCreateModel);
                }
                else
                {
                    airportCreateModel.Notification = new AlertNotification(NotificationType.Error, "The country entered for this Airport doesn't exist!");
                    return View(airportCreateModel);
                }
            }
            return View(airportCreateModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var airportToEdit = await _context.Airports.FirstOrDefaultAsync(a => a.Id == Id);
            if (airportToEdit == null)
                return NotFound();

            return View(airportToEdit);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Airport airport)
        {
            var airportToEdit = await _context.Airports.FirstOrDefaultAsync(a => a.Id == airport.Id);
            if (airportToEdit == null)
                return NotFound();

            airportToEdit.Name = airport.Name;
            airportToEdit.IATA = airport.IATA;
            airportToEdit.ICAO = airport.ICAO;
            airportToEdit.Latitude = airport.Latitude;
            airportToEdit.Longitude = airport.Longitude;

            _context.Entry(airportToEdit).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var airportToDelete = await _context.Airports.FirstOrDefaultAsync(a => a.Id == Id);
            if (airportToDelete == null)
                return NotFound();

            return View(airportToDelete);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Delete(Airport airport)
        {
            _context.Airports.Remove(airport);
            return RedirectToAction("Index");
        }
        

        private bool AirportExists(Guid id)
        {
            return _context.Airports.Any(e => e.Id == id);
        }
    }
}
