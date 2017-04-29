namespace SchoolSystem.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

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
