using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TripBuddy.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TripBuddyUser class
    public class TripBuddyUser : IdentityUser
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public long Phone { get; set; }

        public char Gender { get; set; }

        public Car? Car { get; set; }

        public Trip? Trip { get; set; }
    }
}
