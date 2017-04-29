namespace SchoolSystem.Models.ViewModels.Account
{
    using SchoolSystem.Models.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Електроната поща е задължителна.")]
        [EmailAddress(ErrorMessage = "Електроната поща не е валидна.")]
        [Index("EmailIndex", IsUnique = true)]
        [Display(Name = "Електрона поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Потребителското име е задължителна.")]
        [Index("UserNameIndex", IsUnique = true)]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Името е задължителна.")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [StringLength(100, ErrorMessage = "Паролата трябва да е поне 6 символа.", MinimumLength = 6)]
        [Password(ErrorMessage = "Паролата трябва да съдържа поне една главна буква, една малка буква и една цифра.")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете паролата")]
        [Compare("Password", ErrorMessage = "Паролата и потвърдената парола не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}
