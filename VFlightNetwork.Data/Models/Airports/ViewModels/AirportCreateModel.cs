﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Airports.ViewModels
{
    public class AirportCreateModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characers")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characers")]
        [MaxLength(4)]
        public string ICAO { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characers")]
        [MaxLength(3)]
        public string IATA { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characers")]
        public string Country { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        public AlertNotification Notification { get; set; }
    }
}
