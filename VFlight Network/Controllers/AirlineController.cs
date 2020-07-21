using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFlightNetwork.Data.Models.Airlines.ViewModels;
using VFlight_Network.Data;
using Microsoft.AspNetCore.Authorization;
using VFlightNetwork.Data.Models.Notification;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Enums.Notification;

namespace VFlight_Network.Controllers
{
    public class AirlineController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AirlineController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Airlines
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            AirlineIndexModel viewModel = new AirlineIndexModel
            {
                Airlines = new List<Airline>(),
                Notification = new AlertNotification()
            };

            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Search(string airlineSearch)
        {
            List<Airline> airlinesFound = string.IsNullOrEmpty(airlineSearch) 
                                        ? await _context.Airlines.ToListAsync() 
                                        : await _context.Airlines.Where(al => al.Name.Contains(airlineSearch) || al.IATA.Contains(airlineSearch) || al.ICAO.Contains(airlineSearch)).ToListAsync();

            AirlineIndexModel viewModel = new AirlineIndexModel
            {
                Airlines = airlinesFound,
                Notification = new AlertNotification()
            };

            return View("Index", viewModel);
        }

        [Authorize]
        // GET: Airlines/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines.FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }

        [Authorize]
        // GET: Airlines/Create
        public IActionResult Create()
        {
            AirlineCreateModel viewModel = new AirlineCreateModel();
            return View(viewModel);
        }

        // POST: Airlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(AirlineCreateModel airlineCreateModel)
        {
            if (ModelState.IsValid)
            {
                var foundCountry = _context.Countries.FirstOrDefault(co => co.Name == airlineCreateModel.Country);

                if (foundCountry != null)
                {
                    Airline newAirline = new Airline
                    {
                        Name = airlineCreateModel.Name,
                        Callsign = airlineCreateModel.Callsign,
                        ICAO = airlineCreateModel.ICAO,
                        IATA = airlineCreateModel.IATA,
                        CountryId = foundCountry.Id,
                        Active = true
                    };
                    _context.Airlines.Add(newAirline);
                    await _context.SaveChangesAsync();

                    airlineCreateModel.Notification = new AlertNotification(NotificationType.Success, $"Successfully added {newAirline.Name}");
                    return View(airlineCreateModel);
                }
                else
                {
                    airlineCreateModel.Notification = new AlertNotification(NotificationType.Error, "The country entered for this Airline doesn't exist!");
                    return View(airlineCreateModel);
                }
            }
            return View(airlineCreateModel);
        }

        [Authorize]
        // GET: Airlines/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }
            return View(airline);
        }

        // POST: Airlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Alais,IATA,ICAO,Callsign,Country,Active,Id,CreationDate")] Airline airline)
        {
            if (id != airline.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirlineExists(airline.Id))
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
            return View(airline);
        }

        [Authorize]
        // GET: Airlines/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airline = await _context.Airlines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airline == null)
            {
                return NotFound();
            }

            return View(airline);
        }


        // POST: Airlines/Delete/5
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var airline = await _context.Airlines.FindAsync(id);
            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirlineExists(Guid id)
        {
            return _context.Airlines.Any(e => e.Id == id);
        }
    }
}
