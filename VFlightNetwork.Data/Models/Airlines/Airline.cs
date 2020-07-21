using System;
using System.Text.Json.Serialization;

namespace VFlightNetwork.Data.Models.Airlines
{
    public class Airline : BaseModel
    {
        public string Callsign { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class AEAirline
    {
        [JsonPropertyName("ageFleet")]
        public float FleetAge { get; set; }

        [JsonPropertyName("airlineId")]
        public int AirlineId { get; set; }

        [JsonPropertyName("callsign")]
        public string Callsign { get; set; }

        [JsonPropertyName("codeHub")]
        public string HubCode { get; set; }

        [JsonPropertyName("codeIataAirline")]
        public string IATA { get; set; }

        [JsonPropertyName("codeIcaoAirline")]
        public string ICAO { get; set; }

        [JsonPropertyName("codeIso2Country")]
        public string CountryISO { get; set; }

        [JsonPropertyName("founding")]
        public int FoundingYear { get; set; }

        [JsonPropertyName("iataPrefixAccounting")]
        public string PrefixAccounting { get; set; }

        [JsonPropertyName("nameAirline")]
        public string Name { get; set; }

        [JsonPropertyName("nameCountry")]
        public string CountryName { get; set; }

        [JsonPropertyName("sizeAirline")]
        public int FleetSize { get; set; }

        [JsonPropertyName("statusAirline")]
        public string Active { get; set; }

        [JsonPropertyName("type")]
        public string Schedule { get; set; }

    }
}

/*
"ageFleet": 10.9,


"airlineId": 1,


"callsign": "AMERICAN",


"codeHub": "DFW",


"codeIataAirline": "AA",


"codeIcaoAirline": "AAL",


"codeIso2Country": "US",


"founding": 1934,


"iataPrefixAccounting": "1",


"nameAirline": "American Airlines",


"nameCountry": "United States",


"sizeAirline": 963,


"statusAirline": "active",


"type": "scheduled"
*/
