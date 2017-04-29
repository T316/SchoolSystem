namespace SchoolSystem.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Електроната поща е задължителна.")]
        [Display(Name = "Електрона поща")]
        public string Email { get; set; }
    }
}
