using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VFlight_Network.Models.Identity;
using VFlightNetwork.Data.Models.Aircraft;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Data.Models.Routes;
using VFlightNetwork.Data.Models.Blacklist;
using VFlightNetwork.Data.Models.Login;
using VFlightNetwork.Data.Models.Fleet;
using VFlightNetwork.Data.Models.Stats;
using VFlightNetwork.Data.Models.World;
using VFlightNetwork.Data.Models.Support;

namespace VFlight_Network.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Airport>()
                .HasIndex(ap => new { ap.ICAO, ap.Name });

            builder.Entity<Airline>()
                .HasIndex(al => new { al.Name, al.IATA, al.ICAO });
        }
        
        //Game Database Data
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Fleet> Fleets { get; set; }
        public DbSet<AccountStats> AccountStats { get; set; }
        public DbSet<Blacklist> Blacklisted { get; set; }
        public DbSet<SupportPage> SupportPages { get; set; }
        public DbSet<SupportTicket> SupportTickets { get; set; }
    }
}
