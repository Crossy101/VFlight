using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VFlightNetwork.Data.Models.Support;
using VFlight_Network.Data;
using Microsoft.AspNetCore.Identity;
using VFlight_Network.Models.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VFlight_Network.Controllers
{
    public class SupportTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<AppUser> _userManager { get; set; }

        public SupportTicketsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [HttpGet]
        // GET: SupportTickets
        public async Task<IActionResult> Index()
        {
            AppUser currentUser = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            SupportModel viewModel = new SupportModel
            {
                Username = currentUser.UserName,
                Email = currentUser.Email,
                SupportTicket = new SupportTicket()
            };

            return View(viewModel);
        }

        // POST: SupportTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Message")] SupportTicket supportTicket)
        {
            if (ModelState.IsValid)
            {
                AppUser currentUser = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

                SupportPage newSupportPage = new SupportPage
                {
                    UserId = Guid.Parse(currentUser.Id),
                    OwnerEmail = currentUser.Email,
                    OwnerUsername = currentUser.UserName
                };
                supportTicket.UserId = Guid.Parse(currentUser.Id);
                supportTicket.SupportPageId = newSupportPage.Id;

                _context.SupportPages.Add(newSupportPage);
                _context.SupportTickets.Add(supportTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportTicket);
        }

    }
}
