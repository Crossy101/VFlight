using System;
using System.Text.Json.Serialization;

namespace VFlightNetwork.Data.Models.Aircraft
{
    public class Aircraft : BaseModel
    {
        public Guid AirlineId { get; set; }

        public Guid AircraftTypeId { get; set; }
        public bool Status { get; set; }
    }

    public class AEAircraft
    {
        [JsonPropertyName("airplaneIataType")]
        public string Name { get; set; }

        [JsonPropertyName("airplaneId")]
        public int AircraftId { get; set; }

        [JsonPropertyName("codeIataAirline")]
        public string AirlineIATA { get; set; }

        [JsonPropertyName("codeIataPlaneLong")]
        public string AircraftICAOLong { get; set; }

        [JsonPropertyName("codeIataPlaneShort")]
        public string ICAO { get; set; }

        [JsonPropertyName("codeIcaoAirline")]
        public string AirlineICAO { get; set; }

        [JsonPropertyName("constructionNumber")]
        public string ConstructionNumber { get; set; }

        [JsonPropertyName("deliveryDate")]
        public string DeliveryDate { get; set; }

        [JsonPropertyName("enginesCount")]
        public string EngineCount { get; set; }

        [JsonPropertyName("enginesType")]
        public string EngineType { get; set; }

        [JsonPropertyName("firstFlight")]
        public string FirstFlightDate { get; set; }

        [JsonPropertyName("hexIcaoAirplane")]
        public string HexICAOAircraft { get; set; }

        [JsonPropertyName("lineNumber")]
        public string LineNumber { get; set; }

        [JsonPropertyName("modelCode")]
        public string ModelCode { get; set; }

        [JsonPropertyName("numberRegistration")]
        public string RegistrationCode { get; set; }

        [JsonPropertyName("numberTestRgistration")]
        public string RegistrationCodeTEST { get; set; }

        [JsonPropertyName("planeAge")]
        public string Age { get; set; }

        [JsonPropertyName("planeClass")]
        public string Class { get; set; }

        [JsonPropertyName("planeModel")]
        public string Model { get; set; }

        [JsonPropertyName("planeOwner")]
        public string Owner { get; set; }

        [JsonPropertyName("planeSeries")]
        public string Series { get; set; }

        [JsonPropertyName("planeStatus")]
        public string Status { get; set; }

        [JsonPropertyName("productionLine")]
        public string ProductionLine { get; set; }

        [JsonPropertyName("registrationDate")]
        public string RegistrationDate { get; set; }

        [JsonPropertyName("rolloutDate")]
        public string ReleaseDate { get; set; }
    }
}

/*
 
"airplaneIataType": "A318-100",


"airplaneId": 4051,


"codeIataAirline": "BA",


"codeIataPlaneLong": "A318",


"codeIataPlaneShort": "318",


"codeIcaoAirline": "",


"constructionNumber": "4007",


"deliveryDate": "2009-08-27T22:00:00.000Z",


"enginesCount": "2",


"enginesType": "JET",


"firstFlight": "2009-08-18T22:00:00.000Z",


"hexIcaoAirplane": "40608F",


"lineNumber": "",


"modelCode": "A318-112",


"numberRegistration": "G-EUNA",


"numberTestRgistration": "D-AUAC",


"planeAge": "8",


"planeClass": "1",


"planeModel": "A318",


"planeOwner": "",


"planeSeries": "112",


"planeStatus": "active",


"productionLine": "Airbus A318/A319/A320",


"registrationDate": "2009-08-27T22:00:00.000Z",


"rolloutDate": "2000-09-07T22:00:00.000Z"

*/
