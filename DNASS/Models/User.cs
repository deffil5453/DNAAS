using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DNASS.Models
{
    public class User : IdentityUser
    {
        [Required]public string LastName { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string MiddleName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
