using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Enums.Aircraft;

namespace VFlightNetwork.Shared.CSV.Model.AircraftTypes
{
    public class AircraftTypeCSV
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Manufacturer { get; set; }
        public string Engines { get; set; }
        public string WeightCategory { get; set; }
        public string MaxCeiling { get; set; }
        public string MaxSpeed { get; set; }
        public string MaxRange { get; set; }
        public string MaxPassengers { get; set; }
        public string OEW { get; set; }
        public string MZFW { get; set; }
        public string MTOW { get; set; }
        public string MLW { get; set; }
        public string FuelCapacity { get; set; }
    }
}
