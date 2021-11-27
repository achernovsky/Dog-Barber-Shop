using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Utils
{
    public class RegisterClientModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string DogName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
