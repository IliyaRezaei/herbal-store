using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Models
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string? Firstname { get; set; }
        [MaxLength(50)]
        public string? Lastname { get; set; }
        public Address? Address { get; set; }
    }
}
