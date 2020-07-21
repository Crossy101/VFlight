using System;
using System.Collections.Generic;
using System.Text;

namespace VFlightNetwork.Data.Models.Support
{
    public class SupportModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public SupportTicket SupportTicket { get; set; }
    }
}
