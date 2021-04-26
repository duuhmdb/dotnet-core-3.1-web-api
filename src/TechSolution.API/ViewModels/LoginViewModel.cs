using System.ComponentModel.DataAnnotations;

namespace TechSolution.API.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
