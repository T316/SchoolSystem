﻿using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Потребителското име е задължителна.")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна.")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }
}
