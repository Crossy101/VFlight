using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using VFlightNetwork.Data.Enums.Route;

namespace VFlightNetwork.Data.Models.Routes
{
    public class Route : BaseModel
    {
        public Guid StartAirportId { get; set; }
        public Guid EndAirportId { get; set; }
        public Guid AirlineId { get; set; }
        public Guid AircraftId { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int PointsCost { get; set; }
        public DateTime DisabledDate { get; set; }
        public bool Disabled { get; set; }
        public Guid CreatedUserId { get; set; }
        public RouteType RouteType { get; set; }
    }

    public class AERoute
    {
        [JsonPropertyName("airlineIata")]
        public string AirlineIATA { get; set; }

        [JsonPropertyName("airlineIcao")]
        public string AirlineICAO { get; set; }
        [JsonPropertyName("arrivalIata")]
        public string ArrivalIATA { get; set; }
        [JsonPropertyName("arrivalIcao")]
        public string ArrivalICAO { get; set; }
        [JsonPropertyName("arrivalTerminal")]
        public string ArrivalTerminal { get; set; }
        [JsonPropertyName("arrivalTime")]
        public string ArrivalTime { get; set; }
        [JsonPropertyName("codeshares")]
        public List<Codeshares> Codeshares { get; set; }
        [JsonPropertyName("departureIata")]
        public string DepartureIATA { get; set; }
        [JsonPropertyName("departureIcao")]
        public string DepartureICAO { get; set; }
        [JsonPropertyName("departureTerminal")]
        public string DepartureTerminal { get; set; }
        [JsonPropertyName("departureTime")]
        public string DepartureTime { get; set; }
        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; }
        [JsonPropertyName("regNumber")]
        public List<string> RegistrationNumbers { get; set; }
    }

    public class Codeshares
    {
        [JsonPropertyName("airline_code")]
        public string AirlineCode { get; set; }

        [JsonPropertyName("flight_number")]
        public string FlightNumber { get; set; }
    }
}

/*
[
{
"airlineIata":"BA",
"airlineIcao":"BAW",
"arrivalIata":"JFK",
"arrivalIcao":"KJFK",
"arrivalTerminal":"7",
"arrivalTime":"14:10:00",
    "codeshares":[
        {
        "airline_code":"AA",
        "flight_number":"6229"
        },
        {
        "airline_code":"AY",
        "flight_number":"5401"
        },
        {
        "airline_code":"IB",
        "flight_number":"4601"
        }
    ],
"departureIata":"SNN",
"departureIcao":"EINN",
"departureTerminal":null,
"departureTime":"11:55:00",
"flightNumber":"1",
    "regNumber":[
        "G-EUNA",
        "G-EUNB"
    ]
}
]
*/