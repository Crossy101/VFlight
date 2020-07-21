using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VFlightNetwork.Data.Models.Notification;

namespace VFlightNetwork.Data.Models.Aircraft.ViewModels
{
    public class AircraftCreateModel
    {
        [Required]
        [Description("Aircraft Type")]
        public string AircraftType { get; set; }
        [Required]
        [Description("Airline")]
        public string Airline { get; set; }
        public AlertNotification Notification {get; set;}
    }
}
