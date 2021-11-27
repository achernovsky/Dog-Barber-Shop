using System;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Utils
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
