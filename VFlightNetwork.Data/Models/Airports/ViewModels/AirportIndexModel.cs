using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Airports.ViewModels
{
    public class AirportIndexModel
    {
        public AirportRequestModel SearchAirport { get; set; }
        public List<AirportResponseModel> Airports { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
