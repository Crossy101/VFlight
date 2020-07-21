using System;
using System.Collections.Generic;
using System.Text;

namespace VFlightNetwork.Data.Models.Blacklist
{
    public class Blacklist : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid StaffId { get; set; }
        public string Reason { get; set; }
        public DateTime BannedDate { get; set; }
        public bool CurrentlyBanned { get; set; }
        public bool PermaBan { get; set; }
        public DateTime UnbannedDate { get; set; }
    }
}
