using System;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public int DogId { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public DateTime CreatedAt { get; set; }

        public Appointment() { }
        public Appointment(int dogId, string userId, DateTime time)
        {
            DogId = dogId;
            ApplicationUserId = userId;
            Time = time;
            CreatedAt = DateTime.Now;
        }
    }
}
