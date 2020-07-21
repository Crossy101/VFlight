using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VFlightNetwork.Data.Models.Login
{
    public class RegisterDetails
    {
        [Required]
        [MinLength(3, ErrorMessage = "The Username must be more than 3 characters.")]
        [MaxLength(255)]
        public string Username { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The Username must be more than 3 characters.")]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "The Username must be more than 3 characters.")]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "The password must be more than 6 characters")]
        [MaxLength(255)]
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        [Required]
        public bool PrivacyPolicy { get; set; }
    }
}
