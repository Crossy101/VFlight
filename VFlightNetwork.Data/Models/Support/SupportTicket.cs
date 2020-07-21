using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VFlightNetwork.Data.Enums.Support;

namespace VFlightNetwork.Data.Models.Support
{
    public class SupportTicket : BaseModel
    {
        public Guid SupportPageId { get; set; }
        public Guid UserId { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "The minimum length of a message is 20 characters.")]
        [MaxLength(500, ErrorMessage = "The maximum amount of characters in one single message is 500.")]
        public string Message { get; set; }
    }
}
