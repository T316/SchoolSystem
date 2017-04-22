using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Account
{
    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required(ErrorMessage = "Кодът е задължителна.")]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомни този браузър?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
}
