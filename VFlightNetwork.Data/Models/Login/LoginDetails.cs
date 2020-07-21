using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VFlightNetwork.Data.Models.Login
{
    public class LoginDetails
    {
        [Required]
        [MinLength(3, ErrorMessage = "The Username must be more than 3 characters.")]
        [MaxLength(255)]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must be more than 6 characters")]
        [MaxLength(255)]
        public string Password { get; set; }
        public bool StayLoggedIn { get; set; }
    }
}
