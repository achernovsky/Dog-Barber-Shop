using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Utils
{
    public class RegisterAdminModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
