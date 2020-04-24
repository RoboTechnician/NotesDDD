using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(User.EmailLength, ErrorMessage = "Email is too long")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(User.PasswordMinLength, ErrorMessage = "Password is too short")]
        [MaxLength(User.PasswordLength, ErrorMessage = "Passwort is too long")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
