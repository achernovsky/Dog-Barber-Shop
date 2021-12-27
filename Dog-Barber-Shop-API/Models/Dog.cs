using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Models
{
    public class Dog
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
