using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VFlightNetwork.Data.Models.World
{
    public class Country : BaseModel
    {
        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        [JsonPropertyName("codeIso2Country")]
        public string CountryISO { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        [JsonPropertyName("nameCountry")]
        public string Name { get; set; }
    }
}
/*
"capital": "Andorra la Vella",


"codeCurrency": "EUR",


"codeFips": "AN",


"codeIso2Country": "AD",


"codeIso3Country": "AND",


"continent": "EU",


"countryId": 1,


"nameCountry": "Andorra",


"nameCurrency": "Euro",


"numericIso": "20",


"phonePrefix": "376",


"population": "84000" 
*/