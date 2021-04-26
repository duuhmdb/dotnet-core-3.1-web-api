using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "E-mail")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 8), Required]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "First name")]
        [StringLength(60, MinimumLength = 3), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [StringLength(60, MinimumLength = 3), Required]
        public string LastName { get; set; }
    }
}
