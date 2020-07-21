using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Airlines.ViewModels
{
    public class AirlineIndexModel
    {
        public List<Airline> Airlines { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
