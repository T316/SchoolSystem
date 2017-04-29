namespace SchoolSystem.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Електроната поща е задължителна.")]
        [EmailAddress(ErrorMessage = "Електроната поща не е валидна.")]
        [Display(Name = "Електрона поща")]
        public string Email { get; set; }
    }
}
