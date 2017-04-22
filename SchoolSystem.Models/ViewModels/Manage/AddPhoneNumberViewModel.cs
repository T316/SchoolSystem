using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string Number { get; set; }
    }
}