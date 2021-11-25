using Microsoft.AspNetCore.Identity;

namespace Dog_Barber_Shop_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
