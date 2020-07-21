using System;
using System.Collections.Generic;
using System.Text;

namespace VFlightNetwork.Data.Models.Fleet
{
    public class Fleet : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid AircraftTypeId { get; set; }
        public Guid AirlineId { get; set; }
        public string Registration { get; set; }
        public string ImageId { get; set; }
    }
}
