using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VFlightNetwork.Data.Enums.Support;

namespace VFlightNetwork.Data.Models.Support
{
    public class SupportPage : BaseModel
    {
        public Guid UserId { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerEmail { get; set; }
        public SupportType TicketType { get; set; }
        [NotMapped]
        public List<SupportTicket> SupportResponses { get; set; }
    }
}