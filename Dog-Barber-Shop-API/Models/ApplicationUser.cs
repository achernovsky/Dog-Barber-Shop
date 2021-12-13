using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string DogName { get; set; }
    }
}
