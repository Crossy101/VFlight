using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Diagnostics;
using System.Text.Json;
using VFlightNetwork.Data.Models.Airlines;
using VFlightNetwork.Data.Models.Airports;
using VFlightNetwork.Data.Models.Routes;
using VFlightNetwork.Data.Models.World;
using System.Linq;
using VFlightNetwork.Shared.CSV.Model.AircraftTypes;
using CsvHelper;
using VFlightNetwork.Shared.CSV.Controller;
using VFlightNetwork.Data.Models.Aircraft;

namespace VFlightNetwork.Shared.AviationEdge.Controllers
{
    public static class AviationEdgeController
    {
        private const string APIKey = "cada26-b8f8e3";

        //This airport will get all airports from the API and apply CountryId's and City Id's
        public static List<Airport> GetAllAirports(List<Country> countries)
        {
            string APIKey = "cada26-b8f8e3";
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/airportDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                List<AEAirport> allAirports = JsonSerializer.Deserialize<List<AEAirport>>(body);

                List<Airport> currentAirports = new List<Airport>();
                foreach (var airport in allAirports)
                {
                    var foundCountry = countries.FirstOrDefault(co => co.CountryISO == airport.CountryId);
                    
                    if(foundCountry == null)
                    {
                        foundCountry = new Country();
                        foundCountry.Id = Guid.Empty;
                    }

                    Airport newAirport = new Airport
                    {
                        CountryId = foundCountry.Id,
                        IATA = airport.IATA,
                        ICAO = airport.ICAO,
                        Latitude = airport.Latitude,
                        Longitude = airport.Longitude,
                        Name = airport.Name
                    };
                    currentAirports.Add(newAirport);
                }
                return currentAirports;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static List<Airline> GetAllAirlines(List<Country> countries)
        {
            string APIKey = "cada26-b8f8e3";
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/airlineDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                List<AEAirline> allAirlines = JsonSerializer.Deserialize<List<AEAirline>>(body);
                List<AirlineName> goodAirlines = CSVController.GetFlightRadarAirlineNames();

                List<Airline> currentAirlines = new List<Airline>();
                foreach (var airline in allAirlines)
                {
                    if (!goodAirlines.Exists(an => an.Name.ToLower() == airline.Name.ToLower()))
                        continue;

                    if (airline.Active != "active")
                        continue;

                    var foundCountry = countries.FirstOrDefault(co => co.CountryISO == airline.CountryISO);

                    if (foundCountry == null)
                    {
                        foundCountry = new Country();
                        foundCountry.Id = Guid.Empty;
                    }


                    Airline newAirline = new Airline
                    {
                        CountryId = foundCountry.Id,
                        IATA = airline.IATA,
                        ICAO = airline.ICAO,
                        Callsign = airline.Callsign,
                        Active = true,
                        Name = airline.Name
                    };
                    currentAirlines.Add(newAirline);
                }
                return currentAirlines;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static List<Aircraft> GetAllAircraft(List<Airline> airlines, List<AircraftType> aircraftTypes)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/airplaneDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                var allAircrafts = JsonSerializer.Deserialize<List<AEAircraft>>(body);

                List<Aircraft> currentAircraft = new List<Aircraft>();
                foreach (var aircraft in allAircrafts)
                {
                    var foundAirline = airlines.FirstOrDefault(al => al.IATA == aircraft.AirlineIATA);
                    var foundAircraftType = aircraftTypes.FirstOrDefault(act => act.ICAO == aircraft.ICAO);

                    if (foundAirline == null)
                        continue;

                    if (foundAircraftType == null)
                    {
                        foundAircraftType = new AircraftType();
                        foundAircraftType.Id = Guid.Empty;
                    }

                    bool StatusActive = false;
                    if (aircraft.Status == "active")
                        StatusActive = true;

                    Aircraft newAircraft = new Aircraft
                    {
                        AirlineId = foundAirline.Id,
                        AircraftTypeId = foundAircraftType.Id,
                        Status = StatusActive
                    };
                    currentAircraft.Add(newAircraft);
                }
                return currentAircraft;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static List<AircraftType> GetAllAircraftTypes()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/planeTypeDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<List<AircraftType>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static List<Route> GetAllAirlineRoutes(List<Airport> airports, List<Airline> airlines, List<Aircraft> aircraft)
        {
            string body = "";
            try
            {
                HttpResponseMessage result;

                List<Route> allRoutes = new List<Route>();
                using (HttpClient httpClient = new HttpClient())
                {
                    foreach (Airline airline in airlines)
                    {
                        if (string.IsNullOrEmpty(airline.IATA) && string.IsNullOrEmpty(airline.ICAO))
                            continue;

                        if (!string.IsNullOrEmpty(airline.IATA))
                            result = httpClient.GetAsync($"http://aviation-edge.com/v2/public/routes?key={APIKey}&airlineIata={airline.IATA}").Result;
                        else
                            result = httpClient.GetAsync($"http://aviation-edge.com/v2/public/routes?key={APIKey}&airlineIcao={airline.ICAO}").Result;

                        body = result.Content.ReadAsStringAsync().Result;
                        List<AERoute> dataRoutes = new List<AERoute>();
                        try
                        {
                            dataRoutes = JsonSerializer.Deserialize<List<AERoute>>(body);
                        }
                        catch(Exception ex)
                        {
                            
                        }
                        
                        if (dataRoutes.Count <= 0)
                            continue;

                        if (dataRoutes.Count >= 1)
                            Debug.WriteLine("HIT");

                        foreach (AERoute route in dataRoutes)
                        {
                            if (route.RegistrationNumbers == null || route.RegistrationNumbers.Count <= 0)
                                continue;

                            var startAirportId = airports.FirstOrDefault(ap => ap.ICAO == route.DepartureICAO);
                            var endAirportId = airports.FirstOrDefault(ap => ap.ICAO == route.ArrivalICAO);
                            var airlineId = airlines.FirstOrDefault(al => al.ICAO == route.AirlineICAO || al.IATA == route.AirlineIATA);

                            if (startAirportId == null || endAirportId == null || airlineId == null || String.IsNullOrEmpty(route.FlightNumber))
                                continue;

                            foreach (string regNum in route.RegistrationNumbers)
                            {
                                Route newRoute = new Route
                                {
                                    StartAirportId = startAirportId.Id,
                                    EndAirportId = endAirportId.Id,
                                    AirlineId = airlineId.Id,
                                    FlightNumber = route.FlightNumber,
                                    DepartureTime = route.DepartureTime,
                                    ArrivalTime = route.ArrivalTime,
                                    Disabled = false,
                                    DisabledDate = DateTime.MinValue,
                                    PointsCost = 0,
                                    CreatedUserId = Guid.Empty
                                };
                                allRoutes.Add(newRoute);
                            } 
                        }
                        Debug.WriteLine($"Added All Routes for {airline.Name}");
                    }
                }
                return allRoutes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(body);
                return null;
            }
        }

        public static List<Country> GetAllCountries()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/countryDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                return JsonSerializer.Deserialize<List<Country>>(body);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /*
        public static List<City> GetAllCities(List<Country> countries)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var result = httpClient.GetAsync($"https://aviation-edge.com/v2/public/cityDatabase?key={APIKey}").Result;
                string body = result.Content.ReadAsStringAsync().Result;

                foreach (var city in allCities)
                {
                    var foundCountry = countries.FirstOrDefault(co => co.CountryISO == city.CountryISO);

                    City newCity = new City
                    {
                        CountryId = foundCountry.Id,
                        CityId = city.CityId,
                        GeographicalId = city.GeographicalId,
                        IATA = city.IATA,
                        Name = city.Name,
                        Latitude = city.Latitude,
                        Longitude = city.Longitude,
                        Timezone = city.Timezone,
                        GMT = city.GMT
                    };
                    currentCities.Add(newCity);
                }
                return currentCities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        */
    }
}
