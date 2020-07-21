using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Airlines;

namespace VFlightNetwork.Data.Models.Aircraft.ViewModels
{
    public class AircraftSearch
    {
        public AircraftType AircraftType { get; set; }
        public Airline CurrentAirline { get; set; }
    }
}
