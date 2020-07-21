using System;
using System.Collections.Generic;
using System.Text;
using VFlightNetwork.Data.Models.Aircraft;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using VFlightNetwork.Shared.CSV.Model.AircraftTypes;
using VFlightNetwork.Data.Enums.Aircraft;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Shared.CSV.Model.Airports;

namespace VFlightNetwork.Shared.CSV.Controller
{
    public static class CSVController
    {
        //Get all airports from Flight Radar data file
        public static List<Airport> GetAllAirports()
        {
            List<Airport> allAirports = new List<Airport>();
            using (var reader = new StreamReader("Airports.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AirportData>();

                foreach (var airport in records)
                {
                    Airport newAirport = new Airport
                    {
                        Name = airport.Name,
                        ICAO = airport.ICAO,
                        IATA = airport.IATA,
                        Latitude = airport.Latitude,
                        Longitude = airport.Longitude,
                    };
                    allAirports.Add(newAirport);
                }
            }
            return allAirports;
        }

        //Get all aircraft types from Flight Radar data file
        public static List<AircraftType> GetAllAircraftTypes()
        {
            List<AircraftType> allAircraftTypes = new List<AircraftType>();
            using (var reader = new StreamReader("AircraftTypes.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
               var records = csv.GetRecords<AircraftTypeCSV>();

                foreach (var aircraftType in records)
                {
                    if (string.IsNullOrEmpty(aircraftType.MaxSpeed))
                        aircraftType.MaxSpeed = "0";

                    if (string.IsNullOrEmpty(aircraftType.MaxRange))
                        aircraftType.MaxRange = "0";

                    if (string.IsNullOrEmpty(aircraftType.MaxPassengers))
                        aircraftType.MaxPassengers = "0";

                    if (string.IsNullOrEmpty(aircraftType.MLW))
                        aircraftType.MLW = "0";

                    if (string.IsNullOrEmpty(aircraftType.MTOW))
                        aircraftType.MTOW = "0";

                    if (string.IsNullOrEmpty(aircraftType.MZFW))
                        aircraftType.MZFW = "0";

                    if (string.IsNullOrEmpty(aircraftType.FuelCapacity))
                        aircraftType.FuelCapacity = "0";

                    if (string.IsNullOrEmpty(aircraftType.MaxSpeed))
                        aircraftType.OEW = "0";

                    if (string.IsNullOrEmpty(aircraftType.MaxCeiling))
                        aircraftType.MaxCeiling = "0";

                    AircraftType newAircraftType = new AircraftType
                    {
                        Name = aircraftType.Name,
                        ICAO = aircraftType.ICAO,
                        IATA = aircraftType.IATA,
                        Size = (AircraftSize)Enum.Parse(typeof(AircraftSize), aircraftType.WeightCategory),
                        Manufacturer = aircraftType.Manufacturer,
                        MaxCeiling = Convert.ToInt32(aircraftType.MaxCeiling),
                        MaxSpeed = Convert.ToInt32(aircraftType.MaxSpeed),
                        MaxRange = Convert.ToInt32(aircraftType.MaxRange),
                        MaxPassengers = Convert.ToInt32(aircraftType.MaxPassengers),
                        MaxLandingWeight = Convert.ToInt32(aircraftType.MLW),
                        MaxTakeoffWeight = Convert.ToInt32(aircraftType.MTOW),
                        MaxZeroFuelWeight = Convert.ToInt32(aircraftType.MZFW),
                        FuelCapacity = Convert.ToInt32(aircraftType.FuelCapacity),
                        Engines = aircraftType.Engines,
                        OperatingEmptyWeight = Convert.ToInt32(aircraftType.OEW),
                    };
                    allAircraftTypes.Add(newAircraftType);
                }
            }
            return allAircraftTypes;
        }

        public static List<AirlineName> GetFlightRadarAirlineNames()
        {
            using (var reader = new StreamReader("AirlineNames.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<AirlineName>().ToList();
            }
        }
    }
}
