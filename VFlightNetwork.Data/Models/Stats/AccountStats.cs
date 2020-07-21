using System;
using System.Collections.Generic;
using System.Text;

namespace VFlightNetwork.Data.Models.Stats
{
    public class AccountStats : BaseModel
    {
        public Guid UserId { get; set; }
        public int TotalPoints { get; set; }
        public int TotalHours { get; set; }
        public int TotalFlights { get; set; }
        public Guid FavouriteRoute { get; set; }
        public Guid FavouriteAircraft { get; set; }
        public Guid LastRouteId { get; set; }
        public Guid LastAircraftId { get; set; }
    }
}
