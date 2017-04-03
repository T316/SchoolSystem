using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Account
{

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
