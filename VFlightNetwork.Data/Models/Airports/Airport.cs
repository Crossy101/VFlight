using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VFlightNetwork.Data.Enums.Airports;

namespace VFlightNetwork.Data.Models.Airports
{
    public class Airport : BaseModel
    {
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public Guid CountryId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
    }

    public class AEAirport
    {
        [JsonPropertyName("GMT")]
        public string GMT { get; set; }

        [JsonPropertyName("airportId")]
        public int AirportId { get; set; }

        [JsonPropertyName("codeIataAirport")]
        public string IATA { get; set; }

        [JsonPropertyName("codeIataCity")]
        public string CityIATA { get; set; }

        [JsonPropertyName("codeIcaoAirport")]
        public string ICAO { get; set; }

        [JsonPropertyName("codeIso2Country")]
        public string CountryId { get; set; }

        [JsonPropertyName("geonameId")]
        public string GeographicId { get; set; }

        [JsonPropertyName("latitudeAirport")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitudeAirport")]
        public float Longitude { get; set; }

        [JsonPropertyName("nameAirport")]
        public string Name { get; set; }

        [JsonPropertyName("nameCountry")]
        public string CountryName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}

/*
 "GMT": "-10",


"airportId": 1,


"codeIataAirport": "AAA",


"codeIataCity": "AAA",


"codeIcaoAirport": "NTGA",


"codeIso2Country": "PF",


"geonameId": "6947726",


"latitudeAirport": -17.05,


"longitudeAirport": -145.41667,


"nameAirport": "Anaa",


"nameCountry": "French Polynesia",


"phone": "",


"timezone": "Pacific/Tahiti"
    
*/
