using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Teachers
{
    public class EditStudentInfoVm
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Името е задължително.")]
        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        public string Name { get; set; }

        [Display(Name = "ЕГН")]
        [Required(ErrorMessage = "ЕГН е задължително.")]
        [RegularExpression("^\\d{2}(0[1-9]|1[0-2])(0[1-9]|1\\d|2\\d|3[0-1])\\d{4}$", ErrorMessage = "ЕГН трябва да е валидно.")]
        public string PersonalNumber { get; set; }

        [Display(Name = "Адрес")]
        [MaxLength(50, ErrorMessage = "Адресат трябва да е максимум 50 символа.")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Име на родител")]
        [MaxLength(30, ErrorMessage = "Името трябва да е максимум 30 символа.")]
        public string ParentName { get; set; }

        [Display(Name = "Телефон на родител")]
        public string ParentPhone { get; set; }
    }
}
