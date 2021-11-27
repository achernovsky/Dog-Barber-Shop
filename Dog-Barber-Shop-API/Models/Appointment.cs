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

        public string DogName { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public DateTime CreatedAt { get; set; }

        public Appointment(string dogName, DateTime time)
        {
            DogName = dogName;
            Time = time;
            CreatedAt = DateTime.Now;
        }
    }
}
