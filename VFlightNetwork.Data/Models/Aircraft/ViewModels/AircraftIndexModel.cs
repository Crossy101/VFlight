using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Aircraft.ViewModels
{
    public class AircraftIndexModel
    {
        public List<AircraftSearch> AircraftSearches { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
