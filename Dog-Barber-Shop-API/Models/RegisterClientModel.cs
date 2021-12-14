﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Models
{
    public class RegisterClientModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Dog(s) is required")]
        public List<Dog> Dogs { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
