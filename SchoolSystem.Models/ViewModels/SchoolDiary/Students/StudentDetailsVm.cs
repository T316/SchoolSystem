using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class StudentDetailsVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ЕГН е задължително.")]
        [RegularExpression("^\\d{2}(0[1-9]|1[0-2])(0[1-9]|1\\d|2\\d|3[0-1])\\d{4}$", ErrorMessage = "ЕГН трябва да е валидно.")]
        [Display(Name = "ЕГН")]
        public string PersonalNumber { get; set; }

        [MaxLength(50, ErrorMessage = "Адресат трябва да е максимум 50 символа.")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        [Display(Name = "Име на родител")]
        public string ParentName { get; set; }

        [Display(Name = "Телефон на родител")]
        public string ParentPhone { get; set; }

        [Display(Name = "Клас")]
        public Grade Grade { get; set; }
    }
}
