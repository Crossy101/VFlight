using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VFlightNetwork.Data.Enums.Aircraft;

namespace VFlightNetwork.Data.Models.Aircraft
{
    public class AircraftType : BaseModel
    {
        public string Name { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Manufacturer { get; set; }
        public string Engines { get; set; }
        public AircraftSize Size { get; set; }
        public int MaxCeiling { get; set; }
        public int MaxSpeed { get; set; }
        public int MaxRange { get; set; }
        public int MaxPassengers { get; set; }
        public int OperatingEmptyWeight { get; set; }
        public int MaxZeroFuelWeight { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public int MaxLandingWeight { get; set; }
        public int FuelCapacity { get; set; }
    }
}
