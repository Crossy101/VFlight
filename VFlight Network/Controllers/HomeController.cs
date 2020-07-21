using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VFlight_Network.Data;
using VFlight_Network.Models;
using VFlightNetwork.Data.Models.Aircraft;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Data.Models.Routes;
using VFlightNetwork.Data.Models.World;
using VFlightNetwork.Shared.AviationEdge.Controllers;
using VFlightNetwork.Shared.CSV.Controller;

namespace VFlight_Network.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
