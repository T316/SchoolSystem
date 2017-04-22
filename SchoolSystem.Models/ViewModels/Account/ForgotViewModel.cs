using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Електроната поща е задължителна.")]
        [Display(Name = "Електрона поща")]
        public string Email { get; set; }
    }
}
