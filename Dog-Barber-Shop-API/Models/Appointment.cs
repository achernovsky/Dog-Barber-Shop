using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}
