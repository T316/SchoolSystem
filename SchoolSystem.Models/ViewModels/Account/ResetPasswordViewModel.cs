﻿namespace SchoolSystem.Models.ViewModels.Account
{
    using SchoolSystem.Models.ValidationAttributes;
    using System.ComponentModel.DataAnnotations;

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Електроната поща е задължителна.")]
        [EmailAddress(ErrorMessage = "Електроната поща не е валидна.")]
        [Display(Name = "Електрона поща")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [StringLength(100, ErrorMessage = "Паролата трябва да е поне 6 символа..", MinimumLength = 6)]
        [Password(ErrorMessage = "Паролата трябва да съдържа поне една главна буква, една малка буква и една цифра.")]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потвърдете паролата")]
        [Compare("Password", ErrorMessage = "Паролата и потвърдената парола не съвпадат.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
