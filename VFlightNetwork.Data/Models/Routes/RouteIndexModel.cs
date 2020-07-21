using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Routes
{
    public class RouteIndexModel
    {
        public List<Route> Routes { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
