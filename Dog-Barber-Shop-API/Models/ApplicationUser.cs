using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Dog> Dogs { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
