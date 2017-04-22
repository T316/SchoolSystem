using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Manage
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }
    }
}