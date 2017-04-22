using SchoolSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models.ViewModels.SchoolDiary.Students
{
    public class MarksVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(2, 6, ErrorMessage = "Стойността трябва да е между 2 и 6.")]
        [Display(Name = "Оценка")]
        public int Value { get; set; }

        [Required]
        [Display(Name = "Предмет")]
        public Subject Subject { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
