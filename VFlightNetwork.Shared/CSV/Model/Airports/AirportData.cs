using System;
using System.Collections.Generic;
using System.Text;

namespace VFlightNetwork.Shared.CSV.Model.Airports
{
    public class AirportData
    {
        public string Name { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
