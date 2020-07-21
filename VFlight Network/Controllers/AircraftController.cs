using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFlightNetwork.Data.Models.Aircraft;
using VFlight_Network.Data;
using Microsoft.AspNetCore.Authorization;
using VFlightNetwork.Data.Models.Notification;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Aircraft.ViewModels;
using VFlightNetwork.Data.Enums.Notification;

namespace VFlight_Network.Controllers
{
    public class AircraftController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AircraftController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AircraftIndexModel viewModel = new AircraftIndexModel
            {
                AircraftSearches = new List<AircraftSearch>(),
                Notification = new AlertNotification()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Search(AircraftRequestModel aircraftRequestModel)
        {
            List<AircraftType> matchedAircraftTypes = string.IsNullOrEmpty(aircraftRequestModel.AircraftType) 
                                                    ? await _context.AircraftTypes.ToListAsync() 
                                                    : await _context.AircraftTypes.Where(act => act.Name.Contains(aircraftRequestModel.AircraftType)).ToListAsync();

            List<Guid> ListAircraftTypeId = matchedAircraftTypes.Select(act => act.Id).ToList();

            List<Aircraft> matchedAircraft = await _context.Aircrafts.Where(ac => ListAircraftTypeId.Contains(ac.AircraftTypeId)).ToListAsync();
            List<Guid> ListAirlineId = matchedAircraft.Select(ac => ac.AirlineId).ToList();


            List<Airline> matchedAirlines = string.IsNullOrEmpty(aircraftRequestModel.Airline) 
                                            ? await _context.Airlines.Where(al => ListAirlineId.Contains(al.Id)).ToListAsync()
                                            : await _context.Airlines.Where(al => al.Name.Contains(aircraftRequestModel.Airline)).ToListAsync();

            List<AircraftSearch> aircraftSearches = new List<AircraftSearch>();
            foreach (var aircraft in matchedAircraft)
            {
                AircraftType aircraftTypeFound = matchedAircraftTypes.FirstOrDefault(act => act.Id == aircraft.AircraftTypeId);
                Airline airlineFound = matchedAirlines.FirstOrDefault(al => al.Id == aircraft.AirlineId);

                if(aircraftTypeFound != null && airlineFound != null)
                {
                    AircraftSearch newAircraftSearch = new AircraftSearch
                    {
                        AircraftType = aircraftTypeFound,
                        CurrentAirline = airlineFound
                    };
                    aircraftSearches.Add(newAircraftSearch);
                }     
            }

            AircraftIndexModel viewModel = new AircraftIndexModel()
            {
                AircraftSearches = aircraftSearches,
                Notification = new AlertNotification()
            };

            return View("Index", viewModel);
        }

        [Authorize]
        [HttpGet]
        // GET: Aircraft/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        [Authorize]
        [HttpGet]
        // GET: Aircraft/Create
        public IActionResult Create()
        {
            AircraftCreateModel viewModel = new AircraftCreateModel
            {
                AircraftType = string.Empty,
                Airline = string.Empty,
                Notification = new AlertNotification()
            };
            return View(viewModel);
        }

        // POST: Aircraft/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AircraftType,Airline")] AircraftCreateModel aircraft)
        {
            AircraftCreateModel viewModel = new AircraftCreateModel
            {
                AircraftType = "",
                Airline = "",
                Notification = new AlertNotification(NotificationType.Error, "The aircraft type name or airline is invalid!")
            };

            if (ModelState.IsValid)
            {
                var foundAircraftType = await _context.AircraftTypes.FirstOrDefaultAsync(act => act.Name == aircraft.AircraftType);
                var foundAirline = await _context.Airlines.FirstOrDefaultAsync(ac => ac.Name == aircraft.Airline);

                if(foundAircraftType == null || foundAirline == null)
                {

                    viewModel.AircraftType = aircraft.AircraftType;
                    viewModel.Airline = aircraft.Airline;
                    viewModel.Notification.SetNotification(NotificationType.Error, "The aircraft type name or airline is invalid!");
                    return View(viewModel);
                }

                var foundAircraftDuplicate = await _context.Aircrafts.FirstOrDefaultAsync(ac => ac.AircraftTypeId == foundAircraftType.Id && ac.AirlineId == foundAirline.Id);
                if(foundAircraftDuplicate != null)
                {
                    viewModel.AircraftType = aircraft.AircraftType;
                    viewModel.Airline = aircraft.Airline;
                    viewModel.Notification.SetNotification(NotificationType.Error, $"{aircraft.Airline} already has the {aircraft.AircraftType}");
                    return View(viewModel);
                }

                Aircraft newAircraft = new Aircraft
                {
                    AircraftTypeId = foundAircraftType.Id,
                    AirlineId = foundAirline.Id,
                    Status = true
                };

                _context.Aircrafts.Add(newAircraft);
                await _context.SaveChangesAsync();

                viewModel.Notification.SetNotification(NotificationType.Success, $"Successfully created {aircraft.AircraftType} for {aircraft.Airline}");
                return View(viewModel);
            }
            return View(aircraft);
        }

        // GET: Aircraft/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }
            return View(aircraft);
        }

        // POST: Aircraft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Manafacturer,IATA,ICAO,UserCreationId,Id,CreationDate")] Aircraft aircraft)
        {
            if (id != aircraft.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aircraft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AircraftExists(aircraft.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aircraft);
        }

        // GET: Aircraft/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aircraft = await _context.Aircrafts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aircraft == null)
            {
                return NotFound();
            }

            return View(aircraft);
        }

        // POST: Aircraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var aircraft = await _context.Aircrafts.FindAsync(id);
            _context.Aircrafts.Remove(aircraft);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AircraftExists(Guid id)
        {
            return _context.Aircrafts.Any(e => e.Id == id);
        }
    }
}
