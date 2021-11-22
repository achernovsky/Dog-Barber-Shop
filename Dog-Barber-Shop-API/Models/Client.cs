using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Models
{
    public class Client
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
    }
}
