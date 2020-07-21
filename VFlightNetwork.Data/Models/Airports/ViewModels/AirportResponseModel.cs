using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.World;

namespace VFlightNetwork.Data.Models.Airports.ViewModels
{
    public class AirportResponseModel
    {
        public string Name { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public Country Country { get; set; }
    }
}
