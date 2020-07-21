using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFlightNetwork.Data.Models.Fleet;
using VFlight_Network.Data;

namespace VFlight_Network.Controllers
{
    public class FleetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FleetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fleets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fleets.ToListAsync());
        }

        // GET: Fleets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // GET: Fleets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fleets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,AircraftTypeId,AirlineId,Registration,ImageId,Id,CreationDate")] Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                fleet.Id = Guid.NewGuid();
                _context.Add(fleet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fleet);
        }

        // GET: Fleets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets.FindAsync(id);
            if (fleet == null)
            {
                return NotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,AircraftTypeId,AirlineId,Registration,ImageId,Id,CreationDate")] Fleet fleet)
        {
            if (id != fleet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fleet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FleetExists(fleet.Id))
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
            return View(fleet);
        }

        // GET: Fleets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fleet = await _context.Fleets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fleet == null)
            {
                return NotFound();
            }

            return View(fleet);
        }

        // POST: Fleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fleet = await _context.Fleets.FindAsync(id);
            _context.Fleets.Remove(fleet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FleetExists(Guid id)
        {
            return _context.Fleets.Any(e => e.Id == id);
        }
    }
}
