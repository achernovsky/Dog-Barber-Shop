using System.ComponentModel.DataAnnotations;

namespace Dog_Barber_Shop_API.Utils
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Current password is required")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmed new password is required")]
        public string ConfirmedNewPassword { get; set; }
    }
}
